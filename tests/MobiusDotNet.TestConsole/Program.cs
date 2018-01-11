using System;
using MobiusDotNet.Resources.AppStore.Requests;
using MobiusDotNet.Resources.Tokens;
using MobiusDotNet.Resources.Tokens.Requests;

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
                Console.WriteLine("3) Tokens: register token");
                Console.WriteLine("4) Tokens: create address");
                Console.WriteLine("5) Tokens: register address");
                Console.WriteLine("6) Tokens: address balance");
                Console.WriteLine("7) Tokens: transfer managed");
                Console.WriteLine("8) Tokens: get transfer info");
                Console.WriteLine("0) Exit");
                Console.Write("Make your choice: ");

                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch (key)
                {
                    case '1': GetBalance(); break;
                    case '2': Use(); break;
                    case '3': RegisterToken(); break;
                    case '4': CreateAddress(); break;
                    case '5': RegisterAddress(); break;
                    case '6': GetAddressBalance(); break;
                    case '7': TransferManaged(); break;
                    case '8': GetTransferInfo(); break;
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
            return new MobiusConnectionInfo(@"YOUR_API_KEY");
        }
        
        static void GetBalance()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.AppStore.GetBalance(new BalanceRequest
            {
                AppUID = Guid.NewGuid(),
                Email = "john.doe@test.local"
            });

            Console.WriteLine(response);
        }

        static void Use()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.AppStore.Use(new UseRequest
            {
                AppUID = Guid.NewGuid(),
                Email = "john.doe@test.local",
                NumberOfCredits = 200
            });

            Console.WriteLine(response);
        }

        static void RegisterToken()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.Tokens.RegisterToken(new RegisterTokenRequest
            {
                TokenType = TokenType.Erc20,
                Name = "Augur",
                Symbol = "REP",
                Issuer = "0xE94327D07Fb17607b4DB788E5aDf2ed424adDff6"
            });

            Console.WriteLine(response);
        }

        static void CreateAddress()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.Tokens.CreateAddress(new CreateAddressRequest
            {
                TokenUID = Guid.Parse("5ab77196-7fe1-5463-929a-ad33ffa430c9")
            });

            Console.WriteLine(response);
        }

        static void RegisterAddress()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.Tokens.RegisterAddress(new RegisterAddressRequest
            {
                TokenUID = Guid.Parse("5ab77296-7fe0-5463-929a-ad32ffa430c9"),
                Address = "0xa5fca8c9412cd82031f55dA34171388916FdC5eA"
            });

            Console.WriteLine(response);
        }
        
        static void GetAddressBalance()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.Tokens.GetAddressBalance(new AddressBalanceRequest
            {
                TokenUID = Guid.Parse("5ac77196-7fe1-4462-929a-ad32ffa430c9"),
                Address = "0xa5fca8c9412cd82031f55dA34171388916FdC5eA"
            });

            Console.WriteLine(response);
        }

        static void TransferManaged()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.Tokens.TransferManaged(new TransferManagedRequest
            {
                TokenAddressUID = Guid.Parse("4d7dd74a-84b2-45f8-9417-9b2b48f25a01"),
                AddressTo = "0xd89ab230a39f11e9c470e3115b9e0f569952a2fd",
                NumberOfTokens = 1M
            });

            Console.WriteLine(response);
        }

        static void GetTransferInfo()
        {
            var mobius = new Mobius(GetConnectionDetails());
            var response = mobius.Tokens.GetTransferInfo(new TransferInfoRequest
            {
                TokenAddressTransferUID = Guid.Parse("f9d3665d-fe72-49ec-3434-c2c0bfd1c57f")
            });

            Console.WriteLine(response);
        }
    }
}
