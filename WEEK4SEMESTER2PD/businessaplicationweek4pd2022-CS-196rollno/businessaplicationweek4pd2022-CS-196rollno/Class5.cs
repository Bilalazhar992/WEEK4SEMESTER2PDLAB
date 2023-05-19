using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace businessaplicationweek4pd2022_CS_196rollno
{
    public class ROOM
    {

        public string room_type1;
        public int room_rate1;
        public int no_of_room1;

        public ROOM(string room_type,string room_rate,string no_of_room)
        {
            room_type1 = room_type;
            room_rate1 = int.Parse(room_rate);
            no_of_room1 = int.Parse(no_of_room);
        }
        public void StoreInRoomList(ROOM room,List<ROOM> rooms)
        {
            rooms.Add(room);
        }
        public void StoreInRoomFile(string path)
        {
            
                StreamWriter room_record = new StreamWriter(path, true);
                room_record.WriteLine(room_type1 + "," + room_rate1 + "," + no_of_room1);
                room_record.Flush();
                room_record.Close();    
        }
        public ROOM(string room_type)
        {
            room_type1 = room_type;
        }
        public ROOM BookRoom(List<ROOM> ARRAY)
        {
            
            for (int n = 0; n < ARRAY.Count; n++)
            {
                if (room_type1== ARRAY[n].room_type1)
                {
                    if (ARRAY[n].no_of_room1 >= 1)
                    {
                        Console.WriteLine("YOUR ROOM IS SUCEESSFULLY BOOKED ");
                        ARRAY[n].no_of_room1--;
                        return ARRAY[n];
                    }
                    else
                    {
                        Console.WriteLine("All the rooms of this type are totally booked ");
                    }
                    
                }
            }
            Console.WriteLine("THAT TYPE OF ROOM DOES NOT EXIST IN OUR HOSPITAL ");
            return null;
            
        }
        public int AddinBill()
        {
            return room_rate1;
        }
    }
}
