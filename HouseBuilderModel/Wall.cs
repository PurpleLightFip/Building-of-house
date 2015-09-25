using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    class wall
    {
        //Любую прямую стену можно задать с помощью двух точек координат  
        public double dbl_x1_coordinate;    //Первая точка
        public double dbl_y1_coordinate;
        public double dbl_x2_coordinate;    //Вторая точка
        public double dbl_y2_coordinate;

        public wall()
        {
            dbl_x1_coordinate = 0;
            dbl_y1_coordinate = 0;
            dbl_x2_coordinate = 0;
            dbl_y1_coordinate = 0;
        }

        public wall(
            double dbl_x1_coordinate,
            double dbl_y1_coordinate,
            double dbl_x2_coordinate,
            double dbl_y2_coordinate
            )
        {
            this.dbl_x1_coordinate = dbl_x1_coordinate;
            this.dbl_y1_coordinate = dbl_y1_coordinate;
            this.dbl_x2_coordinate = dbl_x2_coordinate;
            this.dbl_y2_coordinate = dbl_y2_coordinate;
        }
    }
}
