using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace VisorMejorado
{
    public partial class Form1 : Form
    {
        private const int IndiceCarpetaCerrada = 0;
        private const int IndiceCarpetaAbierta = 1;
        private const string TextoCargando = "Cargando...";

        private const uint SHGFI_SMALLICON = 0x00000001;
        private const uint SHGFI_OPENICON = 0x00000002;
        private const uint SHGFI_ICON = 0x00000100;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;

        private static readonly string[] FormatosImagen =
            { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif", "*.tif", "*.tiff", "*.webp" };

        private TreeNode? _nodoSeleccionado;
        private string _rutaImagenActual = string.Empty;
        private bool _esAjustar = true;

        public Form1()
        {
            InitializeComponent();
            InicializarIconosCarpetas();

            lvImagenes.LargeImageList = imgListImagenes;
            lvImagenes.SmallImageList = imgListImagenes;
            lvImagenes.StateImageList = imgListImagenes;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarUnidades();
        }

        // --- Unidades lógicas ---

        private void CargarUnidades()
        {
            cbUnidad.Items.Clear();
            foreach (var unidad in DriveInfo.GetDrives())
            {
                try
                {
                    if (unidad.IsReady)
                        cbUnidad.Items.Add(unidad.Name);
                }
                catch (IOException) { }
            }

            if (cbUnidad.Items.Count > 0)
                cbUnidad.SelectedIndex = 0;
        }

        private void CbUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUnidad.SelectedItem == null) return;
            CargarUnidad(cbUnidad.SelectedItem.ToString()!);
        }

        private void CargarUnidad(string ruta)
        {
            _nodoSeleccionado = null;
            tvCarpetas.Nodes.Clear();
            LimpiarVista();

            var info = new DirectoryInfo(ruta);
            if (!info.Exists) return;

            var raiz = new TreeNode(info.FullName, IndiceCarpetaCerrada, IndiceCarpetaAbierta) { Tag = info.FullName };
            raiz.Nodes.Add(new TreeNode(TextoCargando));
            tvCarpetas.Nodes.Add(raiz);

            CargarHijos(raiz);
            raiz.Expand();
        }

        // --- TreeView de directorios ---

        private void CargarHijos(TreeNode nodo)
        {
            nodo.Nodes.Clear();

            if (nodo.Tag is not string ruta || !Directory.Exists(ruta)) return;

            try
            {
                var directorios = new DirectoryInfo(ruta).GetDirectories()
                    .OrderBy(d => d.Name, StringComparer.CurrentCultureIgnoreCase);

                foreach (var dir in directorios)
                {
                    var hijo = new TreeNode(dir.Name, IndiceCarpetaCerrada, IndiceCarpetaAbierta) { Tag = dir.FullName };
                    hijo.Nodes.Add(new TreeNode(TextoCargando));
                    nodo.Nodes.Add(hijo);
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
        }

        private void TvCarpetas_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var nodo = e.Node;
            if (nodo.Nodes.Count == 1 && nodo.Nodes[0].Text == TextoCargando)
                CargarHijos(nodo);
        }

        private void TvCarpetas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;

            if (_nodoSeleccionado != null && _nodoSeleccionado != e.Node)
            {
                _nodoSeleccionado.ImageIndex = IndiceCarpetaCerrada;
                _nodoSeleccionado.SelectedImageIndex = IndiceCarpetaCerrada;
            }

            _nodoSeleccionado = e.Node;
            e.Node.ImageIndex = IndiceCarpetaAbierta;
            e.Node.SelectedImageIndex = IndiceCarpetaAbierta;

            if (e.Node.Tag is string ruta)
                CargarImagenes(ruta);
        }

        // --- ListView de imágenes ---

        private void CargarImagenes(string ruta)
        {
            LimpiarVista();
            if (!Directory.Exists(ruta)) return;

            var archivos = new List<string>();
            try
            {
                foreach (var patron in FormatosImagen)
                    archivos.AddRange(Directory.GetFiles(ruta, patron));
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }

            foreach (var archivo in archivos.OrderBy(a => Path.GetFileName(a) ?? a, StringComparer.CurrentCultureIgnoreCase))
            {
                try
                {
                    using var original = Image.FromFile(archivo);
                    var miniatura = CrearMiniatura(original, imgListImagenes.ImageSize);
                    imgListImagenes.Images.Add(miniatura);

                    var item = new ListViewItem(Path.GetFileName(archivo))
                    {
                        ImageIndex = imgListImagenes.Images.Count - 1
                    };
                    item.SubItems.Add((new FileInfo(archivo).Length / 1024L).ToString("N0"));
                    item.Tag = archivo;
                    lvImagenes.Items.Add(item);
                }
                catch (IOException) { }
                catch (UnauthorizedAccessException) { }
                catch (OutOfMemoryException) { }
            }
        }

        private static Bitmap CrearMiniatura(Image original, Size limite)
        {
            var miniatura = new Bitmap(limite.Width, limite.Height);
            using var g = Graphics.FromImage(miniatura);
            g.Clear(Color.Transparent);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            var escala = Math.Min((double)limite.Width / original.Width, (double)limite.Height / original.Height);
            var ancho = Math.Max(1, (int)(original.Width * escala));
            var alto = Math.Max(1, (int)(original.Height * escala));
            g.DrawImage(original, (limite.Width - ancho) / 2, (limite.Height - alto) / 2, ancho, alto);

            return miniatura;
        }

        private void LvImagenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvImagenes.SelectedItems.Count == 0) return;

            if (lvImagenes.SelectedItems[0].Tag is string ruta)
                MostrarImagen(ruta);
        }

        private void LimpiarVista()
        {
            lvImagenes.Items.Clear();
            VaciarListaImagenes();

            pbPreview.Image?.Dispose();
            pbPreview.Image = null;
            _rutaImagenActual = string.Empty;
            lblInfo.Text = "—";
        }

        private void VaciarListaImagenes()
        {
            foreach (Image imagen in imgListImagenes.Images)
                imagen.Dispose();
            imgListImagenes.Images.Clear();
        }

        // --- PictureBox + Label ---

        private void MostrarImagen(string ruta)
        {
            try
            {
                using var stream = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var original = Image.FromStream(stream);
                var copia = new Bitmap(original);

                pbPreview.Image?.Dispose();
                pbPreview.Image = copia;
                _rutaImagenActual = ruta;
                _esAjustar = true;
                pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
                btnAjustar.Text = "Real";
                lblInfo.Text = $"{Path.GetFileName(ruta)}  -  {original.Width} × {original.Height} px";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la imagen:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Botones ---

        private void BtnPortapapeles_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image == null)
            {
                MessageBox.Show("No hay imagen para copiar al portapapeles.", "Portapapeles",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Clipboard.SetImage(pbPreview.Image);
                MessageBox.Show("Imagen copiada al portapapeles.", "Portapapeles",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ExternalException ex)
            {
                MessageBox.Show($"No se pudo acceder al portapapeles:\n{ex.Message}", "Portapapeles",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnFlip_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image == null) return;

            pbPreview.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            pbPreview.Refresh();
        }

        private void BtnAjustar_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image == null) return;

            _esAjustar = !_esAjustar;
            pbPreview.SizeMode = _esAjustar ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
            btnAjustar.Text = _esAjustar ? "Real" : "Ajustar";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (pbPreview.Image == null)
            {
                MessageBox.Show("No hay imagen para guardar.", "Guardar como ...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var saveDialog = new SaveFileDialog();
            saveDialog.Title = "Guardar imagen como ...";
            saveDialog.Filter = "PNG|*.png|JPEG|*.jpg;*.jpeg|BMP|*.bmp|GIF|*.gif|Todos los archivos|*.*";
            saveDialog.DefaultExt = "png";
            saveDialog.FileName = string.IsNullOrEmpty(_rutaImagenActual)
                ? "imagen"
                : Path.GetFileNameWithoutExtension(_rutaImagenActual);

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

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
                MessageBox.Show("Imagen guardada correctamente.", "Guardar como ...",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Explorador de Imágenes\n\n" +
                "Práctica: Visor de Imágenes Mejorado\n" +
                "Programación Visual I\n" +
                "Universidad Nacional Autónoma de Nicaragua – León\n" +
                "Ingeniería de Sistemas",
                "Acerca de ...",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // --- Iconos de carpeta (cerrada / abierta) ---

        private void InicializarIconosCarpetas()
        {
            var cerrada = ObtenerIconoCarpeta(false) ?? DibujarCarpeta(false);
            var abierta = ObtenerIconoCarpeta(true) ?? DibujarCarpeta(true);

            imgListCarpetas.Images.Add(cerrada);
            imgListCarpetas.Images.Add(abierta);
            tvCarpetas.ImageList = imgListCarpetas;
        }

        private static Image? ObtenerIconoCarpeta(bool abierta)
        {
            try
            {
                var shfi = new SHFILEINFO { szDisplayName = string.Empty, szTypeName = string.Empty };
                var flags = SHGFI_ICON | SHGFI_SMALLICON | (abierta ? SHGFI_OPENICON : 0u);
                SHGetFileInfo("C:\\", FILE_ATTRIBUTE_DIRECTORY, ref shfi,
                    (uint)Marshal.SizeOf<SHFILEINFO>(), flags);

                if (shfi.hIcon == IntPtr.Zero) return null;

                using var icono = Icon.FromHandle(shfi.hIcon);
                var bitmap = icono.ToBitmap();
                DestroyIcon(shfi.hIcon);
                return bitmap;
            }
            catch (DllNotFoundException) { return null; }
            catch (EntryPointNotFoundException) { return null; }
        }

        private static Bitmap DibujarCarpeta(bool abierta)
        {
            var bitmap = new Bitmap(16, 16);
            using var g = Graphics.FromImage(bitmap);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var color = abierta ? Color.FromArgb(255, 220, 120) : Color.FromArgb(255, 190, 60);
            using var relleno = new SolidBrush(color);
            using var borde = new Pen(Color.FromArgb(150, 100, 30));

            g.FillRectangle(relleno, 1, 5, 14, 10);
            g.FillRectangle(relleno, 1, 2, 7, 4);
            g.DrawRectangle(borde, 1, 5, 14, 10);

            return bitmap;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes,
            ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool DestroyIcon(IntPtr hIcon);
    }
}
