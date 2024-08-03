public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var splittedPhoneNumberArray = phoneNumber.Split('-');

        return (
            splittedPhoneNumberArray[0] == "212",
            splittedPhoneNumberArray[1] == "555",
            splittedPhoneNumberArray[2]
        );
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    {
        return phoneNumberInfo.IsFake;
    }
}
