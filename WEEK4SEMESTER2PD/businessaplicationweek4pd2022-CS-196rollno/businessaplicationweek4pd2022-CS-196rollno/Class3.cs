using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace businessaplicationweek4pd2022_CS_196rollno
{
   public  class PATIENT
   {
        public string patient_name1;
        public string patient_father_name1;
        public string patient_age1;
        public string patient_blood_group1;
        public string patient_desease1;
        public string patient_id1;
        public string patient_number1;

        public PATIENT(string patient_name,string patient_father_name, string patient_number,string patient_desease,string patient_blood_group,string patient_age,string patient_id)
        {
            patient_name1 = patient_name;
            patient_father_name1 = patient_father_name;
            patient_desease1 = patient_desease;
            patient_blood_group1 = patient_blood_group;
            patient_id1 = patient_id;
            patient_number1 = patient_number;
            patient_age1 = patient_age;

        }
        public void StoreInPatientList(PATIENT patient ,List<PATIENT> patients)
        {
            patients.Add(patient);
        }
        public void StoreInPatientFile(string path)
        {

            StreamWriter patient_record = new StreamWriter(path, true);
            patient_record.WriteLine(patient_name1 + "," + patient_father_name1 + "," + patient_desease1 + "," + patient_number1 + "," + patient_blood_group1 + "," + patient_age1 + "," + patient_id1);
            patient_record.Flush();
            patient_record.Close();
        }
        public PATIENT(string patient_name,string patient_id)
        {
            patient_name1 = patient_name;
            patient_id1 = patient_id;
        }
        public PATIENT FindPatient(List<PATIENT> objects)
        {
            int flag = 0;
            foreach (PATIENT check in objects)
            {
                if (check.patient_name1 == patient_name1 && check.patient_id1 == patient_id1)
                {
                    flag++;
                    return check;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine(" An invalid entry of patient name or id ");
                Console.ReadKey();
            }
            return null;
        }
        public void ShowPatient()
        {
            Console.WriteLine("-------------------------------------------------------------------Patient's Details--------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" Name: " + patient_name1);
            Console.WriteLine(" Contact number: " + patient_number1);
            Console.WriteLine(" Age: " + patient_age1);
            Console.WriteLine(" Father name of patient: " + patient_father_name1);
            Console.WriteLine(" Patient's id: " + patient_id1);
            Console.WriteLine(" Patient's Desease: " + patient_desease1);
            Console.WriteLine(" Patient's Blood Group: " + patient_blood_group1);
        }
        public int FindIndex(List<PATIENT> patients)
        {
            int flag = 0;
            int i;
            for(i=0;i<patients.Count;i++)
            {
                if(patients[i].patient_name1==patient_name1 && patients[i].patient_id1==patient_id1)
                {
                    flag++;
                    return i;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine(" An invalid entry of patient name or id ");
                Console.ReadKey();
            }
            return i;
        }
        public void DeleteRecord(List<PATIENT> patients,int index)
        {
            patients.RemoveAt(index);
        }
    }
}