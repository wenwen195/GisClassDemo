using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;

namespace DisplayLayers2015
{
    public partial class mainForm : Form
    {
        private static string Simple_RENDER = "simple";
        private static string UNIQUE_RENDER = "unique";
        private static string BREAK_RENDER = "break";
        private string m_strOption;
        private IMapControl3 m_mapControl = null;
        private IMapDocument m_mapDocument = new MapDocument();//jin
        private IMap m_map;//jin 
        private string m_mapDocuemntName = string.Empty;
        private ILayer m_layer;

        public mainForm()
        {
            InitializeComponent();
        }

        private void btnRender_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoLayer = GetLayerByName(cboLayer.Text);
            MessageBox.Show(geoLayer.FeatureClass.ShapeType.ToString());
            switch (m_strOption)
            {
                //
                case "Simple":
                    IRgbColor rgbColor = new RgbColor();
                    rgbColor.Red = Convert.ToInt32(cboRed.Text);
                    rgbColor.Green = Convert.ToInt32(cboGreen.Text);
                    rgbColor.Blue = Convert.ToInt32(cboGreen.Text);
                    //only used to Polygon Layer
                    ISymbol sym = null;
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
                        ILineDecoration pLineDeco = new LineDecoration();
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
                case "Unique":
                    ApplyUniqueValue(geoLayer, cboUniqueVals.Text);
                    break;
                case "Chart":
                    ApplyBarChartValue(geoLayer, cbxProp1.Text);
                    break;
                case "Breaks":
                    ApplyClsssBreaks(geoLayer, cboNumericVals.Text, long.Parse(cboBreaks.Text));
                    break;
                default:
                    break;
            }

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

        //Custom
        private IGeoFeatureLayer GetLayerByName(string LayerName)
        {
            UID uid = new UID();
            uid.Value = "{E156D7E5-22AF-11D3-9f99-00C04F6BC78E}";
            IEnumLayer allFLayers = axMapControl1.ActiveView.FocusMap.get_Layers(uid, true);
            //loop until LayerName is found
            ILayer layer;
            layer = allFLayers.Next();
            while (layer != null)
            {
                if (layer.Name.Equals(LayerName))
                {
                    return layer as IGeoFeatureLayer;
                }
                layer = allFLayers.Next();
            }
            return null;
        }

    }
}
