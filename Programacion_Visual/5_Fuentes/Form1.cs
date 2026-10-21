namespace Fuentes;

public partial class Form1 : Form
{
    private readonly Label lblTitulo;

    private readonly CheckBox[] chkEstilos = new CheckBox[4];
    private readonly CheckBox[] chkFuentes = new CheckBox[4];
    private readonly CheckBox[] chkTamanos = new CheckBox[4];

    private readonly FontFamily familiaBase = new("Microsoft Sans Serif");
    private readonly float tamanoBase = 12F;

    private static readonly FontStyle[] estilosValores = [FontStyle.Bold, FontStyle.Italic, FontStyle.Strikeout, FontStyle.Underline];
    private static readonly string[] familiasNombres = ["Consolas", "Colonna MT", "Verdana", "Broadway"];
    private static readonly float[] tamanosValores = [8F, 12F, 16F, 20F];

    public Form1()
    {
        InitializeComponent();

        Text = "CajadeSeleccion";
        ClientSize = new Size(750, 420);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        lblTitulo = new Label
        {
            AutoSize = true,
            Font = new Font(familiaBase, tamanoBase, FontStyle.Bold),
            Location = new Point(30, 20),
            Text = "Programación Visual I"
        };
        Controls.Add(lblTitulo);

        CrearColumnaEstilo();
        CrearColumnaFuente();
        CrearColumnaTamano();

        var btnSalir = CrearBoton("Salir", 30, 290);
        btnSalir.Click += (_, _) => Close();
        Controls.Add(btnSalir);

        var btnLimpiar = CrearBoton("Limpiar", 270, 290);
        btnLimpiar.Click += (_, _) => Limpiar();
        Controls.Add(btnLimpiar);
    }

    private void CrearColumnaEstilo()
    {
        string[] nombres = ["Bold", "Italic", "Strikeout", "Underline"];

        Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font(familiaBase, 11F, FontStyle.Bold),
            ForeColor = Color.DarkBlue,
            Location = new Point(30, 70),
            Text = "Estilo"
        });

        FontStyle[] estilosFont = [FontStyle.Bold, FontStyle.Italic, FontStyle.Strikeout, FontStyle.Underline];

        for (int i = 0; i < 4; i++)
        {
            chkEstilos[i] = new CheckBox
            {
                AutoSize = true,
                Font = new Font(familiaBase, tamanoBase, estilosFont[i]),
                Location = new Point(30, 100 + i * 40),
                Text = nombres[i]
            };
            chkEstilos[i].CheckedChanged += ActualizarTitulo;
            Controls.Add(chkEstilos[i]);
        }
    }

    private void CrearColumnaFuente()
    {
        Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font(familiaBase, 11F, FontStyle.Bold),
            ForeColor = Color.DarkBlue,
            Location = new Point(270, 70),
            Text = "Fuente"
        });

        for (int i = 0; i < 4; i++)
        {
            chkFuentes[i] = new CheckBox
            {
                AutoSize = true,
                Font = new Font(familiasNombres[i], 11F),
                Location = new Point(270, 100 + i * 40),
                Text = familiasNombres[i]
            };
            chkFuentes[i].CheckedChanged += Fuente_Cambiada;
            Controls.Add(chkFuentes[i]);
        }
    }

    private void CrearColumnaTamano()
    {
        Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font(familiaBase, 11F, FontStyle.Bold),
            ForeColor = Color.DarkBlue,
            Location = new Point(510, 70),
            Text = "Tamaño"
        });

        for (int i = 0; i < 4; i++)
        {
            chkTamanos[i] = new CheckBox
            {
                AutoSize = true,
                Font = new Font(familiaBase, tamanosValores[i]),
                Location = new Point(510, 100 + i * 40),
                Text = tamanosValores[i].ToString("0")
            };
            chkTamanos[i].CheckedChanged += Tamano_Cambiado;
            Controls.Add(chkTamanos[i]);
        }
    }

    private static Button CrearBoton(string texto, int x, int y)
    {
        var btn = new Button
        {
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold),
            ForeColor = Color.DarkBlue,
            Location = new Point(x, y),
            Size = new Size(120, 40),
            Text = texto,
            Cursor = Cursors.Hand
        };
        btn.FlatAppearance.BorderSize = 0;
        return btn;
    }

    private void Fuente_Cambiada(object? sender, EventArgs e)
    {
        if (sender is CheckBox actual && actual.Checked)
            foreach (var chk in chkFuentes)
                if (chk != actual) chk.Checked = false;

        ActualizarTitulo(sender, e);
    }

    private void Tamano_Cambiado(object? sender, EventArgs e)
    {
        if (sender is CheckBox actual && actual.Checked)
            foreach (var chk in chkTamanos)
                if (chk != actual) chk.Checked = false;

        ActualizarTitulo(sender, e);
    }

    private void ActualizarTitulo(object? sender, EventArgs e)
    {
        FontStyle estilo = FontStyle.Regular;
        for (int i = 0; i < 4; i++)
            if (chkEstilos[i].Checked) estilo |= estilosValores[i];

        FontFamily familia = familiaBase;
        for (int i = 0; i < 4; i++)
            if (chkFuentes[i].Checked) { familia = new FontFamily(familiasNombres[i]); break; }

        float tamano = tamanoBase;
        for (int i = 0; i < 4; i++)
            if (chkTamanos[i].Checked) { tamano = tamanosValores[i]; break; }

        lblTitulo.Font.Dispose();
        lblTitulo.Font = new Font(familia, tamano, estilo);
    }

    private void Limpiar()
    {
        foreach (var chk in chkEstilos) chk.Checked = false;
        foreach (var chk in chkFuentes) chk.Checked = false;
        foreach (var chk in chkTamanos) chk.Checked = false;
        lblTitulo.Font.Dispose();
        lblTitulo.Font = new Font(familiaBase, tamanoBase, FontStyle.Bold);
    }
}
