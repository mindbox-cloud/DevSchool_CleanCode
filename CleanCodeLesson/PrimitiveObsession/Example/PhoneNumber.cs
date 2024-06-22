namespace CleanCodeLesson.PrimitiveObsession.Example;

using Itc.DirectCrm.Model;

public sealed record PhoneNumber
{
    private PhoneNumber(string number) => Number = number;
    public string Number { get; }

    public static PhoneNumber Parse(string value) => new(value.TryParsePhone().ToString() ?? throw new ArgumentException(value, nameof(value)));
}

public sealed record ConfirmedPhone(PhoneNumber Phone);

public sealed record AwaitingConfirmationPhone(PhoneNumber PhoneNumber, ConfirmationCode ConfirmationCode)
{
    public bool TryConfirm(ConfirmationCode userInput, out ConfirmedPhone? confirmedPhone)
    {
        confirmedPhone = null;
        if (ConfirmationCode != userInput) return false;
        confirmedPhone = new ConfirmedPhone(PhoneNumber);
        return true;
    }
}

public sealed record ConfirmationCode(string Code)
{
    public static ConfirmationCode Generate(int length = 4) => new(MobilePhoneConfirmationCodeGenerator.Generate(length));

    public static implicit operator ConfirmationCode(string code) => new(code);
}

public class Customer
{
    public ConfirmedPhone? ConfirmedPhone { get; private set; }

    public AwaitingConfirmationPhone? AwaitingConfirmationPhone { get; private set; }

    public void AddUnconfirmedPhone(PhoneNumber phoneNumber)
    {
        AwaitingConfirmationPhone = new AwaitingConfirmationPhone(phoneNumber, ConfirmationCode.Generate(6));
    }

    public void ConfirmPhone(ConfirmationCode userInput)
    {
        if (!AwaitingConfirmationPhone.TryConfirm(userInput, out var confirmedPhone)) throw new InvalidOperationException("User input does not equal confirmation code");
        ConfirmedPhone = confirmedPhone;
        AwaitingConfirmationPhone = null;
    }
}