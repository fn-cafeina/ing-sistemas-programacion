namespace FormulariosDMI;

/// <summary>
/// Formulario padre MDI: contiene y administra los documentos.
/// No manipula el RichTextBox directamente, delega al hijo activo.
/// </summary>
public partial class FormMDI : Form
{
    private int _contadorDocumentos;

    public FormMDI()
    {
        InitializeComponent();
        ActualizarEstado();
    }

    private FormDocumento? HijoActivo => ActiveMdiChild as FormDocumento;

    // ---------- Nivel 1: MDI básico ----------

    private void NuevoDocumento()
    {
        var hijo = new FormDocumento();
        _contadorDocumentos++;
        hijo.CrearNuevo($"Documento {_contadorDocumentos}");
        hijo.MdiParent = this;
        hijo.Show();
    }

    // ---------- Nivel 2: archivos ----------

    private void AbrirDocumento()
    {
        using var dlg = new OpenFileDialog
        {
            Filter = "Archivos de texto (*.txt)|*.txt|Archivos RTF (*.rtf)|*.rtf|Todos los archivos (*.*)|*.*",
            Multiselect = false
        };

        if (dlg.ShowDialog(this) != DialogResult.OK)
            return;

        var hijo = new FormDocumento();
        if (!hijo.Abrir(dlg.FileName))
            return; // error ya mostrado por el hijo

        _contadorDocumentos++;
        hijo.MdiParent = this;
        hijo.Show();
    }

    private void GuardarActual()
    {
        var hijo = HijoActivo;
        if (hijo == null)
        {
            MessageBox.Show("No hay ningún documento abierto.", "Guardar",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        hijo.Guardar();
    }

    private void GuardarComoActual()
    {
        var hijo = HijoActivo;
        if (hijo == null)
        {
            MessageBox.Show("No hay ningún documento abierto.", "Guardar como",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        hijo.GuardarComo();
    }

    // ---------- Nivel 4: administración ----------

    private void CerrarActual() => HijoActivo?.Close();

    private void Salir() => Close();

    private void FormMDI_FormClosing(object? sender, FormClosingEventArgs e)
    {
        // Cada hijo pregunta por sus cambios en su propio FormClosing.
        // Si alguno cancela, se cancela el cierre de la aplicación.
        foreach (Form hijo in MdiChildren)
        {
            hijo.Close();
            if (!hijo.IsDisposed)
            {
                e.Cancel = true;
                return;
            }
        }
    }

    // ---------- Handlers Archivo ----------

    private void NuevoItem_Click(object? sender, EventArgs e) => NuevoDocumento();
    private void AbrirItem_Click(object? sender, EventArgs e) => AbrirDocumento();
    private void GuardarItem_Click(object? sender, EventArgs e) => GuardarActual();
    private void GuardarComoItem_Click(object? sender, EventArgs e) => GuardarComoActual();
    private void CerrarItem_Click(object? sender, EventArgs e) => CerrarActual();
    private void SalirItem_Click(object? sender, EventArgs e) => Salir();

    // ---------- Nivel 3: edición ----------

    private void DeshacerItem_Click(object? sender, EventArgs e) => HijoActivo?.Deshacer();
    private void RehacerItem_Click(object? sender, EventArgs e) => HijoActivo?.Rehacer();
    private void CortarItem_Click(object? sender, EventArgs e) => HijoActivo?.Cortar();
    private void CopiarItem_Click(object? sender, EventArgs e) => HijoActivo?.Copiar();
    private void PegarItem_Click(object? sender, EventArgs e) => HijoActivo?.Pegar();

    // ---------- Nivel 5: organización (literal al documento) ----------

    private void NormalizarHijos()
    {
        // Si un hijo está maximizado/minimizado, LayoutMdi no se aprecia.
        foreach (Form f in MdiChildren)
            f.WindowState = FormWindowState.Normal;
    }

    private void CascadaItem_Click(object? sender, EventArgs e)
    {
        if (MdiChildren.Length == 0) return;
        NormalizarHijos();
        LayoutMdi(MdiLayout.Cascade);
    }

    private void MosaicoHItem_Click(object? sender, EventArgs e)
    {
        if (MdiChildren.Length == 0) return;
        NormalizarHijos();
        LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void MosaicoVItem_Click(object? sender, EventArgs e)
    {
        if (MdiChildren.Length == 0) return;
        NormalizarHijos();
        LayoutMdi(MdiLayout.TileVertical);
    }

    private void OrganizarIconosItem_Click(object? sender, EventArgs e)
    {
        if (MdiChildren.Length == 0) return;
        // ArrangeIcons solo ordena hijos minimizados. Sin minimizados no hace nada (correcto).
        LayoutMdi(MdiLayout.ArrangeIcons);
    }

    // ---------- Ayuda ----------

    private void AcercaDeItem_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "Editor de documentos MDI\n\nAplicación Windows Forms para crear y administrar documentos de texto.\n\nNiveles: MDI básico, archivos, edición, administración y organización.",
            "Acerca de",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    // ---------- Reto adicional: formato ----------

    private void Negrita_Click(object? sender, EventArgs e) => HijoActivo?.AlternarNegrita();
    private void Cursiva_Click(object? sender, EventArgs e) => HijoActivo?.AlternarCursiva();
    private void Subrayado_Click(object? sender, EventArgs e) => HijoActivo?.AlternarSubrayado();
    private void AlinearIzq_Click(object? sender, EventArgs e) => HijoActivo?.AlinearIzquierda();
    private void Centrar_Click(object? sender, EventArgs e) => HijoActivo?.Centrar();
    private void AlinearDer_Click(object? sender, EventArgs e) => HijoActivo?.AlinearDerecha();

    // ---------- Estado de menús / barra ----------

    private void FormMDI_MdiChildActivate(object? sender, EventArgs e) => ActualizarEstado();

    private void ActualizarEstado()
    {
        bool hayHijo = HijoActivo != null;

        guardarItem.Enabled = hayHijo;
        guardarComoItem.Enabled = hayHijo;
        cerrarItem.Enabled = hayHijo;

        deshacerItem.Enabled = hayHijo;
        rehacerItem.Enabled = hayHijo;
        cortarItem.Enabled = hayHijo;
        copiarItem.Enabled = hayHijo;
        pegarItem.Enabled = hayHijo;

        cascadaItem.Enabled = hayHijo;
        mosaicoHItem.Enabled = hayHijo;
        mosaicoVItem.Enabled = hayHijo;
        organizarIconosItem.Enabled = hayHijo;

        btnGuardar.Enabled = hayHijo;
        btnCortar.Enabled = hayHijo;
        btnCopiar.Enabled = hayHijo;
        btnPegar.Enabled = hayHijo;
        btnNegrita.Enabled = hayHijo;
        btnCursiva.Enabled = hayHijo;
        btnSubrayado.Enabled = hayHijo;
        btnIzq.Enabled = hayHijo;
        btnCentro.Enabled = hayHijo;
        btnDer.Enabled = hayHijo;

        lblEstado.Text = MdiChildren.Length == 0
            ? "Sin documentos"
            : $"Documentos abiertos: {MdiChildren.Length}";
        lblActivo.Text = HijoActivo == null ? string.Empty : $"Activo: {HijoActivo.Text}";
    }
}
