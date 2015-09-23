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
using System.Windows.Shapes;

namespace House_builder
{
    /// <summary>
    /// Interaction logic for BuildHouseWindow.xaml
    /// </summary>
    public partial class BuildHouseWindow : Window
    {
        List<Room> room_list = new List<Room>();
        public BuildHouseWindow(List<Room> x)
        {
            room_list = x;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Room room = new Room();

            //Задаем цвет контура, его толщину
            Path pthMainStyle = new Path();
            pthMainStyle.Stroke = Brushes.Black;
            pthMainStyle.StrokeThickness = 1;

            //Задаем внутреннюю заливку для прямоугольника
            SolidColorBrush scbMainStyle = new SolidColorBrush();
            scbMainStyle.Color = Color.FromArgb(255, 204, 204, 255);
            pthMainStyle.Fill = scbMainStyle;



            GeometryGroup ggHouse = new GeometryGroup();

            Canvas Canvas_for_create = new Canvas();

            for (int i = 0; i < room_list.Count; i++)
            {
                Rect rtcRect_for_Room = new Rect();
                room =
                    room_list[i];
                //Задаем координаты прямоугольника и его размеры
                rtcRect_for_Room.X = room.dbl_x_coordinate;
                rtcRect_for_Room.Y = room.dbl_y_coordinate;
                rtcRect_for_Room.Width = room.dbl_width_room;
                rtcRect_for_Room.Height = room.dbl_length_room;

                RectangleGeometry rgRoom = new RectangleGeometry();
                rgRoom.Rect = rtcRect_for_Room;

                ggHouse.Children.Add(rgRoom);

            }

            pthMainStyle.Data = ggHouse;

            Canvas_for_create.Children.Add(
                pthMainStyle
                );

            double dbl_SetT = 0;
            double dbl_SetL = 0;

            for (int i = 0; i < room_list.Count; i++)
            {
                dbl_SetT = room_list[i].dbl_y_coordinate +
                    room_list[i].dbl_length_room / 2 - 25;

                dbl_SetL = room_list[i].dbl_x_coordinate +
                    room_list[i].dbl_width_room / 2 - 25;

                Label Name_Room = new Label();
                Name_Room.Content = room_list[i].str_room_name +
                    "\n  " + room_list[i].dbl_room_area / 400;

                dbl_SetT = room_list[i].dbl_y_coordinate +
                    room_list[i].dbl_length_room / 2 - 25;

                dbl_SetL = room_list[i].dbl_x_coordinate +
                    room_list[i].dbl_width_room / 2 - 25;

                Canvas.SetTop(Name_Room, dbl_SetT);
                Canvas.SetLeft(Name_Room, dbl_SetL);

                Canvas_for_create.Children.Add(Name_Room);
            }

            Canvas_for_create.Visibility = Visibility;
            GridHouse.Children.Add(Canvas_for_create);
        }
    }
}
