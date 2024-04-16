using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainReservation
{
    class Admin
    {
        static Railway_Reservation_SystemEntities db = new Railway_Reservation_SystemEntities();
        static Train_Details t = new Train_Details();
        
        public static void addTrain()
        {
            Console.WriteLine("Enter train no:");
            int tno = int.Parse(Console.ReadLine());
            t.Train_No = tno;
            Console.WriteLine("Enter train name");
            string tname = Console.ReadLine();
            t.T_Name = tname;
            Console.WriteLine("Enter source");
            string source = Console.ReadLine();
            t.Source = source;
            Console.WriteLine("Enter train destination");
            string dest = Console.ReadLine();
            t.Dest = dest;
            string sts = "Active";
            t.softDelete = sts;
            db.Train_Details.Add(t);
            db.SaveChanges();
           // db.AddTrain(tno, tname, source,dest, sts);
            Console.WriteLine("Train has been added successfully now enter train and fair details");
            Console.WriteLine("Now add train seat and fare....");
            
            Console.WriteLine("Fare for first Ac");
             int fac= int.Parse(Console.ReadLine());
            Console.WriteLine("Fare for second Ac");
             int sac = int.Parse(Console.ReadLine());

            Console.WriteLine("Fare for Sleeper");
            int sl= int.Parse(Console.ReadLine());
            db.addfare(tno, fac, sac, sl);
          
            Console.WriteLine("Enter total seat for first Ac");
            int Fac = int.Parse(Console.ReadLine());
            Console.WriteLine("seat for second Ac");
            int Sac = int.Parse(Console.ReadLine());
            Console.WriteLine("seat for Sleeper");
            int Sl = int.Parse(Console.ReadLine());
            db.addseat(tno,Fac, Sac, Sl);


        }
        public static void delete_train()
        {
            showTrains();
            Console.WriteLine("Enter train no:");
            int trainno = int.Parse(Console.ReadLine());
            db.softdel(trainno);
            Console.WriteLine("Train deleted susscessfully....");
        }
         public static void modifytrain()
        {
            showTrains();
            Console.WriteLine("Enter train to modfiy");
            int trainno = int.Parse(Console.ReadLine());
            string source = (Console.ReadLine());
            string dest = (Console.ReadLine());
            db.modifytrain(trainno, source, dest);
         }

        static void showTrains()
        {
            var train = db.Train_Details.ToList();
            foreach (var v in train)
            {
                Console.WriteLine($"Train No{v.Train_No}  Train Name {v.T_Name} Train Source {v.Source} Train Destination  {v.Dest}");
            }
        }
        public static bool Validate(int user_id, string password)
        {
            var admin = db.AdminDetails.FirstOrDefault(a => a.Admin_id == user_id && a.passwords == password);
            return admin != null;
        }
    }
}
