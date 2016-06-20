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

namespace FirstMap6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowFr : Window
    {
        AxMapControl m_map=new AxMapControl();
        public MainWindowFrom()
        {
            InitializeComponent();
            this.mapHost.Child = m_map;
        }

        private void mapHost_Loaded(object sender, RoutedEventArgs e)
        {
            m_map.LoadMxFile("C:\\IPAN\\Exercise02\\SouthAmerica.mxd");
        }
    }
}
