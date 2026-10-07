namespace FormulariosDMI;

partial class FormDocumento
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    internal RichTextBox rtbText;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        rtbText = new RichTextBox();
        SuspendLayout();
        //
        // rtbText
        //
        rtbText.AcceptsTab = true;
        rtbText.Dock = DockStyle.Fill;
        rtbText.HideSelection = false;
        rtbText.Location = new Point(0, 0);
        rtbText.Name = "rtbText";
        rtbText.Size = new Size(600, 400);
        rtbText.TabIndex = 0;
        rtbText.Text = "";
        rtbText.TextChanged += rtbText_TextChanged;
        //
        // FormDocumento
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(600, 400);
        Controls.Add(rtbText);
        Name = "FormDocumento";
        Text = "Documento";
        FormClosing += FormDocumento_FormClosing;
        ResumeLayout(false);
    }

    #endregion
}
