// Hometask 2.7


using Hometask_2._7.Entities;
using System;

namespace Hometask_2._7
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new ScheduleDbContext())
            {
                var person1 = new Client()
                {
                    FullName = "Jorja Smith",
                    Age = 25,
                    Gender = "Female",
                    Schedules = new List<Schedule>
                    {
                        new Schedule { Topic = "Work Meeting", Time = "09:30", Date = "09/07/2022"},
                        new Schedule { Topic = "Talking", Time = "12:10", Date = "09/07/2022"},
                        new Schedule { Topic = "English Practice", Time = "16:00", Date = "09/07/2022"},
                        new Schedule { Topic = "Family Call", Time = "20:00", Date = "09/07/2022"},
                    }
                };

                var person2 = new Client()
                {
                    FullName = "Adele Adkins",
                    Age = 33,
                    Gender = "Female",
                    Schedules = new List<Schedule>
                    {
                        new Schedule { Topic = "Rehearsal", Time = "09:30", Date = "10/01/2022"},
                        new Schedule { Topic = "Singing", Time = "12:10", Date = "09/07/2022"},
                        new Schedule { Topic = "Relax", Time = "21:00", Date = "01/01/2022"}
                    }
                };


                context.Clients.Add(person1);
                context.Clients.Add(person2);
                context.SaveChanges();


                var schedules = context.Schedules.ToList();

                var clientMeetingsCount = context.Clients.Where(client => client.Schedules.Count > 2).ToList();

                var specificTime = context.Schedules.Where(schedule => schedule.Time == "09:30").ToList();

                var specificDate = context.Schedules.Where(schedule => schedule.Date == "09/07/2022").Take(2).ToList();

               
                context.Clients.Remove(person1);
                context.SaveChanges();
            }
        }
    }
}