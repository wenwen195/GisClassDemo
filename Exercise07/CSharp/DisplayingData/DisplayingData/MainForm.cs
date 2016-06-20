using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;


using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;

using ESRI.ArcGIS.Display;

namespace DisplayingData
{
    public sealed partial class MainForm : Form
    {
        #region class private members
        private IMapControl3 m_mapControl = null;
        private string m_mapDocumentName = string.Empty;

        private string m_strOption = string.Empty;
        
 
        #endregion

        #region class constructor
        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

    private void MainForm_Load(object sender, EventArgs e)
    {
        //get the MapControl
        m_mapControl = (IMapControl3)axMapControl1.Object;

        //disable the Save menu (since there is no document yet)
        menuSaveDoc.Enabled = false;

        AddLayersToComboBox();

        for (int i = 0; (i < 255); i++)
        {
            if (((i > 1)
                        && (i < 11)))
            {
                cboBreaks.Items.Add(i);
            }
            cboRed.Items.Add(i);
            cboGreen.Items.Add(i);
            cboBlue.Items.Add(i);
            cboRed.Text = "0";
            cboGreen.Text = "0";
            cboBlue.Text = "0";
        }


    }

        #region Main Menu event handlers
        private void menuNewDoc_Click(object sender, EventArgs e)
        {
            //execute New Document command
            ICommand command = new CreateNewDocument();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open Document command
            ICommand command = new ControlsOpenDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {
            //execute Save Document command
            if (m_mapControl.CheckMxFile(m_mapDocumentName))
            {
                //create a new instance of a MapDocument
                IMapDocument mapDoc = new MapDocumentClass();
                mapDoc.Open(m_mapDocumentName, string.Empty);

                //Make sure that the MapDocument is not readonly
                if (mapDoc.get_IsReadOnly(m_mapDocumentName))
                {
                    MessageBox.Show("Map document is read only!");
                    mapDoc.Close();
                    return;
                }

                //Replace its contents with the current map
                mapDoc.ReplaceContents((IMxdContents)m_mapControl.Map);

                //save the MapDocument in order to persist it
                mapDoc.Save(mapDoc.UsesRelativePaths, false);

                //close the MapDocument
                mapDoc.Close();
            }
        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            //execute SaveAs Document command
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            //exit the application
            Application.Exit();
        }
        #endregion

        //listen to MapReplaced evant in order to update the statusbar and the Save menu
        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            //get the current document name from the MapControl
            m_mapDocumentName = m_mapControl.DocumentFilename;

            //if there is no MapDocument, diable the Save menu and clear the statusbar
            if (m_mapDocumentName == string.Empty)
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                //enable the Save manu and write the doc name to the statusbar
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocumentName);
            }
        }

        public void ApplySimple(IGeoFeatureLayer geoLayer, ISymbol aSymbol)
        {
            ISimpleRenderer simpleRenderer;
            simpleRenderer = new SimpleRenderer();
            simpleRenderer.Symbol = aSymbol as ISymbol;
            geoLayer.Renderer = simpleRenderer as IFeatureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();
        }

        public void ApplyUniqueValue(IGeoFeatureLayer geoLayer, string aFieldName)
        {
            //IUniqueValueRenderer uniqueRenderer;
            //uniqueRenderer = new UniqueValueRenderer();
            //uniqueRenderer.FieldCount = 1;
            //uniqueRenderer.set_Field(0, aFieldName);
            //int intFieldIndex;
            //intFieldIndex = geoLayer.FeatureClass.FindField(aFieldName);
            //IFeatureCursor fCursor;
            //IQueryFilter qFilter;
            //qFilter = new QueryFilter();
            //qFilter.SubFields = aFieldName;
            //fCursor = geoLayer.FeatureClass.Search(qFilter, true);
            //IRandomColorRamp randomColors;
            //randomColors = new RandomColorRamp();
            //randomColors.Size = 16;
            //bool bOK;
            //randomColors.CreateRamp(out bOK);
            //if (!bOK)
            //{
            //    return;
            //}
            //IEnumColors enumColor;
            //enumColor = randomColors.Colors;
            //ISimpleFillSymbol sym;
            //IColor color;
            //IFeature feature;
            //feature = fCursor.NextFeature();
            //while (feature != null)
            //{
            //    sym = new SimpleFillSymbol();
            //    color = enumColor.Next();
            //    if ((color == null))
            //    {
            //        enumColor.Reset();
            //        color = enumColor.Next();
            //    }
            //    sym.Style = esriSimpleFillStyle.esriSFSSolid;
            //    sym.Color = color;
            //    Console.WriteLine(feature.get_Value(intFieldIndex).ToString());
            //    uniqueRenderer.AddValue(feature.get_Value(intFieldIndex).ToString(), "", ((ISymbol)(sym)));
            //    feature = fCursor.NextFeature();
            //}
            //geoLayer.Renderer = uniqueRenderer as IFeatureRenderer;
            //axMapControl1.ActiveView.Refresh();
            //axTOCControl1.Update();
        }

        public void ApplyClassBreaks(IGeoFeatureLayer geoLayer, string aFieldName, long numBreaks)
        {
            ////  Create a table from the geo feature layer
            //ITable table;
            //table = geoLayer as ITable;
            //ITableHistogram tableHistogram;
            //tableHistogram = new TableHistogramClass();
            //tableHistogram.Table = table;
            //// equivalent to geoLayer.FeatureClass
            ////  Retrieve frequency data from the field
            //tableHistogram.Field = aFieldName;
            //// MessageBox.Show("Field is: " & tableHistogram.Field)

            //IHistogram histogram;
            //histogram = tableHistogram as IHistogram;
            //object vValues;
            //object vFreqs;
            //histogram.GetHistogram(out vValues, out vFreqs);

            ////  Classify the data
            //IClassifyGEN classifyGEN = new EqualIntervalClass();

            //int intBreaks;
            //intBreaks = Convert.ToInt32(numBreaks);
            //classifyGEN.Classify(vValues, vFreqs, ref intBreaks);

            //double[] vBreaks = (double[])classifyGEN.ClassBreaks; // need an array

            ////  Create the class breaks renderer
            //IClassBreaksRenderer classBreaksRenderer;
            //classBreaksRenderer = new ClassBreaksRendererClass();
            //classBreaksRenderer.Field = aFieldName;
            ////  passed as a String to the sub routine
            //classBreaksRenderer.BreakCount = (int)(numBreaks);

            //IRgbColor fromColor = new RgbColorClass();
            //fromColor.UseWindowsDithering = true;
            //fromColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 255, 0);

            //IRgbColor toColor = new RgbColorClass();
            //toColor.UseWindowsDithering = true;
            //toColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 0, 0);
                    
            ////  Set up the fill symbol
            //ISimpleFillSymbol sym = new SimpleFillSymbolClass();
            //IColor fillColor;
           
            //MessageBox.Show("vBreaks.Length: " + vBreaks.Length.ToString());

            //IEnumColors colors;
            //colors = GetColors(fromColor.RGB, toColor.RGB, numBreaks);

            //for (int i = 0; (i <= vBreaks.Length - 2); i++) // Length = 6; subtracted 2; why??
            //{  
            //    fillColor = colors.Next();
            //    sym.Color = fillColor;

            //    classBreaksRenderer.set_Break(i, vBreaks[(i + 1)]);
            //    classBreaksRenderer.set_Symbol(i, sym as ISymbol);

            //    geoLayer.Renderer = classBreaksRenderer as IFeatureRenderer;
            //    axMapControl1.ActiveView.Refresh();
            //    axTOCControl1.Update();
            //}
        }

        public IEnumColors GetColors() //long lngStartColor, long lngEndColor, long Colors)
        {
            //IRgbColor startColor = new RgbColor();
            //IRgbColor endColor = new RgbColor();  

            //startColor.RGB = Convert.ToInt32(lngStartColor);
            //endColor.RGB = Convert.ToInt32(lngEndColor);

            //IAlgorithmicColorRamp ramp;
            //ramp = new AlgorithmicColorRamp();
            //ramp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            //ramp.FromColor = startColor;
            //ramp.ToColor = endColor;
            //ramp.Size = Convert.ToInt32(Colors);
            //bool blnIsRampOK;
            //ramp.CreateRamp(out blnIsRampOK);
            //if (!blnIsRampOK)
            //{
            return null;
            //}
            //else
            //{
            //    return ramp.Colors;
            //}
        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoLayer;
            geoLayer = GetLayerByName(cboLayer.Text);
            switch (m_strOption)
            {
                case "Simple":

                    // user-written code
                    


                case "Unique":
                    ApplyUniqueValue(geoLayer, cboUniqueVals.Text);
                    break;
                case "Breaks":
                    ApplyClassBreaks(geoLayer, cboNumericVals.Text, long.Parse(cboBreaks.Text));
                    break;
                default:
                    //return;
                    break;
            }

        }
        
        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strLayerName;
            strLayerName = cboLayer.Text;
            try
            {
                if ((strLayerName != ""))
                {
                    btnRender.Enabled = true;
                    optSimple.Enabled = true;
                    optUnique.Enabled = true;
                    optBreaks.Enabled = true;
                    optSimple.Equals(true);  //"True";
                }
                else
                {
                    btnRender.Enabled = false;
                    m_strOption = "NoLayer";
                    OptionEnabler();
                    return;
                }
                // On Error GoTo LayerNotFound
                IFeatureLayer fLayer;
                fLayer = GetLayerByName(strLayerName);
                FillFieldsComboBox(fLayer);
                return;
            }
            catch (Exception error)
            {
                btnRender.Enabled = false;
                m_strOption = "NoLayer";
                OptionEnabler();
                MessageBox.Show("Error : " + error.Message);
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddLayersToComboBox()
        {
            
            UID uidLayer = new UIDClass();
            //uidLayer.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
            //IMap map = axMapControl1.ActiveView.FocusMap;

            //IEnumLayer allFLayers;
            //allFLayers = map.get_Layers(uidLayer, true);
            
            //IFeatureLayer fLayer;
            //fLayer = allFLayers.Next() as IFeatureLayer;
            //while (fLayer != null)
            //{
            //    if ((fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon))
            //    {
            //        cboLayer.Items.Add(fLayer.Name);
            //    }
            //    else if ((fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline))
            //    {
            //        cboLayer.Items.Add(fLayer.Name);
            //    }
            //    else if ((fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint))
            //    {
            //        cboLayer.Items.Add(fLayer.Name);
            //    }
            //    fLayer = allFLayers.Next() as IFeatureLayer;
            //}
        }

        private IGeoFeatureLayer GetLayerByName(string LayerName)
        {
            UID uid = new UID();
            // This is the ID for layers supporting the IGeoFeatureLayer interface
            uid.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
            IEnumLayer allFLayers;
            allFLayers = axMapControl1.ActiveView.FocusMap.get_Layers(uid, true);
            
            // Loop thru all FeatureLayers until LayerName is found
            ILayer layer;
            layer = allFLayers.Next();
            while (layer != null)
            {
                if ((layer.Name == LayerName))
                {
                    // Pass back the requested layer
                    return ((IGeoFeatureLayer)(layer));
                    //break; 
                }
                layer = allFLayers.Next();
            }
            return null;
            
        }

        private void OptionEnabler() {
        //Windows.Forms.Control cntrl;
        foreach (System.Windows.Forms.Control cntrl in this.Controls)
        {
            Console.WriteLine(cntrl.ToString());
            //Console.WriteLine(cntrl.Tag.ToString());
            //if ((cntrl.Tag.ToString() == "CheckEnable"))
            //{
            //    cntrl.Enabled = false;
            //    //next cntrl;
            //}
        }
        switch (m_strOption) 
        {
            case "Simple":
                lblR.Enabled = true;
                lblG.Enabled = true;
                lblB.Enabled = true;
                cboRed.Enabled = true;
                cboGreen.Enabled = true;
                cboBlue.Enabled = true;
                break;
            case "Unique":
                cboUniqueVals.Enabled = true;
                break;
            case "Breaks":
                cboNumericVals.Enabled = true;
                cboBreaks.Enabled = true;
                lblBreaks.Enabled = true;
                break;
            case "NoLayer":
                optSimple.Enabled = false;
                optUnique.Enabled = false;
                optBreaks.Enabled = false;
                break;
             
        }
    }

        private void FillFieldsComboBox(IFeatureLayer geoLayer)
        {
            //IFeatureClass fClass;
            //fClass = geoLayer.FeatureClass;
            //IFields fields;
            //fields = fClass.Fields;
            //cboNumericVals.Items.Clear();
            //cboUniqueVals.Items.Clear();
            //IField fld;
            //
            //for (int i = 0; (i 
            //            < (fields.FieldCount - 1)); i++)
            //{
            //    fld = fields.get_Field(i);
            //    //int fldType;
            //    //fldType = Convert.ToInt32(pFld.Type);
            //    if (Convert.ToInt32(fld.Type) <= 3) //if ((fld.Type <= 3))
            //    {
            //        cboNumericVals.Items.Add(fld.Name);
            //    }
            //    // numeric
            //    if (Convert.ToInt32(fld.Type) <= 5) //if ((fld.Type <= 5))
            //    {
            //        cboUniqueVals.Items.Add(fld.Name);
            //    }
            //    // not shape, OID, or BLOB
            //}
    }

        private void optBreaks_CheckedChanged(object sender, EventArgs e)
        {    
            m_strOption = "Breaks";
            OptionEnabler();
        }

        private void optSimple_CheckedChanged(object sender, EventArgs e)
        {    
            m_strOption = "Simple";
            OptionEnabler();
        }

        private void optUnique_CheckedChanged(object sender, EventArgs e)
        {
            m_strOption = "Unique";
            OptionEnabler();
        }

        private void btnStretch_Click(object sender, EventArgs e)
        {
            //IMap map;
            //map = axMapControl1.ActiveView.FocusMap;
            //IRasterLayer rLayer;
            //rLayer = map.get_Layer(0) as IRasterLayer;
            //IRaster raster;
            //raster = rLayer.Raster;
            //IRasterStretchColorRampRenderer stretchRen;
            //stretchRen = new RasterStretchColorRampRenderer();
            //IRasterRenderer rasRen;
            //rasRen = stretchRen as IRasterRenderer;
            //rasRen.Raster = raster;
            //rasRen.Update();

            //IRgbColor fromColor = new RgbColor();
            //fromColor.Red = 255;
            //fromColor.Green = 0;
            //fromColor.Blue = 0;

            //IRgbColor toColor;
            //toColor = new RgbColor();
            //toColor.Red = 0;
            //toColor.Green = 255;
            //toColor.Blue = 0;

            //IAlgorithmicColorRamp ramp;
            //ramp = new AlgorithmicColorRamp();
            //ramp.Size = 255;
            //ramp.FromColor = fromColor;
            //ramp.ToColor = toColor;
             
            //bool bTrue = true;
            //ramp.CreateRamp(out bTrue);
            //// Plug this colorramp into renderer and select a band
            //stretchRen.BandIndex = 0;
            //stretchRen.ColorRamp = ramp;
            //// Update the renderer with new settings and plug into layer
            //rasRen.Update();

            //rLayer.Renderer = stretchRen as IRasterRenderer;
            //axMapControl1.ActiveView.Refresh();
            //axTOCControl1.Update();

        }
  
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            //IMap map;
            //map = axMapControl1.ActiveView.FocusMap;
            //IFeatureLayer fLayer1;
            //IFeatureLayer fLayer2;
            //IFeatureLayer fLayer0;

            //// Instantiate your feature layers to current map layers
            //fLayer0 = map.get_Layer(2) as IFeatureLayer;
            //fLayer1 = map.get_Layer(1) as IFeatureLayer;
            //fLayer2 = map.get_Layer(0) as IFeatureLayer;
            //fLayer2.MinimumScale = 500000000;
            //MessageBox.Show(("Layer2 max scale: "
            //                + (fLayer2.Name + (" " + fLayer2.MaximumScale.ToString()))));
            //MessageBox.Show(("Layer2 min scale: " + fLayer2.MinimumScale.ToString()));

            //IFeatureLayer newFLayer;
            //newFLayer = new FeatureLayer();
            //newFLayer.Name = "USA";
            //IFeatureClass featureClass;
            //featureClass = fLayer1.FeatureClass;
            //newFLayer.FeatureClass = featureClass;
            //IGeoFeatureLayer geoFLayer0;
            //IGeoFeatureLayer geoFLayer1;
            //IGeoFeatureLayer geoFLayer2;
            //IGeoFeatureLayer newGeoFLayer;
            //geoFLayer0 = fLayer0 as IGeoFeatureLayer;
            //geoFLayer1 = fLayer1 as IGeoFeatureLayer;
            //geoFLayer2 = fLayer2 as IGeoFeatureLayer;
            //newGeoFLayer = newFLayer as IGeoFeatureLayer;

            //IScaleDependentRenderer scaleDependentRenderer;
            //scaleDependentRenderer = new ScaleDependentRenderer();
            //IFeatureRenderer renderer0;
            //IFeatureRenderer renderer1;
            //IFeatureRenderer renderer2;
            //renderer0 = geoFLayer0.Renderer;
            //renderer1 = geoFLayer1.Renderer;
            //renderer2 = geoFLayer2.Renderer;

            //// Build the new scale dependent renderer from the existing renderers.
            //scaleDependentRenderer.AddRenderer(renderer0);
            //scaleDependentRenderer.AddRenderer(renderer1);
            //scaleDependentRenderer.AddRenderer(renderer2);

            //// Set the scale threshholds for the renderers
            //// within the scale dependent renderer.
            //scaleDependentRenderer.set_Break(0, 10000000);
            //scaleDependentRenderer.set_Break(1, 50000000);
            //scaleDependentRenderer.set_Break(2, 500000000);

            //// Associate the scale dependent renderer with the new layer        
            //// Add the scale dependent renderer to the map
            //newGeoFLayer.Renderer = scaleDependentRenderer as IFeatureRenderer;
            //map.AddLayer(newGeoFLayer);
        }

        private void menuFile_Click(object sender, EventArgs e)
        {

        }
  

    } // end class

} // end namespace DisplayingData