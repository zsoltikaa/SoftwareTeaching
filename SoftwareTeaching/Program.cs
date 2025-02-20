Console.ForegroundColor = ConsoleColor.Green;

const string DIR = "H:\\c#\\cli\\SoftwareTeaching\\";

List<Hallgatok> hallgatok = [];

using (StreamReader reader = new StreamReader($"{DIR}course.txt"))
{

    while (!reader.EndOfStream)
    {
        hallgatok.Add(new(reader.ReadLine()));
    }

}

// 1. feladat
Console.WriteLine($"Hallgatok szama: {hallgatok.Count}");

// 2. feladat
Console.WriteLine($"Hallgatok atlaga backend fejlesztes modulbol: {hallgatok.Average(a => a.BackendEredmeny)}");

// 3. feladat
Console.WriteLine($"Az osztalyelso: {hallgatok.OrderByDescending(h => h.HalozatEredmeny + h.MobilEredmeny + h.FrontendEredmeny + h.BackendEredmeny).First().Nev}");

// 4. feladat
Console.WriteLine($"A ferfiak aranya a kepzesen: {(double)hallgatok.Count(h => h.Nem == 'm') / hallgatok.Count * 100:f2}%");

// 5. feladat
Console.WriteLine($"A legjobb noi webfejleszto: {hallgatok.Where(h => h.Nem == 'f').OrderByDescending(h => h.FrontendEredmeny + h.BackendEredmeny).First().Nev}");

// 6. feladat
Console.WriteLine("Elofinanszirozta a teljes osszeget: ");
hallgatok.Where(h => h.Befizetes == 2600).ToList().ForEach(item => Console.WriteLine($"\t{item.Nev}"));

// 7. feladat
Console.Write("Adj meg egy nevet: ");
string nev = Console.ReadLine();

var hallgato = hallgatok.FirstOrDefault(h => h.Nev.Equals(nev));

if (hallgato != null)
{

    bool kellJavitoVizsga = false;

    if (hallgato.HalozatEredmeny < 51)
    {
        Console.WriteLine("\tJavitovizsga szukseges halozatbol.");
        kellJavitoVizsga = true;
    }
    if (hallgato.MobilEredmeny < 51)
    {
        Console.WriteLine("\tJavitovizsga szukseges mobilfejlesztesbol.");
        kellJavitoVizsga = true;
    }
    if (hallgato.FrontendEredmeny < 51)
    {
        Console.WriteLine("\tJavitovizsga szukseges frontend fejlesztesbol.");
        kellJavitoVizsga = true;
    }
    if (hallgato.BackendEredmeny < 51)
    {
        Console.WriteLine("\tJavitovizsga szukseges backend fejlesztesbol.");
        kellJavitoVizsga = true;
    }

    if (!kellJavitoVizsga)
    {
        Console.WriteLine("\tNincs szukseg javitovizsgara. ");
    }

}

else
{
    Console.WriteLine("\tNincs ilyen nev a hallgatok kozott. ");
}

// 8. feladat
var f8 = hallgatok.Where(h => h.HalozatEredmeny == 100 || h.MobilEredmeny == 100 || h.FrontendEredmeny == 100 || h.BackendEredmeny == 100 && h.HalozatEredmeny <= 51 && h.MobilEredmeny <= 51 && h.FrontendEredmeny <= 51 && h.BackendEredmeny <= 51).Count();
Console.WriteLine($"A 100%-os es javitovizsga nelkuli hallgatok szama: {f8}");

// 9. feladat
Console.WriteLine($"Halozatbol javitovizsgat kell tennie: {hallgatok.Count(h => h.HalozatEredmeny < 51)}");
Console.WriteLine($"Mobilfejlesztesbol javitovizsgat kell tennie: {hallgatok.Count(h => h.MobilEredmeny < 51)}");
Console.WriteLine($"Frontend fejlesztesbol javitovizsgat kell tennie: {hallgatok.Count(h => h.FrontendEredmeny < 51)}");
Console.WriteLine($"Backend fejlesztesbol javitovizsgat kell tennie: {hallgatok.Count(h => h.BackendEredmeny < 51)}");

// 10. feladat
var rendezettHallgatok = hallgatok.OrderBy(h => h.CsaladNev()).ToList();

using (StreamWriter writer = new($"{DIR}output.txt"))
{
    foreach (var h in rendezettHallgatok)
    {
        writer.WriteLine($"{h}");
    }
}
