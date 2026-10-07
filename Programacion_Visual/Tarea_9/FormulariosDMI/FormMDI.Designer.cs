namespace FormulariosDMI;

partial class FormMDI
{
    private System.ComponentModel.IContainer components = null;

    private MenuStrip menuStrip;
    private ToolStripMenuItem archivoMenu;
    private ToolStripMenuItem nuevoItem;
    private ToolStripMenuItem abrirItem;
    private ToolStripMenuItem guardarItem;
    private ToolStripMenuItem guardarComoItem;
    private ToolStripMenuItem cerrarItem;
    private ToolStripSeparator sepArchivo;
    private ToolStripMenuItem salirItem;

    private ToolStripMenuItem edicionMenu;
    private ToolStripMenuItem deshacerItem;
    private ToolStripMenuItem rehacerItem;
    private ToolStripSeparator sepEdicion;
    private ToolStripMenuItem cortarItem;
    private ToolStripMenuItem copiarItem;
    private ToolStripMenuItem pegarItem;

    private ToolStripMenuItem ventanaMenu;
    private ToolStripMenuItem cascadaItem;
    private ToolStripMenuItem mosaicoHItem;
    private ToolStripMenuItem mosaicoVItem;
    private ToolStripMenuItem organizarIconosItem;

    private ToolStripMenuItem ayudaMenu;
    private ToolStripMenuItem acercaDeItem;

    private ToolStrip toolStrip;
    private ToolStripButton btnNuevo;
    private ToolStripButton btnAbrir;
    private ToolStripButton btnGuardar;
    private ToolStripSeparator toolSep1;
    private ToolStripButton btnCortar;
    private ToolStripButton btnCopiar;
    private ToolStripButton btnPegar;
    private ToolStripSeparator toolSep2;
    private ToolStripButton btnNegrita;
    private ToolStripButton btnCursiva;
    private ToolStripButton btnSubrayado;
    private ToolStripSeparator toolSep3;
    private ToolStripButton btnIzq;
    private ToolStripButton btnCentro;
    private ToolStripButton btnDer;

    private StatusStrip statusStrip;
    private ToolStripStatusLabel lblEstado;
    private ToolStripStatusLabel lblActivo;

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
        menuStrip = new MenuStrip();
        archivoMenu = new ToolStripMenuItem();
        nuevoItem = new ToolStripMenuItem();
        abrirItem = new ToolStripMenuItem();
        guardarItem = new ToolStripMenuItem();
        guardarComoItem = new ToolStripMenuItem();
        cerrarItem = new ToolStripMenuItem();
        sepArchivo = new ToolStripSeparator();
        salirItem = new ToolStripMenuItem();
        edicionMenu = new ToolStripMenuItem();
        deshacerItem = new ToolStripMenuItem();
        rehacerItem = new ToolStripMenuItem();
        sepEdicion = new ToolStripSeparator();
        cortarItem = new ToolStripMenuItem();
        copiarItem = new ToolStripMenuItem();
        pegarItem = new ToolStripMenuItem();
        ventanaMenu = new ToolStripMenuItem();
        cascadaItem = new ToolStripMenuItem();
        mosaicoHItem = new ToolStripMenuItem();
        mosaicoVItem = new ToolStripMenuItem();
        organizarIconosItem = new ToolStripMenuItem();
        ayudaMenu = new ToolStripMenuItem();
        acercaDeItem = new ToolStripMenuItem();
        toolStrip = new ToolStrip();
        btnNuevo = new ToolStripButton();
        btnAbrir = new ToolStripButton();
        btnGuardar = new ToolStripButton();
        toolSep1 = new ToolStripSeparator();
        btnCortar = new ToolStripButton();
        btnCopiar = new ToolStripButton();
        btnPegar = new ToolStripButton();
        toolSep2 = new ToolStripSeparator();
        btnNegrita = new ToolStripButton();
        btnCursiva = new ToolStripButton();
        btnSubrayado = new ToolStripButton();
        toolSep3 = new ToolStripSeparator();
        btnIzq = new ToolStripButton();
        btnCentro = new ToolStripButton();
        btnDer = new ToolStripButton();
        statusStrip = new StatusStrip();
        lblEstado = new ToolStripStatusLabel();
        lblActivo = new ToolStripStatusLabel();
        menuStrip.SuspendLayout();
        toolStrip.SuspendLayout();
        statusStrip.SuspendLayout();
        SuspendLayout();
        //
        // menuStrip
        //
        menuStrip.Items.AddRange(new ToolStripItem[] { archivoMenu, edicionMenu, ventanaMenu, ayudaMenu });
        menuStrip.Location = new Point(0, 0);
        menuStrip.MdiWindowListItem = ventanaMenu;
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new Size(900, 24);
        menuStrip.TabIndex = 0;
        //
        // archivoMenu
        //
        archivoMenu.DropDownItems.AddRange(new ToolStripItem[] { nuevoItem, abrirItem, guardarItem, guardarComoItem, cerrarItem, sepArchivo, salirItem });
        archivoMenu.Name = "archivoMenu";
        archivoMenu.Size = new Size(60, 20);
        archivoMenu.Text = "&Archivo";
        //
        // nuevoItem
        //
        nuevoItem.Name = "nuevoItem";
        nuevoItem.ShortcutKeys = Keys.Control | Keys.N;
        nuevoItem.Size = new Size(180, 22);
        nuevoItem.Text = "&Nuevo";
        nuevoItem.Click += NuevoItem_Click;
        //
        // abrirItem
        //
        abrirItem.Name = "abrirItem";
        abrirItem.ShortcutKeys = Keys.Control | Keys.O;
        abrirItem.Size = new Size(180, 22);
        abrirItem.Text = "&Abrir...";
        abrirItem.Click += AbrirItem_Click;
        //
        // guardarItem
        //
        guardarItem.Name = "guardarItem";
        guardarItem.ShortcutKeys = Keys.Control | Keys.S;
        guardarItem.Size = new Size(180, 22);
        guardarItem.Text = "&Guardar";
        guardarItem.Click += GuardarItem_Click;
        //
        // guardarComoItem
        //
        guardarComoItem.Name = "guardarComoItem";
        guardarComoItem.Size = new Size(180, 22);
        guardarComoItem.Text = "Guardar &como...";
        guardarComoItem.Click += GuardarComoItem_Click;
        //
        // cerrarItem
        //
        cerrarItem.Name = "cerrarItem";
        cerrarItem.Size = new Size(180, 22);
        cerrarItem.Text = "&Cerrar";
        cerrarItem.Click += CerrarItem_Click;
        //
        // sepArchivo
        //
        sepArchivo.Name = "sepArchivo";
        sepArchivo.Size = new Size(177, 6);
        //
        // salirItem
        //
        salirItem.Name = "salirItem";
        salirItem.ShortcutKeys = Keys.Alt | Keys.F4;
        salirItem.Size = new Size(180, 22);
        salirItem.Text = "&Salir";
        salirItem.Click += SalirItem_Click;
        //
        // edicionMenu
        //
        edicionMenu.DropDownItems.AddRange(new ToolStripItem[] { deshacerItem, rehacerItem, sepEdicion, cortarItem, copiarItem, pegarItem });
        edicionMenu.Name = "edicionMenu";
        edicionMenu.Size = new Size(58, 20);
        edicionMenu.Text = "&Edición";
        //
        // deshacerItem
        //
        deshacerItem.Name = "deshacerItem";
        deshacerItem.ShortcutKeys = Keys.Control | Keys.Z;
        deshacerItem.Size = new Size(180, 22);
        deshacerItem.Text = "&Deshacer";
        deshacerItem.Click += DeshacerItem_Click;
        //
        // rehacerItem
        //
        rehacerItem.Name = "rehacerItem";
        rehacerItem.ShortcutKeys = Keys.Control | Keys.Y;
        rehacerItem.Size = new Size(180, 22);
        rehacerItem.Text = "&Rehacer";
        rehacerItem.Click += RehacerItem_Click;
        //
        // sepEdicion
        //
        sepEdicion.Name = "sepEdicion";
        sepEdicion.Size = new Size(177, 6);
        //
        // cortarItem
        //
        cortarItem.Name = "cortarItem";
        cortarItem.ShortcutKeys = Keys.Control | Keys.X;
        cortarItem.Size = new Size(180, 22);
        cortarItem.Text = "Cor&tar";
        cortarItem.Click += CortarItem_Click;
        //
        // copiarItem
        //
        copiarItem.Name = "copiarItem";
        copiarItem.ShortcutKeys = Keys.Control | Keys.C;
        copiarItem.Size = new Size(180, 22);
        copiarItem.Text = "&Copiar";
        copiarItem.Click += CopiarItem_Click;
        //
        // pegarItem
        //
        pegarItem.Name = "pegarItem";
        pegarItem.ShortcutKeys = Keys.Control | Keys.V;
        pegarItem.Size = new Size(180, 22);
        pegarItem.Text = "&Pegar";
        pegarItem.Click += PegarItem_Click;
        //
        // ventanaMenu
        //
        ventanaMenu.DropDownItems.AddRange(new ToolStripItem[] { cascadaItem, mosaicoHItem, mosaicoVItem, organizarIconosItem });
        ventanaMenu.Name = "ventanaMenu";
        ventanaMenu.Size = new Size(62, 20);
        ventanaMenu.Text = "&Ventana";
        //
        // cascadaItem
        //
        cascadaItem.Name = "cascadaItem";
        cascadaItem.Size = new Size(180, 22);
        cascadaItem.Text = "&Cascada";
        cascadaItem.Click += CascadaItem_Click;
        //
        // mosaicoHItem
        //
        mosaicoHItem.Name = "mosaicoHItem";
        mosaicoHItem.Size = new Size(180, 22);
        mosaicoHItem.Text = "Mosaico &horizontal";
        mosaicoHItem.Click += MosaicoHItem_Click;
        //
        // mosaicoVItem
        //
        mosaicoVItem.Name = "mosaicoVItem";
        mosaicoVItem.Size = new Size(180, 22);
        mosaicoVItem.Text = "Mosaico &vertical";
        mosaicoVItem.Click += MosaicoVItem_Click;
        //
        // organizarIconosItem
        //
        organizarIconosItem.Name = "organizarIconosItem";
        organizarIconosItem.Size = new Size(180, 22);
        organizarIconosItem.Text = "&Organizar iconos";
        organizarIconosItem.Click += OrganizarIconosItem_Click;
        //
        // ayudaMenu
        //
        ayudaMenu.DropDownItems.AddRange(new ToolStripItem[] { acercaDeItem });
        ayudaMenu.Name = "ayudaMenu";
        ayudaMenu.Size = new Size(53, 20);
        ayudaMenu.Text = "A&yuda";
        //
        // acercaDeItem
        //
        acercaDeItem.Name = "acercaDeItem";
        acercaDeItem.Size = new Size(180, 22);
        acercaDeItem.Text = "&Acerca de...";
        acercaDeItem.Click += AcercaDeItem_Click;
        //
        // toolStrip
        //
        toolStrip.Items.AddRange(new ToolStripItem[] { btnNuevo, btnAbrir, btnGuardar, toolSep1, btnCortar, btnCopiar, btnPegar, toolSep2, btnNegrita, btnCursiva, btnSubrayado, toolSep3, btnIzq, btnCentro, btnDer });
        toolStrip.Location = new Point(0, 24);
        toolStrip.Name = "toolStrip";
        toolStrip.Size = new Size(900, 25);
        toolStrip.TabIndex = 1;
        //
        // btnNuevo
        //
        btnNuevo.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += NuevoItem_Click;
        //
        // btnAbrir
        //
        btnAbrir.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnAbrir.Name = "btnAbrir";
        btnAbrir.Text = "Abrir";
        btnAbrir.Click += AbrirItem_Click;
        //
        // btnGuardar
        //
        btnGuardar.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += GuardarItem_Click;
        //
        // toolSep1
        //
        toolSep1.Name = "toolSep1";
        //
        // btnCortar
        //
        btnCortar.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnCortar.Name = "btnCortar";
        btnCortar.Text = "Cortar";
        btnCortar.Click += CortarItem_Click;
        //
        // btnCopiar
        //
        btnCopiar.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnCopiar.Name = "btnCopiar";
        btnCopiar.Text = "Copiar";
        btnCopiar.Click += CopiarItem_Click;
        //
        // btnPegar
        //
        btnPegar.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnPegar.Name = "btnPegar";
        btnPegar.Text = "Pegar";
        btnPegar.Click += PegarItem_Click;
        //
        // toolSep2
        //
        toolSep2.Name = "toolSep2";
        //
        // btnNegrita
        //
        btnNegrita.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnNegrita.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnNegrita.Name = "btnNegrita";
        btnNegrita.Text = "N";
        btnNegrita.ToolTipText = "Negrita";
        btnNegrita.Click += Negrita_Click;
        //
        // btnCursiva
        //
        btnCursiva.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnCursiva.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
        btnCursiva.Name = "btnCursiva";
        btnCursiva.Text = "K";
        btnCursiva.ToolTipText = "Cursiva";
        btnCursiva.Click += Cursiva_Click;
        //
        // btnSubrayado
        //
        btnSubrayado.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnSubrayado.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
        btnSubrayado.Name = "btnSubrayado";
        btnSubrayado.Text = "S";
        btnSubrayado.ToolTipText = "Subrayado";
        btnSubrayado.Click += Subrayado_Click;
        //
        // toolSep3
        //
        toolSep3.Name = "toolSep3";
        //
        // btnIzq
        //
        btnIzq.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnIzq.Name = "btnIzq";
        btnIzq.Text = "Izq";
        btnIzq.ToolTipText = "Alinear izquierda";
        btnIzq.Click += AlinearIzq_Click;
        //
        // btnCentro
        //
        btnCentro.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnCentro.Name = "btnCentro";
        btnCentro.Text = "Cen";
        btnCentro.ToolTipText = "Centrar";
        btnCentro.Click += Centrar_Click;
        //
        // btnDer
        //
        btnDer.DisplayStyle = ToolStripItemDisplayStyle.Text;
        btnDer.Name = "btnDer";
        btnDer.Text = "Der";
        btnDer.ToolTipText = "Alinear derecha";
        btnDer.Click += AlinearDer_Click;
        //
        // statusStrip
        //
        statusStrip.Items.AddRange(new ToolStripItem[] { lblEstado, lblActivo });
        statusStrip.Location = new Point(0, 528);
        statusStrip.Name = "statusStrip";
        statusStrip.Size = new Size(900, 22);
        statusStrip.TabIndex = 2;
        //
        // lblEstado
        //
        lblEstado.Name = "lblEstado";
        lblEstado.Size = new Size(118, 17);
        lblEstado.Text = "Sin documentos";
        //
        // lblActivo
        //
        lblActivo.Name = "lblActivo";
        lblActivo.Size = new Size(767, 17);
        lblActivo.Spring = true;
        lblActivo.TextAlign = ContentAlignment.MiddleRight;
        //
        // FormMDI
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(900, 550);
        Controls.Add(statusStrip);
        Controls.Add(toolStrip);
        Controls.Add(menuStrip);
        IsMdiContainer = true;
        MainMenuStrip = menuStrip;
        Name = "FormMDI";
        Text = "Editor de documentos MDI";
        WindowState = FormWindowState.Maximized;
        MdiChildActivate += FormMDI_MdiChildActivate;
        FormClosing += FormMDI_FormClosing;
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        toolStrip.ResumeLayout(false);
        toolStrip.PerformLayout();
        statusStrip.ResumeLayout(false);
        statusStrip.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
}
