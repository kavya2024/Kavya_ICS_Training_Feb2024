using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation
{
    class User
    {
        static Railway_Reservation_SystemEntities db = new Railway_Reservation_SystemEntities();
        static Train_Details td = new Train_Details();
        static User_detail ud = new User_detail();
        static Random r = new Random();
        static int userid;
        public static void user_option()
        {
            Console.WriteLine("\t1. Book Ticket Press '1'");
            Console.WriteLine("\t2. Show Booked Ticket Press '2'");
            Console.WriteLine("\t3. Cancel Ticket Press '3'");
            Console.WriteLine("\t4. Exit... Press '4'");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Bookticket(userid);
                user_option();
            }
            else if (ans == 2)
            {
                printtkt(userid);
                user_option()
;
            }
            else if (ans == 3)
            {
                canTicket();
                user_option();
            }
            else
                Environment.Exit(0);
                
        }
        static void showTrains()
        {
            var train = db.Train_Details.Where(t=>t.softDelete=="Active").ToList();
            foreach(var v in train)
            {
                Console.WriteLine($"Train no{v.Train_No} Train Name  {v.T_Name} Train Source {v.Source} Train Destination  {v.Dest}");
            }
        }
        static void Bookticket(int uid)
        {
            showTrains();
            Booked_Ticket bt = new Booked_Ticket();
            int bid = r.Next(10000, 99999);
            bt.Bookid = bid;
            bt.UserId = uid;
            Console.WriteLine("Enter train no to book ticket...");
            int tno = int.Parse(Console.ReadLine());
            bt.TrainNo = tno;
            Console.WriteLine("Enter passenger name...");
            bt.PassengerName = Console.ReadLine();
            Console.WriteLine("Book ticket for FirstAc,SecondAC,Sleeper...");
            string ans = Console.ReadLine().ToLower();
            int amt = 0;
            if(ans=="firstac")
                amt= (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.First_AC).FirstOrDefault();
            else if(ans=="secondac")
                amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.SencodAC).FirstOrDefault();
            else
                amt = (int)db.Fares.Where(t => t.Train_No == tno).Select(t => t.Sleeper).FirstOrDefault();
            bt.TotalFare = amt;
            bt.Booking_Date_Time = DateTime.Now;
            bt.Ticket_status = "Confirm";

            db.Booked_Ticket.Add(bt);
            db.SaveChanges();
            Console.WriteLine("Thanks for booking tiket....");

        }

        static void canTicket()
        {
            Console.WriteLine("Enter booking id to cancel ticket...");
            int bookid = int.Parse(Console.ReadLine());
            db.canTkt(bookid);
        }

        public static void printtkt(int uid)
        {
            var tkt = db.Booked_Ticket.Where(bt => bt.UserId == uid);
            foreach(var v in tkt)
            {
                Console.WriteLine(v.Bookid+"  userid: "+v.UserId+" "+v.TrainNo+" \n"+v.TotalFare+" "+v.Ticket_status );
            }
        }

        public static void usercheck()
        {
            Console.WriteLine("Enter 1 create account..... \nEnter 2 for Login... ");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                Console.WriteLine("Enter user id:");
                userid = int.Parse(Console.ReadLine());
                ud.User_id = userid;
                Console.WriteLine("Enter user Name: ");
                ud.U_Name = Console.ReadLine();
                Console.WriteLine("Enter user Age: ");
                ud.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Password: ");
                ud.Password = Console.ReadLine();
                db.User_detail.Add(ud);
                db.SaveChanges();
                Console.WriteLine("Account Created sucessfully...");
                user_option();
            }
            else if (ans == 2)
            {
                //validateuser...
                Console.Write("Enter User-ID: ");
                userid = int.Parse(Console.ReadLine());
                Console.Write("Enter User Password: ");
                string password = Console.ReadLine();
                var validate = Validate(userid, password);
                if (validate)
                     user_option();
                else
                {
                    Console.WriteLine("Invalid User credentials...");
                    user_option();
                }
                        
            }
            else
                Environment.Exit(0);

        }
        private static bool Validate(int user_id, string password)
        {
            var user = db.User_detail.FirstOrDefault(u => u.User_id == user_id && u.Password == password);
            return user != null;
        }
    }
}
