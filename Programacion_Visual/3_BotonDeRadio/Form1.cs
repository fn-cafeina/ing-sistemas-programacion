namespace BotonDeRadio;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        Text = "Usando Botones de Radio";
        ClientSize = new Size(484, 361);
        StartPosition = FormStartPosition.CenterScreen;

        var grpTipo = new GroupBox
        {
            Text = "Tipo botón",
            Location = new Point(12, 12),
            Size = new Size(200, 210)
        };

        string[] tipos = [
            "Aceptar",
            "Aceptar | Cancelar",
            "Abortar | Reintentar | Ignorar",
            "Si | No | Cancelar",
            "Si | No",
            "Reintentar | Cancelar"
        ];

        RadioButton[] radioTipo = new RadioButton[tipos.Length];
        for (int i = 0; i < tipos.Length; i++)
        {
            radioTipo[i] = new RadioButton
            {
                Text = tipos[i],
                Location = new Point(15, 25 + i * 28),
                AutoSize = true
            };
            grpTipo.Controls.Add(radioTipo[i]);
        }
        radioTipo[0].Checked = true;

        var grpIcono = new GroupBox
        {
            Text = "Icono",
            Location = new Point(250, 12),
            Size = new Size(210, 210)
        };

        string[] iconos = [
            "Asterisco",
            "Error",
            "Exclamación",
            "Mano",
            "Información",
            "Pregunta",
            "Alto",
            "Advertencia"
        ];

        RadioButton[] radioIcono = new RadioButton[iconos.Length];
        for (int i = 0; i < iconos.Length; i++)
        {
            radioIcono[i] = new RadioButton
            {
                Text = iconos[i],
                Location = new Point(15, 25 + i * 22),
                AutoSize = true
            };
            grpIcono.Controls.Add(radioIcono[i]);
        }
        radioIcono[0].Checked = true;

        var btnMostrar = new Button
        {
            Text = "Mostrar",
            Location = new Point(80, 240),
            Size = new Size(90, 30)
        };

        var lblResultado = new Label
        {
            Text = "Resultado es",
            Location = new Point(12, 290),
            AutoSize = true,
            Font = new Font(Font.FontFamily, 9, FontStyle.Bold)
        };

        btnMostrar.Click += (s, e) =>
        {
            int tipoIdx = Array.FindIndex(radioTipo, r => r.Checked);
            int iconoIdx = Array.FindIndex(radioIcono, r => r.Checked);

            MessageBoxButtons buttons = tipoIdx switch
            {
                0 => MessageBoxButtons.OK,
                1 => MessageBoxButtons.OKCancel,
                2 => MessageBoxButtons.AbortRetryIgnore,
                3 => MessageBoxButtons.YesNoCancel,
                4 => MessageBoxButtons.YesNo,
                5 => MessageBoxButtons.RetryCancel,
                _ => MessageBoxButtons.OK
            };


            MessageBoxIcon icon = iconoIdx switch
            {
                0 => MessageBoxIcon.Asterisk,
                1 => MessageBoxIcon.Error,
                2 => MessageBoxIcon.Exclamation,
                3 => MessageBoxIcon.Hand,
                4 => MessageBoxIcon.Information,
                5 => MessageBoxIcon.Question,
                6 => MessageBoxIcon.Stop,
                7 => MessageBoxIcon.Warning,
                _ => MessageBoxIcon.Information
            };

            DialogResult result = MessageBox.Show("Texto predeterminado", "Mensaje", buttons, icon);

            string respuesta = result switch
            {
                DialogResult.Yes => "Si",
                DialogResult.No => "No",
                DialogResult.Cancel => "Cancelar",
                DialogResult.Abort => "Abortar",
                DialogResult.Retry => "Reintentar",
                DialogResult.Ignore => "Ignorar",
                _ => "OK"
            };

            lblResultado.Text = $"Resultado es: {respuesta}";
        };

        Controls.AddRange([grpTipo, grpIcono, btnMostrar, lblResultado]);
    }
}
