using System.Collections.Generic;
public class Bag
{
    public string BagColor;
    public string[] TempContents;
    public Dictionary<Bag, int> BagContents = new Dictionary<Bag, int>();
}