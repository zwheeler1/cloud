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
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace PhoneApp1
{
    public partial class MainPage : PhoneApplicationPage
    {
        GeoCoordinateWatcher locationManager;
        double z;
       // map1.ZoomLevel = 10;
       
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            locationManager = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            locationManager.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(locationManager_getStatus);
            locationManager.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(locationManager_getPosition);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            map1.Mode = new RoadMode();
            locationManager.Start();
            locationManager.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(locationManager_getStatus);
            //
            tbxAddress.Text = locationManager.Position.Location.Latitude.ToString() + ";" + locationManager.Position.Location.Longitude.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            map1.Mode = new AerialMode();
            locationManager.Stop();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
           
            z = map1.ZoomLevel;
            map1.ZoomLevel = ++z;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            
            z = map1.ZoomLevel;
            map1.ZoomLevel = --z;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            map1.Visibility = Visibility.Visible;
           // map1.Visibility = Visibility.Collapsed; //Invisible
            //using System.Device.Location;
            //allows GeoCoordinates
            // map1.Center=new GeoCoordinate(55, -1.5);
            //The GeoCoordinate class is used to create position aware applications not just mapping apps. 
            //As well as specifying position it can also be used to specify a velocity and direction of travel for example.
        }

        void locationManager_getStatus(object sender,
           GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Initializing:
                    tblkStatus.Text = "Loading ...";
                    break;
                case GeoPositionStatus.Ready:
                    tbxAddress.Text = locationManager.Position.Location.Latitude.ToString() + ";" + locationManager.Position.Location.Longitude.ToString();
                    tblkStatus.Text = "Location Available";
                    break;
                case GeoPositionStatus.Disabled:
                    if (locationManager.Permission == GeoPositionPermission.Denied)
                    {
                        tblkStatus.Text = "User has disabled location settings";
                    }
                    else
                        tblkStatus.Text = "Disabled";
                    break;
                case GeoPositionStatus.NoData:
                    tblkStatus.Text = "No Data at this time";
                    break;
                   
            }// end of switch
        } // end of locationManager_getStatus



        void locationManager_getPosition(object sender,GeoPositionChangedEventArgs<GeoCoordinate>newLoc)
        {
            Pushpin myPin = new Pushpin();
            myPin.Location = new GeoCoordinate(newLoc.Position.Location.Latitude, newLoc.Position.Location.Longitude);
            map1.Children.Add(myPin);
            map1.SetView(new GeoCoordinate(newLoc.Position.Location.Latitude, newLoc.Position.Location.Longitude), map1.ZoomLevel);
            tbxAddress.Text = locationManager.Position.Location.Latitude.ToString() + ";" + locationManager.Position.Location.Longitude.ToString();
        } // end of
    }
}


//First you have to create a Pushpin object:
//Pushpin pin = new Pushpin(){Location= 
//             new GeoCoordinate(38, -1.5)};

//This creates a Pushpin at the specified position. To make the pin display you need to add it to the map object:
//MyMap.Children.Add(pin);