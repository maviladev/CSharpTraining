using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public interface IGeneralLogger 
    {
        public int LoggerPriority { get; set; }
        public string LoggerType { get; set; }

        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
        string MessageReturnString(string message);
        bool MessageWithOutParameterReturnsBoolean(string message, out string outputString);
        bool MessageWithObjectReferenceReturnsBoolean(ref Client client);
    }
    public class GeneralLogger : IGeneralLogger
    {
        public int LoggerPriority { get; set; }
        public string LoggerType { get; set; }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            if (balanceAfterWithdrawal >= 0)
            {
                Console.WriteLine("éxito");
                return true;
            }

            Console.WriteLine("error");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageReturnString(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }

        public bool MessageWithObjectReferenceReturnsBoolean(ref Client client)
        {
            return true;
        }

        public bool MessageWithOutParameterReturnsBoolean(string message, out string outputString)
        {
            outputString = "Hi " + message;
            return true;
        }
    }
    public class FakeGeneralLogger : IGeneralLogger
    {
        public int LoggerPriority { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LoggerType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
        {
            throw new NotImplementedException();
        }

        public bool LogDatabase(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
        }

        public string MessageReturnString(string message)
        {
            throw new NotImplementedException();
        }

        public bool MessageWithObjectReferenceReturnsBoolean(ref Client client)
        {
            throw new NotImplementedException();
        }

        public bool MessageWithOutParameterReturnsBoolean(string message, out string outputString)
        {
            throw new NotImplementedException();
        }
    }

    
}
