namespace CleanCodeLesson.Tests;

using Examples.PrimitiveObsession;

[TestClass]
public class DemoTests
{
    [TestMethod]
    public void DemoTest()
    {
        // Arrange
        var customer = new Customer();

        var phone = PhoneNumber.Parse("79275612023");

        customer.AddUnconfirmedPhone(phone);

        var code = customer.AwaitingConfirmationPhone.ConfirmationCode;

        customer.ConfirmPhone(code);
    }
}