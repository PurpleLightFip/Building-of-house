using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    class House
    {
        public List<Room> roomsList = new List<Room>();
        public double houseWidth;
        public double houseLength;

        public House()
        {
            roomsList = null;
            houseWidth = 0;
            houseLength = 0;
        }

        public House(
            List<Room> roomsList,
            double houseWidth,
            double houseLength
            )
        { 
            this.roomsList = roomsList;
            this.houseWidth = houseWidth;
            this.houseLength = houseLength;
        }
		
		public void addRoom(room Room)
		{
			this.roomsList.add(room);
		}
		
		public Room getRoom(integer index)
		{
			return this.roomsList.at(index);
		}
		
        public double HouseWidth
		{
			get
			{
				return this.houseWidth;
			}
			set
			{
				this.houseWidth = value < 0 ? 0 : value;
			}
		}
		
        public double houseLength
		{
			get
			{
				return this.houseLength;
			}
			set
			{
				this.houseLength = value < 0 ? 0 : value;
			}
		}
    }
}
