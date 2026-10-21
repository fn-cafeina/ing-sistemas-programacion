namespace SimuladorDescargas;

public partial class Form1 : Form
{
    // Lista de archivos a descargar (enunciado)
    private readonly List<ArchivoDescarga> archivos = new()
    {
        new ArchivoDescarga("VideoTutorial.mp4", 50),
        new ArchivoDescarga("ActualizacionJuego.zip", 120),
        new ArchivoDescarga("DocumentoPDF.pdf", 15),
        new ArchivoDescarga("InstaladorApp.msi", 80),
        new ArchivoDescarga("MusicaAlbum.zip", 35),
    };

    private readonly List<ProgressBar> barras = new();
    private readonly Label lblTotal;
    private readonly Button btnIniciar;

    // Total global de MB descargados, protegido por candado
    private double totalDescargado;
    private readonly object candado = new();

    private int hilosActivos;
    private volatile bool cerrando;

    public Form1()
    {
        InitializeComponent();
        Text = "Simulador de Descargas Concurrentes";

        // Interfaz armada por código: una etiqueta y una barra por archivo
        for (int i = 0; i < archivos.Count; i++)
        {
            ArchivoDescarga archivo = archivos[i];
            Controls.Add(new Label
            {
                Text = $"{archivo.Id}. {archivo.Nombre} ({archivo.longitud} MB)",
                Location = new Point(20, 15 + i * 58),
                AutoSize = true,
            });
            var barra = new ProgressBar
            {
                Location = new Point(20, 40 + i * 58),
                Size = new Size(440, 20),
            };
            Controls.Add(barra);
            barras.Add(barra);
        }

        btnIniciar = new Button
        {
            Text = "Iniciar descargas",
            Location = new Point(20, 25 + archivos.Count * 58),
            Size = new Size(160, 30),
        };
        btnIniciar.Click += IniciarDescargas;
        lblTotal = new Label
        {
            Text = "Total descargado: 0,0 MB",
            Location = new Point(200, 32 + archivos.Count * 58),
            AutoSize = true,
        };
        Controls.Add(btnIniciar);
        Controls.Add(lblTotal);
        ClientSize = new Size(490, 95 + archivos.Count * 58);

        FormClosing += (_, _) => cerrando = true;
    }

    // Crea e inicia un hilo por cada archivo
    private void IniciarDescargas(object? sender, EventArgs e)
    {
        btnIniciar.Enabled = false;
        hilosActivos = archivos.Count;
        totalDescargado = 0;
        lblTotal.Text = "Total descargado: 0,0 MB";
        foreach (ProgressBar barra in barras)
        {
            barra.Value = 0;
        }

        // Arreglo para almacenar las referencias de los hilos
        Thread[] hilos = new Thread[archivos.Count];

        // Crear e iniciar un hilo por cada archivo
        for (int i = 0; i < archivos.Count; i++)
        {
            ArchivoDescarga archivoActual = archivos[i];
            ProgressBar barraActual = barras[i];
            hilos[i] = new Thread(() => Descargar(archivoActual, barraActual))
            {
                IsBackground = true,
            };
            hilos[i].Start();
        }
    }

    // Lógica del hilo de descarga: avanza paso a paso con tiempo aleatorio
    private void Descargar(ArchivoDescarga archivo, ProgressBar barra)
    {
        const int pasos = 20;
        double mbPorPaso = archivo.longitud / (double)pasos;

        for (int paso = 1; paso <= pasos; paso++)
        {
            if (cerrando) break;
            Thread.Sleep(Random.Shared.Next(80, 300)); // tiempo aleatorio de descarga

            // Registrar el total de megabytes de forma segura ante concurrencia
            double totalParcial;
            lock (candado)
            {
                totalDescargado += mbPorPaso;
                totalParcial = totalDescargado;
            }

            // Copia local: el lambda no debe leer la variable del for
            int porcentaje = paso * 100 / pasos;

            ActualizarInterfaz(() =>
            {
                barra.Value = porcentaje;
                lblTotal.Text = $"Total descargado: {totalParcial:F1} MB";
            });
        }

        TerminarHilo();
    }

    // La interfaz solo puede tocarse desde su propio hilo
    private void ActualizarInterfaz(Action accion)
    {
        if (cerrando || !IsHandleCreated) return;
        try
        {
            BeginInvoke(accion);
        }
        catch (InvalidOperationException)
        {
            // El formulario ya se está cerrando, se ignora
        }
    }

    private void TerminarHilo()
    {
        ActualizarInterfaz(() =>
        {
            hilosActivos--;
            if (hilosActivos == 0)
            {
                btnIniciar.Enabled = true;
            }
        });
    }
}
