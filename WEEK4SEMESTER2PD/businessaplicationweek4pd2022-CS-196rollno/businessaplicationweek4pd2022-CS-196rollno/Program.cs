using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace businessaplicationweek4pd2022_CS_196rollno
{
    class Program
    {
       

        static int total = 0;
        static int bill = 0;
        static void Main(string[] args)
        {
            logo();
            welcome();
            loading();
            bool isValid;
            string option = "";
            string user_decision;
            string admin_decision;
            List<MUser> users = new List<MUser>();
            List<DOCTER> docters = new List<DOCTER>();
            List<PATIENT> patients = new List<PATIENT>();
            List<BLOOD> bloods = new List<BLOOD>();
            List<ROOM> rooms = new List<ROOM>();
            List<TEST> tests = new List<TEST>();
            

            string path = "textfile.txt";
            string path1 = "docterfile.txt";
            string path2 = "patientfile.txt";
            string path3 = "bloodtfile.txt";
            string path4 = "roomfile.txt";
            string path5 = "testfile.txt";
            readfile(users,path);
            read_file2(docters,path1);
            read_file3(patients,path2);
            read_file4(bloods,path3);
            read_file5(rooms,path4);
            read_file6(tests,path5);
            do
            {
                Console.Clear();
                logo();
                option = Menu();
                Console.Clear();
                if (option == "1")
                {
                    MUser user = takeInputWithRole();
                    isValid = user.isValidname(users);
                    if (isValid)
                    {
                        user.StoreInList(user, users);
                        Console.WriteLine("SignedUp Sucessfully ");
                        user.StoreInFile(path);
                    }
                    else
                    {
                        Console.WriteLine("User Already Exists ");
                    }
                }
                else if(option=="2")
                {
                    string role;
                    MUser user = takeInputWithoutRole();
                    if(user.SignIn(users))
                    {
                        user = user.ReturnObject(users);
                        role = user.CheckRole();
                        if (role == "admin" || role == "Admin" || role == "ADMIN")
                        {
                            while (true)
                            {
                                Console.Clear();
                                logo();
                                admin_decision = admin_menu();
                                if (admin_decision == "1")
                                {
                                    Console.Clear();
                                    logo();
                                    DOCTER docter = Inputdocterdata();
                                    docter.StoreInDocterList(docter, docters);
                                    docter.StoreInDocterFile(path1);
                                }
                                else if (admin_decision == "2")
                                {
                                    Console.Clear();
                                    logo();
                                    PATIENT patient = Inputpatientdata();
                                    patient.StoreInPatientList(patient, patients);
                                    patient.StoreInPatientFile(path2);
                                }
                                else if (admin_decision == "3")
                                {
                                    Console.Clear();
                                    logo();
                                    DOCTER docter = InputDocter();
                                    docter = docter.FindDocter(docters);
                                    if (docter != null)
                                    {
                                        docter.ShowDocter();
                                    }
                                }
                                else if (admin_decision == "4")
                                {
                                    Console.Clear();
                                    logo();
                                    PATIENT patient = InputPatient();
                                    patient = patient.FindPatient(patients);
                                    if (patient != null)
                                    {
                                        patient.ShowPatient();
                                    }
                                }
                                else if (admin_decision == "5")
                                {
                                    Console.Clear();
                                    logo();
                                    int flag18 = 1;
                                    string blood_range = "";
                                    while (flag18 >= 1)
                                    {
                                        flag18 = 0;
                                        Console.Write("ENTER NUMBER OF TYPES OF BLOOD YOU WANT TO ENTER IN THE RECORD ");
                                        blood_range = Console.ReadLine();
                                        for (int i = 0; i < blood_range.Length; i++)
                                        {
                                            if (!(blood_range[i] >= 48 && blood_range[i] <= 57))
                                            {
                                                Console.WriteLine("AN INVALID TERM ENTER BY THE ADMIN ");
                                                Console.WriteLine("Press any key from your keyboard for entering agian ");
                                                Console.ReadKey();
                                                flag18++;
                                                break;
                                            }
                                        }
                                    }
                                    int m = int.Parse(blood_range);
                                    for (int i = 0; i < m; i++)
                                    {
                                        BLOOD blood = InputBlood();
                                        blood.StoreInBloodList(blood, bloods);
                                        blood.StoreInBloodFile(path3);
                                    }
                                }
                                else if (admin_decision == "6")
                                {
                                    Console.Clear();
                                    logo();
                                    int size;
                                    Console.Write("ENTER NUMBER OF TYPES OF ROOMS YOU WANT TO ENTER IN THE RECORD ");
                                    size = int.Parse(Console.ReadLine());
                                    for (int i = 0; i < size; i++)
                                    {
                                        ROOM room = InputRoom();
                                        room.StoreInRoomList(room, rooms);
                                        room.StoreInRoomFile(path4);
                                    }
                                }
                                else if (admin_decision == "7")
                                {
                                    Console.Clear();
                                    logo();
                                    int flag24 = 1;
                                    string size = "";
                                    while (flag24 >= 1)
                                    {
                                        flag24 = 0;
                                        Console.Write("ENTER NUMBER OF TYPES OF TESTS YOU WANT TO ENTER IN THE RECORD ");
                                        size = Console.ReadLine();
                                        for (int i = 0; i < size.Length; i++)
                                        {
                                            if (!(size[i] >= 48 && size[i] <= 57))
                                            {
                                                Console.WriteLine("AN INVALID TERM ENTER BY THE ADMIN ");
                                                Console.WriteLine("Press any key from your keyboard for entering agian ");
                                                Console.ReadKey();
                                                flag24++;
                                                break;
                                            }
                                        }
                                    }
                                    for (int i = 0; i < int.Parse(size); i++)
                                    {
                                        TEST test = InputTest();
                                        test.StoreInTestList(test, tests);
                                        test.StoreInTestFile(path5);
                                    }
                                }
                                else if (admin_decision == "8")
                                {
                                    Console.Clear();
                                    logo();
                                    Console.WriteLine("Total revenue generated by hospital today is " + total + " Rs ");
                                }
                                else if (admin_decision == "9")
                                {
                                    Console.Clear();
                                    logo();
                                    PATIENT patient = Patient_Refrence();
                                    int index = patient.FindIndex(patients);
                                    if (index != patients.Count)
                                    {
                                        patient.DeleteRecord(patients, index);
                                    }
                                }
                                else if (admin_decision == "10")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("An invalid entry ");

                                }
                                Console.ReadKey();
                            }
                        }
                        else if (role=="user"||role=="USER"||role=="User")
                        {
                            bill = 0;
                            
                            while(true)
                            {
                                user_decision = user_menu();
                                if (user_decision == "1")
                                {
                                    Console.Clear();
                                    logo();
                                    view_blood_bank_status(bloods);
                                    BLOOD blood = EnterBlood();
                                    blood.BookBlood(bloods);
                                }
                                else if (user_decision == "2")
                                {
                                    Console.Clear();
                                    logo();
                                    view_available_physicians(docters);
                                }
                                else if (user_decision == "3")
                                {
                                    Console.Clear();
                                    logo();
                                    view_lab_test_rates(tests);
                                    string no_of_test = "";
                                    int flag27 = 1;
                                    while (flag27 >= 1)
                                    {
                                        flag27 = 0;
                                        Console.Write("Enter number of tests you want ");
                                        no_of_test = Console.ReadLine();
                                        for (int i = 0; i < no_of_test.Length; i++)
                                        {
                                            if (!(no_of_test[i] >= 48 && no_of_test[i] <= 57))
                                            {
                                                Console.WriteLine("AN INVALID TERM ENTERED BY YOU ");
                                                Console.WriteLine("Press any key from your keyboard for entering agian ");
                                                Console.ReadKey();
                                                flag27++;
                                                break;
                                            }
                                        }
                                    }
                                    for (int i = 0; i < int.Parse(no_of_test); i++)
                                    {
                                        TEST test = EnterTest();
                                        test= test.CheckTest(tests);
                                        if(test!=null)
                                        {
                                            bill=test.AddinBill()+bill;
                                            total = total + test.AddinBill();
                                        }
                                    }                                      
                                }
                                else if(user_decision=="4")
                                {
                                    int j = 1;
                                    Console.Clear();
                                    logo();
                                    show_rooms(rooms);
                                    while(j==1)
                                    {
                                        j = 0;
                                        ROOM room = EnterRoom();
                                        room = room.BookRoom(rooms);
                                        if(room!=null)
                                        {
                                            
                                            bill = room.AddinBill() + bill;
                                            total = total + room.AddinBill();
                                        }
                                        else
                                        {
                                            j++;
                                        }
                                    }
                                    
                                }
                                else if (user_decision == "5")
                                {
                                    Console.Clear();
                                    logo();
                                    Console.WriteLine("YOUR BILL IS:            " + bill);

                                }
                                else if (user_decision == "6")
                                {
                                    Console.Clear();
                                    logo();
                                    string desease;
                                    Console.Write("Enter the affected body part  ");
                                    desease = Console.ReadLine();
                                    Console.Clear();
                                    logo();
                                    recommendations(desease, docters);
                                }
                                else if (user_decision == "7")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("An invalid entry ");
                                }
                                Console.WriteLine(" Press any key from your keyboard to go back on user menu ");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Credentials Added ");
                    }
                }
                else if (option == "3")
                {
                    Console.Write("                                            Exiting");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid Entry");

                }
                Console.WriteLine("Press any key to back on menu interface ");
                Console.ReadKey();
            } while (option != "3");
            OverWriteCompletePatientFile(path2, patients);
            overWriteCompletebloodfile(path3, bloods);
            overWriteCompleteroomfile(path4,rooms);
        }

        static string Menu()
        {
            string choice;
            Console.WriteLine("1-SIGNUP");
            Console.WriteLine("2-SIGNIN");
            Console.WriteLine("3 - EXIT");
            Console.WriteLine("Press Respective Number For The Given Options: ");
            choice = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            return choice;
        }

        static void logo()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                        *****************************************************************                    ");
            Console.WriteLine("                                      *                                                                   *                   ");
            Console.WriteLine("                                      * *                                                               * *                   ");
            Console.WriteLine("                                      *   *                                                           *   *                   ");
            Console.WriteLine("                                      *     *               HOSPITAL MANAGEMENT SYSTEM               *    *                   ");
            Console.WriteLine("                                      *     *                                                        *    *                   ");
            Console.WriteLine("                                      *    *                                                          *   *                   ");
            Console.WriteLine("                                      *  *                                                              * *                   ");
            Console.WriteLine("                                        *****************************************************************                    ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void welcome()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("                                                  *      * **** *      ****   *****  *    * ****                     ");
            Console.WriteLine("                                                  *   *  * **** *     *      *     * *  * * ****        ");
            Console.WriteLine("                                                  * *  * * *    *     *      *     * *    * *          ");
            Console.WriteLine("                                                  *      * **** *****  ****   *****  *    * ****       ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void loading()
        {
            int p = 0;
            for (int n = 0; p == 0; n++)
            {
                Console.Clear();
                logo();
                welcome();
                Console.WriteLine("Press Y or y to go on login menu ");
                string starter = Console.ReadLine();
                if (starter == "Y" || starter == "y")
                {
                    Console.Clear();
                    logo();
                    p++;
                    Console.Write("                                                               LOADING");
                    for (int x = 0; x < 5; x++)
                    {
                        Console.Write(".");
                        Thread.Sleep(150);
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("AN INVALID ENTERY");
                    Console.WriteLine();
                    Console.WriteLine(" Press any key from your keyboard to go back on welcome menu ");
                    Console.ReadKey();
                }
            }
        }
        static MUser takeInputWithRole()
        {
            int flag1 = 1;
            int flag2 = 1;
            int flag5 = 1;
            string username="";
            string password="";
            string role="";
            logo();
            Console.WriteLine("-----------------------------------------------------------SIGN UP------------------------------------------------");
            Console.WriteLine();
            while (flag1 == 1)
            {
                Console.WriteLine("Enter User Name: ");
                username = Console.ReadLine();
                flag1 = 0;
                for (int i = 0; i < username.Length; i++)
                {
                    if (!((username[i] >= 65 && username[i] <= 90) || (username[i] >= 97 && username[i] <= 122) || username[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY YOU ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag1++;
                        break;
                    }
                }
            }

            while (flag2 == 1)
            {
                Console.WriteLine("Enter User Password: ");
                password = Console.ReadLine();
                flag2 = 0;
                while (password.Length < 8)
                {
                    Console.WriteLine("AN INVALID  PASSWORD ENTER BY YOU ");
                    Console.WriteLine("Press any key from your keyboard for entering agian ");
                    Console.WriteLine("Note:Password must be of eight characters minimum");
                    Console.ReadKey();
                    flag2++;
                    break;
                }
            }

            while (flag5 == 1)
            {
                flag5 = 0;
                Console.WriteLine("Enter Role: ");
                role = Console.ReadLine();
                if (!((role == "user") || (role == "USER") || (role == "admin") || (role == "ADMIN") || (role == "Admin") || (role == "User")))
                {
                    flag5++;
                    Console.WriteLine("That Role does not exist ");
                    Console.WriteLine();
                    Console.WriteLine(" Press any key from your keyboard for entering identity again   ");
                    Console.ReadKey();
                }
            }
            if(username !=null && password!=null &&role!=null)
            {
                MUser user = new MUser(username, password, role);
                return user;
            }
            return null;
        }
        static MUser takeInputWithoutRole()
        {
            int flag1 = 1;
            int flag2 = 1;
            string username = "";
            string password = "";
           
            logo();
            Console.WriteLine("-----------------------------------------------------------SIGN IN------------------------------------------------");
            Console.WriteLine();
            while (flag1 == 1)
            {
                Console.WriteLine("Enter User Name: ");
                username = Console.ReadLine();
                flag1 = 0;
                for (int i = 0; i < username.Length; i++)
                {
                    if (!((username[i] >= 65 && username[i] <= 90) || (username[i] >= 97 && username[i] <= 122) || username[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY YOU ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag1++;
                        break;
                    }
                }
            }

            while (flag2 == 1)
            {
                Console.WriteLine("Enter User Password: ");
                password = Console.ReadLine();
                flag2 = 0;
                while (password.Length < 8)
                {
                    Console.WriteLine("AN INVALID  PASSWORD ENTER BY YOU ");
                    Console.WriteLine("Press any key from your keyboard for entering agian ");
                    Console.WriteLine("Note:Password must be of eight characters minimum");
                    Console.ReadKey();
                    flag2++;
                    break;
                }
            }

            if (username != null && password != null)
            {
                MUser user = new MUser(username, password);
                return user;
            }
            return null;
        }
        static string admin_menu()
        {
            Console.Clear();
            logo();
            Console.WriteLine("-------------------------------------------------------------------------ADMIN MENU---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1-Enter personal details of docter of hospital ");
            Console.WriteLine("2-Enter personal details of patient of hospital ");
            Console.WriteLine("3-View personal details of docters of hospital ");
            Console.WriteLine("4-View personal details of patients of hospital ");
            Console.WriteLine("5-Enter blood bank status ");
            Console.WriteLine("6-Enter rates of different rooms  of hospital ");
            Console.WriteLine("7-Enter and modify lab test rates ");
            Console.WriteLine("8-Calculation of revenue generated in a day ");
            Console.WriteLine("9 - Delete record of any patient ");
            Console.WriteLine("10-Exit ");
            Console.Write("Enter Here ");
            string choice = Console.ReadLine();
            return choice;
        }
        static DOCTER Inputdocterdata()
        {
            string docter_name = "";
            string docter_degree = "";
            string docter_specialization = "";
            string docter_id;
            string docter_contact_number = "";
            string docter_timing = "";
            string docter_age = "";
            int flag6 = 1;
            int flag7 = 1;
            int flag8 = 1;
            int flag9 = 1;
            int flag10 = 1;
            int flag11 = 1;
            Console.Clear();
            logo();
            Console.WriteLine("Enter the details of docter ");
            Console.WriteLine();
            while (flag6 >= 1)
            {
                flag6 = 0;
                Console.Write("Enter docter name ");
                docter_name = Console.ReadLine();
                for (int i = 0; i < docter_name.Length; i++)
                {
                    if (!((docter_name[i] >= 65 && docter_name[i] <= 90) || (docter_name[i] >= 97 && docter_name[i] <= 122) || (docter_name[i] == ' ')))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag6++;
                        break;
                    }
                }
            }
            while (flag7 >= 1)
            {
                flag7 = 0;
                Console.Write("Enter docter specilaization ");
                docter_specialization = Console.ReadLine();
                for (int i = 0; i < docter_specialization.Length; i++)
                {
                    if (!((docter_specialization[i] >= 65 && docter_specialization[i] <= 90) || (docter_specialization[i] >= 97 && docter_specialization[i] <= 122) || docter_specialization[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID TERMONOLOGY ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag7++;
                        break;
                    }
                }
            }

            while (flag8 >= 1)
            {
                flag8 = 0;
                Console.Write("Enter docter degrees ");
                docter_degree = Console.ReadLine();
                for (int i = 0; i < docter_degree.Length; i++)
                {
                    if (!((docter_degree[i] >= 65 && docter_degree[i] <= 90) || (docter_degree[i] >= 97 && docter_degree[i] <= 122) || docter_degree[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID TERMONOLOGY ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag8++;
                        break;
                    }
                }
            }
            while (flag9 >= 1)
            {
                flag9 = 0;
                Console.Write("Enter docter contact number ");
                docter_contact_number = Console.ReadLine();
                for (int i = 0; i < docter_contact_number.Length; i++)
                {
                    if (!(docter_contact_number[i] >= 48 && docter_contact_number[i] <= 57))
                    {
                        Console.WriteLine("AN INVALID CONTACT NUMBER ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag9++;
                        break;
                    }
                }

            }
            while (flag10 >= 1)
            {
                flag10 = 0;
                Console.Write("Enter docter days in hospital ");
                docter_timing = Console.ReadLine();
                for (int i = 0; i < docter_timing.Length; i++)
                {
                    if (!((docter_timing[i] >= 65 && docter_timing[i] <= 90) || (docter_timing[i] >= 97 && docter_timing[i] <= 122) || docter_timing[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID DAY ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag10++;
                        break;
                    }
                }
            }
            while (flag11 >= 1)
            {
                flag11 = 0;
                Console.Write("Enter docter's age  ");
                docter_age = Console.ReadLine();
                for (int i = 0; i < docter_age.Length; i++)
                {
                    if (!(docter_age[i] >= 48 && docter_age[i] <= 57))
                    {
                        Console.WriteLine("AN INVALID AGE ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag11++;
                        break;
                    }
                }
            }
            Console.Write("Enter docter's id  ");
            docter_id = Console.ReadLine();
            DOCTER docter = new DOCTER(docter_name, docter_specialization, docter_degree, docter_contact_number, docter_timing, docter_age, docter_id);
            return docter;
        }
        static PATIENT Inputpatientdata()
        {
            int flag12 = 1;
            int flag13 = 1;
            int flag14 = 1;
            int flag15 = 1;
            int flag16 = 1;
            int flag17 = 1;
            string patient_name = "";
            string patient_father_name = "";
            string patient_age = "";
            string patient_blood_group = "";
            string patient_desease = "";
            string patient_id;
            string patient_number = "";
            Console.Clear();
            logo();
            Console.WriteLine("Enter the details of patient ");
            Console.WriteLine();
            while (flag12 >= 1)
            {
                flag12 = 0;
                Console.Write("Enter patient name: ");
                patient_name = Console.ReadLine();
                for (int i = 0; i < patient_name.Length; i++)
                {
                    if (!((patient_name[i] >= 65 && patient_name[i] <= 90) || (patient_name[i] >= 97 && patient_name[i] <= 122) || patient_name[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag12++;
                        break;
                    }
                }
            }
            while (flag13 >= 1)
            {
                flag13 = 0;
                Console.Write("Enter Patient Father Name: ");
                patient_father_name = Console.ReadLine();
                for (int i = 0; i < patient_father_name.Length; i++)
                {
                    if (!((patient_father_name[i] >= 65 && patient_father_name[i] <= 90) || (patient_father_name[i] >= 97 && patient_father_name[i] <= 122) || patient_father_name[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag13++;
                        break;
                    }
                }
            }
            while (flag14 >= 1)
            {
                flag14 = 0;
                Console.Write("Enter Patient Desease ");
                patient_desease = Console.ReadLine();
                for (int i = 0; i < patient_desease.Length; i++)
                {
                    if (!((patient_desease[i] >= 65 && patient_desease[i] <= 90) || (patient_desease[i] >= 97 && patient_desease[i] <= 122) || patient_desease[i] == ' '))
                    {
                        Console.WriteLine("AN INVALID TERMONOLOGY ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag14++;
                        break;
                    }
                }
            }
            while (flag15 >= 1)
            {
                flag15 = 0;
                Console.WriteLine("Enter patient contact number: ");
                patient_number = Console.ReadLine();
                for (int i = 0; i < patient_number.Length; i++)
                {
                    if (!(patient_number[i] >= 48 && patient_number[i] <= 57))
                    {
                        Console.WriteLine("AN INVALID CONTACT NUMBER ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag15++;
                        break;
                    }
                }
            }
            while (flag16 >= 1)
            {
                flag16 = 0;
                Console.Write("Enter Patient Blood Group:  ");
                patient_blood_group = Console.ReadLine();
                for (int i = 0; i < patient_blood_group.Length; i++)
                {
                    if (!((patient_blood_group[i] >= 65 && patient_blood_group[i] <= 90) || (patient_blood_group[i] == '+') || (patient_blood_group[i] == '-')))
                    {
                        Console.WriteLine("AN INVALID TERMONOLOGY ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag16++;
                        break;
                    }
                }
            }
            while (flag17 >= 1)
            {
                flag17 = 0;
                Console.Write("Enter patient's age  ");
                patient_age = Console.ReadLine();
                for (int i = 0; i < patient_age.Length; i++)
                {
                    if (!(patient_age[i] >= 48 && patient_age[i] <= 57))
                    {
                        Console.WriteLine("AN INVALID AGE ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag17++;
                        break;
                    }
                }
            }
            Console.Write("Enter PATIENTS's id  ");
            patient_id = Console.ReadLine();
            PATIENT patient = new PATIENT(patient_name, patient_father_name, patient_number, patient_desease, patient_blood_group, patient_age, patient_id);
            return patient;
        }
        static DOCTER InputDocter()
        {
            string docter_name;
            string docter_id;
            Console.Write("Enter docter name: ");
            docter_name = Console.ReadLine();
            Console.ReadLine();
            Console.Write("Enter docter id: ");
            docter_id = Console.ReadLine();
            DOCTER docter = new DOCTER(docter_name, docter_id);
            return docter;
        }
        static PATIENT InputPatient()
        {
            string patient_name;
            string patient_id;
            Console.Write("Enter patient name ");
            patient_name = Console.ReadLine();
            Console.Write("Enter patient id ");
            patient_id = Console.ReadLine();
            PATIENT patient = new PATIENT(patient_name, patient_id);
            return patient;
        }
         
        static BLOOD InputBlood()
        {
            
            string blood_type="";           
            string blood_packet="";            
                int flag19 = 1;
                int flag20 = 1;
                Console.Clear();
                logo();
                Console.WriteLine("--------------------------------------------------------------------------Blood Bank-------------------------------------------------------------");
                Console.WriteLine();
                while (flag19 >= 1)
                {
                    flag19 = 0;
                    Console.Write("Enter blood type: ");
                    blood_type = Console.ReadLine();
                    for (int n = 0; n < blood_type.Length; n++)
                    {
                        if (!((blood_type[n] >= 65 && blood_type[n] <= 90) || blood_type[n] == '+' || blood_type[n] == '-'))
                        {
                            Console.WriteLine("AN INVALID TERMONOLOGY ENTER BY THE ADMIN ");
                            Console.WriteLine("Press any key from your keyboard for entering agian ");
                            Console.ReadKey();
                            flag19++;
                            break;
                        }
                    }
                }
                while (flag20 >= 1)
                {
                    flag20 = 0;
                    Console.Write("Enter number of packets of  1kg of respective blood type ");
                    blood_packet = Console.ReadLine();
                    for (int n = 0; n < blood_packet.Length; n++)
                    {
                        if (!(blood_packet[n] >= 48 && blood_packet[n] <= 57))
                        {
                            Console.WriteLine("AN INVALID TERM ENTER BY THE ADMIN ");
                            Console.WriteLine("Press any key from your keyboard for entering agian ");
                            Console.ReadKey();
                            flag20++;
                            break;
                        }
                    }
                }
                BLOOD blood = new BLOOD(blood_type,blood_packet);
                return blood;           
        }
        static ROOM InputRoom()
        {
            string room_type="";
            string room_rate="";
            string no_of_room="";
            int flag21 = 1;
            int flag22 = 1;
            int flag23 = 1;
            Console.Clear();
            logo();
            Console.WriteLine("--------------------------------------------------------ROOMS--------------------------------------------------");
            Console.WriteLine();
            while (flag21 >= 1)
            {
                flag21 = 0;
                Console.Write("Enter name of room  ");
                room_type = Console.ReadLine();
                for (int j = 0; j < room_type.Length; j++)
                {
                    if (!((room_type[j] >= 65 && room_type[j] <= 90) || (room_type[j] >= 97 && room_type[j] <= 122) || room_type[j] == ' '))
                    {
                        Console.WriteLine("AN INVALID TERMONOLOGY ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag21++;
                        break;
                    }
                }
            }
            while (flag22 >= 1)
            {
                flag22 = 0;
                Console.Write("Enter rate of respective room in RS. ");
                room_rate = Console.ReadLine();
                for (int k = 0; k < room_rate.Length; k++)
                {
                    if (!(room_rate[k] >= 48 && room_rate[k] <= 57))
                    {
                        Console.WriteLine("AN INVALID TERM ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag22++;
                        break;
                    }
                }
            }
            while (flag23 >= 1)
            {
                flag23 = 0;
                Console.Write("Enter no of rooms available of this type in the hospital ");
                no_of_room = Console.ReadLine();
                for (int l = 0; l < no_of_room.Length; l++)
                {
                    if (!(no_of_room[l] >= 48 && no_of_room[l] <= 57))
                    {
                        Console.WriteLine("AN INVALID TERM ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag23++;
                        break;
                    }
                }
            }
            ROOM room = new ROOM(room_type,room_rate,no_of_room);
            return room;
        }
        static TEST InputTest()
        {
            
            int flag25 = 1;
            int flag26 = 1;
            string test_type="";
            string test_rate="";
            Console.Clear();
            logo();
            Console.WriteLine("-------------------------------------------------------------------------------------LAB TEST RATES--------------------------------------------------");
            Console.WriteLine();
            while (flag25 >= 1)
            {
                flag25 = 0;
                Console.WriteLine("Enter type of test:  ");
                test_type = Console.ReadLine();
                for (int j = 0; j < test_type.Length; j++)
                {
                    if (!((test_type[j] >= 65 && test_type[j] <= 90) || (test_type[j] >= 97 && test_type[j] <= 122) || test_type[j] == ' '))
                    {
                        Console.WriteLine("AN INVALID  NAME ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag25++;
                        break;
                    }
                }
            }
            while (flag26 >= 1)
            {
                flag26 = 0;
                Console.Write("Enter test rate: ");
                test_rate = Console.ReadLine();
                for (int k = 0; k < test_rate.Length; k++)
                {
                    if (!(test_rate[k] >= 48 && test_rate[k] <= 57))
                    {
                        Console.WriteLine("AN INVALID TERM ENTER BY THE ADMIN ");
                        Console.WriteLine("Press any key from your keyboard for entering agian ");
                        Console.ReadKey();
                        flag26++;
                        break;
                    }
                }
            }
            TEST test = new TEST(test_type,test_rate);
            return test;
        }
        static PATIENT Patient_Refrence()
        {
            Console.Write("Enter patient name ");
            string patient_name = Console.ReadLine();
            Console.Write("Enter patient id ");
            string patient_id = Console.ReadLine();
            PATIENT patient = new PATIENT(patient_name, patient_id);
            return patient;
        }
        static string user_menu()
        {
            Console.Clear();
            logo();
            Console.WriteLine("-----------------------------------USER MENU---------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("1-View blood bank status and choose if any required");
            Console.WriteLine("2-View available physicians ");
            Console.WriteLine("3-View tests rates and book test");
            Console.WriteLine("4-Check rates of rooms in hospital and select if any reqiured  ");
            Console.WriteLine("5-Check your bill   ");
            Console.WriteLine("6-Recommendations    ");
            Console.WriteLine("7-Exit");
            string choice;
            Console.Write("Enter Here ");
            choice = Console.ReadLine();
            return choice;
        }
        static void view_blood_bank_status(List<BLOOD> arr)
        {
            Console.WriteLine("-----------------------------------------------Blood Bank-------------------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine("BLOOD TYPE:    " + arr[i].blood_type1);
                Console.WriteLine("NO OF PACKETS AVAILABLE:    " + arr[i].blood_packet1);
                Console.WriteLine();
            }
        }
        static BLOOD EnterBlood()
        {
            string blood;
            string packet;
            Console.Write("Enter blood type you need ");
            blood = Console.ReadLine();
            Console.Write("Enter no of packets you need ");
            packet = Console.ReadLine();
            BLOOD bloodshed = new BLOOD(blood, packet);
            return bloodshed;
        }
        static void view_available_physicians(List<DOCTER> arr)
        {
            Console.WriteLine("------------------------------------------------------------------------Docters Details--------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(" Name: " + arr[i].docter_name1);
                Console.WriteLine(" Contact number: " + arr[i].docter_contact_number1);
                Console.WriteLine(" Age: " + arr[i].docter_age1);
                Console.WriteLine(" Days of docter: " + arr[i].docter_timing1);
                Console.WriteLine(" Docter's id: " + arr[i].docter_id1);
                Console.WriteLine(" Docter's Specialization: " + arr[i].docter_specialization1);
                Console.WriteLine(" Docter's Degrees: " + arr[i].docter_degree1);
                Console.WriteLine();
            }
        }
        static void view_lab_test_rates(List<TEST> arr1)
        {
            Console.Clear();
            logo();
            Console.WriteLine("----------------------------------------------------------------------------------------LAB TEST RATES--------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < arr1.Count; i++)
            {
                Console.WriteLine("TEST NAME: " + arr1[i].test_type1);
                Console.WriteLine("TEST RATE:  " + arr1[i].test_rate1);
                Console.WriteLine();
            }
        }
        static TEST EnterTest()
        {
            string test_name;
            Console.WriteLine("Enter Name of the test you want to book ");
            test_name = Console.ReadLine();
            TEST test = new TEST(test_name);
            return test;
        }
        static void show_rooms(List<ROOM> ARRAY)
        {
            Console.WriteLine("------------------------------------------------------------------------------------------ROOMS RATES-------------------------------------------------------------");
            for (int n = 0; n < ARRAY.Count; n++)
            {
                Console.WriteLine("ROOM NAMES:     " + ARRAY[n].room_type1);
                Console.WriteLine("ROOM RATE:        " + ARRAY[n].room_rate1);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static ROOM EnterRoom()
        {
            Console.WriteLine("Enter room you want to book      ");
            string select_room = Console.ReadLine();
            ROOM room = new ROOM(select_room);
            return room;
        }
        static void recommendations(string desease, List<DOCTER> array)
        {
            int flag = 0;
            if (desease == "TROUGHT" || desease == "NOSE" || desease == "EAR" || desease == "trought" || desease == "nose" || desease == "ear")
            {
                for (int i = 0; array[i].docter_specialization1 == "ENT" && i < array.Count; i++)
                {
                    Console.WriteLine("YOU ARE RECOMMENDED TO GO TO  " + array[i].docter_name1);
                    flag++;
                }
            }
            else
            {
                for (int i = 0; i < array.Count; i++)
                {
                    if (desease == array[i].docter_specialization1)
                    {
                        Console.WriteLine("YOU ARE RECOMMENDED TO GO TO " + array[i].docter_name1);
                        flag++;
                    }
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("DOCTER OF THAT DESEASE IS NOT AVAILABLE IN OUR HOSPITAL ");
                Console.ReadKey();
            }
        }
        static void readfile(List<MUser> arr,string path)
        {           
            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    
                    string username = getfield(line, 1);
                    string password = getfield(line, 2);
                    string role = getfield(line, 3);
                    MUser info = new MUser(username,password,role);
                    arr.Add(info);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");

            }
        }
        static string getfield(string line, int field)
        {
            int commacount = 1;
            string item = "";
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ',')
                {
                    commacount++;
                }
                else if (commacount == field)
                {
                    item = item + line[i];
                }
            }
            return item;
        }
        static void read_file2(List<DOCTER> arr,string path)
        {
            
            string record1;
            if (File.Exists(path))
            {
                StreamReader docter_record = new StreamReader(path);
                while ((record1 = docter_record.ReadLine()) != null)
                {
                    
                    string docter_name1 = getfield(record1, 1);
                   string docter_specialization1 = getfield(record1, 2);
                   string docter_degree1 = getfield(record1, 3);
                   string docter_timing1 = getfield(record1, 4);
                   string docter_age1 = getfield(record1, 5);
                   string docter_id1 = getfield(record1, 6);
                   string docter_contact_number1 = getfield(record1, 7);
                    DOCTER info1 = new DOCTER(docter_name1,docter_specialization1,docter_degree1,docter_timing1,docter_age1,docter_id1,docter_contact_number1);
                    arr.Add(info1);
                }
                docter_record.Close();
            }
        }
        static void read_file3(List<PATIENT> patient,string path)
        {
            
            string record2;
            if (File.Exists(path))
            {
                StreamReader patient_record = new StreamReader(path);
                while ((record2 = patient_record.ReadLine()) != null)
                {
                    
                   string patient_name1 = getfield(record2, 1);
                   string patient_father_name1 = getfield(record2, 2);
                   string patient_desease1 = getfield(record2, 3);
                   string patient_number1 = getfield(record2, 4);
                  string patient_blood_group1 = getfield(record2, 5);
                   string patient_age1 = getfield(record2, 6);
                   string patient_id1 = getfield(record2, 7);
                    PATIENT obj = new PATIENT(patient_name1,patient_father_name1,patient_desease1,patient_number1,patient_blood_group1,patient_age1,patient_id1);
                    patient.Add(obj);
                }
                patient_record.Close();
            }
        }
        static void read_file4(List<BLOOD> arr,string path)
        {
           
            string record3;
            if (File.Exists(path))
            {
                StreamReader blood_record = new StreamReader(path);
                while ((record3 = blood_record.ReadLine()) != null)
                {
                    
                   string blood_type1 = getfield(record3, 1);
                   string blood_packet1 = getfield(record3, 2);
                    BLOOD obj = new BLOOD(blood_type1,blood_packet1);
                    arr.Add(obj);
                }
                blood_record.Close();
            }
        }
        static void read_file5(List<ROOM> room,string path)
        {
            
            string record4;
            if (File.Exists(path))
            {
                StreamReader room_record = new StreamReader(path);
                while ((record4 = room_record.ReadLine()) != null)
                {
                    
                    string room_type1 = getfield(record4, 1);
                   string room_rate1 = getfield(record4, 2);
                  string no_of_room1 = getfield(record4, 3);
                    ROOM obj9 = new ROOM(room_type1,room_rate1,no_of_room1);
                    room.Add(obj9);
                }
                room_record.Close();
            }
        }
        static void read_file6(List<TEST> test,string path)
        {
           
            string record5;
            if (File.Exists(path))
            {
                StreamReader lab_record = new StreamReader(path);
                while ((record5 = lab_record.ReadLine()) != null)
                {
                   
                   string test_type1 = getfield(record5, 1);
                   string test_rate1 = getfield(record5, 2);
                    TEST obj7 = new TEST(test_type1,test_rate1);
                    test.Add(obj7);
                }
                lab_record.Close();
            }
        }
        static void OverWriteCompletePatientFile(string path2,List<PATIENT> patients)
        {
            StreamWriter patient_record = new StreamWriter(path2, false);
            foreach(PATIENT objects in patients)
            {
                patient_record.WriteLine(objects.patient_name1 + "," +objects.patient_father_name1 + "," +objects.patient_desease1 + "," +objects.patient_number1 + "," +objects.patient_blood_group1 + "," +objects.patient_age1 + "," +objects.patient_id1);                
            }
            patient_record.Flush();
            patient_record.Close();
        }
        static void overWriteCompletebloodfile(string path3,List<BLOOD> bloods)
        {
            StreamWriter blood_record = new StreamWriter(path3,false);
            foreach(BLOOD objects in bloods)
            {
                Console.WriteLine(objects.blood_type1 + "," +objects.blood_packet1);                
            }
            blood_record.Flush();
            blood_record.Close();
        }
        static void overWriteCompleteroomfile(string path4,List<ROOM> rooms)
        {
            StreamWriter room_record = new StreamWriter(path4, false);
            foreach(ROOM objects in rooms)
            {
                room_record.WriteLine(objects.room_type1 + "," +objects.room_rate1 + "," +objects.no_of_room1);               
            }
            room_record.Flush();
            room_record.Close();
        }
    }
}
    
    

                        




