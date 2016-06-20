Imports System.IO
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.ADF
Imports ESRI.ArcGIS.SystemUI

Imports ESRI.ArcGIS.Geometry ' Used in AddLayersToComboBox()

Public Class MainForm
    Private m_mapControl As IMapControl3 = Nothing
    Private m_mapDocumentName As String = String.Empty

    Private m_StrOption As String

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        'get the MapControl
        m_mapControl = CType(axMapControl1.Object, IMapControl3)

        'disable the Save menu (since there is no document yet)
        menuSaveDoc.Enabled = False

        AddLayersToComboBox()

        ' Populate the color comboboxes with values 0 to 255
        Dim i As Integer
        For i = 0 To 255
            If i > 1 And i < 11 Then cboBreaks.Items.Add(i)
            cboRed.Items.Add(i)
            cboGreen.Items.Add(i)
            cboBlue.Items.Add(i)
            cboRed.Text = "0"
            cboGreen.Text = "0"
            cboBlue.Text = "0"
        Next i

    End Sub


#Region "Main Menu event handlers"
    Private Sub menuNewDoc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuNewDoc.Click
        'execute New Document command
        Dim command As ICommand = New CreateNewDocument()
        command.OnCreate(m_mapControl.Object)
        command.OnClick()
    End Sub

    Private Sub menuOpenDoc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuOpenDoc.Click
        'execute Open Document command
        Dim command As ICommand = New ControlsOpenDocCommandClass()
        command.OnCreate(m_mapControl.Object)
        command.OnClick()
    End Sub

    Private Sub menuSaveDoc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuSaveDoc.Click
        'execute Save Document command
        If m_mapControl.CheckMxFile(m_mapDocumentName) Then
            'create a new instance of a MapDocument
            Dim mapDoc As IMapDocument = New MapDocumentClass()
            mapDoc.Open(m_mapDocumentName, String.Empty)

            'Make sure that the MapDocument is not readonly
            If mapDoc.IsReadOnly(m_mapDocumentName) Then
                MessageBox.Show("Map document is read only!")
                mapDoc.Close()
                Return
            End If

            'Replace its contents with the current map
            mapDoc.ReplaceContents(CType(m_mapControl.Map, IMxdContents))

            'save the MapDocument in order to persist it
            mapDoc.Save(mapDoc.UsesRelativePaths, False)

            'close the MapDocument
            mapDoc.Close()
        End If
    End Sub

    Private Sub menuSaveAs_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuSaveAs.Click
        'execute SaveAs Document command
        Dim command As ICommand = New ControlsSaveAsDocCommandClass()
        command.OnCreate(m_mapControl.Object)
        command.OnClick()
    End Sub

    Private Sub menuExitApp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuExitApp.Click
        'exit the application
        Application.Exit()
    End Sub
#End Region

    'listen to MapReplaced evant in order to update the statusbar and the Save menu
    Private Sub axMapControl1_OnMapReplaced(ByVal sender As Object, ByVal e As IMapControlEvents2_OnMapReplacedEvent) Handles axMapControl1.OnMapReplaced
        'get the current document name from the MapControl
        m_mapDocumentName = m_mapControl.DocumentFilename

        'if there is no MapDocument, diable the Save menu and clear the statusbar
        If m_mapDocumentName = String.Empty Then
            menuSaveDoc.Enabled = False
            statusBarXY.Text = String.Empty
        Else
            'enable the Save manu and write the doc name to the statusbar
            menuSaveDoc.Enabled = True
            statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName)
        End If
    End Sub

    Private Sub axMapControl1_OnMouseMove(ByVal sender As Object, ByVal e As IMapControlEvents2_OnMouseMoveEvent) Handles axMapControl1.OnMouseMove
        statusBarXY.Text = String.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4))
    End Sub

    Private Sub ChangeRGBRenderer()
        ''RGB Raster rendering


    End Sub

    Public Sub ApplySimple(ByVal geoLayer As IGeoFeatureLayer, ByVal aSymbol As ISymbol) 'ISimpleFillSymbol

        Dim simpleRenderer As ISimpleRenderer
        simpleRenderer = New SimpleRenderer

        simpleRenderer.Symbol = CType(aSymbol, ISymbol)

        geoLayer.Renderer = CType(simpleRenderer, IFeatureRenderer)

        axMapControl1.ActiveView.Refresh()
        axTOCControl1.Update()

    End Sub
    Public Sub ApplyUniqueValue(ByVal geoLayer As IGeoFeatureLayer, ByVal aFieldName As String)

        'Dim uniqueRenderer As IUniqueValueRenderer
        'uniqueRenderer = New UniqueValueRenderer

        'uniqueRenderer.FieldCount = 1
        'uniqueRenderer.Field(0) = aFieldName

        'Dim intFieldIndex As Integer
        'intFieldIndex = geoLayer.FeatureClass.FindField(aFieldName)

        'Dim fCursor As IFeatureCursor
        'Dim qFilter As IQueryFilter
        'qFilter = New QueryFilter
        'qFilter.SubFields = aFieldName
        'fCursor = geoLayer.FeatureClass.Search(qFilter, True)

        'Dim randomColors As IRandomColorRamp
        'randomColors = New RandomColorRamp
        'randomColors.Size = 16

        'Dim bOK As Boolean
        'randomColors.CreateRamp(bOK)
        'If Not bOK Then Exit Sub

        'Dim enumColor As IEnumColors
        'enumColor = randomColors.Colors

        'Dim sym As ISimpleFillSymbol
        'Dim color As IColor

        'Dim feature As IFeature
        'feature = fCursor.NextFeature
        'Do Until feature Is Nothing
        '    sym = New SimpleFillSymbol
        '    color = enumColor.Next
        '    If color Is Nothing Then
        '        enumColor.Reset()
        '        color = enumColor.Next
        '    End If
        '    sym.Style = esriSimpleFillStyle.esriSFSSolid
        '    sym.Color = color
        '    uniqueRenderer.AddValue(feature.Value(intFieldIndex).ToString(), "", CType(sym, ISymbol))
        '    feature = fCursor.NextFeature
        'Loop

        'geoLayer.Renderer = CType(uniqueRenderer, IFeatureRenderer)

        'axMapControl1.ActiveView.Refresh()
        'axTOCControl1.Update()

    End Sub


    Public Sub ApplyClassBreaks(ByVal geoLayer As IGeoFeatureLayer, ByVal aFieldName As String, ByVal numBreaks As Long)

        '' Create a table from the geo feature layer
        'Dim table As ITable
        'table = CType(geoLayer, ITable)

        'Dim tableHistogram As ITableHistogram
        'tableHistogram = New TableHistogram
        'tableHistogram.Table = table 'equivalent to geoLayer.FeatureClass

        '' Retrieve frequency data from the field
        'tableHistogram.Field = aFieldName

        ''MessageBox.Show("Field is: " & tableHistogram.Field)

        'Dim histogram As IHistogram
        'histogram = CType(tableHistogram, IHistogram)
        ''histogram = tableHistogram

        'Dim vValues As Object
        'Dim vFreqs As Object
        'histogram.GetHistogram(vValues, vFreqs)

        '' Classify the data
        'Dim classify As IClassifyGEN
        'classify = New EqualInterval
        'classify.Classify(vValues, vFreqs, CInt(numBreaks))

        'Dim vBreaks As Object
        'vBreaks = classify.ClassBreaks

        '' Create the class breaks renderer
        'Dim classBreaksRenderer As IClassBreaksRenderer
        'classBreaksRenderer = New ClassBreaksRenderer

        'classBreaksRenderer.Field = aFieldName ' passed as a String to the Sub
        'classBreaksRenderer.BreakCount = CType(numBreaks, Integer)

        '' Set the begin and end colors
        'Dim fromColor As IRgbColor = New RgbColor
        'fromColor.RGB = RGB(255, 255, 0)
        'Dim toColor As IRgbColor = New RgbColor
        'toColor.RGB = RGB(255, 0, 0)

        'Dim colors As IEnumColors
        'colors = GetColors(fromColor.RGB, toColor.RGB, numBreaks)

        '' Set up the fill symbol
        'Dim sym As ISimpleFillSymbol
        'Dim color As IColor
        'Dim i As Integer

        'For i = 0 To UBound(vBreaks) - 1
        '    sym = New SimpleFillSymbol
        '    color = colors.Next
        '    sym.Color = color
        '    classBreaksRenderer.Break(i) = vBreaks(i + 1)
        '    classBreaksRenderer.Symbol(i) = CType(sym, ISymbol)
        'Next i

        'geoLayer.Renderer = CType(classBreaksRenderer, IFeatureRenderer)

        'axMapControl1.ActiveView.Refresh()
        'axTOCControl1.Update()

    End Sub


    Public Function GetColors(ByVal vbStartColor As Long, ByVal vbEndColor As Long, ByVal Colors As Long) As IEnumColors

        'Dim startColor As IRgbColor
        'Dim endColor As IRgbColor
        'startColor = New RgbColor
        'endColor = New RgbColor
        'startColor.RGB = CInt(vbStartColor)
        'endColor.RGB = CInt(vbEndColor)

        'Dim ramp As IAlgorithmicColorRamp
        'ramp = New AlgorithmicColorRamp
        'ramp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm
        'ramp.FromColor = startColor
        'ramp.ToColor = endColor
        'ramp.Size = CInt(Colors)

        'Dim blnIsRampOK As Boolean
        'ramp.CreateRamp(blnIsRampOK)

        'If Not blnIsRampOK Then
        GetColors = Nothing
        'Else
        '    GetColors = ramp.Colors
        'End If

    End Function

    Private Sub btnRender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRender.Click

        Dim geoLayer As IGeoFeatureLayer
        geoLayer = GetLayerByName(cboLayer.Text)

        Select Case m_strOption
            Case "Simple"
                'Step 1: code here to create a new fill symbol and color
                'code here to create a new fill symbol and color





            Case "Unique"
                'call the ApplyUniqueValue sub procedure
                ApplyUniqueValue(geoLayer, cboUniqueVals.Text)
            Case "Breaks"
                'call the ApplyClassBreaks sub procedure
                ApplyClassBreaks(geoLayer, cboNumericVals.Text, CLng(cboBreaks.Text))
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub cboLayer_Change()

        Dim strLayerName As String
        strLayerName = cboLayer.Text

        Try
            If strLayerName <> "" Then
                btnRender.Enabled = True
                optSimple.Enabled = True
                optUnique.Enabled = True
                optBreaks.Enabled = True
                optSimple.Text = "True"
            Else
                btnRender.Enabled = False
                m_strOption = "NoLayer"
                Call OptionEnabler()
                Exit Sub
            End If

            'On Error GoTo LayerNotFound

            Dim fLayer As IFeatureLayer
            fLayer = GetLayerByName(strLayerName)
            FillFieldsComboBox(fLayer)

            Exit Sub

        Catch noLayer As Exception
            btnRender.Enabled = False
            m_strOption = "NoLayer"
            Call OptionEnabler()
            Exit Sub
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub AddLayersToComboBox()

        'Dim allFLayers As IEnumLayer
        'Dim uid As New UID 'Dim uid As New esriSystem.UID
        'uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}"
        'allFLayers = axMapControl1.ActiveView.FocusMap.Layers(uid, True)

        'Dim fLayer As IFeatureLayer
        'fLayer = CType(allFLayers.Next(), IFeatureLayer)
        'Do Until fLayer Is Nothing
        '    If fLayer.FeatureClass.ShapeType = esriGeometryType.esriGeometryPolygon Then
        '        cboLayer.Items.Add(fLayer.Name)
        '    ElseIf fLayer.FeatureClass.ShapeType = esriGeometryType.esriGeometryPolyline Then
        '        cboLayer.Items.Add(fLayer.Name)
        '    ElseIf fLayer.FeatureClass.ShapeType = esriGeometryType.esriGeometryPoint Then
        '        cboLayer.Items.Add(fLayer.Name)
        '    End If
        '    fLayer = CType(allFLayers.Next(), IFeatureLayer)
        'Loop

    End Sub

    Private Function GetLayerByName(ByVal LayerName As String) As IGeoFeatureLayer

        Dim uid As UID = New UID
        'This is the ID for layers supporting the IGeoFeatureLayer interface
        uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}"

        'Get all the FeatureLayers from the map using the UID
        Dim allFLayers As IEnumLayer
        allFLayers = axMapControl1.ActiveView.FocusMap.Layers(uid, True)

        'Loop thru all FeatureLayers until LayerName is found
        Dim layer As ILayer
        layer = allFLayers.Next
        Do Until layer Is Nothing
            If layer.Name = LayerName Then
                Exit Do
            End If
            layer = allFLayers.Next
        Loop

        'Pass back the requested layer
        GetLayerByName = CType(layer, IGeoFeatureLayer)

    End Function

    Private Sub OptionEnabler()

        Dim cntrl As Windows.Forms.Control
        For Each cntrl In Me.Controls
            If cntrl.Tag Is "CheckEnable" Then cntrl.Enabled = False
        Next cntrl

        Select Case m_strOption
            Case "Simple"
                lblR.Enabled = True
                lblG.Enabled = True
                lblB.Enabled = True
                cboRed.Enabled = True
                cboGreen.Enabled = True
                cboBlue.Enabled = True
            Case "Unique"
                cboUniqueVals.Enabled = True
            Case "Breaks"
                cboNumericVals.Enabled = True
                cboBreaks.Enabled = True
                lblBreaks.Enabled = True
            Case "NoLayer"
                optSimple.Enabled = False
                optUnique.Enabled = False
                optBreaks.Enabled = False
        End Select
    End Sub

    Private Sub FillFieldsComboBox(ByVal geoLayer As IFeatureLayer)

        'Dim pFClass As IFeatureClass
        'pFClass = geoLayer.FeatureClass

        'Dim pFields As IFields
        'pFields = pFClass.Fields

        'cboNumericVals.Items.Clear()
        'cboUniqueVals.Items.Clear()

        'Dim pFld As IField
        'Dim i As Integer
        'For i = 0 To pFields.FieldCount - 1
        '    pFld = pFields.Field(i)
        '    If pFld.Type <= 3 Then cboNumericVals.Items.Add(pFld.Name) 'numeric
        '    If pFld.Type <= 5 Then cboUniqueVals.Items.Add(pFld.Name) 'not shape, OID, or BLOB
        'Next i

    End Sub

    Private Sub cboLayer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLayer.SelectedValueChanged

        Dim strLayerName As String
        strLayerName = cboLayer.Text
        Try
            If strLayerName <> "" Then
                btnRender.Enabled = True
                optSimple.Enabled = True
                optUnique.Enabled = True
                optBreaks.Enabled = True
                optSimple.Equals(True)
            Else
                btnRender.Enabled = False
                m_strOption = "NoLayer"
                Call OptionEnabler()
                Exit Sub
            End If

            Dim fLayer As IFeatureLayer
            fLayer = GetLayerByName(strLayerName)
            FillFieldsComboBox(fLayer)

        Catch excGeneric As Exception
            btnRender.Enabled = False
            btnSaveLayer.Enabled = False
            m_strOption = "NoLayer"
            Call OptionEnabler()
            MessageBox.Show("No layer selected")
        End Try

    End Sub
    
    Private Sub btnChangeRGBRenderer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeRGBRenderer.Click
        ''' RGB Raster Rendering

    End Sub

    Private Sub optBreaks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optBreaks.Click
        m_StrOption = "Breaks"
        Call OptionEnabler()
    End Sub

    Private Sub optSimple_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optSimple.Click
        m_StrOption = "Simple"
        Call OptionEnabler()
    End Sub

    Private Sub optUnique_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles optUnique.Click
        m_StrOption = "Unique"
        Call OptionEnabler()
    End Sub

    

    Private Sub btnStretch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStretch.Click

        'Dim map As IMap
        'map = axMapControl1.ActiveView.FocusMap

        ''Get raster input from layer
        'Dim rLayer As IRasterLayer
        'rLayer = CType(map.Layer(0), IRasterLayer)
        'Dim raster As IRaster
        'raster = rLayer.Raster

        ''Create renderer and QI for RasterRenderer
        'Dim stretchRen As IRasterStretchColorRampRenderer
        'stretchRen = New RasterStretchColorRampRenderer
        'Dim rasRen As IRasterRenderer
        'rasRen = CType(stretchRen, IRasterRenderer)

        ''Set raster for the renderer and update
        'rasRen.Raster = raster
        'rasRen.Update()

        ''Define two colors
        'Dim fromColor As IColor
        'Dim toColor As IColor
        'fromColor = New RgbColor
        'fromColor.RGB = RGB(255, 0, 0)
        'toColor = New RgbColor
        'toColor.RGB = RGB(0, 255, 0)

        ''Create color ramp
        'Dim ramp As IAlgorithmicColorRamp
        'ramp = New AlgorithmicColorRamp
        'ramp.Size = 255
        'ramp.FromColor = fromColor
        'ramp.ToColor = toColor
        'ramp.CreateRamp(True)

        ''Plug this colorramp into renderer and select a band
        'stretchRen.BandIndex = 0
        'stretchRen.ColorRamp = ramp

        ''Update the renderer with new settings and plug into layer
        'rasRen.Update()
        'rLayer.Renderer = CType(stretchRen, IRasterRenderer)

        'axMapControl1.ActiveView.Refresh()
        'axTOCControl1.Update()

    End Sub

    Private Sub btnScale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnScale.Click
        'This code creates a scale dependent renderer with three scale threshholds

        'The code creates pointers to the three existing layers
        'plus the new layer that is
        'created with the scale dependent renderer.

        'Dim map As IMap
        'map = axMapControl1.ActiveView.FocusMap

        ''Reference IFeatureLayer
        'Dim fLayer1 As IFeatureLayer
        'Dim fLayer2 As IFeatureLayer
        'Dim fLayer0 As IFeatureLayer

        ''Instantiate your feature layers to current map layers

        'fLayer0 = CType(map.Layer(2), IFeatureLayer)
        'fLayer1 = CType(map.Layer(1), IFeatureLayer)
        'fLayer2 = CType(map.Layer(0), IFeatureLayer)

        ''MessageBox.Show("Layer 0 is " & fLayer0.Name)
        ''MessageBox.Show("Layer 1 is " & fLayer1.Name)
        ''MessageBox.Show("Layer 2 is " & fLayer2.Name)

        'fLayer2.MinimumScale = 500000000
        'MessageBox.Show("Layer2 max scale: " & fLayer2.Name & " " & fLayer2.MaximumScale.ToString())
        'MessageBox.Show("Layer2 min scale: " & fLayer2.MinimumScale.ToString())

        'Dim newFLayer As IFeatureLayer
        'newFLayer = New FeatureLayer
        'newFLayer.Name = "USA"

        ''Set the feature class of the new Layer to be the same as that of one of the
        ''existing layers.
        'Dim featureClass As IFeatureClass
        'featureClass = fLayer1.FeatureClass
        'newFLayer.FeatureClass = featureClass

        ''QI to the IGeofeatureLayer interface to work with the renderers.
        'Dim geoFLayer0 As IGeoFeatureLayer
        'Dim geoFLayer1 As IGeoFeatureLayer
        'Dim geoFLayer2 As IGeoFeatureLayer
        'Dim newGeoFLayer As IGeoFeatureLayer
        'geoFLayer0 = CType(fLayer0, IGeoFeatureLayer)
        'geoFLayer1 = CType(fLayer1, IGeoFeatureLayer)
        'geoFLayer2 = CType(fLayer2, IGeoFeatureLayer)
        'newGeoFLayer = CType(newFLayer, IGeoFeatureLayer)

        ''Create a new scale dependent renderer
        'Dim scaleDependentRenderer As IScaleDependentRenderer
        'scaleDependentRenderer = New ScaleDependentRenderer

        ''Grab the renderers from the existing layers
        'Dim renderer0 As IFeatureRenderer
        'Dim renderer1 As IFeatureRenderer
        'Dim renderer2 As IFeatureRenderer
        'renderer0 = geoFLayer0.Renderer
        'renderer1 = geoFLayer1.Renderer
        'renderer2 = geoFLayer2.Renderer

        ''Build the new scale dependent renderer from the existing renderers.
        'scaleDependentRenderer.AddRenderer(renderer0)
        'scaleDependentRenderer.AddRenderer(renderer1)
        'scaleDependentRenderer.AddRenderer(renderer2)

        ''Set the scale threshholds for the renderers within the scale dependent renderer.
        'scaleDependentRenderer.Break(0) = 10000000
        'scaleDependentRenderer.Break(1) = 50000000
        'scaleDependentRenderer.Break(2) = 500000000

        ''Associate the scale dependent renderer with the new layer
        ''Add the scale dependent renderer to the map
        'newGeoFLayer.Renderer = CType(scaleDependentRenderer, IFeatureRenderer)
        'map.AddLayer(newGeoFLayer)

    End Sub

End Class