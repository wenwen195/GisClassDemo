using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace FirstMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axToolbarControl1.SetBuddyControl(axMapControl1);
            axTOCControl1.SetBuddyControl(axMapControl1);
        }

        private void axLicenseControl1_Enter(object sender, EventArgs e)
        {

        }

        private void axToolbarControl1_OnMouseDown(object sender, AxESRI.ArcGIS.Controls.IToolbarControlEvents_OnMouseDownEvent e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Layers is " + axMapControl1.LayerCount);

        }
        //Exercise 3
        private void btnInfo_Click(object sender, EventArgs e)
        {
            //Method 1 set the MXD path in the property of axMapControl
            //Method 2
            IMapDocument mapDoc = new MapDocument();
            mapDoc.Open("F:\\Student\\IPAN\\Exercise02\\SouthAmerica.mxd");
            IMap inMap = mapDoc.get_Map(1);
            IActiveView actView = (IActiveView)inMap;
            //System.Diagnostics.Debug.WriteLine("Test map is "+mapDoc.MapCount);
            Console.Out.WriteLine("The sum of maps is " + mapDoc.MapCount);
            Console.Out.WriteLine("The first map is " + inMap.Name);
            Console.Out.WriteLine("The actView map is " + actView.FocusMap.Name);
            //axMapControl1.LoadMxFile(mapDoc.DocumentFilename);
            //method 3, Set a map directly
            axMapControl1.Map = inMap;
            //axMapControl1.ActiveView = actView;
            IEnvelope env = actView.Extent;
            MessageBox.Show("The number of layers in the map is " + inMap.LayerCount.ToString());
            MessageBox.Show("Min(" + env.XMin.ToString() + "," + env.XMin + "),Max(" + env.XMax.ToString() + "," + env.YMax + ")");
        }

        private void btnMapName_Click(object sender, EventArgs e)
        {
            MessageBox.Show(axMapControl1.Map.Name + "\r\n" + "The number of layers in the map is " + axMapControl1.Map.LayerCount.ToString());
        }

        private void axMapControl1_OnMouseDown(object sender, AxESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {

        }
    }
}
