using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SystemUI;
namespace QueryFilters
{
    public partial class MainForm : Form
    {
        private IMapControl3 m_mapControl = null;
        private ILayer m_layer;
        public MainForm()
        {
            InitializeComponent();
        }

        private void menuExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuOpenDoc_Click(object sender, EventArgs e)
        {
             ICommand command = new ControlsOpenDocCommand();
            command.OnCreate(m_mapControl.Object);
            command.OnClick();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            m_mapControl = axMapControl1.Object as IMapControl3;
           
            menuSaveDoc.Enabled = false;
            menuSaveAs.Enabled = false;
        }

        //QueryFilter Example, 
        private void btnLandlocked1_Click(object sender, EventArgs e)
        {
            IFeatureLayer fLayer = axMapControl1.get_Layer(2) as IFeatureLayer;//Country layer
             
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
            while(feat!=null){
                dblArea += Convert.ToDouble(feat.get_Value(10));//11th field
                feat = fCursor.NextFeature();
            }
            MessageBox.Show(string.Format("Number of landlocked countries:{0}\r\n Area: {1:#} sq km", lngCountries, dblArea));
            
            //Query mthod2 : search features using IfeatureSelection and show them
            IFeatureSelection fSel = fLayer as IFeatureSelection;
            qFilter.WhereClause = "Population>100000000";
             fSel.SelectFeatures(qFilter,esriSelectionResultEnum.esriSelectionResultNew,false);
            //Using Symbol as renderer
             ISimpleFillSymbol sSym = new SimpleFillSymbol();
             sSym.Style = esriSimpleFillStyle.esriSFSSolid;
             IRgbColor blu = new RgbColor();
             blu.Blue = 255;
             sSym.Color = blu;
             fSel.SetSelectionSymbol = true;
             fSel.SelectionSymbol = sSym as ISymbol;
              
            //Label
             IMap iMap = axMapControl1.Map;
             if (iMap is AnnotateMap)
             {
                 MessageBox.Show("Casting is success");
             }
             //fSel.SelectionColor = blu;
            axMapControl1.ActiveView.Refresh();
        }

        private void axMapControl1_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            statusBarXY.Text = string.Format("{0},{1}{2}",e.mapX.ToString("#######.##"),e.mapY.ToString("#######.##"),axMapControl1.MapUnits.ToString().Substring(4));
        }

        private void btnSpatialFilter1_Click(object sender, EventArgs e)
        {
            IFeatureSelection cntryLayer = axMapControl1.get_Layer(2) as IFeatureSelection;
            ISelectionSet cntrySel;
            // code ommited 
            IQueryFilter qFilterCountry = new QueryFilter();
            qFilterCountry.WhereClause = "Population>200000000";//Country layer

            cntryLayer.SelectFeatures(qFilterCountry,esriSelectionResultEnum.esriSelectionResultNew,false);
            cntrySel = cntryLayer.SelectionSet;
            ICursor cntryCursor;
            //Generate Cursor from SelectionSet 
            cntrySel.Search(null, true, out cntryCursor);
          
            //Obtain spatial features 
            IFeatureCursor cntryFCursor=cntryCursor as IFeatureCursor;
    
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
                MessageBox.Show("This is "+country.get_Value(6));
            }
            ISpatialFilter spatFilter = new SpatialFilter();
            IQueryFilter qFilter = spatFilter as IQueryFilter;
            qFilter.WhereClause = "Population>200000";//used to Cities layer

            //IFeatureDataset fDataset = cntryFLayer.FeatureClass.FeatureDataset;
            //IGeoDataset gDataset = fDataset as IGeoDataset;
            //spatFilter.Geometry = country.Shape;
            spatFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
            //Original code
            IFeatureLayer cityLayer = axMapControl1.get_Layer(0) as IFeatureLayer;//Cities layer
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
            green.Green= 255;
            cityFeatureSel.SelectionColor = green;
            //Show the result
            axMapControl1.ActiveView.Refresh();
        }

        //Query by IfeatureSelection
        private void btnSelectCities_Click(object sender, EventArgs e)
        {
            IMap map = axMapControl1.ActiveView.FocusMap;
            IFeatureSelection featSel=m_layer as IFeatureSelection;

            IQueryFilter qfilter = new QueryFilter();
            qfilter.WhereClause = "population>1000000";
            if (featSel != null)
            {
                featSel.Clear();
            }
            else
            {
                return;
            }
            //Selection 
            featSel.SelectFeatures(qfilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            //Get Cursor from SelectionSet
            ISelectionSet sSet = featSel.SelectionSet;
            ICursor cursor;
            //Search in SelectitonSet
            sSet.Search(null, true, out cursor);//null means all featuers in SelectionSet;
            IFeatureCursor fCursor = cursor as IFeatureCursor;
            IFeature aFeature = fCursor.NextFeature();
            int totalPopulation=0;
            IFields fields = aFeature.Fields;
            int indexField=fields.FindField("Population");
            while (aFeature!=null){
                totalPopulation+=Convert.ToInt32(aFeature.get_Value(indexField));
                aFeature = fCursor.NextFeature();
            }

            IRgbColor grn = new RgbColor();
            grn.Green = 255;
            featSel.SelectionColor = grn;
            axMapControl1.ActiveView.Refresh();
            int averagePopulation = totalPopulation / sSet.Count;
            MessageBox.Show("Total population is " + totalPopulation.ToString()+"\r\n"+"Average Population is "+averagePopulation.ToString());

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
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;

            axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);
            if ((item == esriTOCControlItem.esriTOCControlItemLayer))
            {
                m_layer = layer;
            }

     	
        }

    }
}
