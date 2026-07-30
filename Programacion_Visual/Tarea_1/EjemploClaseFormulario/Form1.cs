namespace EjemploClaseFormulario;

public partial class Form1 : Form
{
    private Button btnSaludo;
    private ToolTip toolTip;

    public Form1()
    {
        InitializeComponent();

        BuildUI();
    }

    private void BuildUI()
    {
        ClientSize = new Size(300, 200);
        Name = "frm1";
        Text = "Hola soy un formulario...";

        btnSaludo = new Button
        {
            Name = "btSaludo",
            Text = "Pulse aqui",
            Location = new Point(53, 90),
            Size = new Size(187, 23),
            TabIndex = 0
        };

        toolTip = new ToolTip();
        toolTip.SetToolTip(btnSaludo, "Hola soy un botón, pulsame");

        btnSaludo.Click += new EventHandler(BtnSaludoClick);

        Controls.Add(btnSaludo);
    }

    public void BtnSaludoClick(object sender, EventArgs e)
    {
        MessageBox.Show(this, "Hola, como estas...");
    }
}
