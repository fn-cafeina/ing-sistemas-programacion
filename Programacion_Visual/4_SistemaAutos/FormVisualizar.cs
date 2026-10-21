using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaAutos;

public class FormVisualizar : Form
{
    private readonly BindingList<Auto> autos;
    private readonly BindingSource bindingSource = new();

    private readonly TextBox txtBuscarMarca = new();
    private readonly DataGridView dgvAutos = new();

    public FormVisualizar(BindingList<Auto> autos)
    {
        this.autos = autos;

        Text = "Autos ingresados";
        ClientSize = new Size(760, 420);

        var lblBuscar = new Label
        {
            Text = "Buscar por marca",
            Location = new Point(20, 23),
            AutoSize = true
        };

        txtBuscarMarca.Location = new Point(150, 20);
        txtBuscarMarca.Width = 250;
        txtBuscarMarca.TextChanged += TxtBuscarMarca_TextChanged;

        dgvAutos.Location = new Point(20, 55);
        dgvAutos.Size = new Size(720, 340);
        dgvAutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvAutos.ReadOnly = true;
        dgvAutos.AllowUserToAddRows = false;
        dgvAutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        Controls.Add(lblBuscar);
        Controls.Add(txtBuscarMarca);
        Controls.Add(dgvAutos);

        bindingSource.DataSource = this.autos;
        dgvAutos.DataSource = bindingSource;
    }

    private void TxtBuscarMarca_TextChanged(object? sender, EventArgs e)
    {
        FiltrarPorMarca();
    }

    private void FiltrarPorMarca()
    {
        string filtro = txtBuscarMarca.Text.Trim().ToLower();

        if (string.IsNullOrEmpty(filtro))
        {
            bindingSource.DataSource = autos;
        }
        else
        {
            var filtrados = new BindingList<Auto>(
                autos.Where(a => a.Marca.ToLower().Contains(filtro)).ToList()
            );

            bindingSource.DataSource = filtrados;
        }

        dgvAutos.Refresh();
    }
}
