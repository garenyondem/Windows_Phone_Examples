using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BingMapsSample.Resources;

using Microsoft.Devices.Sensors;

using System.Device;
using System.Device.Location;
using Microsoft.Phone.Tasks;

namespace BingMapsSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void bingMapsTask(object sender, RoutedEventArgs e)
        {
            //GeoCoordinate ada = new GeoCoordinate(40.197979, 25.908476);
            BingMapsTask bingMapsTask = new BingMapsTask();
            //Center metodunu override etmediğiniz takdirde varsayılan değeri, kullanıcının mevcut konumu olacak.
            //bingMapsTask.Center = ada;
            bingMapsTask.SearchTerm = searchTerm.Text.ToString();
            bingMapsTask.ZoomLevel = Convert.ToInt16(zoomLevel.Text);
            bingMapsTask.Show();
        }

        private void bingDirectionTask(object sender, RoutedEventArgs e)
        {
            BingMapsDirectionsTask bingDirectionTask = new BingMapsDirectionsTask();
            //Start metodunu kullanmadığınız takdirde kullanıcının bulunduğu konum başlangıç noktası olarak set edilir.
            bingDirectionTask.Start = new LabeledMapLocation(start.Text.ToString(), null);

            //LabeledMapLocatıon classı'nın ikinci parametresini null geçtiğiniz zaman, konum arama servisine yönlendirilerek koordinat alırsınız.
            //Custom koordinat değeri atamak için yukarıdaki örnekte olduğu gibi GeoCoordinate classı'ndan faydalanabilirsiniz.
            bingDirectionTask.End = new LabeledMapLocation(end.Text.ToString(), null);
            bingDirectionTask.Show();

        }

        private void blog_link(object sender, System.Windows.Input.GestureEventArgs e)
        {
            WebBrowserTask browser = new WebBrowserTask();
            browser.Uri = new Uri("http://garen.yondem.com");
            browser.Show();
        }

    }
}