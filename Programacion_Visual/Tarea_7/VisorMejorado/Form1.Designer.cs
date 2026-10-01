namespace VisorMejorado
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            imgListCarpetas = new ImageList(components);
            imgListImagenes = new ImageList(components);
            gbUnidad = new GroupBox();
            cbUnidad = new ComboBox();
            gbCarpetas = new GroupBox();
            tvCarpetas = new TreeView();
            pbPreview = new PictureBox();
            lblInfo = new Label();
            gbImagenes = new GroupBox();
            lvImagenes = new ListView();
            colNombre = new ColumnHeader();
            colTamano = new ColumnHeader();
            gbAcciones = new GroupBox();
            btnAcercaDe = new Button();
            btnPortapapeles = new Button();
            btnFlip = new Button();
            btnAjustar = new Button();
            btnGuardar = new Button();
            btnSalir = new Button();
            gbUnidad.SuspendLayout();
            gbCarpetas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            gbImagenes.SuspendLayout();
            gbAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // gbUnidad
            // 
            gbUnidad.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            gbUnidad.Controls.Add(cbUnidad);
            gbUnidad.Location = new Point(16, 16);
            gbUnidad.Name = "gbUnidad";
            gbUnidad.Padding = new Padding(12, 8, 12, 12);
            gbUnidad.Size = new Size(246, 66);
            gbUnidad.TabIndex = 0;
            gbUnidad.TabStop = false;
            gbUnidad.Text = "Unidad lógica";
            // 
            // cbUnidad
            // 
            cbUnidad.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbUnidad.FormattingEnabled = true;
            cbUnidad.Location = new Point(14, 28);
            cbUnidad.Name = "cbUnidad";
            cbUnidad.Size = new Size(218, 28);
            cbUnidad.TabIndex = 0;
            cbUnidad.SelectedIndexChanged += CbUnidad_SelectedIndexChanged;
            // 
            // gbCarpetas
            // 
            gbCarpetas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
            gbCarpetas.Controls.Add(tvCarpetas);
            gbCarpetas.Location = new Point(16, 92);
            gbCarpetas.Name = "gbCarpetas";
            gbCarpetas.Padding = new Padding(12, 8, 12, 12);
            gbCarpetas.Size = new Size(246, 454);
            gbCarpetas.TabIndex = 1;
            gbCarpetas.TabStop = false;
            gbCarpetas.Text = "Carpetas";
            // 
            // tvCarpetas
            // 
            tvCarpetas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            tvCarpetas.HideSelection = false;
            tvCarpetas.Location = new Point(14, 28);
            tvCarpetas.Name = "tvCarpetas";
            tvCarpetas.Size = new Size(218, 412);
            tvCarpetas.TabIndex = 0;
            tvCarpetas.AfterSelect += TvCarpetas_AfterSelect;
            tvCarpetas.BeforeExpand += TvCarpetas_BeforeExpand;
            // 
            // pbPreview
            // 
            pbPreview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbPreview.BorderStyle = BorderStyle.FixedSingle;
            pbPreview.Location = new Point(278, 16);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(626, 300);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbPreview.TabIndex = 2;
            pbPreview.TabStop = false;
            // 
            // lblInfo
            // 
            lblInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblInfo.Location = new Point(278, 322);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(626, 24);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "—";
            lblInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbImagenes
            // 
            gbImagenes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            gbImagenes.Controls.Add(lvImagenes);
            gbImagenes.Location = new Point(278, 354);
            gbImagenes.Name = "gbImagenes";
            gbImagenes.Padding = new Padding(12, 8, 12, 12);
            gbImagenes.Size = new Size(626, 192);
            gbImagenes.TabIndex = 4;
            gbImagenes.TabStop = false;
            gbImagenes.Text = "Imágenes del directorio";
            // 
            // lvImagenes
            // 
            lvImagenes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            lvImagenes.Columns.AddRange(new ColumnHeader[] { colNombre, colTamano });
            lvImagenes.FullRowSelect = true;
            lvImagenes.HideSelection = false;
            lvImagenes.Location = new Point(14, 28);
            lvImagenes.MultiSelect = false;
            lvImagenes.Name = "lvImagenes";
            lvImagenes.Size = new Size(598, 150);
            lvImagenes.TabIndex = 0;
            lvImagenes.UseCompatibleStateImageBehavior = false;
            lvImagenes.View = View.Details;
            lvImagenes.SelectedIndexChanged += LvImagenes_SelectedIndexChanged;
            // 
            // colNombre
            // 
            colNombre.Text = "Nombre";
            colNombre.Width = 420;
            // 
            // colTamano
            // 
            colTamano.Text = "Tamaño (KB)";
            colTamano.TextAlign = HorizontalAlignment.Right;
            colTamano.Width = 140;
            // 
            // gbAcciones
            // 
            gbAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbAcciones.Controls.Add(btnAcercaDe);
            gbAcciones.Controls.Add(btnPortapapeles);
            gbAcciones.Controls.Add(btnFlip);
            gbAcciones.Controls.Add(btnAjustar);
            gbAcciones.Controls.Add(btnGuardar);
            gbAcciones.Controls.Add(btnSalir);
            gbAcciones.Location = new Point(16, 558);
            gbAcciones.Name = "gbAcciones";
            gbAcciones.Padding = new Padding(12, 8, 12, 12);
            gbAcciones.Size = new Size(888, 66);
            gbAcciones.TabIndex = 5;
            gbAcciones.TabStop = false;
            gbAcciones.Text = "Acciones";
            // 
            // btnAcercaDe
            // 
            btnAcercaDe.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAcercaDe.Location = new Point(14, 28);
            btnAcercaDe.Name = "btnAcercaDe";
            btnAcercaDe.Size = new Size(135, 28);
            btnAcercaDe.TabIndex = 0;
            btnAcercaDe.Text = "Acerca de ...";
            btnAcercaDe.UseVisualStyleBackColor = true;
            btnAcercaDe.Click += BtnAcercaDe_Click;
            // 
            // btnPortapapeles
            // 
            btnPortapapeles.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnPortapapeles.Location = new Point(159, 28);
            btnPortapapeles.Name = "btnPortapapeles";
            btnPortapapeles.Size = new Size(135, 28);
            btnPortapapeles.TabIndex = 1;
            btnPortapapeles.Text = "Portapapeles";
            btnPortapapeles.UseVisualStyleBackColor = true;
            btnPortapapeles.Click += BtnPortapapeles_Click;
            // 
            // btnFlip
            // 
            btnFlip.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnFlip.Location = new Point(304, 28);
            btnFlip.Name = "btnFlip";
            btnFlip.Size = new Size(135, 28);
            btnFlip.TabIndex = 2;
            btnFlip.Text = "Flip horizontal";
            btnFlip.UseVisualStyleBackColor = true;
            btnFlip.Click += BtnFlip_Click;
            // 
            // btnAjustar
            // 
            btnAjustar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnAjustar.Location = new Point(449, 28);
            btnAjustar.Name = "btnAjustar";
            btnAjustar.Size = new Size(135, 28);
            btnAjustar.TabIndex = 3;
            btnAjustar.Text = "Ajustar / Real";
            btnAjustar.UseVisualStyleBackColor = true;
            btnAjustar.Click += BtnAjustar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnGuardar.Location = new Point(594, 28);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(135, 28);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guarda como ...";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalir.Location = new Point(739, 28);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(135, 28);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += BtnSalir_Click;
            // 
            // imgListCarpetas
            // 
            imgListCarpetas.ColorDepth = ColorDepth.Depth32Bit;
            imgListCarpetas.ImageSize = new Size(16, 16);
            // 
            // imgListImagenes
            // 
            imgListImagenes.ColorDepth = ColorDepth.Depth32Bit;
            imgListImagenes.ImageSize = new Size(48, 48);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 640);
            Controls.Add(gbUnidad);
            Controls.Add(gbCarpetas);
            Controls.Add(pbPreview);
            Controls.Add(lblInfo);
            Controls.Add(gbImagenes);
            Controls.Add(gbAcciones);
            MinimumSize = new Size(820, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Explorador de Imágenes";
            Load += Form1_Load;
            gbUnidad.ResumeLayout(false);
            gbCarpetas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            gbImagenes.ResumeLayout(false);
            gbAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbUnidad;
        private ComboBox cbUnidad;
        private GroupBox gbCarpetas;
        private TreeView tvCarpetas;
        private PictureBox pbPreview;
        private Label lblInfo;
        private GroupBox gbImagenes;
        private ListView lvImagenes;
        private ColumnHeader colNombre;
        private ColumnHeader colTamano;
        private GroupBox gbAcciones;
        private Button btnAcercaDe;
        private Button btnPortapapeles;
        private Button btnFlip;
        private Button btnAjustar;
        private Button btnGuardar;
        private Button btnSalir;
        private ImageList imgListCarpetas;
        private ImageList imgListImagenes;
    }
}
