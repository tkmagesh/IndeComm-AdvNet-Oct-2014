using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GreetingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name...");
            var name = Console.ReadLine();
            /*var greeter = new Greeter(new TimeService());
            greeter.Greet(name);*/
            Console.ReadLine();
        }
    }

    public class Greeter
    {
        private readonly ITimeService _timeService;
        private readonly IEmailService _emailService;

        public Greeter(ITimeService timeService, IEmailService emailService)
        {
            _timeService = timeService;
            _emailService = emailService;
        }

        public Greeter()
        {
            _timeService = new TimeService();
        }

        public string Greet(string name)
        {
            
            if ( _timeService.GetCurentDateTime().Hour < 12)
            {
               return string.Format("Good Day {0}", name);
            }
            else
            {
                _emailService.Send(name);
                return string.Format("Good Evening {0}", name);
            }
        }
    }

    public interface ITimeService 
    {
        DateTime GetCurentDateTime();
    }

    public class TimeService : ITimeService
    {
        public DateTime GetCurentDateTime()
        {
            return DateTime.Now;
        }
    }

    public interface IEmailService
    {
        void Send(string name);
    }
}
