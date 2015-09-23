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

namespace House_builder
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



        private void btn_Build_button_Click(object sender, RoutedEventArgs e)
        {

            List<Room> room_list = new List<Room>();


            if (Room_number_1.Text != "")
            {
                Room rtc_Room_1 =
                    new Room(
                        "Гостиная",
                        Convert.ToDouble(Room_number_1.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_1);
            }

            if (Room_number_2.Text != "")
            {
                Room rtc_Room_2 =
                    new Room(
                        "Кухня",
                        Convert.ToDouble(Room_number_2.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_2);
            }

            if (Room_number_3.Text != "")
            {
                Room rtc_Room_3 =
                    new Room(
                        "Ванная",
                        Convert.ToDouble(Room_number_3.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_3);
            }

            if (Room_number_4.Text != "")
            {
                Room rtc_Room_4 =
                    new Room(
                        "Санузел",
                        Convert.ToDouble(Room_number_4.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_4);
            }

            if (Room_number_5.Text != "")
            {
                Room rtc_Room_5 =
                    new Room(
                        "Спальня",
                        Convert.ToDouble(Room_number_5.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_5);
            }

            if (Room_number_6.Text != "")
            {
                Room rtc_Room_6 =
                    new Room(
                        "Холл",
                        Convert.ToDouble(Room_number_6.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_6);
            }

            if (Room_number_7.Text != "")
            {
                Room rtc_Room_7 =
                    new Room(
                        "Тамбур",
                        Convert.ToDouble(Room_number_7.Text) * 400,
                        0,
                        0,
                        0,
                        0,
                        false
                        );

                room_list.Add(rtc_Room_7);
            }

            House house = new House(
                room_list,
                Convert.ToDouble(t_dbl_width_house.Text),
                Convert.ToDouble(t_dbl_length_house.Text)
                );

            House_builder house_builder = new House_builder();
            house_builder.buildHouse(house);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
