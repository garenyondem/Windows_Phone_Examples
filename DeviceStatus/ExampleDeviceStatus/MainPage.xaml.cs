using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;

namespace ExampleDeviceStatus
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            brand.Text = DeviceStatus.DeviceManufacturer;
            model.Text = DeviceStatus.DeviceName;
            hardwareversion.Text = DeviceStatus.DeviceHardwareVersion;
            devicetotalmemory.Text = DeviceStatus.DeviceTotalMemory.ToString();
            currentmemory.Text = DeviceStatus.ApplicationCurrentMemoryUsage.ToString();
            peakmemoryusage.Text = DeviceStatus.ApplicationPeakMemoryUsage.ToString();
            firmware.Text = DeviceStatus.DeviceFirmwareVersion;
            power.Text = DeviceStatus.PowerSource.ToString();

            //DeviceStatus.IsKeyboardDeployed.ToString();
            //DeviceStatus.IsKeyboardPresent.ToString();
        }
    }
}