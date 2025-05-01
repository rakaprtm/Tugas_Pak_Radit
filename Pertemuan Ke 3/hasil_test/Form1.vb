Public Class Form1
    Private lblTatapMuka As Label
    Private lblMidTest As Label
    Private lblFinalTest As Label
    Private txtTatapMuka As TextBox
    Private txtMidTest As TextBox
    Private txtFinalTest As TextBox
    Private btnTampil As Button

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Form Nilai"
        Me.Size = New Size(400, 300)

        lblTatapMuka = New Label()
        lblTatapMuka.Text = "TATAP MUKA:"
        lblTatapMuka.Location = New Point(30, 30)
        lblTatapMuka.AutoSize = True
        Me.Controls.Add(lblTatapMuka)

        txtTatapMuka = New TextBox()
        txtTatapMuka.Location = New Point(150, 25)
        txtTatapMuka.Width = 200
        Me.Controls.Add(txtTatapMuka)

        lblMidTest = New Label()
        lblMidTest.Text = "MID TEST:"
        lblMidTest.Location = New Point(30, 70)
        lblMidTest.AutoSize = True
        Me.Controls.Add(lblMidTest)

        txtMidTest = New TextBox()
        txtMidTest.Location = New Point(150, 65)
        txtMidTest.Width = 200
        Me.Controls.Add(txtMidTest)

        lblFinalTest = New Label()
        lblFinalTest.Text = "FiNAL TEST:"
        lblFinalTest.Location = New Point(30, 110)
        lblFinalTest.AutoSize = True
        Me.Controls.Add(lblFinalTest)

        txtFinalTest = New TextBox()
        txtFinalTest.Location = New Point(150, 105)
        txtFinalTest.Width = 200
        Me.Controls.Add(txtFinalTest)

        btnTampil = New Button()
        btnTampil.Text = "TAMPILKAN"
        btnTampil.Location = New Point(150, 150)
        AddHandler btnTampil.Click, AddressOf btnTampil_Click
        Me.Controls.Add(btnTampil)
    End Sub

    Private Sub btnTampil_Click(sender As Object, e As EventArgs)
        Dim tatapMuka, midTest, finalTest As Integer

        Try
            tatapMuka = CInt(txtTatapMuka.Text)
            midTest = CInt(txtMidTest.Text)
            finalTest = CInt(txtFinalTest.Text)

            Dim rataRata As Double = (tatapMuka + midTest + finalTest) / 3

            Dim keterangan As String = If(rataRata >= 60, "LULUS!", "TIDAK LULUS.")

            Dim hasil As String = "NILAI AKHIR" & vbCrLf &
                                  "TATAP MUKA : " & tatapMuka & vbCrLf &
                                  "MID TEST   : " & midTest & vbCrLf &
                                  "FINAL TEST : " & finalTest & vbCrLf &
                                  "RATA RATA  : " & rataRata.ToString("F2") & vbCrLf & vbCrLf &
                                  keterangan

            MessageBox.Show(hasil, "Nilai Akhir")

        Catch ex As Exception
            MessageBox.Show("Pastikan semua input diisi dengan angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
