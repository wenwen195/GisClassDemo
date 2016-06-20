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
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace FirstMap5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        AxMapControl m_map = new AxMapControl();
        AxTOCControl m_toc = new AxTOCControl();
        AxToolbarControl m_toolbar = new AxToolbarControl();
        public MainWindow()
        {
            InitializeComponent();
            this.windowsFormsHostMap.Child=m_map;
            this.tocHost.Child = m_toc;
            this.toolbarHost.Child = m_toolbar;
         }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_map.LoadMxFile("C:\\IPAN\\Exercise02\\SouthAmerica.mxd", 0, null);
            m_toc.SetBuddyControl(m_map);
            m_toolbar.SetBuddyControl(m_map);
            m_toolbar.AddItem("esriControls.ControlsMapNavigationToolbar");
 
        }

     }
}
