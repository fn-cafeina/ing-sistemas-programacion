using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAutos;

public partial class Form1 : Form
{
    private readonly BindingList<Auto> autos = new();

    private readonly ComboBox cmbMarca = new();
    private readonly TextBox txtKilometraje = new();
    private readonly ComboBox cmbEstado = new();
    private readonly TextBox txtPrecio = new();
    private readonly ComboBox cmbTransmision = new();
    private readonly RadioButton rbRinesSi = new();
    private readonly RadioButton rbRinesNo = new();

    private readonly Button btnGuardar = new();
    private readonly Button btnVisualizar = new();

    public Form1()
    {
        Text = "Sistema Autos";
        ClientSize = new Size(520, 420);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var lblMarca = new Label
        {
            Text = "Seleccione la marca del auto",
            Location = new Point(20, 20),
            AutoSize = true
        };

        var lblKilometraje = new Label
        {
            Text = "Ingrese el Kilometraje",
            Location = new Point(20, 75),
            AutoSize = true
        };

        var lblEstado = new Label
        {
            Text = "Seleccione el estado",
            Location = new Point(20, 130),
            AutoSize = true
        };

        var lblPrecio = new Label
        {
            Text = "Ingrese el precio (US$)",
            Location = new Point(20, 185),
            AutoSize = true
        };

        var lblTransmision = new Label
        {
            Text = "Seleccione el sistema de transmisión",
            Location = new Point(20, 240),
            AutoSize = true
        };

        var lblRines = new Label
        {
            Text = "¿Tiene rines de lujo?",
            Location = new Point(20, 295),
            AutoSize = true
        };

        cmbMarca.Location = new Point(20, 40);
        cmbMarca.Width = 300;
        cmbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbMarca.Items.AddRange(new object[]
        {
            "Toyota", "Honda", "Nissan", "Hyundai", "Kia", "Ford", "Chevrolet", "Mazda"
        });

        txtKilometraje.Location = new Point(20, 95);
        txtKilometraje.Width = 300;

        cmbEstado.Location = new Point(20, 150);
        cmbEstado.Width = 300;
        cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbEstado.Items.AddRange(new object[] { "Nuevo", "Usado", "Seminuevo" });

        txtPrecio.Location = new Point(20, 205);
        txtPrecio.Width = 300;

        cmbTransmision.Location = new Point(20, 260);
        cmbTransmision.Width = 300;
        cmbTransmision.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTransmision.Items.AddRange(new object[] { "Manual", "Automática" });

        rbRinesSi.Text = "Sí";
        rbRinesSi.Location = new Point(20, 315);
        rbRinesSi.AutoSize = true;
        rbRinesSi.Checked = true;

        rbRinesNo.Text = "No";
        rbRinesNo.Location = new Point(80, 315);
        rbRinesNo.AutoSize = true;

        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(20, 360);
        btnGuardar.Size = new Size(140, 35);
        btnGuardar.Click += BtnGuardar_Click;

        btnVisualizar.Text = "Visualizar";
        btnVisualizar.Location = new Point(180, 360);
        btnVisualizar.Size = new Size(140, 35);
        btnVisualizar.Click += BtnVisualizar_Click;

        Controls.AddRange(new Control[]
        {
            lblMarca,
            cmbMarca,
            lblKilometraje,
            txtKilometraje,
            lblEstado,
            cmbEstado,
            lblPrecio,
            txtPrecio,
            lblTransmision,
            cmbTransmision,
            lblRines,
            rbRinesSi,
            rbRinesNo,
            btnGuardar,
            btnVisualizar
        });
    }

    private void BtnGuardar_Click(object? sender, EventArgs e)
    {
        if (!ValidarCampos())
            return;

        autos.Add(new Auto
        {
            Marca = cmbMarca.SelectedItem!.ToString()!,
            Kilometraje = int.Parse(txtKilometraje.Text.Trim()),
            Estado = cmbEstado.SelectedItem!.ToString()!,
            Precio = decimal.Parse(txtPrecio.Text.Trim()),
            Transmision = cmbTransmision.SelectedItem!.ToString()!,
            RinesDeLujo = rbRinesSi.Checked
        });

        LimpiarCampos();
        MessageBox.Show("Auto guardado correctamente.");
    }

    private bool ValidarCampos()
    {
        if (cmbMarca.SelectedIndex == -1)
        {
            MessageBox.Show("Debes seleccionar la marca del auto.");
            cmbMarca.Focus();
            return false;
        }

        if (!int.TryParse(txtKilometraje.Text.Trim(), out int km) || km < 0)
        {
            MessageBox.Show("El kilometraje debe ser un número mayor o igual a 0.");
            txtKilometraje.Focus();
            return false;
        }

        if (cmbEstado.SelectedIndex == -1)
        {
            MessageBox.Show("Debes seleccionar el estado.");
            cmbEstado.Focus();
            return false;
        }

        if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
        {
            MessageBox.Show("El precio debe ser un número mayor a 0.");
            txtPrecio.Focus();
            return false;
        }

        if (cmbTransmision.SelectedIndex == -1)
        {
            MessageBox.Show("Debes seleccionar el sistema de transmisión.");
            cmbTransmision.Focus();
            return false;
        }

        return true;
    }

    private void LimpiarCampos()
    {
        cmbMarca.SelectedIndex = -1;
        txtKilometraje.Clear();
        cmbEstado.SelectedIndex = -1;
        txtPrecio.Clear();
        cmbTransmision.SelectedIndex = -1;
        rbRinesSi.Checked = true;
        cmbMarca.Focus();
    }

    private void BtnVisualizar_Click(object? sender, EventArgs e)
    {
        FormVisualizar frm = new(autos);
        frm.ShowDialog();
    }
}