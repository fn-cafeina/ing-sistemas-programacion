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
            gbBuscar = new GroupBox();
            cbRuta = new ComboBox();
            lbArchivos = new ListBox();
            gbElegir = new GroupBox();
            lbImagenes = new ListBox();
            pbPreview = new PictureBox();
            gbEditar = new GroupBox();
            btnPortapapeles = new Button();
            btnAjustar = new Button();
            btnFlip = new Button();
            btnGuardar = new Button();
            btnAcercaDe = new Button();
            btnSalir = new Button();
            gbBuscar.SuspendLayout();
            gbElegir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            gbEditar.SuspendLayout();
            SuspendLayout();
            // 
            // gbBuscar
            // 
            gbBuscar.Controls.Add(cbRuta);
            gbBuscar.Controls.Add(lbArchivos);
            gbBuscar.Location = new Point(16, 16);
            gbBuscar.Name = "gbBuscar";
            gbBuscar.Padding = new Padding(12, 8, 12, 12);
            gbBuscar.Size = new Size(260, 190);
            gbBuscar.TabIndex = 0;
            gbBuscar.TabStop = false;
            gbBuscar.Text = "Buscar imágenes";
            // 
            // cbRuta
            // 
            cbRuta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbRuta.FormattingEnabled = true;
            cbRuta.Location = new Point(14, 32);
            cbRuta.Name = "cbRuta";
            cbRuta.Size = new Size(232, 28);
            cbRuta.TabIndex = 0;
            cbRuta.KeyDown += CbRuta_KeyDown;
            cbRuta.SelectedIndexChanged += CbRuta_SelectedIndexChanged;
            // 
            // lbArchivos
            // 
            lbArchivos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            lbArchivos.FormattingEnabled = true;
            lbArchivos.ItemHeight = 20;
            lbArchivos.Location = new Point(14, 68);
            lbArchivos.Name = "lbArchivos";
            lbArchivos.Size = new Size(232, 104);
            lbArchivos.TabIndex = 1;
            lbArchivos.DoubleClick += LbArchivos_DoubleClick;
            // 
            // gbElegir
            // 
            gbElegir.Controls.Add(lbImagenes);
            gbElegir.Location = new Point(16, 216);
            gbElegir.Name = "gbElegir";
            gbElegir.Padding = new Padding(12, 8, 12, 12);
            gbElegir.Size = new Size(260, 208);
            gbElegir.TabIndex = 1;
            gbElegir.TabStop = false;
            gbElegir.Text = "Elegir una imagen";
            // 
            // lbImagenes
            // 
            lbImagenes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            lbImagenes.FormattingEnabled = true;
            lbImagenes.ItemHeight = 20;
            lbImagenes.Location = new Point(14, 32);
            lbImagenes.Name = "lbImagenes";
            lbImagenes.Size = new Size(232, 164);
            lbImagenes.TabIndex = 0;
            lbImagenes.SelectedIndexChanged += LbImagenes_SelectedIndexChanged;
            // 
            // pbPreview
            // 
            pbPreview.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pbPreview.BorderStyle = BorderStyle.FixedSingle;
            pbPreview.Location = new Point(292, 16);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(532, 310);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbPreview.TabIndex = 2;
            pbPreview.TabStop = false;
            // 
            // gbEditar
            // 
            gbEditar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbEditar.Controls.Add(btnPortapapeles);
            gbEditar.Controls.Add(btnAjustar);
            gbEditar.Controls.Add(btnFlip);
            gbEditar.Controls.Add(btnGuardar);
            gbEditar.Location = new Point(292, 338);
            gbEditar.Name = "gbEditar";
            gbEditar.Padding = new Padding(12, 8, 12, 12);
            gbEditar.Size = new Size(532, 96);
            gbEditar.TabIndex = 3;
            gbEditar.TabStop = false;
            gbEditar.Text = "Editar imagen";
            // 
            // btnPortapapeles
            // 
            btnPortapapeles.Location = new Point(20, 30);
            btnPortapapeles.Name = "btnPortapapeles";
            btnPortapapeles.Size = new Size(120, 28);
            btnPortapapeles.TabIndex = 0;
            btnPortapapeles.Text = "Portapapeles";
            btnPortapapeles.UseVisualStyleBackColor = true;
            btnPortapapeles.Click += BtnPortapapeles_Click;
            // 
            // btnAjustar
            // 
            btnAjustar.Location = new Point(152, 30);
            btnAjustar.Name = "btnAjustar";
            btnAjustar.Size = new Size(120, 28);
            btnAjustar.TabIndex = 1;
            btnAjustar.Text = "Ajustar/Real";
            btnAjustar.UseVisualStyleBackColor = true;
            btnAjustar.Click += BtnAjustar_Click;
            // 
            // btnFlip
            // 
            btnFlip.Location = new Point(20, 62);
            btnFlip.Name = "btnFlip";
            btnFlip.Size = new Size(120, 28);
            btnFlip.TabIndex = 2;
            btnFlip.Text = "Flip horizontal";
            btnFlip.UseVisualStyleBackColor = true;
            btnFlip.Click += BtnFlip_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(152, 62);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 28);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar como...";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnAcercaDe
            // 
            btnAcercaDe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAcercaDe.Location = new Point(16, 452);
            btnAcercaDe.Name = "btnAcercaDe";
            btnAcercaDe.Size = new Size(130, 36);
            btnAcercaDe.TabIndex = 4;
            btnAcercaDe.Text = "Acerca de...";
            btnAcercaDe.UseVisualStyleBackColor = true;
            btnAcercaDe.Click += BtnAcercaDe_Click;
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(704, 452);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(120, 36);
            btnSalir.TabIndex = 5;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += BtnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 500);
            Controls.Add(gbBuscar);
            Controls.Add(gbElegir);
            Controls.Add(pbPreview);
            Controls.Add(gbEditar);
            Controls.Add(btnAcercaDe);
            Controls.Add(btnSalir);
            MinimumSize = new Size(760, 480);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Explorador de Imágenes";
            gbBuscar.ResumeLayout(false);
            gbElegir.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            gbEditar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbBuscar;
        private ComboBox cbRuta;
        private ListBox lbArchivos;
        private GroupBox gbElegir;
        private ListBox lbImagenes;
        private PictureBox pbPreview;
        private GroupBox gbEditar;
        private Button btnPortapapeles;
        private Button btnAjustar;
        private Button btnFlip;
        private Button btnGuardar;
        private Button btnAcercaDe;
        private Button btnSalir;
    }
}
