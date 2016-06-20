using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesOleDB;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using stdole;

namespace Town.ArcGIS
{
    class Render
    {
        /// <summary>
        /// Render City and Village
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void RenderCityVillage(ILayer currentLayer)
        {
            IUniqueValueRenderer pUniqueValueR = new UniqueValueRendererClass();
            pUniqueValueR.FieldCount = 1;
            string fieldName = Town.Constant.Constant.TmpTableDevide + "." + Town.Constant.Constant.TmpFieldName;
            pUniqueValueR.set_Field(0, fieldName);

            ISimpleFillSymbol pFillSymbolDef = new SimpleFillSymbolClass();
            pFillSymbolDef.Color = Town.ArcGIS.Color.ToEsriColor(System.Drawing.Color.Gray);
            pUniqueValueR.DefaultSymbol = pFillSymbolDef as ISymbol;
            pUniqueValueR.UseDefaultSymbol = true;

            ISimpleFillSymbol citySymbol = new SimpleFillSymbolClass();
            citySymbol.Color = Town.ArcGIS.Color.ToEsriColor(System.Drawing.Color.Yellow);
            pUniqueValueR.AddValue("城镇", "城镇", citySymbol as ISymbol);

            ISimpleFillSymbol vilageSymbol = new SimpleFillSymbolClass();
            vilageSymbol.Color = Town.ArcGIS.Color.ToEsriColor(System.Drawing.Color.Tomato);
            pUniqueValueR.AddValue("乡村", "乡村", vilageSymbol as ISymbol);

            IGeoFeatureLayer geoFeaLayer = currentLayer as IGeoFeatureLayer;
            geoFeaLayer.Renderer = pUniqueValueR as IFeatureRenderer;
        }

        /// <summary>
        /// Class Break Render
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <param name="breakCount"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void ClassBreakRender(ILayer currentLayer, int breakCount, string fieldName, ref double[] Classes, ref int[] Colors, bool reverse)
        {
            //Get All Value
            object dataFrequency = null;
            object dataValues = null;
            ITableHistogram pTableHistogram = new BasicTableHistogramClass();
            IBasicHistogram pHistogram = (IBasicHistogram)pTableHistogram;
            pTableHistogram.Field = fieldName;
            pTableHistogram.Table = (currentLayer as IGeoFeatureLayer).DisplayFeatureClass as ITable;
            pHistogram.GetHistogram(out dataValues, out dataFrequency);

            //Class
            IClassifyGEN pClassify = new EqualIntervalClass();
            pClassify.Classify(dataValues, dataFrequency, ref breakCount);

            //Set Class Breaks
            Classes = (double[])pClassify.ClassBreaks;
            int ClassesCount = Classes.GetUpperBound(0);
            IClassBreaksRenderer pClassBreaksRenderer = new ClassBreaksRendererClass();
            pClassBreaksRenderer.Field = fieldName;

            //Set From to Color
            IHsvColor pFromColor = new HsvColorClass();
            pFromColor.Hue = reverse ? 105 : 353;
            pFromColor.Saturation = reverse ? 46 : 56;
            pFromColor.Value = reverse ? 76 : 92;
            IHsvColor pToColor = new HsvColorClass();
            pToColor.Hue = reverse ? 353 : 105;
            pToColor.Saturation = reverse ? 56 : 46;
            pToColor.Value = reverse ? 92 : 76;

            //Get Color
            IAlgorithmicColorRamp pAlgorithmicCR = new AlgorithmicColorRampClass();
            pAlgorithmicCR.Algorithm = esriColorRampAlgorithm.esriHSVAlgorithm;
            pAlgorithmicCR.FromColor = pFromColor;
            pAlgorithmicCR.ToColor = pToColor;
            pAlgorithmicCR.Size = ClassesCount;
            bool ok = false;
            pAlgorithmicCR.CreateRamp(out ok);
            IEnumColors pEnumColors = pAlgorithmicCR.Colors;

            //Set Break Count
            pClassBreaksRenderer.BreakCount = ClassesCount;
            pClassBreaksRenderer.SortClassesAscending = true;

            //Set Break Interval
            for (int lbreakIndex = 0; lbreakIndex <= ClassesCount - 1; lbreakIndex++)
            {
                IColor pColor = pEnumColors.Next();
                Colors[lbreakIndex] = pColor.RGB;
                ISimpleFillSymbol pSimpleFillS = new SimpleFillSymbolClass();
                pSimpleFillS.Color = pColor;
                pSimpleFillS.Style = esriSimpleFillStyle.esriSFSSolid;
                pClassBreaksRenderer.set_Symbol(lbreakIndex, (ISymbol)pSimpleFillS);
                pClassBreaksRenderer.set_Break(lbreakIndex, Classes[lbreakIndex + 1]);
            }

            //Set Render
            (currentLayer as IGeoFeatureLayer).Renderer = pClassBreaksRenderer as IFeatureRenderer;
        }


        /// <summary>
        /// Bar Chart Render
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <param name="breakCount"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void BarChartRender(ILayer currentLayer)
        {
            //Scale Symbol
            IGeoFeatureLayer pGeoFeatureL = currentLayer as IGeoFeatureLayer;
            pGeoFeatureL.ScaleSymbols = true;

            //Chart Render
            IChartRenderer pChartRenderer = new ChartRendererClass();
            IRendererFields pRendererFields = (IRendererFields)pChartRenderer;
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Ecology", "生态");
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Social", "社会");
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Economic", "经济");

            //Search Max
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Ecology");
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Social");
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Economic");
            IFeatureCursor pCursor = pGeoFeatureL.DisplayFeatureClass.Search(pQueryFilter, true);

            int fldFiledEcology = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + "Ecology");
            int fldFiledSocial = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + "Social");
            int fldFiledEconomic = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + "Economic");

            List<double> valueList = new List<double>();

            IFeature pFeature = pCursor.NextFeature();
            while (pFeature != null)
            {
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledEcology)));
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledSocial)));
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledEconomic)));
                pFeature = pCursor.NextFeature();
            }

            //Bar Chart
            IBarChartSymbol pBarChartSymbol = new BarChartSymbolClass();
            IChartSymbol pChartSymbol = (IChartSymbol)pBarChartSymbol;
            pBarChartSymbol.Width = 12;
            IMarkerSymbol pMarkerSymbol = (IMarkerSymbol)pBarChartSymbol;

            pChartSymbol.MaxValue = valueList.Max();
            pMarkerSymbol.Size = 50;

            //Set Symbol
            ISymbolArray pSymbolArray = (ISymbolArray)pBarChartSymbol;
            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Green);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Red);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Blue);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);

            //Render Attribute
            pChartRenderer.ChartSymbol = (IChartSymbol)pBarChartSymbol;
            pChartRenderer.Label = "指标";
            pChartRenderer.UseOverposter = false;
            pChartRenderer.CreateLegend();

            //Back Ground
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(239, 228, 190));
            pChartRenderer.BaseSymbol = (ISymbol)pFillSymbol;

            //Render Label
            pGeoFeatureL.Renderer = pChartRenderer as IFeatureRenderer;
        }


        /// <summary>
        /// Bar Chart Render for Enviroment
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <param name="breakCount"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void BarChartRenderSingle(ILayer currentLayer)
        {
            //Scale Symbol
            IGeoFeatureLayer pGeoFeatureL = currentLayer as IGeoFeatureLayer;
            pGeoFeatureL.ScaleSymbols = true;

            //Chart Render
            IChartRenderer pChartRenderer = new ChartRendererClass();
            IRendererFields pRendererFields = (IRendererFields)pChartRenderer;
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + Town.Constant.Constant.TmpFieldName, "指标");

            //Search Max
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + Town.Constant.Constant.TmpFieldName);
            IFeatureCursor pCursor = pGeoFeatureL.DisplayFeatureClass.Search(pQueryFilter, true);

            int fldFiledEcology = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + Town.Constant.Constant.TmpFieldName);

            List<double> valueList = new List<double>();

            IFeature pFeature = pCursor.NextFeature();
            while (pFeature != null)
            {
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledEcology)));
                pFeature = pCursor.NextFeature();
            }

            //Bar Chart
            IBarChartSymbol pBarChartSymbol = new BarChartSymbolClass();
            IChartSymbol pChartSymbol = (IChartSymbol)pBarChartSymbol;
            pBarChartSymbol.Width = 12;
            IMarkerSymbol pMarkerSymbol = (IMarkerSymbol)pBarChartSymbol;

            pChartSymbol.MaxValue = valueList.Max();
            pMarkerSymbol.Size = 50;

            //Set Symbol
            ISymbolArray pSymbolArray = (ISymbolArray)pBarChartSymbol;
            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Green);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);

            //Render Attribute
            pChartRenderer.ChartSymbol = (IChartSymbol)pBarChartSymbol;
            pChartRenderer.Label = "指标";
            pChartRenderer.UseOverposter = false;
            pChartRenderer.CreateLegend();

            //Back Ground
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(239, 228, 190));
            pChartRenderer.BaseSymbol = (ISymbol)pFillSymbol;

            //Render Label
            pGeoFeatureL.Renderer = pChartRenderer as IFeatureRenderer;
        }


        /// <summary>
        /// Pie Chart Render
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <param name="breakCount"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void PieChartRender(ILayer currentLayer)
        {
            //Scale Symbol
            IGeoFeatureLayer pGeoFeatureL = currentLayer as IGeoFeatureLayer;
            pGeoFeatureL.ScaleSymbols = true;

            //Chart Render
            IChartRenderer pChartRenderer = new ChartRendererClass();
            IRendererFields pRendererFields = (IRendererFields)pChartRenderer;
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Ecology", "生态");
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Social", "社会");
            pRendererFields.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Economic", "经济");

            //Search Max
            IQueryFilter pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Ecology");
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Social");
            pQueryFilter.AddField(Town.Constant.Constant.TmpTableIndex + "." + "Economic");
            IFeatureCursor pCursor = pGeoFeatureL.DisplayFeatureClass.Search(pQueryFilter, true);

            int fldFiledEcology = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + "Ecology");
            int fldFiledSocial = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + "Social");
            int fldFiledEconomic = pCursor.Fields.FindField(Town.Constant.Constant.TmpTableIndex + "." + "Economic");

            List<double> valueList = new List<double>();

            IFeature pFeature = pCursor.NextFeature();
            while (pFeature != null)
            {
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledEcology)));
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledSocial)));
                valueList.Add(Convert.ToDouble(pFeature.get_Value(fldFiledEconomic)));
                pFeature = pCursor.NextFeature();
            }

            //Pie Chart
            IPieChartSymbol pPieChartSymbol;
            pPieChartSymbol = new PieChartSymbolClass();
            IChartSymbol pChartSymbol = (IChartSymbol)pPieChartSymbol;

            //Pie Chart Attribute
            pPieChartSymbol.Clockwise = true;
            pPieChartSymbol.UseOutline = true;
            ILineSymbol pOutline;
            pOutline = new SimpleLineSymbolClass();
            pOutline.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(100, 205, 30));
            pOutline.Width = 1;
            pPieChartSymbol.Outline = pOutline;
            IMarkerSymbol pMarkerSymbol = (IMarkerSymbol)pPieChartSymbol;

            pChartSymbol.MaxValue = valueList.Max();
            pMarkerSymbol.Size = 60;

            //Symbol Array
            ISymbolArray pSymbolArray = (ISymbolArray)pPieChartSymbol;
            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Green);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Red);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.Blue);
            pSymbolArray.AddSymbol((ISymbol)pFillSymbol);

            pChartRenderer.ChartSymbol = (IChartSymbol)pPieChartSymbol;
            pChartRenderer.Label = "指标";

            //Back Ground
            pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(239, 228, 190));
            pChartRenderer.BaseSymbol = (ISymbol)pFillSymbol;

            //Render Label
            pGeoFeatureL.Renderer = pChartRenderer as IFeatureRenderer;
        }


        /// <summary>
        /// Dot Density Render
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <param name="breakCount"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void DotDensityRender(ILayer currentLayer, string fieldName)
        {
            IGeoFeatureLayer pGeoFeatureL = currentLayer as IGeoFeatureLayer;
            pGeoFeatureL.ScaleSymbols = true;

            //Dot Density Render
            IDotDensityRenderer pDotDensityRenderer = new DotDensityRendererClass();
            IRendererFields pRendererFields = (IRendererFields)pDotDensityRenderer;
            pRendererFields.AddField(fieldName, "生态");

            //Dot Style
            IDotDensityFillSymbol pDotDensityFillS = new DotDensityFillSymbolClass();
            pDotDensityFillS.DotSize = 4;
            pDotDensityFillS.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(0, 0, 0));
            pDotDensityFillS.BackgroundColor = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(239, 228, 190));

            //Symbol Array
            ISymbolArray pSymbolArray = (ISymbolArray)pDotDensityFillS;
            ISimpleMarkerSymbol pSimpleMarkerS = new SimpleMarkerSymbolClass();
            pSimpleMarkerS.Style = esriSimpleMarkerStyle.esriSMSCircle;
            pSimpleMarkerS.Size = 4;
            pSimpleMarkerS.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(128, 128, 255));
            pSymbolArray.AddSymbol((ISymbol)pSimpleMarkerS);

            pDotDensityRenderer.DotDensitySymbol = pDotDensityFillS;
            pDotDensityRenderer.DotValue = 0.05;
            pDotDensityRenderer.CreateLegend();
            pGeoFeatureL.Renderer = (IFeatureRenderer)pDotDensityRenderer;
        }


        /// <summary>
        /// Symbol Render
        /// </summary>
        /// <param name="currentLayer"></param>
        /// <param name="breakCount"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        public static void SymbolRender(ILayer currentLayer, string fieldName)
        {
            IGeoFeatureLayer pGeoFeatureL = currentLayer as IGeoFeatureLayer;
            pGeoFeatureL.ScaleSymbols = true;

            //Use the statistics objects to calculate the max value and the min value
            IFeatureCursor pCursor = pGeoFeatureL.DisplayFeatureClass.Search(null, true);
            IDataStatistics pDataStatistics = new DataStatisticsClass();
            pDataStatistics.Cursor = pCursor as ICursor;
            pDataStatistics.Field = fieldName;
            IStatisticsResults pStatisticsResult = pDataStatistics.Statistics;


            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(239, 228, 190));
            ICharacterMarkerSymbol pCharaterMarkerS = new CharacterMarkerSymbolClass();
            stdole.StdFont pFontDisp = new stdole.StdFontClass();
            pFontDisp.Name = "ESRI Default Marker";
            pFontDisp.Size = 30;
            pCharaterMarkerS.Font = (IFontDisp)pFontDisp;
            pCharaterMarkerS.CharacterIndex = 81;
            pCharaterMarkerS.Color = ArcGIS.Color.ToEsriColor(System.Drawing.Color.FromArgb(255, 0, 0));
            pCharaterMarkerS.Size = 30;

            IProportionalSymbolRenderer pProportionalSymbolR = new ProportionalSymbolRendererClass();
            pProportionalSymbolR.ValueUnit = esriUnits.esriUnknownUnits;
            pProportionalSymbolR.Field = fieldName;
            pProportionalSymbolR.FlanneryCompensation = false;
            pProportionalSymbolR.MinDataValue = pStatisticsResult.Minimum;
            pProportionalSymbolR.MaxDataValue = pStatisticsResult.Maximum;
            pProportionalSymbolR.BackgroundSymbol = pFillSymbol;
            pProportionalSymbolR.MinSymbol = (ISymbol)pCharaterMarkerS;
            pProportionalSymbolR.LegendSymbolCount = 12;
            pProportionalSymbolR.CreateLegendSymbols();

            pGeoFeatureL.Renderer = (IFeatureRenderer)pProportionalSymbolR;
        }

        public static void UniqueRender(ILayer currentLayer, string fieldName)
        {
            IGeoFeatureLayer m_pGeoFeatureL;
            IUniqueValueRenderer pUniqueValueR;
            IFillSymbol pFillSymbol;
            IColor pNextUniqueColor;
            IEnumColors pEnumRamp;
            ITable pTable;
            int lfieldNumber;
            IRow pNextRow;
            IRowBuffer pNextRowBuffer;
            ICursor pCursor;
            IQueryFilter pQueryFilter;
            string codeValue;
            IRandomColorRamp pColorRamp;
            m_pGeoFeatureL = (IGeoFeatureLayer)currentLayer;
            pUniqueValueR = new UniqueValueRendererClass();
            pTable = (ITable)m_pGeoFeatureL;
            lfieldNumber = 0;
            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                if (pTable.Fields.get_Field(i).Name.ToUpper().Contains(fieldName.ToUpper()))
                {
                    fieldName = pTable.Fields.get_Field(i).Name;
                    lfieldNumber = i;
                    break;
                }
            }
            pUniqueValueR.FieldCount = 1;
            pUniqueValueR.set_Field(0, fieldName);
            pColorRamp = new RandomColorRampClass();
            pColorRamp.StartHue = 0;
            pColorRamp.MinValue = 99;
            pColorRamp.MinSaturation = 15;
            pColorRamp.EndHue = 360;
            pColorRamp.MaxValue = 100;
            pColorRamp.MaxSaturation = 30;
            pColorRamp.Size = 100;
            bool ok = true;
            pColorRamp.CreateRamp(out ok);
            pEnumRamp = pColorRamp.Colors;
            pNextUniqueColor = null;
            pQueryFilter = new QueryFilterClass();
            pQueryFilter.AddField(fieldName);
            pCursor = pTable.Search(pQueryFilter, true);
            pNextRow = pCursor.NextRow();
            while (pNextRow != null)
            {
                pNextRowBuffer = pNextRow;
                codeValue = (string)pNextRowBuffer.get_Value(lfieldNumber);
                pNextUniqueColor = pEnumRamp.Next();
                if (pNextUniqueColor == null)
                {
                    pEnumRamp.Reset();
                    pNextUniqueColor = pEnumRamp.Next();
                }
                pFillSymbol = new SimpleFillSymbolClass();
                pFillSymbol.Color = pNextUniqueColor;
                pUniqueValueR.AddValue(codeValue, fieldName, (ISymbol)
                pFillSymbol);
                pNextRow = pCursor.NextRow();
            }
            m_pGeoFeatureL.Renderer = (IFeatureRenderer)pUniqueValueR;
        }
    }
}
