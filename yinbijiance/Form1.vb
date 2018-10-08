Imports HalconDotNet

Public Class Form1
    Dim bln_Click As Int16 = 0
   
    ' Local iconic variables 
    Dim ho_Th As HObject = Nothing, ho_GrayImage As HObject = Nothing
    Dim ho_Regions As HObject = Nothing, ho_ConnectedRegions As HObject = Nothing
    Dim ho_RegionClosing As HObject = Nothing, ho_RegionUnion1 As HObject = Nothing
    Dim ho_RegionFillUp1 As HObject = Nothing, ho_RegionBorder As HObject = Nothing
    Dim ho_Image As HObject = Nothing
    Dim ho_RegionUnion As HObject = Nothing, ho_RegionFillUp As HObject = Nothing
    Dim ho_RegionZoom As HObject = Nothing
    Dim ho_ImageZoom As HObject = Nothing

    ' Local control variables 
    Dim hv_Area As HTuple = New HTuple, hv_Row1 As HTuple = New HTuple
    Dim hv_Column1 As HTuple = New HTuple, hv_Width As HTuple = New HTuple
    Dim hv_Height As HTuple = New HTuple, hv_Row As HTuple = New HTuple
    Dim hv_Column As HTuple = New HTuple, hv_Radius As HTuple = New HTuple
    Dim hv_Diameter As HTuple = New HTuple
    Dim hv_AcqHandle As HTuple = New HTuple
    Dim hv_k As HTuple = New HTuple, hv_WindowHandle1 As HTuple = New HTuple
    ' Initialize local and output iconic variables 

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        bln_Click = 1

        Dim ImagePath As String
        OpenFileDialog1.Filter = "JPEG文件|*.jpg|BMP文件|*.bmp*"
        OpenFileDialog1.RestoreDirectory = True
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then

            ImagePath = OpenFileDialog1.FileName
            HOperatorSet.ReadImage(ho_Th, ImagePath)


            HOperatorSet.GetImageSize(ho_Th, hv_Width, hv_Height)
            Dim w As Double = hv_Width.TupleInt
            Dim h As Double = hv_Height.TupleInt
            If (hv_Width < 600 And hv_Height < 600) Then
                HWindowControl1.Width = hv_Width
                HWindowControl1.Height = hv_Height
            ElseIf (hv_Width > 600 Or hv_Height > 600) Then
                HWindowControl1.Width = 500
                HWindowControl1.Height = HWindowControl1.Width * (h / w)


            End If
        End If
        HOperatorSet.DispObj(ho_Th, HWindowControl1.HalconWindow)

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        If (bln_Click = 0) Then
            MessageBox.Show("未选择图片")

        ElseIf (bln_Click) Then
            HOperatorSet.Rgb1ToGray(ho_Th, ho_GrayImage)
            HOperatorSet.DispObj(ho_GrayImage, HWindowControl1.HalconWindow)
            HOperatorSet.Threshold(ho_GrayImage, ho_Regions, New HTuple(0), New HTuple(210))

            HOperatorSet.Connection(ho_Regions, ho_ConnectedRegions)

            HOperatorSet.Closing(ho_ConnectedRegions, ho_ConnectedRegions, ho_RegionClosing _
                )

            HOperatorSet.Union1(ho_RegionClosing, ho_RegionUnion1)

            HOperatorSet.FillUp(ho_RegionUnion1, ho_RegionFillUp1)

            HOperatorSet.DispObj(ho_RegionFillUp1, HWindowControl1.HalconWindow)

            HOperatorSet.AreaCenter(ho_RegionFillUp1, hv_Area, hv_Row1, hv_Column1)
            HOperatorSet.GetImageSize(ho_GrayImage, hv_Width, hv_Height)

            HOperatorSet.Boundary(ho_RegionFillUp1, ho_RegionBorder, New HTuple("inner"))
            HOperatorSet.SmallestCircle(ho_RegionBorder, hv_Row, hv_Column, hv_Radius)
            hv_Diameter = (New HTuple(2)).TupleMult(hv_Radius)
            HOperatorSet.SetPart(HWindowControl1.HalconWindow, New HTuple(0), New HTuple(0), hv_Height, _
          hv_Width)

            HOperatorSet.DispObj(ho_RegionBorder, HWindowControl1.HalconWindow)
            TextBox1.Text = hv_Diameter.ToString()

            ho_Th.Dispose()
            ho_GrayImage.Dispose()
            ho_Regions.Dispose()
            ho_ConnectedRegions.Dispose()
            ho_RegionClosing.Dispose()
            ho_RegionUnion1.Dispose()
            ho_RegionFillUp1.Dispose()
            ho_RegionBorder.Dispose()
            bln_Click = 0
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        bln_Click = 1
        HOperatorSet.CloseAllFramegrabbers()
        HOperatorSet.OpenFramegrabber(New HTuple("GigEVision"), New HTuple(0), New HTuple(0), _
            New HTuple(0), New HTuple(0), New HTuple(0), New HTuple(0), New HTuple("default"), _
            New HTuple(-1), New HTuple("default"), New HTuple(-1), New HTuple("false"), _
            New HTuple("default"), New HTuple("0030531fa30d_Basler_ACA130MGED"), New HTuple(0), _
            New HTuple(-1), hv_AcqHandle)


    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        HOperatorSet.GrabImageStart(hv_AcqHandle, New HTuple(-1))
        HOperatorSet.GrabImageAsync(ho_Image, hv_AcqHandle, New HTuple(-1))
        HOperatorSet.DispObj(ho_Image, HWindowControl1.HalconWindow)
        HOperatorSet.GrabImageStart(hv_AcqHandle, New HTuple(-1))

        HOperatorSet.GrabImageAsync(ho_Image, hv_AcqHandle, New HTuple(-1))
        'Image Acquisition 01: Do something

        HOperatorSet.Rgb1ToGray(ho_Image, ho_GrayImage)
        HOperatorSet.GetImageSize(ho_GrayImage, hv_Width, hv_Height)

        HOperatorSet.ZoomImageSize(ho_GrayImage, ho_ImageZoom, hv_Width, hv_Height, New HTuple("constant"))

        HOperatorSet.Threshold(ho_GrayImage, ho_Regions, New HTuple(15), New HTuple(153))

        HOperatorSet.Connection(ho_Regions, ho_ConnectedRegions)

        HOperatorSet.Closing(ho_ConnectedRegions, ho_ConnectedRegions, ho_RegionClosing _
            )

        HOperatorSet.Union1(ho_RegionClosing, ho_RegionUnion)

        HOperatorSet.FillUp(ho_RegionUnion, ho_RegionFillUp)
        HOperatorSet.AreaCenter(ho_RegionFillUp, hv_Area, hv_Row, hv_Column)
        hv_k = hv_Width.TupleDiv(New HTuple(600))
        hv_Width = hv_Width.TupleDiv(hv_k)
        hv_Height = hv_Height.TupleDiv(hv_k)
        HOperatorSet.SetPart(HWindowControl1.HalconWindow, New HTuple(0), New HTuple(0), hv_Height, _
            hv_Width)

        HOperatorSet.ZoomRegion(ho_RegionFillUp, ho_RegionZoom, New HTuple(0.5), New HTuple(0.5))
        dev_open_window_fit_size(New HTuple(0), New HTuple(0), hv_Area, hv_Area, New HTuple(-1), _
            New HTuple(-1), hv_WindowHandle1)
        HOperatorSet.DispObj(ho_RegionZoom, HWindowControl1.HalconWindow)
        HOperatorSet.InnerCircle(ho_RegionZoom, hv_Row1, hv_Column1, hv_Radius)
        hv_Diameter = hv_Radius.TupleMult(New HTuple(2))
        TextBox1.Text = hv_Diameter.ToString()
        '释放资源
        ho_Image.Dispose()
        ho_GrayImage.Dispose()
        ho_ImageZoom.Dispose()
        ho_Regions.Dispose()
        ho_ConnectedRegions.Dispose()
        ho_RegionClosing.Dispose()
        ho_RegionUnion.Dispose()
        ho_RegionFillUp.Dispose()
        ho_RegionZoom.Dispose()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If (bln_Click = 0) Then
            MessageBox.Show("相机未初始化或相机未连接")
        ElseIf (bln_Click = 1) Then
            Timer1.Enabled = True
            HOperatorSet.GetImageSize(ho_Image, hv_Width, hv_Height)

            ho_Image.Dispose()
            bln_Click = bln_Click + 1
        ElseIf (bln_Click > 1) Then
            MessageBox.Show("请勿重复点击按钮")
        End If
       

        bln_Click = 0

    End Sub


    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        HOperatorSet.CloseAllFramegrabbers()



    End Sub
End Class
