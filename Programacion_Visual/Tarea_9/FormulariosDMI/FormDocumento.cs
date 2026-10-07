using FormulariosDMI.Helpers;

namespace FormulariosDMI;

/// <summary>
/// Formulario hijo: encapsula un documento de texto.
/// El padre (FormMDI) solo usa su API pública, nunca toca rtbText directamente.
/// </summary>
public partial class FormDocumento : Form
{
    public string? RutaArchivo { get; private set; }
    public bool Modificado { get; private set; }
    public bool EsNuevo => string.IsNullOrEmpty(RutaArchivo);

    /// <summary>Acceso de solo lectura al editor (para el helper de formato).</summary>
    public RichTextBox Editor => rtbText;

    private string _tituloBase = "Documento";
    private bool _suprimirModificado; // evita marcar como modificado al cargar/guardar

    public FormDocumento()
    {
        InitializeComponent();
    }

    // ---------- Nivel 1: creación ----------

    public void CrearNuevo(string titulo)
    {
        _tituloBase = titulo;
        RutaArchivo = null;
        rtbText.Clear();
        MarcarLimpio();
    }

    // ---------- Nivel 2: archivos ----------

    public bool Abrir(string ruta)
    {
        try
        {
            if (Path.GetExtension(ruta).Equals(".rtf", StringComparison.OrdinalIgnoreCase))
                rtbText.LoadFile(ruta, RichTextBoxStreamType.RichText);
            else
                rtbText.LoadFile(ruta, RichTextBoxStreamType.PlainText);

            RutaArchivo = ruta;
            _tituloBase = Path.GetFileName(ruta);
            MarcarLimpio();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo abrir el archivo.\n{ex.Message}",
                "Abrir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    public bool Guardar()
    {
        if (EsNuevo)
            return GuardarComo();

        return GuardarEn(RutaArchivo!);
    }

    public bool GuardarComo()
    {
        using var dlg = new SaveFileDialog
        {
            Filter = "Archivos de texto (*.txt)|*.txt|Archivos RTF (*.rtf)|*.rtf|Todos los archivos (*.*)|*.*",
            DefaultExt = "txt",
            AddExtension = true,
            FileName = EsNuevo ? _tituloBase : Path.GetFileName(RutaArchivo)
        };

        if (dlg.ShowDialog(this) != DialogResult.OK)
            return false; // usuario canceló

        return GuardarEn(dlg.FileName);
    }

    private bool GuardarEn(string ruta)
    {
        try
        {
            if (Path.GetExtension(ruta).Equals(".rtf", StringComparison.OrdinalIgnoreCase))
                rtbText.SaveFile(ruta, RichTextBoxStreamType.RichText);
            else
                rtbText.SaveFile(ruta, RichTextBoxStreamType.PlainText);

            RutaArchivo = ruta;
            _tituloBase = Path.GetFileName(ruta);
            MarcarLimpio();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo guardar el archivo.\n{ex.Message}",
                "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    // ---------- Nivel 3: edición ----------

    public void Deshacer() => rtbText.Undo();
    public void Rehacer() => rtbText.Redo();
    public void Cortar() => rtbText.Cut();
    public void Copiar() => rtbText.Copy();
    public void Pegar() => rtbText.Paste();

    public bool PuedeDeshacer => rtbText.CanUndo;
    public bool PuedeRehacer => rtbText.CanRedo;

    // ---------- Reto adicional: formato (delega al Helper) ----------

    public void AlternarNegrita() => FormatoHelper.AlternarNegrita(rtbText);
    public void AlternarCursiva() => FormatoHelper.AlternarCursiva(rtbText);
    public void AlternarSubrayado() => FormatoHelper.AlternarSubrayado(rtbText);
    public void AlinearIzquierda() => FormatoHelper.Alinear(rtbText, HorizontalAlignment.Left);
    public void Centrar() => FormatoHelper.Alinear(rtbText, HorizontalAlignment.Center);
    public void AlinearDerecha() => FormatoHelper.Alinear(rtbText, HorizontalAlignment.Right);

    // ---------- Nivel 4: control de modificaciones ----------

    private void MarcarLimpio()
    {
        _suprimirModificado = true;
        try
        {
            Modificado = false;
            Text = _tituloBase;
        }
        finally
        {
            _suprimirModificado = false;
        }
    }

    private void MarcarModificado()
    {
        if (Modificado) return;
        Modificado = true;
        if (!Text.EndsWith(" *"))
            Text = $"{_tituloBase} *";
    }

    private void rtbText_TextChanged(object? sender, EventArgs e)
    {
        if (_suprimirModificado) return;
        // Sincroniza el título base si aún es documento nuevo sin guardar
        MarcarModificado();
    }

    private void FormDocumento_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!Modificado) return;

        var r = MessageBox.Show(
            $"¿Desea guardar los cambios en \"{_tituloBase}\"?",
            "Cerrar documento",
            MessageBoxButtons.YesNoCancel,
            MessageBoxIcon.Question);

        if (r == DialogResult.Cancel)
        {
            e.Cancel = true;
        }
        else if (r == DialogResult.Yes)
        {
            if (!Guardar())
                e.Cancel = true; // si canceló el Guardar como, no cerrar
        }
        // No -> cerrar sin guardar
    }
}
