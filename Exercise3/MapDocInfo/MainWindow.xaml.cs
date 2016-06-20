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
using ESRI.ArcGIS.Geodatabase;
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
            mapDoc.Open("C:\\IPAN\\Exercise08\\QueryFilters.mxd");
           /// IMap inMap = mapDoc.get_Map(0);//mapDoc.get_Map(0);
                m_map.Map =mapDoc.get_Map(0);
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

        private void btnLandlocked_Click(object sender, RoutedEventArgs e)
        {
            IFeatureLayer fLayer = this.m_map.get_Layer(2) as IFeatureLayer;//Country layer

            IFeatureClass fClass = fLayer.FeatureClass;

            IQueryFilter qFilter = new QueryFilter();
            qFilter.WhereClause = "LANDLOCKED=\'Y\'";
            //Query Method 1: search featues using IFeatureCursor
            IFeatureCursor fCursor = fClass.Search(qFilter, true);//Query Cursor

            double dblArea = 0;
            //
            long lngCountries = fClass.FeatureCount(qFilter);
            //Read feature from cursor
            IFeature feat = fCursor.NextFeature();
            while (feat != null)
            {
                dblArea += Convert.ToDouble(feat.get_Value(10));//11th field
                feat = fCursor.NextFeature();
            }
            MessageBox.Show(string.Format("Number of landlocked countries:{0}\r\n Area: {1:#} sq km", lngCountries, dblArea));

            //Query mthod2 : search features using IfeatureSelection and show them
            IFeatureSelection fSel = fLayer as IFeatureSelection;
            qFilter.WhereClause = "Population>100000000";
            fSel.SelectFeatures(qFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            //Using Symbol as renderer
            ISimpleFillSymbol sSym = new SimpleFillSymbol();
            sSym.Style = esriSimpleFillStyle.esriSFSSolid;
            IRgbColor blu = new RgbColor();
            blu.Blue = 255;
            sSym.Color = blu;
            fSel.SetSelectionSymbol = true;
            fSel.SelectionSymbol = sSym as ISymbol;

            //Label
            IMap iMap = this.m_map.Map;
            if (iMap is AnnotateMap)
            {
                MessageBox.Show("Casting is success");
            }
            //fSel.SelectionColor = blu;
            this.m_map.ActiveView.Refresh();
 
        }

        private void btnSpatial_Click(object sender, RoutedEventArgs e)
        {
            IFeatureSelection cntryLayer = this.m_map.get_Layer(2) as IFeatureSelection;
            ISelectionSet cntrySel;
            // code ommited 
            IQueryFilter qFilterCountry = new QueryFilter();
            qFilterCountry.WhereClause = "Population>200000000";//Country layer

            cntryLayer.SelectFeatures(qFilterCountry, esriSelectionResultEnum.esriSelectionResultNew, false);
            cntrySel = cntryLayer.SelectionSet;
            ICursor cntryCursor;
            //Generate Cursor from SelectionSet 
            cntrySel.Search(null, true, out cntryCursor);

            //Obtain spatial features 
            IFeatureCursor cntryFCursor = cntryCursor as IFeatureCursor;

            IFeatureLayer cntryFLayer = cntryLayer as IFeatureLayer;
            // cntryFCursor = cntryFLayer.Search(null, true);
            IFeature country = cntryFCursor.NextFeature();
            if (country == null)
            {
                MessageBox.Show("Please select a country!");
                //return;
            }
            else
            {
                MessageBox.Show("This is " + country.get_Value(6));
            }
            ISpatialFilter spatFilter = new SpatialFilter();
            IQueryFilter qFilter = spatFilter as IQueryFilter;
            qFilter.WhereClause = "Population>200000";//used to Cities layer

            //IFeatureDataset fDataset = cntryFLayer.FeatureClass.FeatureDataset;
            //IGeoDataset gDataset = fDataset as IGeoDataset;
            //spatFilter.Geometry = country.Shape;
            spatFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
            //Original code
            IFeatureLayer cityLayer = this.m_map.get_Layer(0) as IFeatureLayer;//Cities layer
            IFeatureClass cityFClass = cityLayer.FeatureClass;
            long lngCities = cityFClass.FeatureCount(spatFilter);//
            MessageBox.Show("This country has" + "\r\n" + lngCities.ToString() + " cities with population > 2,000,000");
            //Set the city selection by jin
            IFeatureSelection cityFeatureSel = cityLayer as IFeatureSelection;
            //Loop the countries selected
            while (country != null)
            {
                //Set SpatialFilter 
                spatFilter.Geometry = country.Shape;
                cityFeatureSel.SelectFeatures(spatFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                country = cntryFCursor.NextFeature();
            }
            IRgbColor green = new RgbColor();
            green.Green = 255;
            cityFeatureSel.SelectionColor = green;
            //Show the result
            this.m_map.ActiveView.Refresh();
 
        }

        private void btnSpatial_Click_1(object sender, RoutedEventArgs e)
        {
            IFeatureSelection cntryLayer = this.m_map.get_Layer(2) as IFeatureSelection;
            ISelectionSet cntrySel;
            // code ommited 
            IQueryFilter qFilterCountry = new QueryFilter();
            qFilterCountry.WhereClause = "Population>200000000";//Country layer

            cntryLayer.SelectFeatures(qFilterCountry, esriSelectionResultEnum.esriSelectionResultNew, false);
            cntrySel = cntryLayer.SelectionSet;
            ICursor cntryCursor;
            //Generate Cursor from SelectionSet 
            cntrySel.Search(null, true, out cntryCursor);

            //Obtain spatial features 
            IFeatureCursor cntryFCursor = cntryCursor as IFeatureCursor;

            IFeatureLayer cntryFLayer = cntryLayer as IFeatureLayer;
            // cntryFCursor = cntryFLayer.Search(null, true);
            IFeature country = cntryFCursor.NextFeature();
            if (country == null)
            {
                MessageBox.Show("Please select a country!");
                //return;
            }
            else
            {
                MessageBox.Show("This is " + country.get_Value(6));
            }
            ISpatialFilter spatFilter = new SpatialFilter();
            IQueryFilter qFilter = spatFilter as IQueryFilter;
            qFilter.WhereClause = "Population>200000";//used to Cities layer

            //IFeatureDataset fDataset = cntryFLayer.FeatureClass.FeatureDataset;
            //IGeoDataset gDataset = fDataset as IGeoDataset;
            //spatFilter.Geometry = country.Shape;
            spatFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
            //Original code
            IFeatureLayer cityLayer = this.m_map.get_Layer(0) as IFeatureLayer;//Cities layer
            IFeatureClass cityFClass = cityLayer.FeatureClass;
            long lngCities = cityFClass.FeatureCount(spatFilter);//
            MessageBox.Show("This country has" + "\r\n" + lngCities.ToString() + " cities with population > 2,000,000");
            //Set the city selection by jin
            IFeatureSelection cityFeatureSel = cityLayer as IFeatureSelection;
            //Loop the countries selected
            while (country != null)
            {
                //Set SpatialFilter 
                spatFilter.Geometry = country.Shape;
                cityFeatureSel.SelectFeatures(spatFilter, esriSelectionResultEnum.esriSelectionResultAdd, false);
                country = cntryFCursor.NextFeature();
            }
            IRgbColor green = new RgbColor();
            green.Green = 255;
            cityFeatureSel.SelectionColor = green;
            //Show the result
            this.m_map.ActiveView.Refresh();
 
        }
    }
}
