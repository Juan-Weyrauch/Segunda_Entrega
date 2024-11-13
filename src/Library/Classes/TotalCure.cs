using Library.Interfaces;

namespace Library.Classes;

public class TotalCure : IPotions
{
    public string Name { get; set; }
    public int RegenValue { get; set; }

    public TotalCure()
    {
        Name = "Total Cure";
        RegenValue = 0;
    }
}