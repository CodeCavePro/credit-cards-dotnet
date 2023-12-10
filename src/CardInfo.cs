namespace CodeCave.CredyCard;

public abstract class CardInfo
{
    public CardType Type { get; internal set; }

    public long Number { get; internal set; }

    public string NumberFormatted => string.Format("{0:0000 0000 0000 0000}", Number);
}
