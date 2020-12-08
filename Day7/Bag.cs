using System.Collections.Generic;
using System.Linq;
public class Bag
{
    public string Color;
    public string[] RawContents;
    public Dictionary<Bag, int> InnerBags = new Dictionary<Bag, int>();

    public Bag(string Color, string[] RawContents)
    {
        this.Color = Color;
        this.RawContents = RawContents;
    }

    //Populates the bag with the inner bags
    public void FillBag(List<Bag> AllBags)
    {
        for(int i = 1; i < this.RawContents.Length; i++)
        {
            if(!this.RawContents[i].Contains("no other"))
            {
                InnerBags.Add(AllBags.Where(x => x.Color == RawContents[i].Substring(2)).FirstOrDefault(), int.Parse(RawContents[i].Substring(0, 1)));
            }
        }
        
    }
}