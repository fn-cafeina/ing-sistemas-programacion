using System.Drawing.Drawing2D;

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

        // Iconos de la barra de herramientas (creados por código)
        private ImageList imgBarra = null!;

        // Menú dinámico creado mediante programación (indicador: menús dinámicos)
        private readonly ToolStripMenuItem menuRecientes = new ToolStripMenuItem();
        private readonly List<string> recientes = new List<string>();

        public Form1()
        {
            InitializeComponent();

            // Imágenes en los controles de la barra de herramientas y del menú
            InicializarBarraDeHerramientas();

            // Menú "Recientes" construido con código (no en el diseñador)
            ConstruirMenuRecientes();

            // Barra de estado reactiva al pasar el cursor por las opciones del menú
            CablearEstadosDeMenu();

            // Comportamiento dinámico al iniciar: Guardar, Modificar y Eliminar deshabilitados
            HabilitarEdicion(false);

            // Las categorías ya vienen cargadas desde el Diseñador (no duplicar aquí).

            // Initial grid population
            RefreshGrid();
        }

        // ============================================================
        //  Handlers compartidos (menú, barra de herramientas y botones)
        // ============================================================

        private void ArchivoSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Refresh the DataGridView to show current libro list
        private void RefreshGrid()
        {
            // Bind a simple list snapshot to the grid
            var list = libros.Values.Select(l => new
            {
                l.Codigo,
                l.Titulo,
                l.Autor,
                l.Categoria,
                l.Anio,
                ISBN = l.Isbn,
                Disponible = l.Disponible ? "Sí" : "No"
            }).ToList();

            dgvLibros.DataSource = null;
            dgvLibros.DataSource = list;

            // Column configuration will run after binding completes (see DataBindingComplete handler)

            // Update record counter in status strip
            etbarestRegistros.Text = $"Registros: {libros.Count}";
        }

        private void ConfigurarColumna(string nombre, string encabezado, float peso, int minimo)
        {
            var col = dgvLibros.Columns[nombre];
            if (col == null) return;
            col.HeaderText = encabezado;
            col.FillWeight = peso;
            col.MinimumWidth = minimo;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DgvLibros_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (dgvLibros.Columns.Count == 0) return;
                ConfigurarColumna("Codigo", "Código", 60, 55);
                ConfigurarColumna("Titulo", "Título", 170, 120);
                ConfigurarColumna("Autor", "Autor", 130, 90);
                ConfigurarColumna("Categoria", "Categoría", 110, 80);
                ConfigurarColumna("Anio", "Año", 55, 45);
                ConfigurarColumna("ISBN", "ISBN", 105, 85);
                ConfigurarColumna("Disponible", "Disp.", 70, 55);
            }
            catch
            {
                // ignore configuration errors to avoid crashing on weird grid states
            }
        }

        // Load selected book into form when user double-clicks a row
        private void DgvLibros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvLibros.Rows[e.RowIndex];
            string codigo = dgvLibros.Columns.Contains("Codigo")
                ? row.Cells["Codigo"].Value?.ToString() ?? ""
                : row.Cells[0].Value?.ToString() ?? "";
            if (codigo.Length == 0) return;

            txtCodigo.Text = codigo;
            Consultar();
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
            toolStrip1.Visible = VerBarraHerramientas.Checked;
        }

        private void VerBarraEstado_CheckedChanged(object sender, EventArgs e)
        {
            statusStrip1.Visible = VerBarraEstado.Checked;
        }

        // Ejemplo de la guía: la barra de estado cambia al recorrer las opciones del menú
        private void MenuItem_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is not ToolStripItem item || string.IsNullOrWhiteSpace(item.Text))
                return;

            etbarestPpal.Text = item == ArchivoSalir
                ? "Cierra la aplicación"
                : "Estado: " + item.Text.Replace("&", string.Empty);
        }

        // ============================================================
        //  Imágenes en los controles (indicador 6)
        // ============================================================

        private void InicializarBarraDeHerramientas()
        {
            imgBarra = new ImageList(components);
            imgBarra.ImageSize = new Size(16, 16);
            imgBarra.ColorDepth = ColorDepth.Depth32Bit;

            imgBarra.Images.Add(DibujarNuevaPagina());   // 0 - Nuevo
            imgBarra.Images.Add(DibujarDisquete());      // 1 - Guardar
            imgBarra.Images.Add(DibujarLapiz());         // 2 - Modificar
            imgBarra.Images.Add(DibujarPapelera());      // 3 - Eliminar
            imgBarra.Images.Add(DibujarLupa());          // 4 - Consultar
            imgBarra.Images.Add(DibujarPuerta());        // 5 - Salir

            // Botones de la barra de herramientas
            tsbNuevo.Image = imgBarra.Images[0];
            tsbGuardar.Image = imgBarra.Images[1];
            tsbModificar.Image = imgBarra.Images[2];
            tsbEliminar.Image = imgBarra.Images[3];
            tsbConsultar.Image = imgBarra.Images[4];
            tsbSalir.Image = imgBarra.Images[5];

            // Las mismas imágenes se muestran en las opciones del menú
            LibrosNuevo.Image = imgBarra.Images[0];
            LibrosGuardar.Image = imgBarra.Images[1];
            LibrosModificar.Image = imgBarra.Images[2];
            LibrosEliminar.Image = imgBarra.Images[3];
            LibrosConsultar.Image = imgBarra.Images[4];
            ArchivoSalir.Image = imgBarra.Images[5];
        }

        private static Bitmap DibujarNuevaPagina()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var papel = new SolidBrush(Color.White);
            using var borde = new Pen(Color.FromArgb(90, 120, 170));
            using var linea = new Pen(Color.FromArgb(140, 170, 210));

            g.FillRectangle(papel, 3, 1, 9, 13);
            g.DrawRectangle(borde, 3, 1, 9, 13);
            g.DrawLine(linea, 5, 5, 10, 5);
            g.DrawLine(linea, 5, 7, 10, 7);
            g.DrawLine(linea, 5, 9, 8, 9);

            return bmp;
        }

        private static Bitmap DibujarDisquete()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var cuerpo = new SolidBrush(Color.FromArgb(50, 90, 160));
            using var claro = new SolidBrush(Color.FromArgb(235, 235, 235));

            g.FillRectangle(cuerpo, 2, 2, 12, 12);
            g.FillRectangle(claro, 5, 2, 6, 5);
            g.FillRectangle(cuerpo, 9, 3, 2, 3);
            g.FillRectangle(claro, 4, 9, 8, 5);

            return bmp;
        }

        private static Bitmap DibujarLapiz()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var cuerpo = new SolidBrush(Color.FromArgb(250, 200, 60));
            using var punta = new SolidBrush(Color.FromArgb(235, 215, 180));
            using var borde = new Pen(Color.FromArgb(120, 90, 20));

            g.TranslateTransform(8, 8);
            g.RotateTransform(-45);
            g.FillRectangle(cuerpo, -7, -2, 11, 4);
            g.FillRectangle(punta, 4, -2, 3, 4);
            g.DrawRectangle(borde, -7, -2, 11, 4);

            return bmp;
        }

        private static Bitmap DibujarPapelera()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var gris = new SolidBrush(Color.FromArgb(150, 155, 165));
            using var oscuro = new SolidBrush(Color.FromArgb(95, 100, 110));
            using var linea = new Pen(Color.FromArgb(105, 110, 120));

            g.FillRectangle(oscuro, 3, 2, 10, 2);
            g.FillRectangle(oscuro, 6, 1, 4, 1);
            g.FillRectangle(gris, 4, 5, 8, 9);
            g.DrawLine(linea, 6, 7, 6, 12);
            g.DrawLine(linea, 8, 7, 8, 12);
            g.DrawLine(linea, 10, 7, 10, 12);

            return bmp;
        }

        private static Bitmap DibujarLupa()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var cristal = new SolidBrush(Color.FromArgb(200, 225, 245));
            using var aro = new Pen(Color.FromArgb(40, 100, 170), 2f);
            using var mango = new Pen(Color.FromArgb(90, 70, 40), 3f);

            g.FillEllipse(cristal, 2, 2, 9, 9);
            g.DrawEllipse(aro, 2, 2, 9, 9);
            g.DrawLine(mango, 10, 10, 14, 14);

            return bmp;
        }

        private static Bitmap DibujarPuerta()
        {
            var bmp = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using var puerta = new SolidBrush(Color.FromArgb(200, 70, 70));
            using var borde = new Pen(Color.FromArgb(120, 35, 35));
            using var picaporte = new SolidBrush(Color.White);

            g.FillRectangle(puerta, 4, 2, 8, 12);
            g.DrawRectangle(borde, 4, 2, 8, 12);
            g.FillEllipse(picaporte, 9, 7, 2, 2);

            return bmp;
        }

        // ============================================================
        //  Menús mediante código + menús dinámicos (indicadores 3 y 11)
        // ============================================================

        private void ConstruirMenuRecientes()
        {
            menuRecientes.Name = "menuRecientes";
            menuRecientes.Text = "&Recientes";
            menuRecientes.Enabled = false;

            menuArchivo.DropDownItems.Add(new ToolStripSeparator());
            menuArchivo.DropDownItems.Add(menuRecientes);
        }

        private void AgregarReciente(string codigo)
        {
            if (codigo.Length == 0) return;

            recientes.Remove(codigo);
            recientes.Insert(0, codigo);
            while (recientes.Count > 5)
                recientes.RemoveAt(recientes.Count - 1);

            menuRecientes.DropDownItems.Clear();
            foreach (var cod in recientes)
            {
                var item = new ToolStripMenuItem(cod);
                item.Click += Reciente_Click;
                item.MouseEnter += MenuItem_MouseEnter;
                menuRecientes.DropDownItems.Add(item);
            }

            menuRecientes.Enabled = menuRecientes.DropDownItems.Count > 0;
        }

        private void Reciente_Click(object? sender, EventArgs e)
        {
            if (sender is not ToolStripMenuItem item) return;
            txtCodigo.Text = item.Text;
            Consultar();
        }

        // ============================================================
        //  Barra de estado reactiva (indicador 9)
        // ============================================================

        private void CablearEstadosDeMenu()
        {
            CablearOpciones(menuArchivo.DropDownItems);
            CablearOpciones(menuLibros.DropDownItems);
            CablearOpciones(menuVer.DropDownItems);
            CablearOpciones(menuAyuda.DropDownItems);

            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item is ToolStripButton boton)
                    boton.MouseEnter += MenuItem_MouseEnter;
            }
        }

        private void CablearOpciones(ToolStripItemCollection opciones)
        {
            foreach (ToolStripItem item in opciones)
            {
                if (item is ToolStripMenuItem opcion)
                    opcion.MouseEnter += MenuItem_MouseEnter;
            }
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

        // Nuevo: limpiar el formulario y habilitar Guardar para registrar
        private void Nuevo()
        {
            txtCodigo.Clear();
            txtTitulo.Clear();
            txtAutor.Clear();
            txtAnio.Clear();
            txtISBN.Clear();
            cmbCategoria.SelectedIndex = -1;
            chkDisponible.Checked = true;
            HabilitarEdicion(true);
            SoloGuardarHabilitado();
            etbarestPpal.Text = "Estado: Preparado para registrar un libro";
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
            RefreshGrid();
            HabilitarEdicion(true);   // Después de registrar un libro se habilitan
            AgregarReciente(codigo);
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
            RefreshGrid();
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

            if (respuesta != DialogResult.Yes)
            {
                etbarestPpal.Text = "Estado: Listo";
                return;
            }

            libros.Remove(codigo);
            ActualizarContador();
            RefreshGrid();
            Nuevo();   // Limpia el formulario y deja "Estado: Preparado para registrar un libro"
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
                SeleccionarCategoria(libro.Categoria);
                HabilitarEdicion(true);
                AgregarReciente(codigo);

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

        private void SeleccionarCategoria(string categoria)
        {
            if (categoria.Length == 0)
            {
                cmbCategoria.SelectedIndex = -1;
                return;
            }

            int indice = cmbCategoria.FindStringExact(categoria);
            if (indice >= 0)
            {
                cmbCategoria.SelectedIndex = indice;
                return;
            }

            cmbCategoria.Items.Add(categoria);
            cmbCategoria.SelectedIndex = cmbCategoria.Items.Count - 1;
        }

        private void HabilitarEdicion(bool habilitar)
        {
            // Opciones del menú
            LibrosGuardar.Enabled = habilitar;
            LibrosModificar.Enabled = habilitar;
            LibrosEliminar.Enabled = habilitar;
            // Botones de la barra de herramientas: misma acción, mismo estado
            tsbGuardar.Enabled = habilitar;
            tsbModificar.Enabled = habilitar;
            tsbEliminar.Enabled = habilitar;
            // Botón Guardar del formulario acompaña al menú
            btnGuardar.Enabled = habilitar;
        }

        // Tras un "Nuevo" solo queda habilitado el registro de un libro
        private void SoloGuardarHabilitado()
        {
            LibrosModificar.Enabled = false;
            LibrosEliminar.Enabled = false;
            tsbModificar.Enabled = false;
            tsbEliminar.Enabled = false;
        }
    }
}
