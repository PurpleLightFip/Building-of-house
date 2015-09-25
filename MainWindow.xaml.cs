using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HouseBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnBuildButton_Click(object sender, RoutedEventArgs e)
        {

            List<Room> roomsList = new List<Room>();


            if (RoomN1.Text != "")
            {
                Room rtcRoom1 =
                    new Room(
                        "Гостиная",
                        Convert.ToDouble(RoomN1.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom1);
            }

            if (RoomN2.Text != "")
            {
                Room rtcRoom2 =
                    new Room(
                        "Кухня",
                        Convert.ToDouble(RoomN2.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom2);
            }

            if (RoomN3.Text != "")
            {
                Room rtcRoom3 =
                    new Room(
                        "Ванная",
                        Convert.ToDouble(RoomN3.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom3);
            }

            if (RoomN4.Text != "")
            {
                Room rtcRoom4 =
                    new Room(
                        "Санузел",
                        Convert.ToDouble(RoomN4.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom4);
            }

            if (RoomN5.Text != "")
            {
                Room rtcRoom5 =
                    new Room(
                        "Спальня",
                        Convert.ToDouble(RoomN5.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom5);
            }

            if (RoomN6.Text != "")
            {
                Room rtcRoom6 =
                    new Room(
                        "Холл",
                        Convert.ToDouble(RoomN6.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom6);
            }

            if (RoomN7.Text != "")
            {
                Room rtcRoom7 =
                    new Room(
                        "Тамбур",
                        Convert.ToDouble(RoomN7.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                roomsList.Add(rtcRoom7);
            }

            House house = new House(
                roomsList,
                Convert.ToDouble(tWidthHouse.Text),
                Convert.ToDouble(tLengthHouse.Text)
                );

            HouseBuilder HouseBuilder = new HouseBuilder();
            HouseBuilder.buildHouse(house);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
