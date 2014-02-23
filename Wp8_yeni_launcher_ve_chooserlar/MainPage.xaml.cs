using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Wp8_yeni_launcher_ve_chooserlar.Resources;

using Microsoft.Phone.Tasks;
using System.Device.Location;

namespace Wp8_yeni_launcher_ve_chooserlar
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

private void save_appointment_task(object sender, RoutedEventArgs e)
{
    SaveAppointmentTask save = new SaveAppointmentTask();
    save.Subject = "Akşam yemeği";
    save.Location = "Yan yol";
    save.Details = "cüzdanını almayı unutma";
    save.StartTime = new DateTime(2013, 6, 24);
    save.IsAllDayEvent = true;
    save.Reminder = Reminder.FifteenMinutes;
    save.AppointmentStatus = Microsoft.Phone.UserData.AppointmentStatus.Busy;
    save.Show();
}

private void maps_task(object sender, RoutedEventArgs e)
{
    MapsTask map = new MapsTask();
    map.SearchTerm = "istanbul taksim";
    map.ZoomLevel = 3;
    map.Show();
}

private void map_direction_task(object sender, RoutedEventArgs e)
{

    MapsDirectionsTask MapsDirectionsTask = new MapsDirectionsTask();

    //MapsDirectionTask'ın Start methoduna karşılık bir değer vermediğinizde başlangıç noktası olarak telefonun mevcut konumunu kullanabilirsiniz.
    //GeoCoordinate besiktas_koordinat = new GeoCoordinate(41.042646, 29.007299);
    //MapsDirectionsTask.End = new LabeledMapLocation("Istanbul Beşiktaş", besiktas_koordinat);

    MapsDirectionsTask.Start = new LabeledMapLocation("Istanbul Mecidiyeköy", null);
    MapsDirectionsTask.End = new LabeledMapLocation("Istanbul Taksim", null);

    MapsDirectionsTask.Show();
}

private void map_downloader_task(object sender, RoutedEventArgs e)
{
    MapDownloaderTask mapdownloader = new MapDownloaderTask();
    mapdownloader.Show();
}

private void map_updater_task(object sender, RoutedEventArgs e)
{
    MapUpdaterTask mapupdater = new MapUpdaterTask();
    mapupdater.Show();
}

private void share_media_task(object sender, RoutedEventArgs e)
{
    PhotoChooserTask choosen_photo = new PhotoChooserTask();
    choosen_photo.ShowCamera = true;
    var take_choosen = choosen_photo;
    take_choosen.Completed += PhotoChooserTaskCompleted;
    take_choosen.Show();
}

void PhotoChooserTaskCompleted(object sender, PhotoResult e)
{
    var share_media = new ShareMediaTask { FilePath = e.OriginalFileName };
    share_media.Show();
}

private void save_ringtone(object sender, RoutedEventArgs e)
{
    SaveRingtoneTask saveringtone = new SaveRingtoneTask();
    saveringtone.Completed += new EventHandler<TaskEventArgs>(saveringtoneChooser_Completed);//extra
    saveringtone.Source = new Uri("appdata:/ringtone/Super_Mario_Ringtone.mp3");// veya isolated storage'daki dosyaları da gösterebilirsiniz 
    //("isostore:/Super_Mario_Ringtone.mp3");
    saveringtone.DisplayName = "Super Mario Ringtone";
    saveringtone.Show();
}

        //extra
        private void saveringtoneChooser_Completed(object sender, TaskEventArgs e)
        {
            switch (e.TaskResult)
            {
                case TaskResult.OK:
                    MessageBox.Show("Zil sesi kaydı başarılı");
                    break;

                case TaskResult.Cancel:
                    MessageBox.Show("Zil sesi kaydedilmedi");
                    break;

                case TaskResult.None:
                    MessageBox.Show("Zil sesi kaydı başarısız :(");
                    break;
            }
        }
    }
}