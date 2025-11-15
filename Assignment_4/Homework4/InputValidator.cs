using System.Net.Mail;

public static class InputValidator
{
    public static bool ValidateName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && name.Trim().Length >= 2;
    }

    public static bool ValidatePhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        foreach (char c in phone)
        {
            if (!char.IsDigit(c) && c != '+' && c != '-' && c != ' ' && c != '(' && c != ')')
                return false;
        }
        return true;
    }

    public static bool ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var mailAddress = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool ValidateAge(int age)
    {
        return age >= 1 && age <= 120;
    }

    public static bool ValidateAddress(string address)
    {
        return !string.IsNullOrWhiteSpace(address) && address.Trim().Length >= 5;
    }
}