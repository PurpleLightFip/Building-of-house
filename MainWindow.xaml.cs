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

            List<room> room_list = new List<room>();


            if (Room_number_1.Text != "")
            {
                room rtc_Room_1 =
                    new room(
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
                room rtc_Room_2 =
                    new room(
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
                room rtc_Room_3 =
                    new room(
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
                room rtc_Room_4 =
                    new room(
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
                room rtc_Room_5 =
                    new room(
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
                room rtc_Room_6 =
                    new room(
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
                room rtc_Room_7 =
                    new room(
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

            house House = new house(
                room_list,
                t_dbl_width_house.Text,
                t_dbl_length_house.Text
                )

            house_builder House_builder = new house_builder();
            House_builder.buildHouse(House);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
