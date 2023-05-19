using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace businessaplicationweek4pd2022_CS_196rollno
{
    
   public class TEST
   {
        public string test_type1;
        public int test_rate1;

        public TEST(string test_type,string test_rate)
        {
            test_type1 = test_type;
            test_rate1 = int.Parse(test_rate);
        }
        public void StoreInTestList(TEST test,List<TEST> tests)
        {
            tests.Add(test);
        }
        public void StoreInTestFile(string path)
        {
            StreamWriter lab_record = new StreamWriter(path, true);

            lab_record.WriteLine(test_type1 + "," + test_rate1);
            lab_record.Flush();
            lab_record.Close();
        }
        public TEST(string test_type)
        {
            test_type1 = test_type;
        }
        public TEST CheckTest(List<TEST> arr)
        {
            
            foreach (TEST obj in arr)
            {
                if (test_type1 == obj.test_type1)
                {
                    
                   return obj;
                }
            }
            Console.WriteLine("An invalid entry that test does not available in our hospital ");
            Console.ReadKey();
            return null;
        }
        public int AddinBill()
        {
            return test_rate1;
        }
    }
}
