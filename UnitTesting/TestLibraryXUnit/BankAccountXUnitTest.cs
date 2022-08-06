using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestLibrary
{
    public class BankAccountXUnitTest
    {
        private BankAccount bankAccount;

        [Fact]
        public void Deposit_InputAmount100_ReturnsTrue()
        {
            BankAccount bankAccount = new BankAccount(new FakeGeneralLogger());

            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.Equal(100, bankAccount.Balance);
        }

        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            var mocking = new Mock<IGeneralLogger>();

            BankAccount bankAccount = new BankAccount(mocking.Object);

            var result = bankAccount.Deposit(100);
            Assert.True(result);
            Assert.Equal(100, bankAccount.Balance);
        }
        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
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

            Assert.True(result);

        }

        [Theory]
        [InlineData(200, 300)]
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

            Assert.False(result);
        }

        [Fact]
        public void BankAccountGeneralLogger_LogMocking_ReturnTrue()
        {
            var generalLogger = new Mock<IGeneralLogger>();
            string testText = "hello world";

            generalLogger.Setup(u => u.MessageReturnString(It.IsAny<string>())).Returns<string>(str => str.ToLower());
            var result = generalLogger.Object.MessageReturnString("heLLo world");

            Assert.Equal(testText, result);
        }

        [Fact]
        public void BankAccountGeneralLogger_LogMockingOutput_ReturnsTrue()
        {
            var generalLogger = new Mock<IGeneralLogger>();
            string testText = "Hi";

            // Setup out parameter
            generalLogger.Setup(u => u.MessageWithOutParameterReturnsBoolean(It.IsAny<string>(), out testText)).Returns(true);
            string outParameter = "";
            var result = generalLogger.Object.MessageWithOutParameterReturnsBoolean("Marcos", out outParameter);

            Assert.True(result);
        }

        [Fact]
        public void BankAccountGeneralLogger_LogMockingObjectReference_ReturnsTrue()
        {
            var generalLogger = new Mock<IGeneralLogger>();

            Client client = new();
            Client unusedClient = new();

            generalLogger.Setup(u => u.MessageWithObjectReferenceReturnsBoolean(ref client)).Returns(true);

            Assert.True(generalLogger.Object.MessageWithObjectReferenceReturnsBoolean(ref client));

            Assert.False(generalLogger.Object.MessageWithObjectReferenceReturnsBoolean(ref unusedClient));
        }

        [Fact]
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

            Assert.Equal(100, generalLoggger.Object.LoggerPriority);
            Assert.Equal("error", generalLoggger.Object.LoggerType);

            // Callback
            string temporalText = "marcos";
            generalLoggger.Setup(u => u.LogDatabase(It.IsAny<string>()))
                .Returns(true)
                .Callback((string param) => temporalText += param);
            generalLoggger.Object.LogDatabase("avila");

            Assert.Equal("marcosavila", temporalText);

        }
    }
}
