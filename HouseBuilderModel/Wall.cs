using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    class Wall
    {
        //Любую прямую стену можно задать с помощью двух точек координат  
        private double xLeftTop;    //Первая точка
        private double yLeftTop;
        private double xRightBottom;    //Вторая точка
        private double yRightBottom;

        public Wall()
        {
            xLeftTop = 0;
            yLeftTop = 0;
            xRightBottom = 0;
            yLeftTop = 0;
        }

        public Wall(
            double xLeftTop,
            double yLeftTop,
            double xRightBottom,
            double yRightBottom
            )
        {
            this.xLeftTop = xLeftTop;
            this.yLeftTop = yLeftTop;
            this.xRightBottom = xRightBottom;
            this.yRightBottom = yRightBottom;
        }
		
		private double XLeftTop
		{
			get
			{
				return this.xLeftTop;
			}
			set
			{
				this.xLeftTop = value < 0 ? 0 : value;
			}
		}
		
        private double YLeftTop
		{
			get
			{
				return this.yLeftTop;
			}
			set
			{
				this.yLeftTop = value < 0 ? 0 : value;
			}
		}
		
        private double XRightBottom
		{
			get
			{
				return this.xRightBottom;
			}
			set
			{
				this.xRightBottom = value < 0 ? 0 : value;
			}
		}
		
        private double YRightBottom
		{
			get
			{
				return this.yRightBottom;
			}
			set
			{
				this.yRightBottom = value < 0 ? 0 : value;
			}
		}
    }
}
