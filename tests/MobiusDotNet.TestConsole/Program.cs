using System;
using MobiusDotNet.Resources.AppStore.Parameters;

namespace MobiusDotNet.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("MobiusDotNet Test Console");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1) App Store: get balance");
                Console.WriteLine("2) App Store: use balance");
                Console.WriteLine("0) Exit");
                Console.Write("Make your choice: ");

                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '1': GetBalance(); break;
                    case '2': Use(); break;
                    case '0': return;
                    default: continue;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static MobiusConnectionInfo GetConnectionDetails()
        {
            return new MobiusConnectionInfo(@"12345-12345-12345", @"http://agilebits.mocklab.io/api", "v1");
        }
        
        static void GetBalance()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.AppStore.GetBalance(new BalanceParameters
            {
                AppUID = Guid.NewGuid(),
                Email = "john.doe@test.local"
            });

            Console.WriteLine(response);
        }

        static void Use()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.AppStore.Use(new UseParameters
            {
                AppUID = Guid.NewGuid(),
                Email = "john.doe@test.local",
                NumberOfCredits = 200
            });

            Console.WriteLine(response);
        }
    }
}
