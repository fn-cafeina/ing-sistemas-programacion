namespace VisorMejorado
{
    public partial class Form1 : Form
    {
        private readonly string[] _formatosImagen = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tiff", "*.tif", "*.webp" };
        private string _rutaActual = string.Empty;
        private string _imagenActual = string.Empty;
        private bool _esAjustar = true;

        public Form1()
        {
            InitializeComponent();
            cbRuta.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
            cbRuta.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            cbRuta.Items.Add(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            cbRuta.SelectedIndex = 0;
        }

        private void CargarCarpeta(string ruta)
        {
            if (!Directory.Exists(ruta))
            {
                MessageBox.Show("La ruta no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _rutaActual = ruta;

            // Cargar subcarpetas
            lbArchivos.Items.Clear();
            try
            {
                foreach (var dir in Directory.GetDirectories(ruta))
                {
                    lbArchivos.Items.Add(Path.GetFileName(dir));
                }
            }
            catch (UnauthorizedAccessException) { }

            // Cargar imágenes
            lbImagenes.Items.Clear();
            try
            {
                foreach (var patron in _formatosImagen)
                {
                    foreach (var archivo in Directory.GetFiles(ruta, patron))
                    {
                        lbImagenes.Items.Add(Path.GetFileName(archivo));
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        private void MostrarImagen(string rutaImagen)
        {
            if (!File.Exists(rutaImagen)) return;

            try
            {
                // Liberar imagen anterior
                pbPreview.Image?.Dispose();

                // Cargar imagen en memoria para evitar bloqueo del archivo
                using var stream = new FileStream(rutaImagen, FileMode.Open, FileAccess.Read);
                var imagen = Image.FromStream(stream);
                pbPreview.Image = new Bitmap(imagen);

                _imagenActual = rutaImagen;
                _esAjustar = true;
                pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                btnAjustar.Text = "Real";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerRutaCompleta(string nombreArchivo)
        {
            return Path.Combine(_rutaActual, nombreArchivo);
        }

        // --- Eventos ---

        private void CbRuta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var ruta = cbRuta.Text.Trim();
                if (Directory.Exists(ruta))
                {
                    if (!cbRuta.Items.Contains(ruta))
                        cbRuta.Items.Add(ruta);
                    CargarCarpeta(ruta);
                }
                else
                {
                    MessageBox.Show("La ruta no es válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void CbRuta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRuta.SelectedItem != null)
                CargarCarpeta(cbRuta.SelectedItem.ToString()!);
        }

        private void LbArchivos_DoubleClick(object sender, EventArgs e)
        {
            if (lbArchivos.SelectedItem == null) return;

            var nombreCarpeta = lbArchivos.SelectedItem.ToString()!;
            var ruta = Path.Combine(_rutaActual, nombreCarpeta);

            if (Directory.Exists(ruta))
            {
                cbRuta.Text = ruta;
                CargarCarpeta(ruta);
            }
        }

        private void LbImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbImagenes.SelectedItem == null) return;

            var ruta = ObtenerRutaCompleta(lbImagenes.SelectedItem.ToString()!);
            MostrarImagen(ruta);
        }

        // --- Botones de edición ---

        private void BtnPortapapeles_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image != null && Clipboard.ContainsImage())
            {
                // Pegar imagen del portapapeles
                var imagen = Clipboard.GetImage();
                if (imagen != null)
                {
                    pbPreview.Image?.Dispose();
                    pbPreview.Image = new Bitmap(imagen);
                    _imagenActual = string.Empty;
                }
            }
            else if (pbPreview.Image != null)
            {
                // Copiar imagen al portapapeles
                Clipboard.SetImage(pbPreview.Image);
                MessageBox.Show("Imagen copiada al portapapeles.", "Portapapeles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay imagen para copiar ni imagen en el portapapeles para pegar.", "Portapapeles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAjustar_Click(object sender, EventArgs e)
        {
            _esAjustar = !_esAjustar;
            pbPreview.SizeMode = _esAjustar ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
            btnAjustar.Text = _esAjustar ? "Real" : "Ajustar";
        }

        private void BtnFlip_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image == null) return;

            pbPreview.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pbPreview.Refresh();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image == null)
            {
                MessageBox.Show("No hay imagen para guardar.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var saveDialog = new SaveFileDialog();
            saveDialog.Title = "Guardar imagen como...";
            saveDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|Todos los archivos|*.*";
            saveDialog.DefaultExt = "png";
            saveDialog.FileName = string.IsNullOrEmpty(_imagenActual) ? "imagen" : Path.GetFileNameWithoutExtension(_imagenActual);

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var formato = saveDialog.FilterIndex switch
                    {
                        2 => System.Drawing.Imaging.ImageFormat.Jpeg,
                        3 => System.Drawing.Imaging.ImageFormat.Bmp,
                        4 => System.Drawing.Imaging.ImageFormat.Gif,
                        _ => System.Drawing.Imaging.ImageFormat.Png
                    };

                    pbPreview.Image.Save(saveDialog.FileName, formato);
                    MessageBox.Show("Imagen guardada correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- Otros botones ---

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Explorador de Imágenes v1.0\n\nAplicación para visualizar y editar imágenes.\nSoporta: JPG, PNG, BMP, GIF, TIFF, WebP",
                "Acerca de",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
