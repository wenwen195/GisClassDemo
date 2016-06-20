using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using ESRI.ArcGIS;
using ESRI.ArcGIS.esriSystem;

namespace DisplayLayers2016
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitArcGISLicence();
        }

        public void InitArcGISLicence()
        {
            ESRI.ArcGIS.
            RuntimeManager.Bind(ProductCode.EngineOrDesktop);

            AoInitialize aoi = new AoInitializeClass();
            esriLicenseProductCode productCode = esriLicenseProductCode.esriLicenseProductCodeAdvanced;
            if (aoi.IsProductCodeAvailable(productCode) == esriLicenseStatus.esriLicenseAvailable)
            {
                aoi.Initialize(productCode);
            }
        }

    }
}
