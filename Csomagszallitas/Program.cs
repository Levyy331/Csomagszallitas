using Csomagszallitas;

List<Csomag> csomagok = new List<Csomag>();
string[] sorok = File.ReadAllLines("csomagok.txt");
foreach (string sor in sorok)
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        continue;
    }
    string[] elemek = sor.Split(';');
    if (elemek.Length >= 4)
    {
        bool sulySiker = int.TryParse(elemek[2], out int suly);
        bool tavolsagSiker = int.TryParse(elemek[3], out int tavolsag);
        if (sulySiker && tavolsagSiker)
        {
            csomagok.Add(new Csomag(elemek[0], elemek[1], suly, tavolsag));
        }
        else
        {
            Console.WriteLine($"[HIBA] Hibás számformátum a sorban: \"{sor}\" -> Sor átugorva.");
        }
    }
    else if (elemek.Length >= 3)
    {
        bool sulySiker = int.TryParse(elemek[2], out int suly);
        if (sulySiker)
        {
            csomagok.Add(new Csomag(elemek[0], elemek[1], suly));
        }
        else
        {
            Console.WriteLine($"[HIBA] Hibás súlyformátum a sorban: \"{sor}\" -> Sor átugorva.");
        }
    }
}
Console.WriteLine();
Console.WriteLine($"Regisztrált csomagok száma a rendszerben: {Csomag.OsszesCsomagSzam}");