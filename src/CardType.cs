namespace CodeCave.CredyCard;

public class CardType
{
    private CardType()
    {
        
    }

    public bool IsCreditCard { get; private set; }

    public bool IsDebitCard => !IsCreditCard;

    public string[] VendorCodes { get; private set; }

    public string VendorCode => VendorCodes?.FirstOrDefault();

    public string[] VendorNames { get; private set; }

    public string VendorName => VendorNames?.FirstOrDefault();

    public int RequiredLength { get; private set; }

    private void ParseNumber(long cardNumber)
    {
        RequiredLength = 16;

        switch (cardNumber)
        {
            case var visa when cardNumber.IsVisaCardNumber():
                VendorCodes = ["VISA"];
                VendorNames = ["Visa"];
                break;

            case var mastercard when cardNumber.IsMastercardNumber():
                VendorCodes = ["MAST"];
                VendorNames = ["Mastercard"];
                break;

            case var maestro when cardNumber.IsMaestroCardNumber():
                VendorCodes = ["MAES"];
                VendorNames = ["Maestro"];
                break;

            case var amex when cardNumber.IsAmexCardNumber():
                VendorCodes = ["AMEX"];
                VendorNames = ["American Express"];
                break;

            case var maestro when cardNumber.IsDinersCardNumber():
                VendorCodes = ["DINR"];
                VendorNames = ["Diners"];
                break;

            default:
                VendorCodes = ["N/A"];
                VendorNames = ["Unknown"];
                break;
        }
    }

    public static CardType Parse(long cardNumber)
    {
        var cardType = new CardType();
        cardType.ParseNumber(cardNumber);
        return cardType;
    }

    public static bool TryParse(long cardNumber, out CardType cardType)
    {
        try
        {
            cardType = Parse(cardNumber);
            return true;
        }
        catch
        {
            cardType = default;
            return false;
        }
    }
}