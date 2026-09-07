namespace MenusBarras
{
    public partial class Form1 : Form
    {
        // Almacenamiento temporal de los libros registrados (código -> libro)
        private sealed class Libro
        {
            public string Codigo = "";
            public string Titulo = "";
            public string Autor = "";
            public string Categoria = "";
            public string Anio = "";
            public string Isbn = "";
            public bool Disponible = true;
        }

        private readonly Dictionary<string, Libro> libros = new Dictionary<string, Libro>();

        public Form1()
        {
            InitializeComponent();

            // Comportamiento dinámico al iniciar: Guardar, Modificar y Eliminar deshabilitados
            HabilitarEdicion(false);
        }

        // ============================================================
        //  Handlers compartidos (menú, barra de herramientas y botones)
        // ============================================================

        private void ArchivoSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LibrosNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void LibrosGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void LibrosModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void LibrosEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void LibrosConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void AyudaAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Sistema de Gestión de Biblioteca\n\n" +
                "Aplicación de ejemplo que utiliza MenuStrip, ToolStrip, " +
                "StatusStrip y ContextMenuStrip en Windows Forms.",
                "Acerca de...",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Menú Ver: mostrar / ocultar barras (propiedades Visible y Checked)
        private void VerBarraHerramientas_CheckedChanged(object sender, EventArgs e)
        {
            // ToolStrip was removed; keep the menu item checked to indicate the
            // main menu is always visible.
            VerBarraHerramientas.Checked = true;
        }

        private void VerBarraEstado_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip1.Visible = VerBarraEstado.Checked;
        }

        // Ejemplo de la guía: la barra de estado cambia al recorrer las opciones del menú
        private void ArchivoSalir_MouseEnter(object sender, EventArgs e)
        {
            etbarestPpal.Text = "Cierra la aplicación";
        }

        private void ArchivoSalir_MouseLeave(object sender, EventArgs e)
        {
            etbarestPpal.Text = "Estado: Listo";
        }

        // ============================================================
        //  Menú contextual del campo Título
        // ============================================================

        private void CtxCortar_Click(object sender, EventArgs e)
        {
            txtTitulo.Cut();
        }

        private void CtxCopiar_Click(object sender, EventArgs e)
        {
            txtTitulo.Copy();
        }

        private void CtxPegar_Click(object sender, EventArgs e)
        {
            txtTitulo.Paste();
        }

        private void CtxLimpiar_Click(object sender, EventArgs e)
        {
            txtTitulo.Clear();
        }

        // ============================================================
        //  Operaciones de la aplicación
        // ============================================================

        // Nuevo: limpiar el formulario
        private void Nuevo()
        {
            txtCodigo.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtAnio.Clear();
            txtISBN.Clear();
            cmbCategoria.SelectedIndex = -1;
            chkDisponible.Checked = true;
            etbarestPpal.Text = "Estado: Preparado";
            txtCodigo.Focus();
        }

        // Guardar: registrar un libro
        private void Guardar()
        {
            etbarestPpal.Text = "Estado: Registrando libro";

            if (!ValidarCampos())
            {
                etbarestPpal.Text = "Estado: Listo";
                return;
            }

            string codigo = txtCodigo.Text.Trim();
            bool yaExistia = libros.ContainsKey(codigo);

            libros[codigo] = new Libro
            {
                Codigo = codigo,
                Titulo = txtTitulo.Text.Trim(),
                Autor = txtAutor.Text.Trim(),
                Categoria = cmbCategoria.SelectedItem?.ToString() ?? "",
                Anio = txtAnio.Text.Trim(),
                Isbn = txtISBN.Text.Trim(),
                Disponible = chkDisponible.Checked
            };

            ActualizarContador();
            HabilitarEdicion(true);   // Después de registrar un libro se habilitan
            etbarestPpal.Text = "Estado: Listo";

            MessageBox.Show(
                yaExistia ? "El libro se actualizó correctamente." : "Libro registrado correctamente.",
                "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Modificar: actualizar la información del libro con el código indicado
        private void Modificar()
        {
            etbarestPpal.Text = "Estado: Modificando libro";

            string codigo = txtCodigo.Text.Trim();
            if (!libros.ContainsKey(codigo))
            {
                MessageBox.Show("No existe un libro con ese código. Consulte un libro primero.",
                    "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                etbarestPpal.Text = "Estado: Listo";
                return;
            }

            if (!ValidarCampos())
            {
                etbarestPpal.Text = "Estado: Listo";
                return;
            }

            Libro libro = libros[codigo];
            libro.Titulo = txtTitulo.Text.Trim();
            libro.Autor = txtAutor.Text.Trim();
            libro.Categoria = cmbCategoria.SelectedItem?.ToString() ?? "";
            libro.Anio = txtAnio.Text.Trim();
            libro.Isbn = txtISBN.Text.Trim();
            libro.Disponible = chkDisponible.Checked;

            etbarestPpal.Text = "Estado: Listo";
            MessageBox.Show("Información modificada correctamente.",
                "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Eliminar: dar de baja el registro con el código indicado
        private void Eliminar()
        {
            etbarestPpal.Text = "Estado: Eliminando registro";

            string codigo = txtCodigo.Text.Trim();
            if (!libros.ContainsKey(codigo))
            {
                MessageBox.Show("No existe un libro con ese código. Consulte un libro primero.",
                    "Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                etbarestPpal.Text = "Estado: Listo";
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                $"¿Eliminar el libro con código '{codigo}'?",
                "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta == DialogResult.Yes)
            {
                libros.Remove(codigo);
                ActualizarContador();

                if (libros.Count == 0)
                {
                    HabilitarEdicion(false);   // Sin registros vuelven a deshabilitarse
                }

                Nuevo();   // Limpiar el formulario
            }

            etbarestPpal.Text = "Estado: Listo";
        }

        // Consultar: buscar un libro por su código y cargarlo en el formulario
        private void Consultar()
        {
            etbarestPpal.Text = "Estado: Consultando libro";

            string codigo = txtCodigo.Text.Trim();
            if (codigo.Length == 0)
            {
                MessageBox.Show("Escriba el código del libro a consultar.",
                    "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                etbarestPpal.Text = "Estado: Listo";
                return;
            }

            if (libros.TryGetValue(codigo, out var libro))
            {
                txtTitulo.Text = libro.Titulo;
                txtAutor.Text = libro.Autor;
                txtAnio.Text = libro.Anio;
                txtISBN.Text = libro.Isbn;
                chkDisponible.Checked = libro.Disponible;
                if (libro.Categoria.Length > 0)
                {
                    cmbCategoria.SelectedItem = libro.Categoria;
                }

                etbarestPpal.Text = "Estado: Libro encontrado";
                return;
            }

            MessageBox.Show($"No se encontró un libro con el código '{codigo}'.",
                "Consultar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            etbarestPpal.Text = "Estado: Listo";
        }

        // ============================================================
        //  Utilidades
        // ============================================================

        private bool ValidarCampos()
        {
            if (txtCodigo.Text.Trim().Length == 0 ||
                txtTitulo.Text.Trim().Length == 0 ||
                txtAutor.Text.Trim().Length == 0 ||
                cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Complete Código, Título, Autor y Categoría antes de guardar.",
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtAnio.Text.Trim().Length > 0 && !int.TryParse(txtAnio.Text.Trim(), out _))
            {
                MessageBox.Show("El año debe ser un número.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ActualizarContador()
        {
            etbarestRegistros.Text = $"Registros: {libros.Count}";
        }

        private void HabilitarEdicion(bool habilitar)
        {
            // Opciones del menú
            LibrosGuardar.Enabled = habilitar;
            LibrosModificar.Enabled = habilitar;
            LibrosEliminar.Enabled = habilitar;
        }
    }
}
