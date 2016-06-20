using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

namespace Town.ArcGIS
{
    class Annotate
    {
        /// <summary>
        /// Annotate Layer
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="labelField"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static void AnnotateLayer(ILayer layer, string labelField)
        {
            IFeatureLayer feaLayer = layer as IFeatureLayer;
            IGeoFeatureLayer geoFeaLayer = layer as IGeoFeatureLayer;
            IAnnotateLayerPropertiesCollection pAnnoProps = geoFeaLayer.AnnotationProperties;
            pAnnoProps.Clear();

            ITextSymbol pTextSyl = new TextSymbolClass();
            Font fnt = new System.Drawing.Font("宋体", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pTextSyl.Size = 10;
            //pTextSyl.Font = ESRI.ArcGIS.ADF.COMSupport.OLE.GetIFontDispFromFont(fnt) as stdole.IFontDisp;
            pTextSyl.Color = Town.ArcGIS.Color.ToEsriColor(System.Drawing.Color.Black);

            IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerPropertiesClass();
            if (feaLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
            {
                ILineLabelPosition pPosition = new LineLabelPositionClass();
                ILineLabelPlacementPriorities pPlacementLine = new LineLabelPlacementPrioritiesClass();

                pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolygon;
                pBasic.LineLabelPlacementPriorities = pPlacementLine;
                pBasic.LineLabelPosition = pPosition;
            }
            else if (feaLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
            {
                IPointPlacementPriorities pPlacementPoint = new PointPlacementPrioritiesClass();
                pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPoint;
                pBasic.PointPlacementPriorities = pPlacementPoint;
                pBasic.PointPlacementOnTop = false;
                pBasic.PointPlacementMethod = esriOverposterPointPlacementMethod.esriAroundPoint;
            }
            else if (feaLayer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
            {
                ILineLabelPosition pPosition = new LineLabelPositionClass();
                ILineLabelPlacementPriorities pPlacementLine = new LineLabelPlacementPrioritiesClass();

                pBasic.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
                pBasic.LineLabelPlacementPriorities = pPlacementLine;
                pBasic.LineLabelPosition = pPosition;
            }

            pBasic.LabelWeight = esriBasicOverposterWeight.esriHighWeight;
            pBasic.FeatureWeight = esriBasicOverposterWeight.esriNoWeight;

            ILabelEngineLayerProperties pLabelEngine = new LabelEngineLayerPropertiesClass();
            pLabelEngine.Symbol = pTextSyl;
            pLabelEngine.BasicOverposterLayerProperties = pBasic;
            pLabelEngine.Expression = "[" + labelField + "]";

            IAnnotateLayerProperties pAnnoLayerProps = pLabelEngine as IAnnotateLayerProperties;

            pAnnoProps.Add(pAnnoLayerProps);
            geoFeaLayer.DisplayAnnotation = true;
        }

        /// <summary>
        /// Close Annotate
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="labelField"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public static void CloseAnnotate(ILayer layer)
        {
            IGeoFeatureLayer geoFeaLayer = layer as IGeoFeatureLayer;
            geoFeaLayer.DisplayAnnotation = false;
        }

    }
}
