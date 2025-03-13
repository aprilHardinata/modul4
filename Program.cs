// See https://aka.ms/new-console-template for more information
class KodeProduk
{
    private Dictionary<string, string> tableKodeProduk = new Dictionary<string, string>
    {
        {"Laptop","E100" },
        {"Smartphone", "E101" },
        {"Tablet", "E102" },
        {"Headset", "E103"},
        {"Keyboard", "E104" },
        {"Mouse", "E105" },
        {"Printer", "E106" },
        {"Monitor", "E107" },
        {"Smartwatch", "E108" },
        {"Kamera", "E109" },
    };

    public string getKodeProduk(string barang)
    {
        if (tableKodeProduk.ContainsKey(barang))
        {
            return tableKodeProduk[barang];
        }
        else
        {
            return "Kode barang tidak di temukan";
        }
    }
}

class Program
{
    static void Main()
    {
        KodeProduk kode = new KodeProduk();

        string barang = Console.ReadLine();

        Console.WriteLine($"Kode barang untuk {barang} adalah : {kode.getKodeProduk(barang)}");

    }
}