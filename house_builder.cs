using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_builder
{
    class House_builder
    {
        //Функция, запускающая процесс автоматизированного формирования плана дома
        public void buildHouse(House house)
        {
            //Сортировка комнат по убыванию площадей комнат
            house.room_list.Sort(
                delegate(Room R1, Room R2)
                {
                    return R2.dbl_room_area.CompareTo(R1.dbl_room_area);
                }
            );

            createRooms(
                0,
                0,
                house.dbl_width_house,
                house.dbl_length_house,
                house.room_list
                );
        }

        //Функция, вычисляющая координаты верхнего левого угла комнаты,
        //длину и ширину комнаты.
        void createRooms(
            double f_dbl_x_coordinate,
            double f_dbl_y_coordinate,
            double f_dbl_Width,
            double f_dbl_Length,
            List<Room> room_list
            )
        {
            List<Room> copy1_room_list = new List<Room>();
            Room room = new Room();

            for (int i = 0; i < room_list.Count; i++)
            {
                room = room_list[i];
                copy1_room_list.Add(room);
            }		

            #region variation№1
                
            if (iNumberRoomOfNoUse(copy1_room_list) > 2)
            {
                int iRoomIndexV1 = iSelectRoom(
                    copy1_room_list, 
                    f_dbl_x_coordinate,
                    f_dbl_y_coordinate,
                    f_dbl_Width,
                    1
                    );

                if (iRoomIndexV1 != -1)
                {
                    room = copy1_room_list[iRoomIndexV1];

                    double dbl_Area_for_copy = room.dbl_room_area;

                    double dbl_Length_for_copy1 =
                        dbl_Area_for_copy / f_dbl_Width;

                    if (f_dbl_Width / 2 <= dbl_Length_for_copy1 &&
                        dbl_Length_for_copy1 <= 2 * f_dbl_Width
                       )
                    {
                        copy1_room_list[iRoomIndexV1] = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate,
                            f_dbl_Width,
                            dbl_Length_for_copy1,
                            true
                            );

                        createRooms(
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate + dbl_Length_for_copy1,
                            f_dbl_Width,
                            f_dbl_Length - dbl_Length_for_copy1,
                            copy1_room_list
                            );
                    }
                }
             }
             else
             {
                if (iNumberRoomOfNoUse(copy1_room_list) > 1)
                {
                    int iRoomIndexV1 = iSelectRoom(
                        copy1_room_list,
                        f_dbl_x_coordinate,
                        f_dbl_y_coordinate,
                        f_dbl_Width,
                        1
                        );

                    if (iRoomIndexV1 != -1)
                    {
                        room = copy1_room_list[iRoomIndexV1];

                        double dbl_Area_for_copy = room.dbl_room_area;

                        double dbl_Length_for_copy1 =
                            dbl_Area_for_copy / f_dbl_Width;

                        if ((f_dbl_Width / 2 <= dbl_Length_for_copy1 &&
                            dbl_Length_for_copy1 <= 2 * f_dbl_Width) &&
                            ((f_dbl_Length - dbl_Length_for_copy1) <= 2 * f_dbl_Width &&
                            f_dbl_Width / 2 <= (f_dbl_Length - dbl_Length_for_copy1))
                            )
                        {
                            
                            copy1_room_list[iRoomIndexV1] = new Room(
                                room.str_room_name,
                                room.dbl_room_area,
                                f_dbl_x_coordinate,
                                f_dbl_y_coordinate,
                                f_dbl_Width,
                                dbl_Length_for_copy1,
                                true
                                );

                            iRoomIndexV1 = iSelectRoom(
                                copy1_room_list,
                                f_dbl_x_coordinate,
                                f_dbl_y_coordinate + dbl_Length_for_copy1,
                                f_dbl_Width,
                                1
                                );

                            if (iRoomIndexV1 != -1)
                            {
                                room = copy1_room_list[iRoomIndexV1];

                                copy1_room_list[iRoomIndexV1] = new Room(
                                    room.str_room_name,
                                    room.dbl_room_area,
                                    f_dbl_x_coordinate,
                                    f_dbl_y_coordinate + dbl_Length_for_copy1,
                                    f_dbl_Width,
                                    f_dbl_Length - dbl_Length_for_copy1,
                                    true
                                    );

                                createWindow_for_House(copy1_room_list);
                            }
                        }
                    }
                    
                }
            }
            #endregion

            List<Room> copy2_room_list = new List<Room>();

            for (int i = 0; i < room_list.Count; i++)
            {
                room = room_list[i];
                copy2_room_list.Add(room);
            }

            #region variation№2
            if (iNumberRoomOfNoUse(copy2_room_list) > 2)
            {
                int iRoomIndexV2 = iSelectRoom(
                    copy2_room_list,
                    f_dbl_x_coordinate,
                    f_dbl_y_coordinate,
                    f_dbl_Length,
                    2);

                if (iRoomIndexV2 != -1)
                {
                    room = copy2_room_list[iRoomIndexV2];

                    double dbl_Area_for_copy = room.dbl_room_area;

                    double dbl_Width_for_copy2 =
                        dbl_Area_for_copy / f_dbl_Length;

                    if (f_dbl_Length / 2 <= dbl_Width_for_copy2 &&
                        dbl_Width_for_copy2 <= 2 * f_dbl_Length
                       )
                    {
                        copy2_room_list[iRoomIndexV2] = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate,
                            dbl_Width_for_copy2,
                            f_dbl_Length,
                            true
                            ); 

                        createRooms(
                            f_dbl_x_coordinate + dbl_Width_for_copy2,
                            f_dbl_y_coordinate,
                            f_dbl_Width - dbl_Width_for_copy2,
                            f_dbl_Length,
                            copy2_room_list
                            );
                    }
                }
            }
            else 
            {
                if (iNumberRoomOfNoUse(copy2_room_list) > 1)
                {
                    int iRoomIndexV2 = iSelectRoom(
                        copy2_room_list,
                        f_dbl_x_coordinate,
                        f_dbl_y_coordinate,
                        f_dbl_Length,
                        2);

                    if (iRoomIndexV2 != -1)
                    {
                        room = copy2_room_list[iRoomIndexV2];

                        double dbl_Area_for_copy = room.dbl_room_area;

                        double dbl_Width_for_copy2 =
                            dbl_Area_for_copy / f_dbl_Length;

                        if ((f_dbl_Length / 2 <= dbl_Width_for_copy2 &&
                            dbl_Width_for_copy2 <= 2 * f_dbl_Length) &&
                            ((f_dbl_Width - dbl_Width_for_copy2) <= 2 * f_dbl_Length &&
                            f_dbl_Length / 2 <= (f_dbl_Width - dbl_Width_for_copy2))
                            )
                        {
                            Room copy2_Room = new Room(
                                room.str_room_name,
                                room.dbl_room_area,
                                f_dbl_x_coordinate,
                                f_dbl_y_coordinate,
                                dbl_Width_for_copy2,
                                f_dbl_Length,
                                true
                                );

                            copy2_room_list[iRoomIndexV2] = copy2_Room;

                                
                            iRoomIndexV2 = iSelectRoom(copy2_room_list,
                                                      f_dbl_x_coordinate + dbl_Width_for_copy2,
                                                      f_dbl_y_coordinate,
                                                      f_dbl_Length,
                                                      2);

                            if (iRoomIndexV2 != -1)
                            {
                                room = copy2_room_list[iRoomIndexV2];

                                copy2_room_list[iRoomIndexV2] = new Room(
                                        room.str_room_name,
                                        room.dbl_room_area,
                                        f_dbl_x_coordinate + dbl_Width_for_copy2,
                                        f_dbl_y_coordinate,
                                        f_dbl_Width - dbl_Width_for_copy2,
                                        f_dbl_Length,
                                        true
                                        );

                                createWindow_for_House(copy2_room_list);
                            }
                        }
                    }
                }
            }
            #endregion

            //copy2_room_list.Clear();

            List<Room> copy3_room_list = new List<Room>();

            for (int i = 0; i < room_list.Count; i++)
            {
                room = room_list[i];
                copy3_room_list.Add(room);
            }

            #region variations№3
            if (iNumberRoomOfNoUse(copy3_room_list) > 2)
            {
                int iRoomIndexV3 = iSelectRoom(
                    copy3_room_list, 
                    f_dbl_x_coordinate,
                    f_dbl_y_coordinate + f_dbl_Length,
                    f_dbl_Width,
                    3
                    );

                if (iRoomIndexV3 != -1)
                {
                    room = copy3_room_list[iRoomIndexV3];

                    double dbl_Area_for_copy = room.dbl_room_area;

                    double dbl_Length_for_copy3 =
                        dbl_Area_for_copy / f_dbl_Width;

                    if (f_dbl_Width / 2 <= dbl_Length_for_copy3 &&
                        dbl_Length_for_copy3 <= 2 * f_dbl_Width
                       )
                    {

                        copy3_room_list[iRoomIndexV3] = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate + f_dbl_Length - dbl_Length_for_copy3,
                            f_dbl_Width,
                            dbl_Length_for_copy3,
                            true
                            );

                        createRooms(
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate,
                            f_dbl_Width,
                            f_dbl_Length - dbl_Length_for_copy3,
                            copy3_room_list
                            );
                    }
                }
             }
             else
             {
                if (iNumberRoomOfNoUse(copy3_room_list) > 1)
                {
                    int iRoomIndexV3 = iSelectRoom(
                        copy3_room_list,
                        f_dbl_x_coordinate,
                        f_dbl_y_coordinate + f_dbl_Length,
                        f_dbl_Width,
                        3
                        );

                    if (iRoomIndexV3 != -1)
                    {
                        room = copy3_room_list[iRoomIndexV3];

                        double dbl_Area_for_copy = room.dbl_room_area;

                        double dbl_Length_for_copy3 =
                            dbl_Area_for_copy / f_dbl_Width;

                        if ((f_dbl_Width / 2 <= dbl_Length_for_copy3 &&
                            dbl_Length_for_copy3 <= 2 * f_dbl_Width) &&
                            ((f_dbl_Length - dbl_Length_for_copy3) <= 2 * f_dbl_Width &&
                            f_dbl_Width / 2 <= (f_dbl_Length - dbl_Length_for_copy3))
                            )
                        {

                            copy3_room_list[iRoomIndexV3] = new Room(
                                room.str_room_name,
                                room.dbl_room_area,
                                f_dbl_x_coordinate,
                                f_dbl_y_coordinate + f_dbl_Length - dbl_Length_for_copy3,
                                f_dbl_Width,
                                dbl_Length_for_copy3,
                                true
                                );

                            iRoomIndexV3 = iSelectRoom(
                                copy3_room_list,
                                f_dbl_x_coordinate,
                                f_dbl_y_coordinate,
                                f_dbl_Width,
                                1
                                );

                            if (iRoomIndexV3 != -1)
                            {
                                room = copy3_room_list[iRoomIndexV3];

                                copy3_room_list[iRoomIndexV3] = new Room(
                                    room.str_room_name,
                                    room.dbl_room_area,
                                    f_dbl_x_coordinate,
                                    f_dbl_y_coordinate,
                                    f_dbl_Width,
                                    f_dbl_Length - dbl_Length_for_copy3,
                                    true
                                    );

                                createWindow_for_House(copy3_room_list);
                            }
                        }
                    }
                    
                }
            }
            #endregion

            List<Room> copy4_room_list = new List<Room>();

            for (int i = 0; i < room_list.Count; i++)
            {
                room = room_list[i];
                copy4_room_list.Add(room);
            }

            #region variation№4
            if (iNumberRoomOfNoUse(copy4_room_list) > 2)
            {
                int iRoomIndexV4 = iSelectRoom(
                    copy4_room_list,
                    f_dbl_x_coordinate + f_dbl_Width,
                    f_dbl_y_coordinate,
                    f_dbl_Length,
                    4
                    );

                if (iRoomIndexV4 != -1)
                {
                    room = copy4_room_list[iRoomIndexV4];

                    double dbl_Area_for_copy = room.dbl_room_area;

                    double dbl_Width_for_copy4 =
                        dbl_Area_for_copy / f_dbl_Length;

                    if (f_dbl_Length / 2 <= dbl_Width_for_copy4 &&
                        dbl_Width_for_copy4 <= 2 * f_dbl_Length
                       )
                    {
                        Room copy4_Room = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate + f_dbl_Width - dbl_Width_for_copy4,
                            f_dbl_y_coordinate,
                            dbl_Width_for_copy4,
                            f_dbl_Length,
                            true
                            );

                        copy4_room_list[iRoomIndexV4] = copy4_Room;

                        createRooms(
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate,
                            f_dbl_Width - dbl_Width_for_copy4,
                            f_dbl_Length,
                            copy4_room_list
                            );
                    }
                }
            }
            else
            {
                if (iNumberRoomOfNoUse(copy4_room_list) > 1)
                {
                    int iRoomIndexV4 = iSelectRoom(
                        copy4_room_list,
                        f_dbl_x_coordinate + f_dbl_Width,
                        f_dbl_y_coordinate,
                        f_dbl_Length,
                        4);

                    if (iRoomIndexV4 != -1)
                    {
                        room = copy4_room_list[iRoomIndexV4];

                        double dbl_Area_for_copy = room.dbl_room_area;

                        double dbl_Width_for_copy4 =
                            dbl_Area_for_copy / f_dbl_Length;

                        if ((f_dbl_Length / 2 <= dbl_Width_for_copy4 &&
                            dbl_Width_for_copy4 <= 2 * f_dbl_Length) &&
                            ((f_dbl_Width - dbl_Width_for_copy4) <= 2 * f_dbl_Length &&
                            f_dbl_Length / 2 <= (f_dbl_Width - dbl_Width_for_copy4))
                            )
                        {
                            copy4_room_list[iRoomIndexV4] = new Room(
                                room.str_room_name,
                                room.dbl_room_area,
                                f_dbl_x_coordinate + f_dbl_Width - dbl_Width_for_copy4,
                                f_dbl_y_coordinate,
                                dbl_Width_for_copy4,
                                f_dbl_Length,
                                true
                                );

                            iRoomIndexV4 = iSelectRoom(
                                copy4_room_list,
                                f_dbl_x_coordinate,
                                f_dbl_y_coordinate,
                                f_dbl_Length,
                                2);

                            if (iRoomIndexV4 != -1)
                            {
                                room = copy4_room_list[iRoomIndexV4];

                                copy4_room_list[iRoomIndexV4] = new Room(
                                    room.str_room_name,
                                    room.dbl_room_area,
                                    f_dbl_x_coordinate,
                                    f_dbl_y_coordinate,
                                    f_dbl_Width - dbl_Width_for_copy4,
                                    f_dbl_Length,
                                    true
                                    );

                                createWindow_for_House(copy4_room_list);
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
            List<Room> room_list
            )
        {
            Room room = new Room();
            int iSum = 0;   //Переменная, увеличивается на 1, если комната еще не была построена 
            for (int i = 0; i < room_list.Count; i++)
            {
                room = room_list[i];
                if (!room.bFlag_room)
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
            List<Room> f_rtc_Room_list,
            double f_dbl_x_coordinate,
            double f_dbl_y_coordinate,
            double f_dbl_Side,
            int iVersion
            )
        {
            Room room = new Room();
            for (int i = 0; i < f_rtc_Room_list.Count; i++)
            {
                room = f_rtc_Room_list[i];
                if (!room.bFlag_room)      
                {
                    double dbl_Area_for_copy = room.dbl_room_area;

                    Room copy_rtc_Room = new Room();

                    if (iVersion == 1)
                    {
                        double dbl_Length_for_copy1 =
                            dbl_Area_for_copy / f_dbl_Side;

                        copy_rtc_Room = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate,
                            f_dbl_Side,
                            dbl_Length_for_copy1,
                            false
                            );
                    }

                    if (iVersion == 2)
                    {
                        double dbl_Width_for_copy2 =
                            dbl_Area_for_copy / f_dbl_Side;

                        copy_rtc_Room = new Room(
                        room.str_room_name,
                        room.dbl_room_area,
                        f_dbl_x_coordinate,
                        f_dbl_y_coordinate,
                        dbl_Width_for_copy2,
                        f_dbl_Side,
                        false
                        );
                    }

                    if (iVersion == 3)
                    {
                        double dbl_Length_for_copy3 =
                            dbl_Area_for_copy / f_dbl_Side;

                        copy_rtc_Room = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate,
                            f_dbl_y_coordinate - dbl_Length_for_copy3,
                            f_dbl_Side,
                            dbl_Length_for_copy3,
                            false
                            );
                    }

                    if (iVersion == 4)
                    {
                        double dbl_Width_for_copy4 =
                            dbl_Area_for_copy / f_dbl_Side;

                        copy_rtc_Room = new Room(
                            room.str_room_name,
                            room.dbl_room_area,
                            f_dbl_x_coordinate - dbl_Width_for_copy4,
                            f_dbl_y_coordinate,
                            dbl_Width_for_copy4,
                            f_dbl_Side,
                            false
                            );
                    }

                    if (room.str_room_name == "Гостиная")
                    {
                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Кухня",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );




                        bool bFlag2 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        if (bFlag1 && bFlag2)
                            return i;
                    }

                    if (room.str_room_name == "Кухня")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Гостиная",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        bool bFlag2 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        if (bFlag1 && bFlag2)
                            return i;
                    }

                    if (room.str_room_name == "Ванная")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.str_room_name == "Спальня")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.str_room_name == "Санузел")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.str_room_name == "Тамбур")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Холл",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        if (bFlag1)
                            return i;
                    }

                    if (room.str_room_name == "Холл")
                    {

                        bool bFlag1 = CheckTheWall(
                                FoundRoom(
                                    "Гостиная",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        bool bFlag2 = CheckTheWall(
                                FoundRoom(
                                    "Кухня",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        bool bFlag3 = CheckTheWall(
                                FoundRoom(
                                    "Ванная",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        bool bFlag4 = CheckTheWall(
                                FoundRoom(
                                    "Спальня",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        bool bFlag5 = CheckTheWall(
                                FoundRoom(
                                    "Санузел",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
                                );

                        bool bFlag6 = CheckTheWall(
                                FoundRoom(
                                    "Тамбур",
                                    f_rtc_Room_list
                                    ),
                                copy_rtc_Room
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
            Room room_n1,
            Room room_n2
            )
        {
            if (!room_n1.bFlag_room)
                return true;
            else
            {
                #region Wall
                Wall wcLeft_Wall_R1 = new Wall(
                    room_n1.dbl_x_coordinate,
                    room_n1.dbl_y_coordinate,
                    room_n1.dbl_x_coordinate,
                    room_n1.dbl_y_coordinate + room_n1.dbl_length_room
                    );
                Wall wcRigth_Wall_R1 = new Wall(
                    room_n1.dbl_x_coordinate + room_n1.dbl_width_room,
                    room_n1.dbl_y_coordinate,
                    room_n1.dbl_x_coordinate + room_n1.dbl_width_room,
                    room_n1.dbl_y_coordinate + room_n1.dbl_length_room
                    );
                Wall wcTop_Wall_R1 = new Wall(
                    room_n1.dbl_x_coordinate,
                    room_n1.dbl_y_coordinate,
                    room_n1.dbl_x_coordinate + room_n1.dbl_width_room,
                    room_n1.dbl_y_coordinate
                    );
                Wall wcBottom_Wall_R1 = new Wall(
                    room_n1.dbl_x_coordinate,
                    room_n1.dbl_y_coordinate + room_n1.dbl_length_room,
                    room_n1.dbl_x_coordinate + room_n1.dbl_width_room,
                    room_n1.dbl_y_coordinate + room_n1.dbl_length_room
                    );

                Wall wcLeft_Wall_R2 = new Wall(
                    room_n2.dbl_x_coordinate,
                    room_n2.dbl_y_coordinate,
                    room_n2.dbl_x_coordinate,
                    room_n2.dbl_y_coordinate + room_n2.dbl_length_room
                    );
                Wall wcRigth_Wall_R2 = new Wall(
                    room_n2.dbl_x_coordinate + room_n2.dbl_width_room,
                    room_n2.dbl_y_coordinate,
                    room_n2.dbl_x_coordinate + room_n2.dbl_width_room,
                    room_n2.dbl_y_coordinate + room_n2.dbl_length_room
                    );
                Wall wcTop_Wall_R2 = new Wall(
                    room_n2.dbl_x_coordinate,
                    room_n2.dbl_y_coordinate,
                    room_n2.dbl_x_coordinate + room_n2.dbl_width_room,
                    room_n2.dbl_y_coordinate
                    );
                Wall wcBottom_Wall_R2 = new Wall(
                    room_n2.dbl_x_coordinate,
                    room_n2.dbl_y_coordinate + room_n2.dbl_length_room,
                    room_n2.dbl_x_coordinate + room_n2.dbl_width_room,
                    room_n2.dbl_y_coordinate + room_n2.dbl_length_room
                    );
                #endregion

                if (compareWallLR(wcLeft_Wall_R1, wcRigth_Wall_R2) ||
                    compareWallLR(wcLeft_Wall_R2, wcRigth_Wall_R1) ||
                    compareWallTB(wcTop_Wall_R2, wcBottom_Wall_R1) ||
                    compareWallTB(wcTop_Wall_R1, wcBottom_Wall_R2)
                    )
                {
                    return true;
                }

                return false;
            }
        }

        //Сравнение левой стены с правой
        #region compareWall
        bool compareWallLR(
            Wall wall_n1,
            Wall wall_n2)
        {
            if ((wall_n1.dbl_x1_coordinate) ==
                (wall_n2.dbl_x1_coordinate))
            {
                if (
                        ((wall_n1.dbl_y2_coordinate <=
                        wall_n2.dbl_y1_coordinate) 
                        &&
                        (wall_n1.dbl_y1_coordinate <=
                        wall_n2.dbl_y2_coordinate)) 
                        ||
                        ((wall_n2.dbl_y2_coordinate <=
                        wall_n1.dbl_y1_coordinate) 
                        &&
                        (wall_n2.dbl_y1_coordinate <=
                        wall_n1.dbl_y2_coordinate))
                    )
                    return false;
                else return true;
            }
            return false;
        }

        //Сравнение верхней стены с нижней
        bool compareWallTB(
            Wall wall_n1,
            Wall wall_n2)
        {
            if (wall_n1.dbl_y1_coordinate ==
                wall_n2.dbl_y1_coordinate)
            {
                if (
                        ((wall_n1.dbl_x2_coordinate <=
                        wall_n2.dbl_x1_coordinate) 
                        &&
                        (wall_n1.dbl_x1_coordinate <=
                        wall_n2.dbl_x2_coordinate)) 
                        ||
                        ((wall_n2.dbl_x2_coordinate <=
                        wall_n1.dbl_x1_coordinate) 
                        &&
                        (wall_n2.dbl_x1_coordinate <=
                        wall_n1.dbl_x2_coordinate))
                    )
                    return false;
                else return true;
            }
            return false;
        }
        #endregion

        //Поиск комнаты с заданным именем среди использованных в алгоритме.
        Room FoundRoom(
            string f_str_room_name,
            List<Room> room_list
            )
        {
            Room room = new Room();
            for (int i = 0; i < room_list.Count; i++)
            {
                if (room_list[i].str_room_name == f_str_room_name)
                    room = room_list[i];
            }
            return room;
        }

        //Графическое представление дома
        void createWindow_for_House(
            List<Room> room_list
            )
        {
            BuildHouseWindow w = new BuildHouseWindow(room_list);
            w.Show();

            return;
        }
    }
}
