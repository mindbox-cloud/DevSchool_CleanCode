namespace CleanCodeLesson.Tests;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void TryParseAndSetMobilePhoneOrMobilePhoneToBeConfirmed_ValidPhone_ShouldSetMobilePhone()
    {
        // Arrange
        var customer = new Customer();
        string validPhone = "79206542320"; // Assuming this is a valid phone number

        // Act
        customer.TryParseAndSetMobilePhoneOrMobilePhoneToBeConfirmed(validPhone, isForAllowedCountries: true, shouldConfirm: false);

        // Assert
        Assert.AreEqual(79206542320, customer.MobilePhone);
        Assert.IsFalse(customer.IsMobilePhoneConfirmed);
        Assert.IsNull(customer.MobilePhoneToBeConfirmed);
    }

    [TestMethod]
    public void TryParseAndSetMobilePhoneOrMobilePhoneToBeConfirmed_InvalidPhone_ShouldNotSetMobilePhone()
    {
        // Arrange
        var customer = new Customer();
        string invalidPhone = "invalid";

        // Act
        customer.TryParseAndSetMobilePhoneOrMobilePhoneToBeConfirmed(invalidPhone, isForAllowedCountries: true, shouldConfirm: false);

        // Assert
        Assert.IsNull(customer.MobilePhone);
        Assert.IsFalse(customer.IsMobilePhoneConfirmed);
        Assert.IsNull(customer.MobilePhoneToBeConfirmed);
    }

    [TestMethod]
    public void SetMobilePhoneOrMobilePhoneToBeConfirmed_ShouldConfirmTrue_ShouldSetMobilePhoneToBeConfirmed()
    {
        // Arrange
        var customer = new Customer();
        long validPhone = 1234567890;

        // Act
        customer.SetMobilePhoneOrMobilePhoneToBeConfirmed(validPhone, shouldConfirm: true);

        // Assert
        Assert.IsNull(customer.MobilePhone);
        Assert.AreEqual(validPhone, customer.MobilePhoneToBeConfirmed);
        Assert.IsFalse(customer.IsMobilePhoneConfirmed);
    }

    [TestMethod]
    public void SetMobilePhoneOrMobilePhoneToBeConfirmed_ShouldConfirmFalse_ShouldSetMobilePhone()
    {
        // Arrange
        var customer = new Customer();
        long validPhone = 1234567890;

        // Act
        customer.SetMobilePhoneOrMobilePhoneToBeConfirmed(validPhone, shouldConfirm: false);

        // Assert
        Assert.AreEqual(validPhone, customer.MobilePhone);
        Assert.IsNull(customer.MobilePhoneToBeConfirmed);
        Assert.IsFalse(customer.IsMobilePhoneConfirmed);
    }

    [TestMethod]
    public void ClearMobilePhone_ClearToBeConfirmedTrue_ShouldClearAll()
    {
        // Arrange
        var customer = new Customer
        {
            MobilePhone = 1234567890,
            IsMobilePhoneConfirmed = true,
            IsMobilePhoneInvalid = true,
            MobilePhoneToBeConfirmed = 1234567890,
            MobilePhoneConfirmationCode = "1234"
        };

        // Act
        customer.ClearMobilePhone(clearToBeConfirmed: true);

        // Assert
        Assert.IsNull(customer.MobilePhone);
        Assert.IsFalse(customer.IsMobilePhoneConfirmed);
        Assert.IsFalse(customer.IsMobilePhoneInvalid);
        Assert.IsNull(customer.MobilePhoneToBeConfirmed);
        Assert.IsNull(customer.MobilePhoneConfirmationCode);
    }

    [TestMethod]
    public void ClearMobilePhone_ClearToBeConfirmedFalse_ShouldClearMobilePhoneOnly()
    {
        // Arrange
        var customer = new Customer
        {
            MobilePhone = 1234567890,
            IsMobilePhoneConfirmed = true,
            IsMobilePhoneInvalid = true,
            MobilePhoneToBeConfirmed = 1234567890,
            MobilePhoneConfirmationCode = "1234"
        };

        // Act
        customer.ClearMobilePhone(clearToBeConfirmed: false);

        // Assert
        Assert.IsNull(customer.MobilePhone);
        Assert.IsFalse(customer.IsMobilePhoneConfirmed);
        Assert.IsFalse(customer.IsMobilePhoneInvalid);
        Assert.IsNotNull(customer.MobilePhoneToBeConfirmed);
        Assert.IsNotNull(customer.MobilePhoneConfirmationCode);
    }
}