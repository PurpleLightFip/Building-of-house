using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_builder
{
    class House
    {
        public List<Room> room_list = new List<Room>();
        public double dbl_width_house;
        public double dbl_length_house;

        public House()
        {
            room_list = null;
            dbl_width_house = 0;
            dbl_length_house = 0;
        }

        public House(
            List<Room> room_list,
            double dbl_width_house,
            double dbl_length_house
            )
        { 
            this.room_list = room_list;
            this.dbl_width_house = dbl_width_house;
            this.dbl_length_house = dbl_length_house;
        }

    }
}
