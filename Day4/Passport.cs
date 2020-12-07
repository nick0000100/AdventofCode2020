public class Passport
{
    private string byr {get; set;}
    private string iyr {get; set;}
    private string eyr {get; set;}
    private string hgt {get; set;}
    private string hcl {get; set;}
    private string ecl {get; set;}
    private string pid {get; set;}
    private string cid {get; set;}

    public Passport(string byr, string iyr, string eyr, string hgt, string hcl, string ecl, string pid, string cid)
    {
        this.byr = byr;
        this.iyr = iyr;
        this.eyr = eyr;
        this.hgt = hgt;
        this.hcl = hcl;
        this.ecl = ecl;
        this.pid = pid;
        this.cid = cid;
    }
}