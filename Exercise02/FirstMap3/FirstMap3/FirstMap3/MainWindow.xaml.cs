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

namespace FirstMap3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        AxMapControl m_map = new AxMapControl();
        AxLicenseControl m_license = new AxLicenseControl();
        AxTOCControl m_toc = new AxTOCControl();
        AxToolbarControl m_toolbar = new AxToolbarControl();

        public MainWindow()

        {
            this.mapHost.Child = m_map;
            m_map.DocumentMap = "E:\\StudentIPAN\\Exercise02\\SouthAmerica.mxd";
            m_toc.SetBuddyControl(m_map);
            m_toolbar.SetBuddyControl(m_map);
            this.tocHost.Child = m_toc;
            this.toolbarHost.Child =m_toolbar;
            
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
