using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Client
    {
        public string ClientName { get; set; }
        public int Discount = 10;
        public int OrderTotal { get; set; }

        public bool IsPremium { get; set; }

        public Client()
        {
            IsPremium = false;
        }

        public string CreateFullName(string firstName, string lastName) 
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("El nombre esta en blanco");

            Discount = 30;
            ClientName = $"{firstName} {lastName}";
            return ClientName;
        }

        public ClientType GetClientDetail() 
        {
            if (OrderTotal < 500)
                return new ClientBasic();

            return new ClientPremium();
        }
    }


    public class ClientType
    {

    }

    public class ClientBasic : ClientType
    {

    }

    public class ClientPremium: ClientType
    {

    }


}
