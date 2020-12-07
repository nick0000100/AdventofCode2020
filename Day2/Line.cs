public class Line
{
    public int Min {get; set;}
    public int Max {get; set;}
    public char Letter {get; set;}
    public string Pass {get; set;}

    public Line(int Min, int Max, char Letter, string Pass)
    {
        this.Min = Min;
        this.Max = Max;
        this.Letter = Letter;
        this.Pass = Pass;
    }
}

