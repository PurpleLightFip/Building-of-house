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

namespace HouseBuilder
{
    /// <summary>
    /// Interaction logic for BuildHouseWindow.xaml
    /// </summary>
    public partial class BuildHouseWindow : Window
    {
        List<Room> roomsList = new List<Room>();
        public BuildHouseWindow(List<Room> x)
        {
            roomsList = x;
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

            Canvas canvasforCreate = new Canvas();

            for (int i = 0; i < roomsList.Count; i++)
            {
                Rect rtcRectForRoom = new Rect();
                room =
                    roomsList[i];
                //Задаем координаты прямоугольника и его размеры
                rtcRectForRoom.X = room.XCoordinate;
                rtcRectForRoom.Y = room.YCoordinate;
                rtcRectForRoom.Width = room.RoomWidth;
                rtcRectForRoom.Height = room.RoomLength;

                RectangleGeometry rgRoom = new RectangleGeometry();
                rgRoom.Rect = rtcRectForRoom;

                ggHouse.Children.Add(rgRoom);

            }

            pthMainStyle.Data = ggHouse;

            canvasforCreate.Children.Add(
                pthMainStyle
                );

            double setT = 0;
            double setL = 0;

            for (int i = 0; i < roomsList.Count; i++)
            {
                setT = roomsList[i].YCoordinate +
                    roomsList[i].RoomLength / 2 - 25;

                setL = roomsList[i].XCoordinate +
                    roomsList[i].RoomWidth / 2 - 25;

                Label nameRoom = new Label();
                nameRoom.Content = roomsList[i].str_room_name +
                    "\n  " + roomsList[i].dbl_room_area / 400;

                setT = roomsList[i].YCoordinate +
                    roomsList[i].RoomLength / 2 - 25;

                setL = roomsList[i].XCoordinate +
                    roomsList[i].RoomWidth / 2 - 25;

                Canvas.SetTop(nameRoom, setT);
                Canvas.SetLeft(nameRoom, setL);

                canvasforCreate.Children.Add(nameRoom);
            }

            canvasforCreate.Visibility = Visibility;
            GridHouse.Children.Add(canvasforCreate);
        }
    }
}
