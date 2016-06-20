using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.CartoUI;



namespace DisplayLayers2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AxMapControl m_mapControl = new AxMapControl();
        AxToolbarControl m_toolbar = new AxToolbarControl();
        IMapDocument m_mapDoc =new MapDocument();
        IMap m_map;
        private string m_strOption = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            this.mapControlHost.Child =m_mapControl;
            this.toolbarHost.Child = this.m_toolbar;
        }

        private void windowsFormsHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
                       m_mapDoc.Open("E:\\Student\\IPAN\\Exercise07\\Rendering.mxd");
            this.cbxActiveMap.Items.Clear();
            for (int i = 0; i < m_mapDoc.MapCount; i++)
            {
                m_map = m_mapDoc.get_Map(i);
                this.cbxActiveMap.Items.Add(m_map.Name);
            }

        }

        private void cbxActiveMap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            m_map= m_mapDoc.get_Map(this.cbxActiveMap.SelectedIndex);
            m_toolbar.SetBuddyControl(m_mapControl);
            m_toolbar.AddItem("esriControls.ControlsMapNavigationToolbar");
            this.cbxFeatureLayer.Items.Clear();
            AddLayersToComboBox();
 
        }
        private void AddLayersToComboBox()
        {

            UID uidLayer = new UIDClass();
            uidLayer.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
            //IMap map = axMapControl1.ActiveView.FocusMap;

            IEnumLayer allFLayers;
            allFLayers = m_map.get_Layers(uidLayer, true);

            IFeatureLayer fLayer;
            fLayer = allFLayers.Next() as IFeatureLayer;
            while (fLayer != null)
            {
                if ((fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon))
                {
                    this.cbxFeatureLayer.Items.Add(fLayer.Name);
               }
                else if ((fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline))
                {
                                       this.cbxFeatureLayer.Items.Add(fLayer.Name);
                        }
                else if ((fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint))
                {
                    cbxFeatureLayer.Items.Add(fLayer.Name);
                }
                fLayer = allFLayers.Next() as IFeatureLayer;
            }
        }

        private void cbxFeatureLayer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ILayer fLayer;
            fLayer = m_map.get_Layer(this.cbxFeatureLayer.SelectedIndex);
            this.FillFieldsComboBox(fLayer);
            if (m_mapControl.Map.LayerCount == 1)
            {
                ILayer layer = m_mapControl.Map.get_Layer(0);
                m_mapControl.Map.DeleteLayer(layer);
            }
            m_mapControl.Map.AddLayer(fLayer);
            m_mapControl.Refresh();
  
        }

        private void rbtnUnique_Checked(object sender, RoutedEventArgs e)
        {
            m_strOption = "Unique";
 
        }
        private void FillFieldsComboBox(ILayer layer)
        {
            IFeatureClass fClass;
            IFeatureLayer fLayer = (IFeatureLayer)layer;
            fClass = fLayer.FeatureClass;
            IFields fields;
            fields = fClass.Fields;
            this.cbxClassBreak.Items.Clear();
            this.cbxUnique.Items.Clear();
            IField fld;
            
            for (int i = 0; (i < (fields.FieldCount - 1)); i++)
            {
                fld = fields.get_Field(i);
                int fldType;
                fldType = Convert.ToInt32(fld.Type);
                if (Convert.ToInt32(fld.Type) <= 3) //if ((fld.Type <= 3))
                {
                  this.cbxClassBreak.Items.Add(fld.Name);
                }
                // numeric
                if (Convert.ToInt32(fld.Type) <= 5) //if ((fld.Type <= 5))
                {
                   this.cbxUnique.Items.Add(fld.Name);
                }
                // not shape, OID, or BLOB
            }
        }

        private void rbunClass_Checked(object sender, RoutedEventArgs e)
        {
            m_strOption = "Breaks";

        }

        private void btnRenderer_Click(object sender, RoutedEventArgs e)
        {
            IGeoFeatureLayer geoLayer;
            geoLayer = (IGeoFeatureLayer)m_mapControl.Map.get_Layer(0);
            switch (m_strOption)
            {
                case "Simple":

                // user-written code



                case "Unique":
                   // ApplyUniqueValue(geoLayer, this.cbxUnique.Text);
                    break;
                case "Breaks":
                    ApplyClassBreaks(geoLayer, this.cbxClassBreak.Text, long.Parse(cbxClassBreak.Text));
                    break;
                default:
                    //return;
                    break;
            }

        }
        public void ApplyClassBreaks(IGeoFeatureLayer geoLayer, string aFieldName, long numBreaks)
        {
            //  Create a table from the geo feature layer
            ITable table;
            table = geoLayer as ITable;
            ITableHistogram tableHistogram;
            tableHistogram = new BasicTableHistogramClass();
            tableHistogram.Table = table;
            // equivalent to geoLayer.FeatureClass
            //  Retrieve frequency data from the field
            tableHistogram.Field = aFieldName;
            // MessageBox.Show("Field is: " & tableHistogram.Field)

            IHistogram histogram;
            histogram = tableHistogram as IHistogram;
            object vValues;
            object vFreqs;
            histogram.GetHistogram(out vValues, out vFreqs);

            //  Classify the data
            IClassifyGEN classifyGEN = new EqualIntervalClass();

            int intBreaks;
            intBreaks = Convert.ToInt32(numBreaks);
            classifyGEN.Classify(vValues, vFreqs, ref intBreaks);

            double[] vBreaks = (double[])classifyGEN.ClassBreaks; // need an array

            //  Create the class breaks renderer
            IClassBreaksRenderer classBreaksRenderer;
            classBreaksRenderer = new ClassBreaksRendererClass();
            classBreaksRenderer.Field = aFieldName;
            //  passed as a String to the sub routine
            classBreaksRenderer.BreakCount = (int)(numBreaks);

            IRgbColor fromColor = new RgbColorClass();
            fromColor.UseWindowsDithering = true;
            fromColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 255, 0);

            IRgbColor toColor = new RgbColorClass();
            toColor.UseWindowsDithering = true;
            toColor.RGB = Microsoft.VisualBasic.Information.RGB(255, 0, 0);

            //  Set up the fill symbol
            ISimpleFillSymbol sym = new SimpleFillSymbolClass();
            IColor fillColor;

            MessageBox.Show("vBreaks.Length: " + vBreaks.Length.ToString());

            IEnumColors colors;
            colors = GetColors(fromColor.RGB, toColor.RGB, numBreaks);

            for (int i = 0; (i <= vBreaks.Length - 2); i++) // Length = 6; subtracted 2; why??
            {  
                fillColor = colors.Next();
                sym.Color = fillColor;

                classBreaksRenderer.set_Break(i, vBreaks[(i + 1)]);
                classBreaksRenderer.set_Symbol(i, sym as ISymbol);

                geoLayer.Renderer = classBreaksRenderer as IFeatureRenderer;
                this.m_mapControl.ActiveView.Refresh();
                this.m_toolbar.Update();
            }
        }
        public IEnumColors GetColors(long lngStartColor, long lngEndColor, long Colors)
        {
            IRgbColor startColor = new RgbColor();
            IRgbColor endColor = new RgbColor();  

            startColor.RGB = Convert.ToInt32(lngStartColor);
            endColor.RGB = Convert.ToInt32(lngEndColor);

            IAlgorithmicColorRamp ramp;
            ramp = new AlgorithmicColorRamp();
            ramp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            ramp.FromColor = startColor;
            ramp.ToColor = endColor;
            ramp.Size = Convert.ToInt32(Colors);
            bool blnIsRampOK;
            ramp.CreateRamp(out blnIsRampOK);
            if (!blnIsRampOK)
            {
            return null;
            }
            else
            {
                return ramp.Colors;
            }
        }


    }
}
