using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    class Room
    {
        private string roomName;       //Название комнаты (Кухня, прихожая и т.п.)
        private double roomArea;       //Площадь комнаты в метрах
        private double xCoordinate;    //Координата на оси Х левого верхнего угла
        private double yCoordinate;    //Координата на оси Y левого верхнего угла
        private double widthRoom;      //Ширина комнаты
        private double lengthRoom;     //Длина комнаты
        private bool isUsed;            //Специальный флаг, необходимый для определения, участвовала ли
                                           //комната(элемент списка) в алгоритме или нет.

        public Room()
        {
            roomName = "default";
            roomArea = 0;
            xCoordinate = 0;
            yCoordinate = 0;
            widthRoom = 0;
            lengthRoom = 0;
            isUsed = false;
        }

        public Room(
            string roomName,
            double roomArea,
            double xCoordinate,
            double yCoordinate,
            double widthRoom,
            double lengthRoom,
            bool isUsed
            )
        {
            this.roomName = roomName;
            this.roomArea = roomArea;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.lengthRoom = lengthRoom;
            this.widthRoom = widthRoom;
            this.isUsed = isUsed;
        }
		
		public string RoomName
		{
			get
			{
				return this.roomName;
			}

			set
			{
				this.roomName = value;
			}
		}
        
		public double RoomArea
		{
			get
			{
				return this.roomArea;
			}

			set
			{
				this.roomArea = value < 0 ? 0 : value;
			}
		}
		
        public double X
		{
			get
			{
				return this.xCoordinate;
			}
			
			set
			{
				this.xCoordinate = value < 0 ? 0 : value;
			}
		}
        
		public double Y
		{
			get
			{
				return this.yCoordinate;
			}
			
			set
			{
				this.yCoordinate = value < 0 ? 0 : value;
			}
		}
        
		public double RoomWidth
		{
			get
			{
				return this.widthRoom;
			}
			
			set
			{
				this.widthRoom = value < 0 ? 0 : value;
			}
		}
        
		public double RoomLength
		{
			get
			{
				return this.lengthRoom;
			}
			
			set
			{
				this.lengthRoom = value < 0 ? 0 : value;
			}
		}
    
		public bool IsUsed
		{
			get
			{
				return this.isUsed;
			}
			
			set
			{
				this.isUsed = value;
			}
		}		
    }
}
