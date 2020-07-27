using System;
using LaunchDarkly.Client;

namespace LaunchDarklyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LdClient client = new LdClient("sdk-654e6002-b3bb-416f-a4a4-da02032e068f");
            //Console.WriteLine(typeof(LdClient).FullName);
            User user = User.Builder("20")
              .FirstName("Bob")
              .LastName("Loblaw")
              .Country("JAP")
              .Custom("State","NY")
              .Custom("Site", "1000")
              .Build();

            bool pilotflag = client.BoolVariation("msb-idv-pilot", user, false);
            if (pilotflag)
            {
                Console.WriteLine("Pilot Flag for Site is true");
            }
            else
            {
                Console.WriteLine("Pilot Flag for Site is false");
            }
            
            string countrieflag = client.StringVariation("msb-idv-country", user, "flase");
            if (countrieflag=="true" || countrieflag == "US")
            {
                Console.WriteLine("Countries Flag for country Us is true");
            }
            else
            {
                Console.WriteLine("Countries Flag for country Us is false");
            }

            bool Stateflag = client.BoolVariation("msb-idv-states", user, false);
            
            if (Stateflag)
            {
                Console.WriteLine("State Flag for state NY is true");
            }
            else
            {
                Console.WriteLine("State Flag for state NY is false");
            }

            
            client.Flush();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
