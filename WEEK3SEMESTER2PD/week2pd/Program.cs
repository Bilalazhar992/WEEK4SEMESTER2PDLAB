using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace week2pd
{
    class Program
    {
        class CREDENTIALS
        {
            public string username;
            public string password;
            public string role;
        }
        class DOCTER
        {
            public string docter_name1;
            public string docter_degree1;
            public string docter_specialization1;
            public string docter_id1;
            public string docter_contact_number1;
            public string docter_timing1;
            public string docter_age1;
        }
        class PATIENT
        {
            public string patient_name1;
            public string patient_father_name1;
            public string patient_age1;
            public string patient_blood_group1;
            public string patient_desease1;
            public string patient_id1;
            public string patient_number1;

        }
        class BLOOD
        {
            public string blood_type1;
            public int blood_packet1;
        }
        class ROOM
        {

            public string room_type1;
            public int room_rate1;
            public int no_of_room1;

        }

        class TEST
        {
            public string test_type1;
            public int test_rate1;
        }
        class BILL
        {
            public int bill;
        }

        static int paisa;
        static int helper_for_sign_in;
        static int total = 0;

        static void Main(string[] args)
        {
            string docter_name = "";
            string docter_degree = "";
            string docter_specialization = "";
            string docter_id;
            string docter_contact_number = "";
            string docter_timing = "";
            string docter_age = "";
            string patient_name = "";
            string patient_father_name = "";
            string patient_age = "";
            string patient_blood_group = "";
            string patient_desease = "";
            string patient_id;
            string patient_number = "";
            string user_decision;
            string admin_decision;
            string blood_type = "";
            string blood_packet = "";
            string room_type = "";
            string room_rate = "";
            string no_of_room = "";
            string test_type = "";
            string test_rate = "";
            logo();
            welcome();
            loading();
            bool isValid;

            List<CREDENTIALS> users = new List<CREDENTIALS>();
            List<DOCTER> docters = new List<DOCTER>();
            List<PATIENT> patients = new List<PATIENT>();
            List<BLOOD> bloods = new List<BLOOD>();
            List<ROOM> rooms = new List<ROOM>();
            List<TEST> tests = new List<TEST>();
            List<BILL> bills = new List<BILL>();

            readfile(users);
            read_file2(docters);
            read_file3(patients);
            read_file4(bloods);
            read_file5(rooms);
            read_file6(tests);
            string option = "";
            do
            {
                Console.Clear();
                logo();
                option = Menu();
                Console.Clear();
                if (option == "1")
                {
                    CREDENTIALS newUser = SignUp();
                    isValid = isValidname(newUser.username, users);
                    if (isValid)
                    {
                        users.Add(newUser);
                        Console.WriteLine("SignedUp Sucessfully ");
                        StoreInFile(newUser.username, newUser.password, newUser.role);
                    }
                    else
                    {
                        Console.WriteLine("User Already Exists ");
                    }
                }

                else if (option == "2")
                {

                    if (SignIn(users))
                    {
                        Console.WriteLine("Signed In Sucessfully ");
                        Console.Clear();
                        logo();
                        if (users[helper_for_sign_in].role == "admin" || users[helper_for_sign_in].role == "ADMIN" || users[helper_for_sign_in].role == "Admin")
                        {
                            while (true)
                            {
                                admin_decision = admin_menu();
                                if (admin_decision == "1")
                                {
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
                                    docters.Add(add_docter_details(docter_name, docter_specialization, docter_degree, docter_timing, docter_age, docter_id, docter_contact_number));
                                    storeInFile2(docter_name, docter_specialization, docter_degree, docter_timing, docter_age, docter_id, docter_contact_number);
                                }
                                else if (admin_decision == "2")
                                {
                                    int flag12 = 1;
                                    int flag13 = 1;
                                    int flag14 = 1;
                                    int flag15 = 1;
                                    int flag16 = 1;
                                    int flag17 = 1;

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
                                    patients.Add(add_patient_details(patient_name, patient_father_name, patient_desease, patient_number, patient_blood_group, patient_age, patient_id));
                                    storeInFile3(patient_name, patient_father_name, patient_desease, patient_number, patient_blood_group, patient_age, patient_id);
                                }
                                else if (admin_decision == "3")
                                {
                                    Console.Clear();
                                    logo();
                                    Console.Write("Enter docter name: ");
                                    docter_name = Console.ReadLine();
                                    Console.ReadLine();
                                    Console.Write("Enter docter id: ");
                                    docter_id = Console.ReadLine();
                                    view_docter_details(docter_name, docter_id,docters);
                                    
                                }
                                else if (admin_decision == "4")
                                {
                                    Console.Clear();
                                    logo();
                                    Console.Write("Enter patient name ");
                                    patient_name = Console.ReadLine();
                                    Console.Write("Enter patient id ");
                                    patient_id = Console.ReadLine();
                                    view_patient_details(patient_name, patient_id, patients);
                                }
                                else if (admin_decision == "5")
                                {
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
                                    int m= int.Parse(blood_range);
                                    for (int i = 0; i < m; i++)
                                    {
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
                                        
                                        Console.ReadKey();
                                        bloods.Add(blood_bank_status(blood_type, blood_packet));
                                        storeInFile4(blood_type, blood_packet);
                                        continue;

                                    }
                                }
                                else if (admin_decision == "6")
                                {
                                   
                                    int size;
                                    Console.Write("ENTER NUMBER OF TYPES OF ROOMS YOU WANT TO ENTER IN THE RECORD ");
                                    size = int.Parse(Console.ReadLine());
                                    for (int i = 0; i < size; i++)
                                    {
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
                                        rooms.Add(room_status(room_type, room_rate, no_of_room));
                                        storeInFile5(room_type, room_rate, no_of_room);
                                    }
                                }
                                else if (admin_decision == "7")
                                {
                                    int flag24 = 1;
                                    int flag25;
                                    int flag26;
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
                                        flag25 = 1;
                                        flag26 = 1;
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
                                        tests.Add(lab_test_status(test_type, test_rate));
                                        storeInFile6(test_type, test_rate);
                                    }
                                }
                                else if (admin_decision == "8")
                                {
                                    Console.WriteLine("Total revenue generated by hospital today is " + total + " Rs ");
                                }
                                else if (admin_decision == "9")
                                {
                                    Console.Clear();
                                    logo();
                                    Console.Write("Enter patient name ");
                                    patient_name = Console.ReadLine();
                                    Console.Write("Enter patient id ");
                                    patient_id = Console.ReadLine();
                                    delete_patient_record(patient_name, patient_id, patients);
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
                        if (users[helper_for_sign_in].role == "user" || users[helper_for_sign_in].role == "USER")
                        {
                            paisa = 0;
                            while (true)
                            {

                                user_decision = user_menu();
                                if (user_decision == "1")
                                {
                                    Console.Clear();
                                    logo();
                                    view_blood_bank_status(bloods);
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
                                    bills.Insert(helper_for_sign_in, new BILL());
                                    bills[helper_for_sign_in].bill = bills[helper_for_sign_in].bill + paisa;
                                }
                                else if (user_decision == "4")
                                {
                                    Console.Clear();
                                    logo();
                                    room_selection(rooms);
                                    bills.Insert(helper_for_sign_in, new BILL());
                                    bills[helper_for_sign_in].bill = bills[helper_for_sign_in].bill + paisa;
                                }
                                else if (user_decision == "5")
                                {
                                    Console.Clear();
                                    logo();
                                    bills.Insert(helper_for_sign_in, new BILL());
                                    total = total + bills[helper_for_sign_in].bill;
                                    Console.WriteLine("YOUR BILL IS:            " + bills[helper_for_sign_in].bill);

                                }
                                else if (user_decision == "6")
                                {
                                    string desease;
                                    Console.Write("Enter the affected body part  ");
                                    desease = Console.ReadLine();
                                    Console.Clear();
                                    logo();
                                    recommendations(desease,docters);
                                }
                                else if (user_decision == "7")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("An invalid entry ");
                                }
                                Console.WriteLine(" Press any key from your keyboard to go back on admin menu ");
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
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Entery");

                }
                Console.WriteLine("Press any key to back on menu interface ");
                Console.ReadKey();
            } while (option != "3");
            
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
        static CREDENTIALS SignUp()
        {
            int flag1 = 1;
            int flag2 = 1;
            int flag5 = 1;
            CREDENTIALS s1 = new CREDENTIALS();
            logo();
            Console.WriteLine("-----------------------------------------------------------SIGN UP------------------------------------------------");
            Console.WriteLine();
            while (flag1 == 1)
            {
                Console.WriteLine("Enter User Name: ");
                s1.username = Console.ReadLine();
                flag1 = 0;
                for (int i = 0; i < s1.username.Length; i++)
                {
                    if (!((s1.username[i] >= 65 && s1.username[i] <= 90) || (s1.username[i] >= 97 && s1.username[i] <= 122) || s1.username[i] == ' '))
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
                s1.password = Console.ReadLine();
                flag2 = 0;
                while (s1.password.Length < 8)
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
                s1.role = Console.ReadLine();
                if (!((s1.role == "user") || (s1.role == "USER") || (s1.role == "admin") || (s1.role == "ADMIN") || (s1.role == "Admin") || (s1.role == "User")))
                {
                    flag5++;
                    Console.WriteLine("That Role does not exist ");
                    Console.WriteLine();
                    Console.WriteLine(" Press any key from your keyboard for entering identity again   ");
                    Console.ReadKey();
                }
            }
            return s1;
        }
        static bool SignIn(List<CREDENTIALS> users)
        {
            Console.Clear();
            logo();
            Console.WriteLine("--------------------------------------------------------------SIGN IN------------------------------------------------");
            Console.WriteLine();
            CREDENTIALS s = new CREDENTIALS();
            Console.WriteLine("Enter User Name: ");
            s.username = Console.ReadLine();
            Console.WriteLine("Enter User Password: ");
            s.password = Console.ReadLine();
            for (helper_for_sign_in = 0; helper_for_sign_in < users.Count; helper_for_sign_in++)
            {
                if ((s.username == users[helper_for_sign_in].username) && (s.password == users[helper_for_sign_in].password))
                {
                    return true;
                }
            }
            return false;
        }
        static void StoreInFile(string username, string password, string role)
        {

            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\data1.txt";
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(username + "," + password + "," + role);
            file.Flush();
            file.Close();

        }
        static void readfile(List<CREDENTIALS> arr)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\data1.txt";
            string line;
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    CREDENTIALS info = new CREDENTIALS();
                    info.username = getfield(line, 1);
                    info.password = getfield(line, 2);
                    info.role = getfield(line, 3);
                    arr.Add(info);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");

            }
        }
        static void read_file2(List<DOCTER> arr)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\DOCTER.txt";
            string record1;
            if (File.Exists(path))
            {
                StreamReader docter_record = new StreamReader(path);
                while ((record1 = docter_record.ReadLine()) != null)
                {
                    DOCTER info1 = new DOCTER();
                    info1.docter_name1 = getfield(record1, 1);
                    info1.docter_specialization1 = getfield(record1, 2);
                    info1.docter_degree1 = getfield(record1, 3);
                    info1.docter_timing1= getfield(record1, 4);
                    info1.docter_age1 = getfield(record1, 5);
                    info1.docter_id1 = getfield(record1, 6);
                    info1.docter_contact_number1 = getfield(record1, 7);
                    arr.Add(info1);
                }
               
                docter_record.Close();
            }
        }
        static void read_file3(List<PATIENT> patient)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\PATIENT.txt";
            string record2;
            if (File.Exists(path))
            {
                StreamReader patient_record = new StreamReader(path);
                while ((record2 = patient_record.ReadLine()) != null)
                {
                    PATIENT obj = new PATIENT();
                    obj.patient_name1 = getfield(record2, 1);
                    obj.patient_father_name1 = getfield(record2, 2);
                   obj.patient_desease1 = getfield(record2, 3);
                    obj.patient_number1= getfield(record2, 4);
                    obj.patient_blood_group1 = getfield(record2, 5);
                    obj.patient_age1 = getfield(record2, 6);
                    obj.patient_id1= getfield(record2, 7);
                    patient.Add(obj);
                }
                patient_record.Close();
            }
        }
        static void read_file4(List<BLOOD> arr)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\BLOOD.txt";
            string record3;
            if (File.Exists(path))
            {
                StreamReader blood_record = new StreamReader(path);
                while ((record3 = blood_record.ReadLine()) != null)
                {
                    BLOOD obj = new BLOOD();
                    obj.blood_type1 = getfield(record3, 1);
                    obj.blood_packet1= int.Parse((getfield(record3, 2)));
                    arr.Add(obj);
                }
                blood_record.Close();
            }
        }
        static void read_file5(List<ROOM> room)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\ROOM.txt";
            string record4;
            if (File.Exists(path))
            {
                StreamReader room_record = new StreamReader(path);
                while ((record4 = room_record.ReadLine()) != null)
                {
                    ROOM obj9 = new ROOM();   
                    obj9.room_type1 = getfield(record4, 1);
                   obj9.room_rate1 = int.Parse((getfield(record4, 2)));
                    obj9.no_of_room1 = int.Parse((getfield(record4, 3)));
                    room.Add(obj9);
                }
                room_record.Close();
            }
        }
        static void read_file6(List<TEST> test)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\LAB.txt";
            string record5;
            if (File.Exists(path))
            {
                StreamReader lab_record = new StreamReader(path);
                while ((record5 = lab_record.ReadLine()) != null)
                {
                    TEST obj7 = new TEST();
                    obj7.test_type1 = getfield(record5, 1);
                    obj7.test_rate1 = int.Parse((getfield(record5, 2)));
                    test.Add(obj7);
                }
                lab_record.Close();
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
        static bool isValidname(string name, List<CREDENTIALS> users)
        {
            for (int i = 0; i < users.Count(); i++)
            {
                if (users[i].username == name)
                {
                    return false;
                }
            }
            return true;
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
        static DOCTER add_docter_details(string docter_name, string docter_specialization, string docter_degree, string docter_timing, string docter_age, string docter_id, string docter_contact_number)
        {
            DOCTER obj = new DOCTER();
            obj.docter_name1 = docter_name;
            obj.docter_specialization1 = docter_specialization;
            obj.docter_degree1 = docter_degree;
            obj.docter_timing1 = docter_timing;
            obj.docter_age1 = docter_age;
            obj.docter_id1 = docter_id;
            obj.docter_contact_number1 = docter_contact_number;
            return obj;
        }
        static void storeInFile2(string docter_name, string docter_specialization, string docter_degree, string docter_timing, string docter_age, string docter_id, string docter_contact_number)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\DOCTER.txt";
            StreamWriter docter_record = new StreamWriter(path, true);

            docter_record.WriteLine(docter_name + "," + docter_specialization + "," + docter_degree + "," + docter_timing + "," + docter_age + "," + docter_id + "," + docter_contact_number);
            docter_record.Flush();
            docter_record.Close();
        }
        static PATIENT add_patient_details(string patient_name, string patient_father_name, string patient_desease, string patient_number, string patient_blood_group, string patient_age, string patient_id)
        {
            PATIENT obj1 = new PATIENT();
            obj1.patient_name1 = patient_name;
            obj1.patient_father_name1 = patient_father_name;
            obj1.patient_desease1 = patient_desease;
            obj1.patient_blood_group1 = patient_blood_group;
            obj1.patient_age1 = patient_age;
            obj1.patient_id1 = patient_id;
            obj1.patient_number1 = patient_number;
            return obj1;
        }
        static void storeInFile3(string patient_name, string patient_father_name, string patient_desease, string patient_number, string patient_blood_group, string patient_age, string patient_id)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\PATIENT.txt";
            StreamWriter patient_record = new StreamWriter(path, true);
            patient_record.WriteLine(patient_name + "," + patient_father_name + "," + patient_desease + "," + patient_number + "," + patient_blood_group + "," + patient_age + "," + patient_id);
            patient_record.Flush();
            patient_record.Close();
        }
        static void view_docter_details(string docter_name_variable, string docter_id_varible, List<DOCTER> ARR)
        {
            int flag = 0;
            for (int i = 0; i < ARR.Count; i++)
            {
                DOCTER OBJ = ARR[i];
                
                if ((docter_name_variable == OBJ.docter_name1) && (docter_id_varible == OBJ.docter_id1))
                {
                    Console.WriteLine("---------------------------------------------------------------Docter's Details--------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine(" Name: " + ARR[i].docter_name1);
                    Console.WriteLine(" Contact number: " + ARR[i].docter_contact_number1);
                    Console.WriteLine(" Age: " + ARR[i].docter_age1);
                    Console.WriteLine(" Days of docter: " + ARR[i].docter_timing1);
                    Console.WriteLine(" Docter's id: " + ARR[i].docter_id1);
                    Console.WriteLine(" Docter's Specialization: " + ARR[i].docter_specialization1);
                    Console.WriteLine(" Docter's Degrees: " + ARR[i].docter_degree1);
                    flag++;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine(" An invalid entry of docter name or id ");
            }
            Console.ReadKey();
        }
        static void view_patient_details(string patient_name_variable, string patient_id_varible, List<PATIENT> arr)
        {
            int flag = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (patient_name_variable == arr[i].patient_name1 && patient_id_varible == arr[i].patient_id1)
                {
                    Console.WriteLine("-------------------------------------------------------------------Patient's Details--------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(" Name: " + arr[i].patient_name1);
                    Console.WriteLine(" Contact number: " + arr[i].patient_number1);
                    Console.WriteLine(" Age: " + arr[i].patient_age1);
                    Console.WriteLine(" Father name of patient: " + arr[i].patient_father_name1);
                    Console.WriteLine(" Patient's id: " + arr[i].patient_id1);
                    Console.WriteLine(" Patient's Desease: " + arr[i].patient_desease1);
                    Console.WriteLine(" Patient's Blood Group: " + arr[i].patient_blood_group1);
                    flag++;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine(" An invalid entry of patient name or id ");
            }
        }
        static BLOOD blood_bank_status(string blood_type, string blood_packet)
        {
            BLOOD obj2 = new BLOOD();
            obj2.blood_type1 = blood_type;
            obj2.blood_packet1 = int.Parse(blood_packet);
            return obj2;
        }
        static void storeInFile4(string blood_type, string blood_packet)
        {
            
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\BLOOD.txt";
            StreamWriter blood_record = new StreamWriter(path, true);
            Console.WriteLine(blood_type + "," + blood_packet);
            blood_record.Flush();
            blood_record.Close();
        }
        static ROOM room_status(string room_type, string room_rate, string no_of_room)
        {
            ROOM obj3 = new ROOM();
            obj3.room_type1 = room_type;
            obj3.room_rate1 = int.Parse(room_rate);
            obj3.no_of_room1 = int.Parse(no_of_room);
            return obj3;
        }
        static void storeInFile5(string room_type, string room_rate, string no_of_room)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\ROOM.txt";
            StreamWriter room_record = new StreamWriter(path, true);

            room_record.WriteLine(room_type + "," + room_rate + "," + no_of_room);
            room_record.Flush();
            room_record.Close();
        }
        static TEST lab_test_status(string test_type, string test_rate)
        {
            TEST obj4 = new TEST();
            obj4.test_type1 = test_type;
            obj4.test_rate1 = int.Parse(test_rate);
            return obj4;
        }
        static void storeInFile6(string test_type, string test_rate)
        {
            string path = "C:\\Users\\uet\\Desktop\\PRACTICING C SHARP\\week2semesterpd\\LAB.txt";
            StreamWriter lab_record = new StreamWriter(path, true);

            lab_record.WriteLine(test_type + "," + test_rate);
            lab_record.Flush();
            lab_record.Close();
        }
        static void delete_patient_record(string patient_name_variable, string patient_id_variable, List<PATIENT> arr)
        {
            int flag = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (patient_name_variable == arr[i].patient_name1 && patient_id_variable == arr[i].patient_id1)
                {
                    arr.RemoveAt(i);
                    flag++;
                    break;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine(" An invalid entry of patient name or id ");
            }
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
            int flag = 0;
            string blood;
            int packet;
            Console.WriteLine("-----------------------------------------------Blood Bank-------------------------------------------------------------");
            Console.WriteLine();
            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine("BLOOD TYPE:    " + arr[i].blood_type1);
                Console.WriteLine("NO OF PACKETS AVAILABLE:    " + arr[i].blood_packet1);
                Console.WriteLine();
            }
            Console.Write("Enter blood type you need ");
            blood = Console.ReadLine();
            Console.Write("Enter no of packets you need ");
            packet = int.Parse(Console.ReadLine());
            for (int i = 0; i < arr.Count; i++)
            {
                if (blood == arr[i].blood_type1)
                {
                    if (packet <= arr[i].blood_packet1)
                    {
                        arr[i].blood_packet1 = arr[i].blood_packet1 - packet;
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
            book_test(arr1);
        }
        static void book_test(List<TEST>arr)
        {
            string test_name;
            int flag = 0;
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
                flag = 0;
                Console.Write("Enter Name of Test: ");
                test_name = Console.ReadLine();
                for (int n = 0; n < arr.Count; n++)
                {
                    if (test_name == arr[n].test_type1)
                    {
                        paisa = arr[n].test_rate1;
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("An invalid entry that test does not available in our hospital ");
                    i--;
                }
            }
        }
        static void room_selection(List<ROOM> ARRAY)
        {
            int flag = 0;
            int j = 1;
            string select_room;
            Console.WriteLine("------------------------------------------------------------------------------------------ROOMS RATES-------------------------------------------------------------");
            for (int n = 0; n < ARRAY.Count; n++)
            {
                Console.WriteLine("ROOM NAMES:     " + ARRAY[n].room_type1);
                Console.WriteLine("ROOM RATE:        " +ARRAY[n].room_rate1);
                Console.WriteLine();
            }
            Console.WriteLine();
            while (j == 1)
            {
                j = 0;
                Console.WriteLine("Enter room you want to book      ");
                select_room = Console.ReadLine();
                for (int n = 0; n < ARRAY.Count; n++)
                {
                    if (select_room == ARRAY[n].room_type1)
                    {
                        if (ARRAY[n].no_of_room1 >= 1)
                        {
                            Console.WriteLine("YOUR ROOM IS SUCEESSFULLY BOOKED ");
                            ARRAY[n].no_of_room1--;
                            paisa= ARRAY[n].room_rate1;
                        }
                        else
                        {
                            Console.WriteLine("All the rooms of this type are totally booked ");
                        }
                        flag++;
                    }
                }
                if (flag == 0)
                {
                    Console.WriteLine("THAT TYPE OF ROOM DOES NOT EXIST IN OUR HOSPITAL ");
                    j++;
                }
            }
        }
        static void recommendations(string desease,List<DOCTER> array)
        {
            int flag = 0;
            if (desease == "TROUGHT" || desease == "NOSE" || desease == "EAR" || desease == "trought" || desease == "nose" || desease == "ear")
            {
                for (int i = 0; array[i].docter_specialization1 == "ENT" && i <array.Count ; i++)
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
    }
}
