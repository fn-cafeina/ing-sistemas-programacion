using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaAutos;

public partial class Form1 : Form
{
    private readonly BindingList<Auto> autos = new();

    private readonly TextBox txtMarca = new();
    private readonly TextBox txtModelo = new();
    private readonly TextBox txtAnio = new();
    private readonly TextBox txtColor = new();
    private readonly TextBox txtPrecio = new();

    private readonly Button btnGuardar = new();
    private readonly Button btnVisualizar = new();

    public Form1()
    {
        Text = "Sistema Autos";
        ClientSize = new Size(430, 260);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;

        var lblMarca = new Label
        {
            Text = "Marca",
            Location = new Point(20, 23),
            AutoSize = true
        };

        var lblModelo = new Label
        {
            Text = "Modelo",
            Location = new Point(20, 53),
            AutoSize = true
        };

        var lblAnio = new Label
        {
            Text = "Año",
            Location = new Point(20, 83),
            AutoSize = true
        };

        var lblColor = new Label
        {
            Text = "Color",
            Location = new Point(20, 113),
            AutoSize = true
        };

        var lblPrecio = new Label
        {
            Text = "Precio",
            Location = new Point(20, 143),
            AutoSize = true
        };

        txtMarca.Location = new Point(120, 20);
        txtMarca.Width = 260;

        txtModelo.Location = new Point(120, 50);
        txtModelo.Width = 260;

        txtAnio.Location = new Point(120, 80);
        txtAnio.Width = 260;

        txtColor.Location = new Point(120, 110);
        txtColor.Width = 260;

        txtPrecio.Location = new Point(120, 140);
        txtPrecio.Width = 260;

        btnGuardar.Text = "Guardar";
        btnGuardar.Location = new Point(120, 180);
        btnGuardar.Size = new Size(120, 35);
        btnGuardar.Click += BtnGuardar_Click;

        btnVisualizar.Text = "Visualizar";
        btnVisualizar.Location = new Point(260, 180);
        btnVisualizar.Size = new Size(120, 35);
        btnVisualizar.Click += BtnVisualizar_Click;

        Controls.AddRange(new Control[]
        {
            lblMarca,
            txtMarca,
            lblModelo,
            txtModelo,
            lblAnio,
            txtAnio,
            lblColor,
            txtColor,
            lblPrecio,
            txtPrecio,
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
            Marca = txtMarca.Text.Trim(),
            Modelo = txtModelo.Text.Trim(),
            Anio = int.Parse(txtAnio.Text.Trim()),
            Color = txtColor.Text.Trim(),
            Precio = decimal.Parse(txtPrecio.Text.Trim())
        });

        LimpiarCampos();
        MessageBox.Show("Auto guardado correctamente.");
    }

    private bool ValidarCampos()
    {
        if (string.IsNullOrWhiteSpace(txtMarca.Text))
        {
            MessageBox.Show("Debes ingresar la marca.");
            txtMarca.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtModelo.Text))
        {
            MessageBox.Show("Debes ingresar el modelo.");
            txtModelo.Focus();
            return false;
        }

        if (!int.TryParse(txtAnio.Text.Trim(), out int anio)
            || anio < 1900
            || anio > DateTime.Now.Year)
        {
            MessageBox.Show("El año debe ser un número válido entre 1900 y " + DateTime.Now.Year + ".");
            txtAnio.Focus();
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtColor.Text))
        {
            MessageBox.Show("Debes ingresar el color.");
            txtColor.Focus();
            return false;
        }

        if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio <= 0)
        {
            MessageBox.Show("El precio debe ser un número mayor a 0.");
            txtPrecio.Focus();
            return false;
        }

        return true;
    }

    private void LimpiarCampos()
    {
        txtMarca.Clear();
        txtModelo.Clear();
        txtAnio.Clear();
        txtColor.Clear();
        txtPrecio.Clear();
        txtMarca.Focus();
    }

    private void BtnVisualizar_Click(object? sender, EventArgs e)
    {
        FormVisualizar frm = new(autos);
        frm.ShowDialog();
    }
}
