using System;
namespace UnitTestingLibrary
{
    public class Client
    {
        public string FullName { get; set; }

        public Client()
        {
        }

        public string CreateFullName(string name, string lastName)
        {
            FullName = $"{name} {lastName}";
            return FullName;
        }

    }
}
