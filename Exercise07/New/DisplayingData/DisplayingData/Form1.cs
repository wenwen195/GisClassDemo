using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using Microsoft.VisualBasic;


namespace DisplayingData
{
    public partial class MainForm : Form
    {
        private static string Simple_RENDER = "simple";
        private static string UNIQUE_RENDER = "unique";
        private static string BREAK_RENDER="break";
        private string m_strOption;
        private IMapControl3 m_mapControl = null;
        private IMapDocument m_mapDocument=new MapDocument();//jin
        private IMap m_map;//jin 
        private string m_mapDocuemntName = string.Empty;
        private ILayer m_layer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuNewDoc_Click(object sender, EventArgs e)
        {
           // ICommand command;
        }

 
        private void lblR_Click(object sender, EventArgs e)
        {

        }

        private void cboBlue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblBlue_Click(object sender, EventArgs e)
        {

        }

        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetControl();
        }
        private void SetControl(){
            string strLayerName = cboLayer.Text;
            if (!strLayerName.Equals(""))
            {
                btnRender.Enabled = true;
                btnChangeRGBRenderer.Enabled = true;
                btnSaveLayer.Enabled = true;
                optSimple.Enabled = true;
                optUnique.Enabled = true;
                optBreaks.Enabled = true;
                //
                optChart.Enabled = true;
                //default setting
                optSimple.Equals(true);
                optSimple.Checked = true;
                //Seeting TocControls 
                
            }
            else
            {
                btnRender.Enabled = false;
                m_strOption = "NoLayer";
                OptionEnabler();
                return;
            }

            IFeatureLayer fLayer = GetLayerByName(strLayerName);
            FillFieldsCombox(fLayer);
            return;

        }
        private void FillFieldsCombox(IFeatureLayer geoLayer)
        {
            IFeatureClass fClass = geoLayer.FeatureClass;
            IFields fields = fClass.Fields;
            cboNumericVals.Items.Clear();
            cboUniqueVals.Items.Clear();
            //jin
            cbxProp1.Items.Clear();
            IField fld;
            for (int i = 0; i < (fields.FieldCount - 1); i++)
            {
                fld = fields.get_Field(i);
                if(Convert.ToInt32(fld.Type)<=3){
                    cboNumericVals.Items.Add(fld.Name);
                }
                if(Convert.ToInt32(fld.Type)<=5){
                    cboUniqueVals.Items.Add(fld.Name);
                    //Jin
                    cbxProp1.Items.Add(fld.Name);

                }

            }
        }


        private void lblGreen_Click(object sender, EventArgs e)
        {

        }

        private void obtUniqueVals_CheckedChanged(object sender, EventArgs e)
        {
            m_strOption = "Unique";
            OptionEnabler();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Custom
        private IGeoFeatureLayer GetLayerByName(string LayerName)
        {
            UID uid = new UID();
            uid.Value = "{E156D7E5-22AF-11D3-9f99-00C04F6BC78E}";
            IEnumLayer allFLayers = axMapControl1.ActiveView.FocusMap.get_Layers(uid, true);
            //loop until LayerName is found
            ILayer layer;
            layer = allFLayers.Next();
            while (layer !=null)
            {
                if(layer .Name.Equals(LayerName)){
                    return layer as IGeoFeatureLayer;
                }
                layer = allFLayers.Next();
            }
            return null;
        }
        //
        public void ApplySimple(IGeoFeatureLayer geoLayer, ISymbol aSymbol)
        {
            //SimpleRender is not engaged with feature data 
            //Old code
            // ISimpleRenderer simpleRender = new SimpleRenderer();
             //geoLayer.Renderer = simpleRender as IFeatureRenderer;
            //Get the render of the GeoFeatureLayer
            ISimpleRenderer simpleRender = geoLayer.Renderer as ISimpleRenderer;
            simpleRender.Symbol = aSymbol as ISymbol;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();
        }
        public void ApplyBarChartValue(IGeoFeatureLayer geoLayer, string aFieldName)
        {
           
            //IChartRender is engaged with feature data 
            IChartRenderer chartRender = new ChartRenderer();
            IRendererFields renderFields = chartRender as IRendererFields;
            renderFields.AddField(aFieldName);
            //Search Max
            IQueryFilter queryFilter = new QueryFilter();
            //Content in Cursor
            queryFilter.AddField(aFieldName);
            //Search all features without WhereClause
            IFeatureCursor fCursor=geoLayer.FeatureClass.Search(queryFilter,true);
            //the index of Field
            int indexField = fCursor.FindField(aFieldName);
            List<double> valueList = new List<double>();
            IFeature aFeature = fCursor.NextFeature();
            while (aFeature != null)
            {
                valueList.Add(Convert.ToDouble(aFeature.get_Value(indexField)));
                aFeature = fCursor.NextFeature();
            }
            //BarChartSymbol
            IBarChartSymbol barSymbol = new BarChartSymbol() as IBarChartSymbol;
            barSymbol.Width = 12;
            IChartSymbol chartSym = barSymbol as IChartSymbol;
            //
            chartSym.MaxValue = valueList.Max();
            IMarkerSymbol markerSymbol = (IMarkerSymbol)chartSym;
            markerSymbol.Size = 50;
            //Set Symbol 
            ISymbolArray pSymbolArray = (ISymbolArray)barSymbol;
            IRgbColor aColor = new RgbColor();
            aColor.Red = Convert.ToInt32(255);
            aColor.Green = Convert.ToInt32(255);
            aColor.Blue = Convert.ToInt32(0);
            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbol();
            pFillSymbol.Color = aColor;
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);

            //Render Attribute
            chartRender.ChartSymbol = (IChartSymbol)barSymbol;
            chartRender.Label = "指标";
            chartRender.UseOverposter = false;
            chartRender.CreateLegend();
           
            //Back Ground
            ISimpleFillSymbol bgSym = new SimpleFillSymbol();
            IRgbColor bgColor = new RgbColor();
            bgColor.Red = Convert.ToInt32(239);
            bgColor.Green = Convert.ToInt32(228);
            bgColor.Blue = Convert.ToInt32(190);
            bgSym.Color = bgColor;
            //bgSym.Color = Convert.ToInt32(System.Drawing.Color.FromArgb(239, 228, 190));
            chartRender.BaseSymbol = (ISymbol)bgSym;

            //Render Label
            geoLayer.ScaleSymbols = true;
            //Scale Symbol
            geoLayer.Renderer = chartRender as IFeatureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();

        }

        public void ApplyUniqueValue(IGeoFeatureLayer geoLayer,string aFieldName)
        {
            //UniqueRender is engaged with feature data 
             IUniqueValueRenderer uniqueRender = new UniqueValueRenderer();
            uniqueRender.FieldCount = 1;
            uniqueRender.set_Field(0, aFieldName);
            //Pointer
            int intFieldIndex = geoLayer.FeatureClass.FindField(aFieldName);
            //Create a ColorRamp with 16 colors
            IRandomColorRamp randomColors = new RandomColorRamp();
            randomColors.Size = 256;
            bool bOK;
            randomColors.CreateRamp(out bOK);
            if (!bOK){
                return;
            }
            IEnumColors enumColor = randomColors.Colors;
            //May be used only to Polygon
            ISymbol pSym=null; 
            //ISimpleFillSymbol sym;
            IColor color;
            //Query
            IFeatureCursor fCursor;
            IQueryFilter qFilter = new QueryFilter();
            qFilter.SubFields = aFieldName;
            fCursor = geoLayer.FeatureClass.Search(qFilter, true);
             IFeature feature = fCursor.NextFeature();
            while(feature!=null){
                color = enumColor.Next();
                if (color == null)
                {
                    enumColor.Reset();
                    color = enumColor.Next();
                }
                //code by jin, old is only used to Polygon Feature
                if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    ISimpleFillSymbol sym = new SimpleFillSymbol();                
                    sym.Style = esriSimpleFillStyle.esriSFSSolid;
                    sym.Color = color;
                    pSym = sym as ISymbol;


                }
                else if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    ISimpleLineSymbol sym = new SimpleLineSymbol();
                    sym.Style = esriSimpleLineStyle.esriSLSSolid;
                    sym.Color = color;
                    pSym = sym as ISymbol;
                }
                else
                {
                    ISimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                    sym.Style = esriSimpleMarkerStyle.esriSMSCircle;
                    sym.Color = color;
                    pSym = sym as ISymbol;
                }

                Console.WriteLine(feature.get_Value(intFieldIndex).ToString());
               //uniqueRender.AddValue(feature.get_Value(intFieldIndex).ToString(), "", ((ISymbol)(sym)));
                //the dynamic COM binder does not support the get_Range syntax exposed in C# before indexed properties were supported. 
                //modified following by jin 
                string codeValue=feature.get_Value(intFieldIndex).ToString();
                //将
                uniqueRender.AddValue(codeValue,"",pSym);
                feature = fCursor.NextFeature();
            }
            geoLayer.Renderer = uniqueRender as IFeatureRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();
            
        }
        public void ApplyClsssBreaks(IGeoFeatureLayer geoLayer,string aFieldName,long numBreaks)
        {
            //Create a Table from the geofeature layer
            ITable table = geoLayer as ITable;
            //ITableHistogram tableHistogram=new TableHistogram(); that is error but canbe coded by following
            TableHistogram tableHistogram2 = new TableHistogram();
            ITableHistogram tableHistogram = tableHistogram2 as ITableHistogram;
            tableHistogram.Table = table;
            tableHistogram.Field = aFieldName;
            IHistogram histogram = tableHistogram as IHistogram;
            object vValues;
            object vFregs;
            //先统计每个值和各个值出现的次数
            histogram.GetHistogram(out vValues, out vFregs);

            //Classify the data
            IClassifyGEN classifyGEN = new EqualInterval();
            int intBreaks = Convert.ToInt32(numBreaks);
            classifyGEN.Classify(vValues, vFregs, ref intBreaks);

            double[] vBreaks =(double[]) classifyGEN.ClassBreaks;
            //books
            int classCount = vBreaks.GetUpperBound(0);
            //Create the ClassBreaksRenderer
            IClassBreaksRenderer classBreaksRenderer = new ClassBreaksRenderer();
            //assigh a field as breaked
            classBreaksRenderer.Field = aFieldName;
            //passed as a string to the sub routine
            //classBreaksRenderer.BreakCount =classCount;
            classBreaksRenderer.BreakCount = (int)(numBreaks);
            classBreaksRenderer.SortClassesAscending = false;


            IRgbColor fromColor = new RgbColor();
            fromColor.UseWindowsDithering = true;
            fromColor.RGB = Information.RGB(0,0,255);
            IRgbColor toColor = new RgbColor();
            toColor.UseWindowsDithering = true;
            toColor.RGB = Information.RGB(255, 0, 0);
            //Set up the fill symbol
            ISymbol pSym;
            //ISimpleFillSymbol sym = new SimpleFillSymbol();
            IColor fillColor;
            MessageBox.Show("vBreaks.Length: " + vBreaks.Length.ToString());

            IEnumColors colors=GetColors(fromColor.RGB,toColor.RGB,numBreaks);
            for (int i = 0; i <= (vBreaks.Length - 2); i++)
            {
                fillColor = colors.Next();
                //code by jin
                if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    ISimpleFillSymbol sym = new SimpleFillSymbol();
                    sym.Color = fillColor;
                    pSym = sym as ISymbol;
                }
                else if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                {
                    ISimpleLineSymbol sym = new SimpleLineSymbol();
                    sym.Color = fillColor;
                    pSym = sym as ISymbol;
                }
                else
                {
                    ISimpleMarkerSymbol sym = new SimpleMarkerSymbol();
                    sym.Color = fillColor;
                    pSym = sym as ISymbol;
                }
                classBreaksRenderer.set_Break(i, vBreaks[i + 1]);
                classBreaksRenderer.set_Symbol(i, pSym);
                geoLayer.Renderer = classBreaksRenderer as IFeatureRenderer;
                axMapControl1.ActiveView.Refresh();
                axTOCControl1.Update();
            }



        }
        private IEnumColors GetColors(long lngStartColor, long lngEndColor, long colors)
        {
            IRgbColor startColor = new RgbColor();
            IRgbColor endColor = new RgbColor();
            startColor.RGB = Convert.ToInt32(lngStartColor);
            endColor.RGB = Convert.ToInt32(lngEndColor);
            IAlgorithmicColorRamp ramp = new AlgorithmicColorRamp();
            ramp.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            ramp.FromColor = startColor;
            ramp.ToColor = endColor;
            ramp.Size = Convert.ToInt32(colors);
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

        private void  btnRender_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoLayer = GetLayerByName(cboLayer.Text);
            MessageBox.Show(geoLayer.FeatureClass.ShapeType.ToString());
            switch (m_strOption)
            {
                //
                case "Simple" :
                    IRgbColor rgbColor = new RgbColor();
                    rgbColor.Red = Convert.ToInt32(cboRed.Text);
                    rgbColor.Green = Convert.ToInt32(cboGreen.Text);
                    rgbColor.Blue = Convert.ToInt32(cboGreen.Text);
                    //only used to Polygon Layer
                    ISymbol sym=null;
                    //Acording the shape type, use different sympol 
                    if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {//Polygon Feature
                        //Orginate Code
                       // ISimpleFillSymbol fillSym = new SimpleFillSymbol() ;
                       //sym.style
                     //   fillSym.Style = esriSimpleFillStyle.esriSFSSolid;
                        //sym.color
                     //   fillSym.Color = rgbColor;
                        //new Code for IGradientFillSymbol by jin 
                        IGradientFillSymbol fillSym = new GradientFillSymbol();
                        fillSym.Style = esriGradientFillStyle.esriGFSBuffered;
                        IRgbColor fromColor = new RgbColor();
                        fromColor.Red = 255;
                        fromColor.Green = 0;
                        fromColor.Blue = 0;
                        IRgbColor toColor = new RgbColor();
                        toColor.Red = 0;
                        toColor.Green = 0;
                        toColor.Blue = 255;
                        IAlgorithmicColorRamp ramp = new AlgorithmicColorRamp();
                        ramp.Size = 16;
                        ramp.FromColor = fromColor;
                        ramp.ToColor = toColor;
                        fillSym.ColorRamp = ramp;

                        sym = fillSym as ISymbol;
                    }
                    else if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                    {//Line Feature
                       // ISimpleLineSymbol lineSym = new SimpleLineSymbol();
                       // lineSym.Style = esriSimpleLineStyle.esriSLSSolid;
                       // lineSym.Color = rgbColor;
                       // sym = lineSym as ISymbol;
                        //
                        ICartographicLineSymbol cartLineSym = new CartographicLineSymbol();
                        cartLineSym.Color = rgbColor;
                        cartLineSym.Cap = esriLineCapStyle.esriLCSSquare;
                        cartLineSym.Join = esriLineJoinStyle.esriLJSMitre;
                        
                        ISimpleLineDecorationElement pSimpleLineDecoEle = new SimpleLineDecorationElement();
                        pSimpleLineDecoEle.FlipAll = true;
                        pSimpleLineDecoEle.FlipFirst = true;
                        ILineDecoration pLineDeco= new LineDecoration();
                        pLineDeco.AddElement(pSimpleLineDecoEle);
//􀑻􂫳􀏔􀏾􀠊􀳒􃒓􃃺􀧋
//QI􀋈􂊼􁛣􀏟􄴶􂱘􀒷􂷕􀋈􂫼􀑢􀗂􄽄􃒓􂱘􁶤􀑯􁈲􁗻
                        ILineProperties pLinePro = cartLineSym as ILineProperties;
                        pLinePro.LineDecoration = pLineDeco;

                        sym = cartLineSym as ISymbol;

                    }
                    else if (geoLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    {//Point Feature
                        ISimpleMarkerSymbol marketSym = new SimpleMarkerSymbol();
                        marketSym.Style = esriSimpleMarkerStyle.esriSMSCircle;//;esriSMSX;cross
                        marketSym.Color = rgbColor;
                        sym = marketSym as ISymbol;
     
                    }
                    
                    ApplySimple(geoLayer, sym);
                    break;
                case "Unique" :
                    ApplyUniqueValue(geoLayer,cboUniqueVals.Text);
                    break;
                case "Chart":
                    ApplyBarChartValue(geoLayer, cbxProp1.Text);
                    break;
                case "Breaks" :
                    ApplyClsssBreaks(geoLayer, cboNumericVals.Text, long.Parse(cboBreaks.Text));
                    break;
                default:
                    break;
            }
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
            //execute Open document
            ICommand command = new ControlsOpenDocCommand();
            command.OnCreate(m_mapControl.Object);//object is axMapControl1
            command.OnClick();
            //added by jwz
            RefreshMap();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Set MapControl object
            m_mapControl = axMapControl1.Object as IMapControl3;
            menuSaveDoc.Enabled = false;
            //SymbloControl
            axSymbologyControl1.Width = 298;
            //Map has not been loaded
            //AddLayersToComboBox();
            for (int i = 0; i < 255; i++)
            {
                if((i>1)&&(i<11)){
                    cboBreaks.Items.Add(i);
                }
                cboRed.Items.Add(i);
                cboGreen.Items.Add(i);
                cboBlue.Items.Add(i);
                cboRed.Text = "0";
                cboGreen.Text = "0";
                cboBlue.Text = "0";
            }
            //initialising controls by jin
            btnRender.Enabled = false;
            btnChangeRGBRenderer.Enabled = false;
            optSimple.Enabled = false;
            optBreaks.Enabled = false;
            optUnique.Enabled = false;
            btnSaveLayer.Enabled = false;
            btnChangeRGBRenderer.Enabled = false;
            btnScale.Enabled = false;

        }
        //Cutomer by jin
        private void AddLayersToComboBox()
        {
            //Add ed by jin
            cboLayer.Items.Clear();
            UID uidLayer = new UID();
            uidLayer.Value = "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}";
            IMap map = axMapControl1.ActiveView.FocusMap;
            
            //UID is inconsistent
            //IEnumLayer allFLayers = map.get_Layers(uidLayer, true);
            IEnumLayer allFLayers = map.get_Layers(null,true);
            //
            ILayer aLayer=allFLayers.Next();
                while (aLayer != null)
                {
                    if (aLayer is IRasterLayer)
                    {
                        MessageBox.Show(aLayer.Name);
                        m_strOption = "NoLayer";
                        OptionEnabler();
                    }
                    else if (aLayer is IFeatureLayer)
                    {

                        IFeatureLayer fLayer = aLayer as IFeatureLayer;
                        if (fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
                        {
                            cboLayer.Items.Add(fLayer.Name);
                        }
                        else if (fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
                        {
                            cboLayer.Items.Add(fLayer.Name);
                        }
                        else if (fLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                        {
                            cboLayer.Items.Add(fLayer.Name);
                        }
                        
                    }
                    aLayer = allFLayers.Next();
                }
           

        }

        private void menuSaveDoc_Click(object sender, EventArgs e)
        {

        }

        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            ICommand command = new ControlsSaveAsDocCommandClass();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optSimple_CheckedChanged(object sender, EventArgs e)
        {
            m_strOption = "Simple";
            OptionEnabler();
        }
        private void OptionEnabler()
        {
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
                case "Chart":
                    cbxProp1.Enabled = true;
                    cbxProp2.Enabled = true;
                    break;
                case "NoLayer":
                    optSimple.Enabled = false;
                    optUnique.Enabled = false;
                    optBreaks.Enabled = false;
                    optChart.Enabled = false;
                    break;

            }

        }

        private void optBreaks_CheckedChanged(object sender, EventArgs e)
        {
            m_strOption = "Breaks";
            OptionEnabler();

        }

        private void btnChangeRGBRenderer_Click(object sender, EventArgs e)
        {
            //Only effective to Raster Layer
            IMap map = axMapControl1.ActiveView.FocusMap;
            ILayer aLayer = map.get_Layer(0);
            //IRasterLayer rLayer = map.get_Layer(3) as IRasterLayer;
            //IRasterLayer rLayer = (IRasterLayer)aLayer;
            IRasterLayer rLayer = aLayer as IRasterLayer;
            IRaster raster = rLayer.Raster;

            IRasterBandCollection bandCol = raster as IRasterBandCollection;
            if (bandCol.Count<3){
                //not meet the requirements
                return;
            }
            IRasterRGBRenderer rgbRen = new RasterRGBRenderer();
            IRasterRenderer rasRen = rgbRen as IRasterRenderer;
            rasRen.Raster = raster;
            rasRen.Update();
            //change band ro renderer
            rgbRen.RedBandIndex = 2;
            rgbRen.GreenBandIndex = 1;
            rgbRen.BlueBandIndex = 0;


            //updtae renderer and refresh layer
            rLayer.Renderer = rgbRen as IRasterRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();
          
        }

        private void btnStretch_Click(object sender, EventArgs e)
        {
            IMap map = axMapControl1.ActiveView.FocusMap;
            IRasterLayer rLayer = map.get_Layer(0) as IRasterLayer;
            IRaster raster = rLayer.Raster;

            IRasterStretchColorRampRenderer stretchRen = new RasterStretchColorRampRenderer();
            IRasterRenderer rasRen = stretchRen as IRasterRenderer;
            rasRen.Raster = raster;
            rasRen.Update();
            IRgbColor fromColor = new RgbColor();
            fromColor.Red = 255;
            fromColor.Green = 0;
            fromColor.Blue = 0;

            IRgbColor toColor = new RgbColor();
            toColor.Red = 0;
            toColor.Green = 255;
            toColor.Blue = 0;

            IAlgorithmicColorRamp ramp = new AlgorithmicColorRamp();
            ramp.Size = 255;
            ramp.FromColor = fromColor;
            ramp.ToColor = toColor;
            bool bTrue = true;
            //Special syntax
            ramp.CreateRamp(out bTrue);
            //plug this colorramp ubti renderer and select a band
            stretchRen.BandIndex=1;//0
            stretchRen.ColorRamp=ramp;
            rasRen.Update();
            rLayer.Renderer=stretchRen as IRasterRenderer;
            axMapControl1.ActiveView.Refresh();
            axTOCControl1.Update();

        }

        private void axMapControl1_OnMapReplaced(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEvent e)
        {
            
            m_mapDocuemntName = m_mapControl.DocumentFilename;//axMapControl1 has no DocumentFilename property
            if (m_mapDocuemntName.Equals(string.Empty))
            {
                menuSaveDoc.Enabled = false;
                statusBarXY.Text = string.Empty;
            }
            else
            {
                menuSaveDoc.Enabled = true;
                statusBarXY.Text = System.IO.Path.GetFileName(m_mapDocuemntName);

            }
            //RefreshMap();
        }
        private void RefreshMap()
        {
            //added by jin
            try
            {

                cboActiveMap.Items.Clear();
                //  MessageBox.Show("Map is replaced");
                //Method 1: Open MapDocument file to get information about maps
               // m_mapDocument.Open(m_mapDocuemntName, "");
                //Method 2: Get information about maps from MapControl3 
                m_mapDocument.Open(m_mapControl.DocumentFilename, "");
               for (int i = 0; i < m_mapDocument.MapCount; i++)
                {
                    string item = m_mapDocument.get_Map(i).Name;
                    cboActiveMap.Items.Add(item);

                }
                //Initialization 
                cboActiveMap.Text = m_mapDocument.get_Map(0).Name;
                //The exception will be throwed,but it runes successfully in Exercise 5, may be a trouble for thread running 
                //axMapControl1.Map = m_mapDocument.get_Map(0);
                //axMapControl1.Map = m_mapDocument.ActiveView.FocusMap;
                m_mapDocument.Close();
                //   axMapControl1.Refresh();
                // axTOCControl1.Update();
                AddLayersToComboBox();
            }
            catch (StackOverflowException se)
            {
                Console.WriteLine(se.Message);
            }

        }
        private void ShowRasterInfo(IRasterLayer rLayer)

        {
            rtxbRasterInfo.Text = "Boand Number is " + rLayer.BandCount.ToString();// "\r\n" +"Resolution is " + rLayer.DisplayResolutionFactor.ToString() + "\r\n" + "Row number is " + rLayer.RowCount.ToString();
            IRaster raster = rLayer.Raster;
            //Raster Data
            IRasterBandCollection rBandCon = raster as IRasterBandCollection;
            int numBands = rBandCon.Count;
            for (int i = 0; i < numBands; i++)
            {
                //
                IRasterBand rBand = rBandCon.Item(i);
                IRasterProps rasterData = rBand as IRasterProps;
                //Raster Height
                int height = rasterData.Height;
                //Raster Width
                int width = rasterData.Width;
                //Raster Cell Size
                IPnt cell = rasterData.MeanCellSize();
                rstPixelType rType=rasterData.PixelType;
                MessageBox.Show(rType.ToString());
                if (rType == rstPixelType.PT_LONG)
                {
                    //Error code
                    //Read Raster
                    //Wrong QI
                    //IRaster pRaster = rBand as IRaster;
                    ITable rasterTable = rBand.AttributeTable;
                    IQueryFilter qFilter = new QueryFilter();
                    for (int j = 0; j < rasterTable.Fields.FieldCount; j++)
                    {
                        IField aField = rasterTable.Fields.get_Field(j);
                        qFilter.AddField(aField.ToString());

                    }

                    ICursor cursor = rasterTable.Search(qFilter, true);
                    IRow aRow = cursor.NextRow();
                    if (aRow != null)
                    {
                        //aRow.get_Value(0);
                        MessageBox.Show(cell.X.ToString() + "x" + cell.Y + ":" + aRow.get_Value(0).ToString());
                        //Read Raster
                        // rBand.
                    }
                }
                // Create pixelblock
                IRawPixels rawPixels = rBand as IRawPixels;
               //cannot be used as  follows
                //IRawPixels rawPixels = raster as IRawPixels;
                IPnt pixelBlockOrigin = new DblPnt();
                pixelBlockOrigin.SetCoords(0, 0);

                IPnt pixelBlockSize = new DblPnt();
                pixelBlockSize.SetCoords(rasterData.Width, rasterData.Height);
                IPixelBlock3 pixelBlock3 = (IPixelBlock3)rawPixels.CreatePixelBlock(pixelBlockSize);
                //Read
                rawPixels.Read(pixelBlockOrigin, (IPixelBlock)pixelBlock3);
                //GetVal( int brand, int X, int Y); brand=0
                int x = 3600;
                int y = 800 ;
                object cellD=pixelBlock3.GetVal(0, x, y);
                //MessageBox.Show(cellD.ToString());

                rtxbRasterInfo.Text = rtxbRasterInfo.Text + "\r\n" + rBand.Bandname.ToString() + ":" + width.ToString() + "x" + height.ToString() + ":(" + x.ToString() + "," + y.ToString() + ")=" + cellD.ToString();
             }
            
        }

        private void cboActiveMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_mapDocument.Open(m_mapDocuemntName, "");
            for (int i = 0; i < m_mapDocument.MapCount; i++)
            {
                //pull a map from the collection
                m_map = m_mapDocument.get_Map(i);
                if (m_map.Name.Equals(cboActiveMap.SelectedItem))
                //Is this the chosen map?
                {
                    axMapControl1.Map = m_map;
                    //Determine layer type according to its layer type of a map
                    ILayer aLayer = m_map.get_Layer(0);
                    if (aLayer is IRasterLayer)//Raster Layer
                    {
                         //MessageBox.Show("Rastser is " + aLayer.Name.ToString());
                        btnChangeRGBRenderer.Enabled = true;
                        btnStretch.Enabled = true;
                        ShowRasterInfo(aLayer as IRasterLayer);
                    }
                    else if (aLayer is IFeatureLayer)//FeatureLayer
                    {
                        //MessageBox.Show("FeatureLayer is " + aLayer.Name.ToString());
                        btnScale.Enabled = true;
                        cboLayer.Enabled = true;
                        AddLayersToComboBox();
                    }
                    break;
                    //Exits the loop once the map is found
                }
            }
            m_mapDocument.Close();


        }

        private void btnSaveLayer_Click(object sender, EventArgs e)
        {

            /* ArcGIS Snippet Title:
             Display save dialog

             Intended ArcGIS Products for this snippet:
             ArcGIS Engine

             Notes:
             This snippet is intended to be inserted into the Click event of a Visual Studio button
             The code assumes that a module-level variable (m_layer) has been declared as ILayer */

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Layer File|*.lyr|All Files|*.*";
            saveFileDialog.Title = "Create Layer File";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = System.IO.Path.Combine(saveFileDialog.InitialDirectory, (m_layer.Name + ".lyr"));
            saveFileDialog.ShowDialog();
            string path;
            path = saveFileDialog.FileName;

            //the code for save
            ILayerFile layerFile = new LayerFile();
            layerFile.New(path);
            layerFile.ReplaceContents(m_layer as ILayer);
            layerFile.Save();

	
        }

        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {

            /* ArcGIS Snippet Title:
             Find the selected layer in the table of contents

             Add the following reference to the project:
             ESRI.ArcGIS.Controls

             Add the following ArcGIS Engine control to the project:
             TOCControl

             Intended ArcGIS Products for this snippet:
             ArcGIS Engine

             Notes:
             This snippet is intended to be inserted into the OnMouseDown event of the TOC Control
             The code assumes that a module-level variable (m_layer) has been declared as ILayer */

            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;
            esTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;

            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if ((item == esriTOCControlItem.esriTOCControlItemLayer))
            {
                m_layer = layer;
                btnSaveLayer.Enabled = true;
                //Settting
                // MessageBox.Show(m_layer.Name.ToString());
                cboLayer.SelectedIndex = cboLayer.FindStringExact(m_layer.Name.ToString());
                //cboLayer.SelectedIndex();


              }
            
     	
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            IFeatureLayer fLayer1=m_map.get_Layer(1) as IFeatureLayer;
            IFeatureLayer fLayer2=m_map.get_Layer(2) as IFeatureLayer;
            IFeatureLayer fLayer0=m_map.get_Layer(0) as IFeatureLayer;
            fLayer2.MinimumScale=500000000;

            IFeatureLayer newFalyer = new FeatureLayer();
            newFalyer.Name = "USA";
            IFeatureClass featureClass = fLayer1.FeatureClass;
            newFalyer.FeatureClass = featureClass;
            IGeoFeatureLayer geoFLayer0=fLayer0 as IGeoFeatureLayer;
            IGeoFeatureLayer geoFLayer1=fLayer1 as IGeoFeatureLayer;
            IGeoFeatureLayer geoFLayer2=fLayer2 as IGeoFeatureLayer;
            IGeoFeatureLayer newGeoFLayer=newFalyer as IGeoFeatureLayer;

            IScaleDependentRenderer scaleDependentRenderer=new ScaleDependentRenderer();
            IFeatureRenderer renderer0=geoFLayer0.Renderer;
            IFeatureRenderer renderer1=geoFLayer1.Renderer;
            IFeatureRenderer renderer2=geoFLayer2.Renderer;

            //Build the new scale dependerer from the existing renderer
            scaleDependentRenderer.AddRenderer(renderer0);
            scaleDependentRenderer.AddRenderer(renderer1);
            scaleDependentRenderer.AddRenderer(renderer2);

            //
            scaleDependentRenderer.set_Break(0,100000000);
            scaleDependentRenderer.set_Break(1,500000000);
            scaleDependentRenderer.set_Break(2,5000000000);

            newGeoFLayer.Renderer=scaleDependentRenderer as IFeatureRenderer;
            m_map.AddLayer(newGeoFLayer);
            axMapControl1.Refresh();


        }

        private void optChart_CheckedChanged(object sender, EventArgs e)
        {
            m_strOption = "Chart";
            OptionEnabler();

        }

        private void cboRed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     }
}
