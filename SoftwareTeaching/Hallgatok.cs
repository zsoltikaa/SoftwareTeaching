class Hallgatok
{

    public string Nev { get; set; }
    public char Nem { get; set; }
    public int Befizetes { get; set; }
    public int HalozatEredmeny { get; set; }
    public int MobilEredmeny { get; set; }
    public int FrontendEredmeny { get; set; }
    public int BackendEredmeny { get; set; }

    public Hallgatok(string line)
    {

        string[] sl = line.Split(';');
        
        Nev = sl[0];
        Nem = char.Parse(sl[1]);
        Befizetes = int.Parse(sl[2]);
        HalozatEredmeny = int.Parse(sl[3]);
        MobilEredmeny= int.Parse(sl[4]);
        FrontendEredmeny = int.Parse(sl[5]);
        BackendEredmeny = int.Parse(sl[6]);

    }

    public double AtlagEredmeny()
    {
        return (HalozatEredmeny + MobilEredmeny + FrontendEredmeny + BackendEredmeny) / 4.0;
    }

    public string CsaladNev()
    {
        return Nev.Split(' ')[1];
    }

    public override string ToString()
    {
        return $"{Nev}, {Nem}, {Befizetes}, {HalozatEredmeny}, {MobilEredmeny}, {FrontendEredmeny}, {BackendEredmeny}, Atlagos eredmeny: {AtlagEredmeny():F2}";
    }

}