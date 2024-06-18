namespace CleanCodeLesson;

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
}