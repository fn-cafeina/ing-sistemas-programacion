namespace FormulariosDMI.Helpers;

/// <summary>
/// Lógica de formato de texto reutilizable (reto adicional).
/// El hijo delega aquí para no duplicar código de fuentes.
/// </summary>
public static class FormatoHelper
{
    public static void AlternarNegrita(RichTextBox rtb) => AlternarEstilo(rtb, FontStyle.Bold);

    public static void AlternarCursiva(RichTextBox rtb) => AlternarEstilo(rtb, FontStyle.Italic);

    public static void AlternarSubrayado(RichTextBox rtb) => AlternarEstilo(rtb, FontStyle.Underline);

    public static void AlternarEstilo(RichTextBox rtb, FontStyle estilo)
    {
        if (rtb == null) return;

        // Si la selección tiene fuentes mixtas, SelectionFont es null -> usar fuente base.
        Font actual = rtb.SelectionFont ?? rtb.Font;
        FontStyle nuevoEstilo = actual.Style ^ estilo; // XOR: alterna el estilo

        rtb.SelectionFont = new Font(actual, nuevoEstilo);
    }

    public static void Alinear(RichTextBox rtb, HorizontalAlignment alineacion)
    {
        if (rtb == null) return;
        rtb.SelectionAlignment = alineacion;
    }
}
