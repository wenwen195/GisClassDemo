Imports System.IO
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Controls
Imports ESRI.ArcGIS.ADF
Imports ESRI.ArcGIS.SystemUI

' Added for exercise 08
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.Display

Public Class MainForm
    Private m_mapControl As IMapControl3 = Nothing
    Private m_mapDocumentName As String = String.Empty

    Private m_layer As ILayer

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        'get the MapControl
        m_mapControl = CType(axMapControl1.Object, IMapControl3)

        'disable the Save menu (since there is no document yet)
        menuSaveDoc.Enabled = False
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
                MsgBox("Map document is read only!")
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

    
    Private Sub axTOCControl1_OnMouseDown(ByVal sender As Object, ByVal e As ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent) Handles axTOCControl1.OnMouseDown
        Dim map As Map = Nothing
        Dim layer As ILayer = Nothing
        Dim other As Object = Nothing
        Dim item As esriTOCControlItem
        Dim index As Object = Nothing
        'When querying interface to ITOCControl in Visual Basic .NET or
        'Visual C# .NET the Object property or container specific code 
        'must be used. This is because .NET contains the real control 
        'inside a wrapper object known as an host.

        'Dim tocControl As ITOCControl = axTOCControl1.Object
        ' http://edndoc.esri.com/arcobjects/9.2/ComponentHelp/esriControls/ITOCControl2_HitTest.htm

        Dim toc As ITOCControl2 = axTOCControl1.Object
        toc.HitTest(e.x, e.y, item, map, layer, other, index)

        If item = esriTOCControlItem.esriTOCControlItemLayer Then
            m_layer = layer
        End If
    End Sub

   
End Class