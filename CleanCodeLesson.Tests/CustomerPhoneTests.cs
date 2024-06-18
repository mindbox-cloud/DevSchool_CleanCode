namespace CleanCodeLesson.Tests;

using PrimitiveObsession.Example;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void ShouldAddPhoneForConfirmation()
    {
        // Arrange
        var customer = new Customer();

        var phone = PhoneNumber.Parse("79275612023");
        
        customer.AddUnconfirmedPhone(phone);

        var code = customer.AwaitingConfirmationPhone.ConfirmationCode;

        customer.ConfirmPhone(code);
    }
}