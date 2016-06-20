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
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using stdole;

namespace MapDocInfo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        AxMapControl m_map = new AxMapControl();
        AxTOCControl m_toc = new AxTOCControl();
        AxToolbarControl m_toolbar = new AxToolbarControl();
         public MainWindow()
        {
            InitializeComponent();
            this.mapControlHost.Child = this.m_map;
            this.toolbarHost.Child = this.m_toolbar;
            this.tocHost.Child = this.m_toc;

        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (this.m_map.Map is IActiveView)
            {
                //Cast Imap to IActiveView
                IActiveView actView = (IActiveView)this.m_map.ActiveView;
                //System.Diagnostics.Debug.WriteLine("Test map is "+mapDoc.MapCount);
                // Console.Out.WriteLine("The sum of maps is " + mapDoc.MapCount);
                Console.Out.WriteLine("The first map is " + this.m_map.Map.Name);
                Console.Out.WriteLine("The actView map is " + actView.FocusMap.Name);
                //axMapControl1.LoadMxFile(mapDoc.DocumentFilename);
                //method 3, Set a map directly
                IEnvelope env = actView.Extent;
                MessageBox.Show("Min(" + env.XMin.ToString() + "," + env.XMin + "),Max(" + env.XMax.ToString() + "," + env.YMax + ")");
            }
 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
         //   m_map.LoadMxFile("C:\\IPAN\\Exercise02\\SouthAmerica.mxd", 0, null);

            IMapDocument mapDoc = new MapDocument();
            mapDoc.Open("C:\\IPAN\\Exercise02\\SouthAmerica.mxd");
           /// IMap inMap = mapDoc.get_Map(0);//mapDoc.get_Map(0);
                m_map.Map =mapDoc.get_Map(1);
                m_toc.SetBuddyControl(m_map);
                m_toolbar.SetBuddyControl(m_map);
                m_toolbar.AddItem("esriControls.ControlsMapNavigationToolbar");
  
        }

        private void btnLabel_Click(object sender, RoutedEventArgs e)
        {
            //The FeatureLayer for labelling


            IFeatureLayer labelLayer = this.m_map.Map.get_Layer(0) as IFeatureLayer;
            IGeoFeatureLayer gLabelLayer = labelLayer as IGeoFeatureLayer;
            IAnnotateLayerPropertiesCollection annoPropCol = gLabelLayer.AnnotationProperties;
            annoPropCol.Clear();
            //ITextSymbol uasage
            ITextSymbol pTextSyl = new TextSymbol();
            //Font fnt = new System.Drawing.Font("宋体", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            //using stdole
            IFontDisp font = new StdFont() as IFontDisp;
            font.Size = 20;
            font.Italic = true;
            // pTextSyl.Size = 20;
            pTextSyl.Font = font;
            //IRgbColor fromColor = new RgbColor(255,0, 0);
            //ESRI.ArcGIS.Display.RgbColorClass()
            RgbColor color = new RgbColor();
            color.Red = 255;
            color.Green = 0;
            color.Blue = 0;
            pTextSyl.Color = color;
            //Position
            IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerProperties();

            //   if (labelLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            //   {
            IPointPlacementPriorities pPlacementPoint = new PointPlacementPriorities();
            pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
            pBasic.PointPlacementPriorities = pPlacementPoint;
            pBasic.PointPlacementOnTop = false;
            pBasic.PointPlacementMethod = esriOverposterPointPlacementMethod.esriOnTopPoint;// esriAroundPoint;
            //      }

            //Point a field as a label
            ILabelEngineLayerProperties labelField = new LabelEngineLayerProperties() as ILabelEngineLayerProperties;
            labelField.Expression = "[name]";
            //set postion
            labelField.BasicOverposterLayerProperties = pBasic;
            //set  symbol
            labelField.Symbol = pTextSyl;
            IAnnotateLayerProperties annoProp = labelField as IAnnotateLayerProperties;
            annoPropCol.Add(annoProp);
            gLabelLayer.DisplayAnnotation = true;
            m_map.Refresh();
        }
    }
}
