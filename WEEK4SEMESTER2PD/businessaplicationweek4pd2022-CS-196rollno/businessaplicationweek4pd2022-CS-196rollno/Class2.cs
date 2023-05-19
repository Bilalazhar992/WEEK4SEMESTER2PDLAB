using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace businessaplicationweek4pd2022_CS_196rollno
{
   public class DOCTER
    {
        public string docter_name1;
        public string docter_degree1;
        public string docter_specialization1;
        public string docter_id1;
        public string docter_contact_number1;
        public string docter_timing1;
        public string docter_age1;
        public DOCTER(string docter_name, string docter_specialization, string docter_degree, string docter_contact_number, string docter_timing, string docter_age,string docter_id)
        {
            docter_name1 = docter_name;
            docter_degree1 = docter_degree;
            docter_specialization1 = docter_specialization;
            docter_id1 = docter_id;
            docter_contact_number1 = docter_contact_number;
            docter_timing1 = docter_timing;
            docter_age1 = docter_age;
        }
        public void StoreInDocterList(DOCTER docter, List<DOCTER> docters)
        {
            docters.Add(docter);
        }
        public void StoreInDocterFile(string path)
        {            
            StreamWriter docter_record = new StreamWriter(path, true);
            docter_record.WriteLine(docter_name1 + "," + docter_specialization1 + "," + docter_degree1 + "," + docter_timing1 + "," + docter_age1 + "," + docter_id1 + "," + docter_contact_number1);
            docter_record.Flush();
            docter_record.Close();
        }
        public DOCTER(string name,string id)
        {
            docter_name1 = name;
            docter_id1 = id;
        }
        public DOCTER FindDocter(List<DOCTER> docters)
        {
            int flag = 0;
            foreach (DOCTER check in docters)
            {
                if(check.docter_name1==docter_name1&&check.docter_id1==docter_id1)
                {
                    flag++;
                    return check;
                }
            }
            if(flag==0)
            {
                Console.WriteLine(" An invalid entry of docter name or id ");
                Console.ReadKey();
            }
            return null;
        }
        public void ShowDocter()
        {
            Console.WriteLine("---------------------------------------------------------------Docter's Details--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine(" Name: " + docter_name1);
            Console.WriteLine(" Contact number: " + docter_contact_number1);
            Console.WriteLine(" Age: " + docter_age1);
            Console.WriteLine(" Days of docter: " + docter_timing1);
            Console.WriteLine(" Docter's id: " + docter_id1);
            Console.WriteLine(" Docter's Specialization: " + docter_specialization1);
            Console.WriteLine(" Docter's Degrees: " + docter_degree1);
            Console.ReadKey();
        }
       
    }
    
}
