using System;
using LaunchDarkly.Client;

namespace LaunchDarklyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LdClient client = new LdClient("sdk-971d4780-5c94-4f75-a3ee-e2f2d6876032");
            User user = User.Builder("UNIQUE IDENTIFIER")
              .FirstName("Bob")
              .LastName("Loblaw")
              .Country("US")
              .Custom("State","NY")
              .Custom("Site", "1")
              .Build();

            bool pilotflag = client.BoolVariation("pilot", user, false);
            if (pilotflag)
            {
                Console.WriteLine("Pilot Flag for Site 4 is true");
            }
            else
            {
                Console.WriteLine("Pilot Flag for Site 4 is false");
            }

            string countrieflag = client.StringVariation("countries", user, "flase");
            if (countrieflag=="true" || countrieflag == "US")
            {
                Console.WriteLine("Countries Flag for country Us is true");
            }
            else
            {
                Console.WriteLine("Countries Flag for country Us is false");
            }

            bool Stateflag = client.BoolVariation("states", user, false);
            
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
