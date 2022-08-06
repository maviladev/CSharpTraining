using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount bankAccount;

        [SetUp]
        public void Setup() 
        {
        }

        [Test]
        public void Deposit_InputAmount100_ReturnsTrue() 
        {
            BankAccount bankAccount = new BankAccount(new FakeGeneralLogger());

            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.Balance, Is.EqualTo(100));
        }

        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<IGeneralLogger>();

            BankAccount bankAccount = new BankAccount(mocking.Object);

            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.Balance, Is.EqualTo(100));
        }
        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Withdrawal_Withdrawal100With200Balance_ReturnsTrue(int balance, int withdrawal) 
        {
            var loggerMock = new Mock<IGeneralLogger>();
            // Simulate dependencies values
            loggerMock.Setup(u => u.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);

            // For a conditional criteria
            // loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdrawal(withdrawal);

            Assert.IsTrue(result);

        }

        [Test]
        [TestCase(200, 300)]
        public void Withdrawal_Withdrawal300With200Balance_ReturnsFalse(int balance, int withdrawal)
        {
            var loggerMock = new Mock<IGeneralLogger>();
            // Simulate dependencies values
            loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
            
            // For a range criteria
            //loggerMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);
            
            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.Withdrawal(withdrawal);

            Assert.IsFalse(result);

        }

        [Test]
        public void BankAccountGeneralLogger_LogMocking_ReturnTrue() 
        {
            var generalLogger = new Mock<IGeneralLogger>();
            string testText = "hello world";

            generalLogger.Setup(u => u.MessageReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());
            var result = generalLogger.Object.MessageReturnString("heLLo world");

            Assert.That(result, Is.EqualTo(testText));
        }

        [Test]
        public void BankAccountGeneralLogger_LogMockingOutput_ReturnsTrue() 
        {
            var generalLogger = new Mock<IGeneralLogger>();
            string testText = "Hi";

            // Setup out parameter
            generalLogger.Setup(u => u.MessageWithOutParameterReturnsBoolean(It.IsAny<string>(), out testText)).Returns(true);
            string outParameter = "";
            var result = generalLogger.Object.MessageWithOutParameterReturnsBoolean("Marcos", out outParameter);

            Assert.IsTrue(result);

        }

        [Test]
        public void BankAccountGeneralLogger_LogMockingObjectReference_ReturnsTrue() 
        {
            var generalLogger = new Mock<IGeneralLogger>();

            Client client = new();
            Client unusedClient = new();

            generalLogger.Setup(u => u.MessageWithObjectReferenceReturnsBoolean(ref client)).Returns(true);

            Assert.IsTrue(generalLogger.Object.MessageWithObjectReferenceReturnsBoolean(ref client));

            Assert.IsFalse(generalLogger.Object.MessageWithObjectReferenceReturnsBoolean(ref unusedClient));
        }

        [Test]
        public void BanlAccountGeneraLogger_LogMockingPropertiesPriorityAndType_RetrunsTrue() 
        {
            var generalLoggger = new Mock<IGeneralLogger>();
            
            generalLoggger.Setup(u => u.LoggerType).Returns("warning");
            generalLoggger.Setup(u => u.LoggerPriority).Returns(10);
            
            // Required in order to modify the values of the properties
            // outside of the Setup method
            generalLoggger.SetupAllProperties();

            generalLoggger.Object.LoggerPriority = 100;
            generalLoggger.Object.LoggerType = "error";

            Assert.That(generalLoggger.Object.LoggerPriority, Is.EqualTo(100));
            Assert.That(generalLoggger.Object.LoggerType, Is.EqualTo("error"));

            // Callback
            string temporalText = "marcos";
            generalLoggger.Setup(u => u.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string param) => temporalText += param);
            generalLoggger.Object.LogDatabase("avila");

            Assert.That(temporalText, Is.EqualTo("marcosavila"));
            
        }
    }
}
