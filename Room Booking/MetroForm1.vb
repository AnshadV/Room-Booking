Imports Syncfusion.WinForms.Controls

Public Class MetroForm1
    Inherits SfForm

    Public Sub New()
        InitializeComponent()

        Me.Style.TitleBar.Height = 26
        Me.Style.TitleBar.BackColor = Color.White
        Me.Style.TitleBar.IconBackColor = Color.FromArgb(15, 161, 212)
        Me.BackColor = Color.White
        Me.Style.TitleBar.ForeColor = ColorTranslator.FromHtml("#343434")
        Me.Style.TitleBar.CloseButtonForeColor = Color.DarkGray
        Me.Style.TitleBar.MaximizeButtonForeColor = Color.DarkGray
        Me.Style.TitleBar.MinimizeButtonForeColor = Color.DarkGray
        Me.Style.TitleBar.HelpButtonForeColor = Color.DarkGray
        Me.Style.TitleBar.IconHorizontalAlignment = HorizontalAlignment.Left
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
        Me.Style.TitleBar.Font = Me.Font
        Me.Style.TitleBar.TextHorizontalAlignment = HorizontalAlignment.Center
        Me.Style.TitleBar.TextVerticalAlignment = System.Windows.Forms.VisualStyles.VerticalAlignment.Center
    End Sub

End Class
