namespace CleanCodeLesson;

using Itc.DirectCrm.Model;
using PrimitiveObsession.Example;

public class Customer
{
	//Пришли в маэстру, а там нет миддл нейма
	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string MiddleName { get; set; }

	public string Email { get; set; }

	public bool? IsEmailValid { get; set; }

	public bool IsEmailConfirmed { get; set; }

	public string EmailToBeConfirmed { get; set; }

	public long? MobilePhone { get; set; }

	public bool IsMobilePhoneConfirmed { get; set; }

	public bool IsMobilePhoneInvalid { get; set; }

	public long? MobilePhoneToBeConfirmed { get; set; }

	public string? MobilePhoneConfirmationCode { get; set; }

	public void TryParseAndSetMobilePhoneOrMobilePhoneToBeConfirmed(
		string phone,
		bool isForAllowedCountries,
		bool shouldConfirm)
	{
		if (string.IsNullOrWhiteSpace(phone))
		{
			MobilePhone = null;
			IsMobilePhoneConfirmed = false;
			SetMobilePhoneToBeConfirmed(null);
		}
		else
		{
			var phoneValue = phone.TryParsePhone(isForAllowedCountries);
			if (phoneValue != null)
			{
				SetMobilePhoneOrMobilePhoneToBeConfirmed(
					phoneValue, shouldConfirm);
			}
		}
	}

	private void SetMobilePhoneToBeConfirmed(long? phoneToBeConfirmed)
	{
		MobilePhoneToBeConfirmed = phoneToBeConfirmed;
		if (phoneToBeConfirmed == null)
			MobilePhoneConfirmationCode = null;
		else
			SetRandomMobilePhoneConfirmationCode();
	}

	private void SetRandomMobilePhoneConfirmationCode()
	{
		MobilePhoneConfirmationCode = MobilePhoneConfirmationCodeGenerator.Generate();
	}

	public void SetMobilePhoneOrMobilePhoneToBeConfirmed(
		long? phone, bool shouldConfirm)
	{
		if (phone == null)
		{
			MobilePhone = null;
			IsMobilePhoneConfirmed = false;
			SetMobilePhoneToBeConfirmed(null);
		}
		else if (IsMobilePhoneConfirmed && phone == MobilePhone)
		{
		}
		else if (shouldConfirm)
		{
			if (MobilePhoneToBeConfirmed != phone)
			{
				SetMobilePhoneToBeConfirmed(phone);
			}
		}
		else
		{
			MobilePhone = phone;
			SetMobilePhoneToBeConfirmed(null);
			IsMobilePhoneConfirmed = false;
		}
	}

	public void ClearMobilePhone(bool clearToBeConfirmed)
	{
		MobilePhone = null;
		IsMobilePhoneConfirmed = false;
		IsMobilePhoneInvalid = false;

		if (clearToBeConfirmed)
		{
			MobilePhoneToBeConfirmed = null;
			MobilePhoneConfirmationCode = null;
		}
	}
}