'
'  File generated by HDevelop for HALCON/DOTNET (Visual Basic .NET) Version 12.0
'
'  This file is intended to be used with the HDevelopTemplate or
'  HDevelopTemplateWPF projects located under %HALCONEXAMPLES%\vb.net

Option Strict Off

Option Explicit

Imports HalconDotNet

Module HDevelopExportCeshixiangji1

Public  hv_ExpDefaultWinHandle As HTuple
' Procedures 
' Chapter: Develop
' Short Description: Open a new graphics window that preserves the aspect ratio of the given image size. 
Public Sub dev_open_window_fit_size (ByVal hv_Row As HTuple, ByVal hv_Column As HTuple,  _
    ByVal hv_Width As HTuple, ByVal hv_Height As HTuple, ByVal hv_WidthLimit As HTuple,  _
    ByVal hv_HeightLimit As HTuple, ByRef hv_WindowHandle As HTuple)



  ' Local iconic variables 

  ' Local control variables 
  Dim  hv_MinWidth As HTuple = New HTuple, hv_MaxWidth As HTuple = New HTuple
  Dim  hv_MinHeight As HTuple = New HTuple, hv_MaxHeight As HTuple = New HTuple
  Dim  hv_ResizeFactor As HTuple = New HTuple, hv_TempWidth As HTuple = New HTuple
  Dim  hv_TempHeight As HTuple = New HTuple, hv_WindowWidth As HTuple = New HTuple
  Dim  hv_WindowHeight As HTuple = New HTuple

  ' Initialize local and output iconic variables 

  'This procedure open a new graphic window
  'such that it fits into the limits specified by WidthLimit
  'and HeightLimit, but also maintains the correct aspect ratio
  'given by Width and Height.
  '
  'If it is impossible to match the minimum and maximum extent requirements
  'at the same time (f.e. if the image is very long but narrow),
  'the maximum value gets a higher priority.
  '
  'Parse input tuple WidthLimit
  If (new HTuple((new HTuple(hv_WidthLimit.TupleLength())).TupleEqual(new HTuple(0)))).TupleOr( _
      new HTuple(hv_WidthLimit.TupleLess(new HTuple(0)))).I() Then
    hv_MinWidth = new HTuple(500)
    hv_MaxWidth = new HTuple(800)
  Elseif new HTuple((new HTuple(hv_WidthLimit.TupleLength())).TupleEqual(new HTuple(1))).I() Then
    hv_MinWidth = new HTuple(0)
    hv_MaxWidth = hv_WidthLimit.Clone()
  Else
    hv_MinWidth = hv_WidthLimit.TupleSelect(new HTuple(0))
    hv_MaxWidth = hv_WidthLimit.TupleSelect(new HTuple(1))
  End If
  'Parse input tuple HeightLimit
  If (new HTuple((new HTuple(hv_HeightLimit.TupleLength())).TupleEqual(new HTuple(0)))).TupleOr( _
      new HTuple(hv_HeightLimit.TupleLess(new HTuple(0)))).I() Then
    hv_MinHeight = new HTuple(400)
    hv_MaxHeight = new HTuple(600)
  Elseif new HTuple((new HTuple(hv_HeightLimit.TupleLength())).TupleEqual(new HTuple(1))).I() Then
    hv_MinHeight = new HTuple(0)
    hv_MaxHeight = hv_HeightLimit.Clone()
  Else
    hv_MinHeight = hv_HeightLimit.TupleSelect(new HTuple(0))
    hv_MaxHeight = hv_HeightLimit.TupleSelect(new HTuple(1))
  End If
  '
  'Test, if window size has to be changed.
  hv_ResizeFactor = new HTuple(1)
  'First, expand window to the minimum extents (if necessary).
  If (new HTuple(hv_MinWidth.TupleGreater(hv_Width))).TupleOr(new HTuple(hv_MinHeight.TupleGreater( _
      hv_Height))).I() Then
    hv_ResizeFactor = (((hv_MinWidth.TupleReal()).TupleDiv(hv_Width)).TupleConcat( _
        (hv_MinHeight.TupleReal()).TupleDiv(hv_Height))).TupleMax()
  End If
  hv_TempWidth = hv_Width.TupleMult(hv_ResizeFactor)
  hv_TempHeight = hv_Height.TupleMult(hv_ResizeFactor)
  'Then, shrink window to maximum extents (if necessary).
  If (new HTuple(hv_MaxWidth.TupleLess(hv_TempWidth))).TupleOr(new HTuple(hv_MaxHeight.TupleLess( _
      hv_TempHeight))).I() Then
    hv_ResizeFactor = hv_ResizeFactor.TupleMult((((hv_MaxWidth.TupleReal()).TupleDiv( _
        hv_TempWidth)).TupleConcat((hv_MaxHeight.TupleReal()).TupleDiv(hv_TempHeight))).TupleMin( _
        ))
  End If
  hv_WindowWidth = hv_Width.TupleMult(hv_ResizeFactor)
  hv_WindowHeight = hv_Height.TupleMult(hv_ResizeFactor)
  'Resize window
  'dev_open_window(...);
  HOperatorSet.SetPart(hv_ExpDefaultWinHandle, new HTuple(0), new HTuple(0), hv_Height.TupleSub( _
      new HTuple(1)), hv_Width.TupleSub(new HTuple(1)))

  Exit Sub
End Sub

' Main procedure 
Private Sub action()


  ' Local iconic variables 
  Dim  ho_Image As HObject = Nothing, ho_GrayImage As HObject = Nothing
  Dim  ho_ImageZoom As HObject = Nothing, ho_Regions As HObject = Nothing
  Dim  ho_ConnectedRegions As HObject = Nothing, ho_RegionClosing As HObject = Nothing
  Dim  ho_RegionUnion As HObject = Nothing, ho_RegionFillUp As HObject = Nothing
  Dim  ho_RegionZoom As HObject = Nothing

  ' Local control variables 
  Dim  hv_AcqHandle As HTuple = New HTuple, hv_Width As HTuple = New HTuple
  Dim  hv_Height As HTuple = New HTuple, hv_Area As HTuple = New HTuple
  Dim  hv_Row As HTuple = New HTuple, hv_Column As HTuple = New HTuple
  Dim  hv_k As HTuple = New HTuple, hv_WindowHandle1 As HTuple = New HTuple
  Dim  hv_Row1 As HTuple = New HTuple, hv_Column1 As HTuple = New HTuple
  Dim  hv_Radius As HTuple = New HTuple, hv_diameter As HTuple = New HTuple

  ' Initialize local and output iconic variables 
  HOperatorSet.GenEmptyObj(ho_Image)
  HOperatorSet.GenEmptyObj(ho_GrayImage)
  HOperatorSet.GenEmptyObj(ho_ImageZoom)
  HOperatorSet.GenEmptyObj(ho_Regions)
  HOperatorSet.GenEmptyObj(ho_ConnectedRegions)
  HOperatorSet.GenEmptyObj(ho_RegionClosing)
  HOperatorSet.GenEmptyObj(ho_RegionUnion)
  HOperatorSet.GenEmptyObj(ho_RegionFillUp)
  HOperatorSet.GenEmptyObj(ho_RegionZoom)


  'Image Acquisition 01: Code generated by Image Acquisition 01
  HOperatorSet.CloseAllFramegrabbers()
  HOperatorSet.OpenFramegrabber(new HTuple("GigEVision"), new HTuple(0), new HTuple(0),  _
      new HTuple(0), new HTuple(0), new HTuple(0), new HTuple(0), new HTuple("default"),  _
      new HTuple(-1), new HTuple("default"), new HTuple(-1), new HTuple("false"),  _
      new HTuple("default"), new HTuple("0030531fa30d_Basler_ACA130MGED"), new HTuple(0),  _
      new HTuple(-1), hv_AcqHandle)
  Do While (new HTuple(1)).I()
    HOperatorSet.GrabImageStart(hv_AcqHandle, new HTuple(-1))
    ho_Image.Dispose()
    HOperatorSet.GrabImageAsync(ho_Image, hv_AcqHandle, new HTuple(-1))
    'Image Acquisition 01: Do something
    ho_GrayImage.Dispose()
    HOperatorSet.Rgb1ToGray(ho_Image, ho_GrayImage)
    HOperatorSet.GetImageSize(ho_GrayImage, hv_Width, hv_Height)
    ho_ImageZoom.Dispose()
    HOperatorSet.ZoomImageSize(ho_GrayImage, ho_ImageZoom, hv_Width, hv_Height, new HTuple("constant"))
    ho_Regions.Dispose()
    HOperatorSet.Threshold(ho_GrayImage, ho_Regions, new HTuple(15), new HTuple(153))
    ho_ConnectedRegions.Dispose()
    HOperatorSet.Connection(ho_Regions, ho_ConnectedRegions)
    ho_RegionClosing.Dispose()
    HOperatorSet.Closing(ho_ConnectedRegions, ho_ConnectedRegions, ho_RegionClosing _
        )
    ho_RegionUnion.Dispose()
    HOperatorSet.Union1(ho_RegionClosing, ho_RegionUnion)
    ho_RegionFillUp.Dispose()
    HOperatorSet.FillUp(ho_RegionUnion, ho_RegionFillUp)
    HOperatorSet.AreaCenter(ho_RegionFillUp, hv_Area, hv_Row, hv_Column)
    hv_k = hv_Width.TupleDiv(new HTuple(600))
    hv_Width = hv_Width.TupleDiv(hv_k)
    hv_Height = hv_Height.TupleDiv(hv_k)
    HOperatorSet.SetPart(hv_ExpDefaultWinHandle, new HTuple(0), new HTuple(0), hv_Height,  _
        hv_Width)
    ho_RegionZoom.Dispose()
    HOperatorSet.ZoomRegion(ho_RegionFillUp, ho_RegionZoom, new HTuple(0.5), new HTuple(0.5))
    dev_open_window_fit_size(new HTuple(0), new HTuple(0), hv_Area, hv_Area, new HTuple(-1),  _
        new HTuple(-1), hv_WindowHandle1)
    HOperatorSet.DispObj(ho_RegionZoom, hv_ExpDefaultWinHandle)
    HOperatorSet.InnerCircle(ho_RegionZoom, hv_Row1, hv_Column1, hv_Radius)
    hv_diameter = hv_Radius.TupleMult(new HTuple(2))

    #If USE_DO_EVENTS Then
    ' Please note: The call of DoEvents() is only a hack to
    ' enable VB to react on events. Please change the code
    ' so that it can handle events in a standard way.
    System.Windows.Forms.Application.DoEvents()
    #End If
  Loop
  HOperatorSet.CloseFramegrabber(hv_AcqHandle)

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



Sub InitHalcon()
  ' Default settings used in HDevelop 
  Call HOperatorSet.SetSystem(New HTuple("width"), New HTuple(512))
  Call HOperatorSet.SetSystem(New HTuple("height"), New HTuple(512))
  End Sub

  Sub RunHalcon(ByRef Window as HTuple)
    hv_ExpDefaultWinHandle = Window
    Call action
  End Sub

End Module

