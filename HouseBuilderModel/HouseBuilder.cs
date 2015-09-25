using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuilder
{
    class HouseBuilder
    {
        //Функция, запускающая процесс автоматизированного формирования плана дома
        public static void buildHouse(House house)
        {
            //Сортировка комнат по убыванию площадей комнат
            house.RoomsList.Sort(
                delegate(Room R1, Room R2)
                {
                    return R2.RoomArea.CompareTo(R1.RoomArea);
                }
            );

            createRooms(
                0,
                0,
                house.HouseWidth,
                house.HouseLength,
                house.RoomsList
                );
        }

        //Функция, вычисляющая координаты верхнего левого угла комнаты,
        //длину и ширину комнаты.
        void createRooms(
            double fXCoordinate,
            double fYCoordinate,
            double fWidth,
            double fLength,
            List<Room> RoomsList
            )
        {
            List<Room> copyRoomsList1 = new List<Room>();
            Room room = new Room();

            for (int i = 0; i < RoomsList.Count; i++)
            {
                room = RoomsList[i];
                copyRoomsList1.Add(room);
            }		

            #region variation№1
                
            if (iNumberRoomOfNoUse(copyRoomsList1) > 2)
            {
                int iRoomIndexV1 = iSelectRoom(
                    copyRoomsList1, 
                    fXCoordinate,
                    fYCoordinate,
                    fWidth,
                    1
                    );

                if (iRoomIndexV1 != -1)
                {
                    room = copyRoomsList1[iRoomIndexV1];

                    double areaForCopy = room.RoomArea;

                    double lengthForCopy1 =
                        areaForCopy / fWidth;

                    if (fWidth / 2 <= lengthForCopy1 &&
                        lengthForCopy1 <= 2 * fWidth
                       )
                    {
                        copyRoomsList1[iRoomIndexV1] = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate,
                            fYCoordinate,
                            fWidth,
                            lengthForCopy1,
                            true
                            );

                        createRooms(
                            fXCoordinate,
                            fYCoordinate + lengthForCopy1,
                            fWidth,
                            fLength - lengthForCopy1,
                            copyRoomsList1
                            );
                    }
                }
             }
             else
             {
                if (iNumberRoomOfNoUse(copyRoomsList1) > 1)
                {
                    int iRoomIndexV1 = iSelectRoom(
                        copyRoomsList1,
                        fXCoordinate,
                        fYCoordinate,
                        fWidth,
                        1
                        );

                    if (iRoomIndexV1 != -1)
                    {
                        room = copyRoomsList1[iRoomIndexV1];

                        double areaForCopy = room.RoomArea;

                        double lengthForCopy1 =
                            areaForCopy / fWidth;

                        if ((fWidth / 2 <= lengthForCopy1 &&
                            lengthForCopy1 <= 2 * fWidth) &&
                            ((fLength - lengthForCopy1) <= 2 * fWidth &&
                            fWidth / 2 <= (fLength - lengthForCopy1))
                            )
                        {
                            
                            copyRoomsList1[iRoomIndexV1] = new Room(
                                room.RoomName,
                                room.RoomArea,
                                fXCoordinate,
                                fYCoordinate,
                                fWidth,
                                lengthForCopy1,
                                true
                                );

                            iRoomIndexV1 = iSelectRoom(
                                copyRoomsList1,
                                fXCoordinate,
                                fYCoordinate + lengthForCopy1,
                                fWidth,
                                1
                                );

                            if (iRoomIndexV1 != -1)
                            {
                                room = copyRoomsList1[iRoomIndexV1];

                                copyRoomsList1[iRoomIndexV1] = new Room(
                                    room.RoomName,
                                    room.RoomArea,
                                    fXCoordinate,
                                    fYCoordinate + lengthForCopy1,
                                    fWidth,
                                    fLength - lengthForCopy1,
                                    true
                                    );

                                createWindowForHouse(copyRoomsList1);
                            }
                        }
                    }
                    
                }
            }
            #endregion

            List<Room> roomsListCopy2 = new List<Room>();

            for (int i = 0; i < RoomsList.Count; i++)
            {
                room = RoomsList[i];
                roomsListCopy2.Add(room);
            }

            #region variation№2
            if (iNumberRoomOfNoUse(roomsListCopy2) > 2)
            {
                int iRoomIndexV2 = iSelectRoom(
                    roomsListCopy2,
                    fXCoordinate,
                    fYCoordinate,
                    fLength,
                    2);

                if (iRoomIndexV2 != -1)
                {
                    room = roomsListCopy2[iRoomIndexV2];

                    double areaForCopy = room.RoomArea;

                    double widthForCopy2 =
                        areaForCopy / fLength;

                    if (fLength / 2 <= widthForCopy2 &&
                        widthForCopy2 <= 2 * fLength
                       )
                    {
                        roomsListCopy2[iRoomIndexV2] = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate,
                            fYCoordinate,
                            widthForCopy2,
                            fLength,
                            true
                            ); 

                        createRooms(
                            fXCoordinate + widthForCopy2,
                            fYCoordinate,
                            fWidth - widthForCopy2,
                            fLength,
                            roomsListCopy2
                            );
                    }
                }
            }
            else 
            {
                if (iNumberRoomOfNoUse(roomsListCopy2) > 1)
                {
                    int iRoomIndexV2 = iSelectRoom(
                        roomsListCopy2,
                        fXCoordinate,
                        fYCoordinate,
                        fLength,
                        2);

                    if (iRoomIndexV2 != -1)
                    {
                        room = roomsListCopy2[iRoomIndexV2];

                        double areaForCopy = room.RoomArea;

                        double widthForCopy2 =
                            areaForCopy / fLength;

                        if ((fLength / 2 <= widthForCopy2 &&
                            widthForCopy2 <= 2 * fLength) &&
                            ((fWidth - widthForCopy2) <= 2 * fLength &&
                            fLength / 2 <= (fWidth - widthForCopy2))
                            )
                        {
                            Room copy2_Room = new Room(
                                room.RoomName,
                                room.RoomArea,
                                fXCoordinate,
                                fYCoordinate,
                                widthForCopy2,
                                fLength,
                                true
                                );

                            roomsListCopy2[iRoomIndexV2] = copy2_Room;

                                
                            iRoomIndexV2 = iSelectRoom(roomsListCopy2,
                                                      fXCoordinate + widthForCopy2,
                                                      fYCoordinate,
                                                      fLength,
                                                      2);

                            if (iRoomIndexV2 != -1)
                            {
                                room = roomsListCopy2[iRoomIndexV2];

                                roomsListCopy2[iRoomIndexV2] = new Room(
                                        room.RoomName,
                                        room.RoomArea,
                                        fXCoordinate + widthForCopy2,
                                        fYCoordinate,
                                        fWidth - widthForCopy2,
                                        fLength,
                                        true
                                        );

                                createWindowForHouse(roomsListCopy2);
                            }
                        }
                    }
                }
            }
            #endregion

            //roomsListCopy2.Clear();

            List<Room> roomsListCopy3 = new List<Room>();

            for (int i = 0; i < RoomsList.Count; i++)
            {
                room = RoomsList[i];
                roomsListCopy3.Add(room);
            }

            #region variations№3
            if (iNumberRoomOfNoUse(roomsListCopy3) > 2)
            {
                int iRoomIndexV3 = iSelectRoom(
                    roomsListCopy3, 
                    fXCoordinate,
                    fYCoordinate + fLength,
                    fWidth,
                    3
                    );

                if (iRoomIndexV3 != -1)
                {
                    room = roomsListCopy3[iRoomIndexV3];

                    double areaForCopy = room.RoomArea;

                    double lengthForCopy3 =
                        areaForCopy / fWidth;

                    if (fWidth / 2 <= lengthForCopy3 &&
                        lengthForCopy3 <= 2 * fWidth
                       )
                    {

                        roomsListCopy3[iRoomIndexV3] = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate,
                            fYCoordinate + fLength - lengthForCopy3,
                            fWidth,
                            lengthForCopy3,
                            true
                            );

                        createRooms(
                            fXCoordinate,
                            fYCoordinate,
                            fWidth,
                            fLength - lengthForCopy3,
                            roomsListCopy3
                            );
                    }
                }
             }
             else
             {
                if (iNumberRoomOfNoUse(roomsListCopy3) > 1)
                {
                    int iRoomIndexV3 = iSelectRoom(
                        roomsListCopy3,
                        fXCoordinate,
                        fYCoordinate + fLength,
                        fWidth,
                        3
                        );

                    if (iRoomIndexV3 != -1)
                    {
                        room = roomsListCopy3[iRoomIndexV3];

                        double areaForCopy = room.RoomArea;

                        double lengthForCopy3 =
                            areaForCopy / fWidth;

                        if ((fWidth / 2 <= lengthForCopy3 &&
                            lengthForCopy3 <= 2 * fWidth) &&
                            ((fLength - lengthForCopy3) <= 2 * fWidth &&
                            fWidth / 2 <= (fLength - lengthForCopy3))
                            )
                        {

                            roomsListCopy3[iRoomIndexV3] = new Room(
                                room.RoomName,
                                room.RoomArea,
                                fXCoordinate,
                                fYCoordinate + fLength - lengthForCopy3,
                                fWidth,
                                lengthForCopy3,
                                true
                                );

                            iRoomIndexV3 = iSelectRoom(
                                roomsListCopy3,
                                fXCoordinate,
                                fYCoordinate,
                                fWidth,
                                1
                                );

                            if (iRoomIndexV3 != -1)
                            {
                                room = roomsListCopy3[iRoomIndexV3];

                                roomsListCopy3[iRoomIndexV3] = new Room(
                                    room.RoomName,
                                    room.RoomArea,
                                    fXCoordinate,
                                    fYCoordinate,
                                    fWidth,
                                    fLength - lengthForCopy3,
                                    true
                                    );

                                createWindowForHouse(roomsListCopy3);
                            }
                        }
                    }
                    
                }
            }
            #endregion

            List<Room> roomsListCopy4 = new List<Room>();

            for (int i = 0; i < RoomsList.Count; i++)
            {
                room = RoomsList[i];
                roomsListCopy4.Add(room);
            }

            #region variation№4
            if (iNumberRoomOfNoUse(roomsListCopy4) > 2)
            {
                int iRoomIndexV4 = iSelectRoom(
                    roomsListCopy4,
                    fXCoordinate + fWidth,
                    fYCoordinate,
                    fLength,
                    4
                    );

                if (iRoomIndexV4 != -1)
                {
                    room = roomsListCopy4[iRoomIndexV4];

                    double areaForCopy = room.RoomArea;

                    double widthForCopy4 =
                        areaForCopy / fLength;

                    if (fLength / 2 <= widthForCopy4 &&
                        widthForCopy4 <= 2 * fLength
                       )
                    {
                        Room copy4_Room = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate + fWidth - widthForCopy4,
                            fYCoordinate,
                            widthForCopy4,
                            fLength,
                            true
                            );

                        roomsListCopy4[iRoomIndexV4] = copy4_Room;

                        createRooms(
                            fXCoordinate,
                            fYCoordinate,
                            fWidth - widthForCopy4,
                            fLength,
                            roomsListCopy4
                            );
                    }
                }
            }
            else
            {
                if (iNumberRoomOfNoUse(roomsListCopy4) > 1)
                {
                    int iRoomIndexV4 = iSelectRoom(
                        roomsListCopy4,
                        fXCoordinate + fWidth,
                        fYCoordinate,
                        fLength,
                        4);

                    if (iRoomIndexV4 != -1)
                    {
                        room = roomsListCopy4[iRoomIndexV4];

                        double areaForCopy = room.RoomArea;

                        double widthForCopy4 =
                            areaForCopy / fLength;

                        if ((fLength / 2 <= widthForCopy4 &&
                            widthForCopy4 <= 2 * fLength) &&
                            ((fWidth - widthForCopy4) <= 2 * fLength &&
                            fLength / 2 <= (fWidth - widthForCopy4))
                            )
                        {
                            roomsListCopy4[iRoomIndexV4] = new Room(
                                room.RoomName,
                                room.RoomArea,
                                fXCoordinate + fWidth - widthForCopy4,
                                fYCoordinate,
                                widthForCopy4,
                                fLength,
                                true
                                );

                            iRoomIndexV4 = iSelectRoom(
                                roomsListCopy4,
                                fXCoordinate,
                                fYCoordinate,
                                fLength,
                                2);

                            if (iRoomIndexV4 != -1)
                            {
                                room = roomsListCopy4[iRoomIndexV4];

                                roomsListCopy4[iRoomIndexV4] = new Room(
                                    room.RoomName,
                                    room.RoomArea,
                                    fXCoordinate,
                                    fYCoordinate,
                                    fWidth - widthForCopy4,
                                    fLength,
                                    true
                                    );

                                createWindowForHouse(roomsListCopy4);
                            }
                        }
                    }
                }
            }
            #endregion

        return;
        }

        //Функция, возвращающая количество комнат, 
        //для которых еще не определено местоположение
        int iNumberRoomOfNoUse(
            List<Room> RoomsList
            )
        {
            Room room = new Room();
            int iSum = 0;   //Переменная, увеличивается на 1, если комната еще не была построена 
            for (int i = 0; i < RoomsList.Count; i++)
            {
                room = RoomsList[i];
                if (!room.IsUsed)
                {
                    iSum++;
                }
            }
            return iSum;
        }

        //Функция нахождения индекса самой приоритетной комнаты, 
        //необходимой для дальнейшей работы программы.
        //Возвращает или индекс комнаты, или -1, что символизирует о том,
        //что ни одна комната не подходит для продолжения алгоритма.
        int iSelectRoom(
            List<Room> rtcRoomsList,
            double fXCoordinate,
            double fYCoordinate,
            double fSide,
            int iVersion
            )
        {
            Room room = new Room();
            for (int i = 0; i < rtcRoomsList.Count; i++)
            {
                room = rtcRoomsList[i];
                if (!room.IsUsed)      
                {
                    double areaForCopy = room.RoomArea;

                    Room rtcRoomCopy = new Room();

                    if (iVersion == 1)
                    {
                        double lengthForCopy1 =
                            areaForCopy / fSide;

                        rtcRoomCopy = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate,
                            fYCoordinate,
                            fSide,
                            lengthForCopy1,
                            false
                            );
                    }

                    if (iVersion == 2)
                    {
                        double widthForCopy2 =
                            areaForCopy / fSide;

                        rtcRoomCopy = new Room(
                        room.RoomName,
                        room.RoomArea,
                        fXCoordinate,
                        fYCoordinate,
                        widthForCopy2,
                        fSide,
                        false
                        );
                    }

                    if (iVersion == 3)
                    {
                        double lengthForCopy3 =
                            areaForCopy / fSide;

                        rtcRoomCopy = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate,
                            fYCoordinate - lengthForCopy3,
                            fSide,
                            lengthForCopy3,
                            false
                            );
                    }

                    if (iVersion == 4)
                    {
                        double widthForCopy4 =
                            areaForCopy / fSide;

                        rtcRoomCopy = new Room(
                            room.RoomName,
                            room.RoomArea,
                            fXCoordinate - widthForCopy4,
                            fYCoordinate,
                            widthForCopy4,
                            fSide,
                            false
                            );
                    }

                    if (room.RoomName == "Гостиная")
                    {
                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Кухня",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );




                        bool bFlag2 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1 && bFlag2)
                            return i;
                    }

                    if (room.RoomName == "Кухня")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Гостиная",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        bool bFlag2 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1 && bFlag2)
                            return i;
                    }

                    if (room.RoomName == "Ванная")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.RoomName == "Спальня")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.RoomName == "Санузел")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.RoomName == "Тамбур")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.RoomName == "Холл")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Гостиная",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        bool bFlag2 = CheckTheWall(
                                FoundRoom(
                                    "Кухня",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        bool bFlag3 = CheckTheWall(
                                FoundRoom(
                                    "Ванная",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        bool bFlag4 = CheckTheWall(
                                FoundRoom(
                                    "Спальня",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        bool bFlag5 = CheckTheWall(
                                FoundRoom(
                                    "Санузел",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        bool bFlag6 = CheckTheWall(
                                FoundRoom(
                                    "Тамбур",
                                    rtcRoomsList
                                    ),
                                rtcRoomCopy
                                );

                        if (bFlag1 && bFlag2 && bFlag3 &&
                            bFlag4 && bFlag5 && bFlag6)
                            return i;
                    }
                }
            }
            return -1;
        }

        //Поиск общей стены. Если общая стена существует, 
        //результат true, иначе false.
        bool CheckTheWall(
            Room roomN1,
            Room roomN2
            )
        {
            if (!roomN1.IsUsed)
                return true;
            else
            {
                #region Wall
                Wall wcLeftWallR1 = new Wall(
                    roomN1.xCoordinate,
                    roomN1.yCoordinate,
                    roomN1.xCoordinate,
                    roomN1.yCoordinate + roomN1.RoomLength
                    );
                Wall wcRigthWallR1 = new Wall(
                    roomN1.xCoordinate + roomN1.RoomWidth,
                    roomN1.yCoordinate,
                    roomN1.xCoordinate + roomN1.RoomWidth,
                    roomN1.yCoordinate + roomN1.RoomLength
                    );
                Wall wcTopWallR1 = new Wall(
                    roomN1.xCoordinate,
                    roomN1.yCoordinate,
                    roomN1.xCoordinate + roomN1.RoomWidth,
                    roomN1.yCoordinate
                    );
                Wall wcBottomWallR1 = new Wall(
                    roomN1.xCoordinate,
                    roomN1.yCoordinate + roomN1.RoomLength,
                    roomN1.xCoordinate + roomN1.RoomWidth,
                    roomN1.yCoordinate + roomN1.RoomLength
                    );

                Wall wcBottomWallR2 = new Wall(
                    roomN2.xCoordinate,
                    roomN2.yCoordinate,
                    roomN2.xCoordinate,
                    roomN2.yCoordinate + roomN2.RoomLength
                    );
                Wall wcRigthWallR2 = new Wall(
                    roomN2.xCoordinate + roomN2.RoomWidth,
                    roomN2.yCoordinate,
                    roomN2.xCoordinate + roomN2.RoomWidth,
                    roomN2.yCoordinate + roomN2.RoomLength
                    );
                Wall wcTopWallR2 = new Wall(
                    roomN2.xCoordinate,
                    roomN2.yCoordinate,
                    roomN2.xCoordinate + roomN2.RoomWidth,
                    roomN2.yCoordinate
                    );
                Wall wcBottomWallR2 = new Wall(
                    roomN2.xCoordinate,
                    roomN2.yCoordinate + roomN2.RoomLength,
                    roomN2.xCoordinate + roomN2.RoomWidth,
                    roomN2.yCoordinate + roomN2.RoomLength
                    );
                #endregion

                return (compareWallLR(wcLeftWallR1, wcRigthWallR2) ||
                    compareWallLR(wcBottomWallR2, wcRigthWallR1) ||
                    compareWallTB(wcTopWallR2, wcBottomWallR1) ||
                    compareWallTB(wcTopWallR1, wcBottomWallR2));
            }
        }

        //Сравнение левой стены с правой
        #region compareWall
        bool compareWallLR(
            Wall wallN1,
            Wall wallN2)
        {
            if ((wallN1.XLeftTop) ==
                (wallN2.XLeftTop))
            {
                if (
                        ((wallN1.dbl_y2_coordinate <=
                        wallN2.YLeftTop) 
                        &&
                        (wallN1.YLeftTop <=
                        wallN2.dbl_y2_coordinate)) 
                        ||
                        ((wallN2.dbl_y2_coordinate <=
                        wallN1.YLeftTop) 
                        &&
                        (wallN2.YLeftTop <=
                        wallN1.dbl_y2_coordinate))
                    )
                    return false;
                else return true;
            }
            return false;
        }

        //Сравнение верхней стены с нижней
        bool compareWallTB(
            Wall wallN1,
            Wall wallN2)
        {
            if (wallN1.YLeftTop ==
                wallN2.YLeftTop)
            {
                if (
                        ((wallN1.XRightBottom <=
                        wallN2.XLeftTop) 
                        &&
                        (wallN1.XLeftTop <=
                        wallN2.XRightBottom)) 
                        ||
                        ((wallN2.XRightBottom <=
                        wallN1.XLeftTop) 
                        &&
                        (wallN2.XLeftTop <=
                        wallN1.XRightBottom))
                    )
                    return false;
                else return true;
            }
            return false;
        }
        #endregion

        //Поиск комнаты с заданным именем среди использованных в алгоритме.
        Room FoundRoom(
            string fRoomName,
            List<Room> RoomsList
            )
        {
            Room room = new Room();
            for (int i = 0; i < RoomsList.Count; i++)
            {
                if (RoomsList[i].RoomName == fRoomName)
                    room = RoomsList[i];
            }
            return room;
        }

        //Графическое представление дома
        void createWindowForHouse(
            List<Room> RoomsList
            )
        {
            BuildHouseWindow w = new BuildHouseWindow(RoomsList);
            w.Show();

            return;
        }
    }
}
