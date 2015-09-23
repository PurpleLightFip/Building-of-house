using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_builder
{
    class Room
    {
        public string str_room_name;       //Название комнаты (Кухня, прихожая и т.п.)
        public double dbl_room_area;       //Площадь комнаты в метрах
        public double dbl_x_coordinate;    //Координата на оси Х левого верхнего угла
        public double dbl_y_coordinate;    //Координата на оси Y левого верхнего угла
        public double dbl_width_room;      //Ширина комнаты
        public double dbl_length_room;     //Длина комнаты
        public bool bFlag_room;            //Специальный флаг, необходимый для определения, участвовала ли
                                           //комната(элемент списка) в алгоритме или нет.

        public Room()
        {
            str_room_name = "default";
            dbl_room_area = 0;
            dbl_x_coordinate = 0;
            dbl_y_coordinate = 0;
            dbl_width_room = 0;
            dbl_length_room = 0;
            bFlag_room = false;
        }

        public Room(
            string str_room_name,
            double dbl_room_area,
            double dbl_x_coordinate,
            double dbl_y_coordinate,
            double dbl_width_room,
            double dbl_length_room,
            bool bFlag_room
            )
        {
            this.str_room_name = str_room_name;
            this.dbl_room_area = dbl_room_area;
            this.dbl_x_coordinate = dbl_x_coordinate;
            this.dbl_y_coordinate = dbl_y_coordinate;
            this.dbl_length_room = dbl_length_room;
            this.dbl_width_room = dbl_width_room;
            this.bFlag_room = bFlag_room;
        }
    }
}
