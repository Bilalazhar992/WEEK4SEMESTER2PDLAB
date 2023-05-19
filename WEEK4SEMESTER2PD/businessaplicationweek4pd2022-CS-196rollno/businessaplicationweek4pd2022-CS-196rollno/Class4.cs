using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace businessaplicationweek4pd2022_CS_196rollno
{
    
   public class BLOOD
    {
        public string blood_type1;
        public int blood_packet1;

        public BLOOD(string blood_type,string blood_packet)
        {
            blood_type1 = blood_type;
            blood_packet1 = int.Parse(blood_packet);
        }
        public void StoreInBloodList(BLOOD blood,List<BLOOD> bloods)
        {
            bloods.Add(blood);
        }
        public void StoreInBloodFile(string path)
        {
            StreamWriter blood_record = new StreamWriter(path, true);
            Console.WriteLine(blood_type1 + "," + blood_packet1);
            blood_record.Flush();
            blood_record.Close();
        }
        public void BookBlood(List<BLOOD> arr)
        {
            int flag = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (blood_type1 == arr[i].blood_type1)
                {
                    if (blood_packet1 <= arr[i].blood_packet1)
                    {
                        arr[i].blood_packet1 = arr[i].blood_packet1 - blood_packet1;
                        Console.WriteLine("Sucessfully Booked ");
                    }
                    else
                    {
                        Console.WriteLine("We have not much packets available of that particular type of blood ");
                    }
                    flag++;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("That type of blood is not available here in our blood bank ");
            }
        }
    }
}
