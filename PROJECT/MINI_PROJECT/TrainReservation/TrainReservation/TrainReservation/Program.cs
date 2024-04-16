using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------Admin press 1...-----------------");
            Console.WriteLine("-----------User Press 2...------------------");
            Console.WriteLine("-----------Exit.. Press 3...----------------");
            int ipt = int.Parse(Console.ReadLine());

            if (ipt == 1)
            {
                Console.Write("Enter Admin-ID: ");
                int adminid = int.Parse(Console.ReadLine());
                Console.Write("Enter Admin Password: ");
                string password = Console.ReadLine();
                var validate = Admin.Validate(adminid, password);

                if (validate)
                {
                    Console.WriteLine("WELCOME ADMIN");
                    //validate method....
                    Console.WriteLine("press 1 to add train..");
                    Console.WriteLine("press 2 to modify train..");
                    Console.WriteLine("press 3 to delete train..");
                    int input = int.Parse(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            Admin.addTrain();
                            break;
                        case 2:
                            Admin.modifytrain();
                            break;
                        case 3:
                            Admin.delete_train();
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Admin Id or Password is wrong...\nPlease Exit...");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

                
            }

            else if (ipt == 2)
            {
                User.usercheck();
            }
        }

    }
}
    
