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

class FanLaptop
{
    public enum State { Quite, Balance, Performance, Turbo}
    public enum Trigger {modeUp, modeDown, tuboShortcut}

    private State currentState = State.Quite;

    public FanLaptop()
    {
        currentState = State.Quite;
    }

    
    public class Transisi
    {
        public State currentState, nextState;
        public Trigger trigger;
        public Transisi(State stateAwal, State stateAkhir, Trigger tgr)
        {
            currentState = stateAwal;
            nextState = stateAkhir;
            trigger = tgr;
        }
    }

    Transisi[] transisi = {
            new Transisi(State.Quite, State.Balance, Trigger.modeUp),
            new Transisi(State.Balance, State.Performance, Trigger.modeUp),
            new Transisi(State.Performance, State.Turbo, Trigger.modeUp),
            new Transisi(State.Turbo, State.Performance, Trigger.modeDown),
            new Transisi(State.Turbo, State.Quite, Trigger.tuboShortcut),
            new Transisi(State.Quite, State.Turbo, Trigger.tuboShortcut),
            new Transisi(State.Performance, State.Balance, Trigger.modeDown),
            new Transisi(State.Balance, State.Quite, Trigger.modeDown)
        };

    public State gantiMode(State currentState, State nextState, Trigger tgr)
    {
        foreach (var change in transisi)
        {
            if (currentState == change.currentState && tgr == change.trigger)
            {
                Console.WriteLine($"Fan {change.currentState} berubah menjadi {change.nextState}");
                return change.nextState;
            }
        }
        return currentState;
    }
}
class Program
{
    static void Main()
    {
        KodeProduk kode = new KodeProduk();

        string barang = "Laptop";

        Console.WriteLine($"Kode barang untuk {barang} adalah : {kode.getKodeProduk(barang)}");

        FanLaptop laptop = new FanLaptop();

        laptop.gantiMode(FanLaptop.State.Quite,FanLaptop.State.Turbo, FanLaptop.Trigger.tuboShortcut);
        laptop.gantiMode(FanLaptop.State.Quite, FanLaptop.State.Balance, FanLaptop.Trigger.modeUp);
        laptop.gantiMode(FanLaptop.State.Balance, FanLaptop.State.Performance, FanLaptop.Trigger.modeUp);
        laptop.gantiMode(FanLaptop.State.Balance, FanLaptop.State.Quite, FanLaptop.Trigger.modeDown);
        laptop.gantiMode(FanLaptop.State.Performance, FanLaptop.State.Balance, FanLaptop.Trigger.modeDown);
        laptop.gantiMode(FanLaptop.State.Performance, FanLaptop.State.Turbo, FanLaptop.Trigger.modeUp);
        laptop.gantiMode(FanLaptop.State.Turbo, FanLaptop.State.Quite, FanLaptop.Trigger.tuboShortcut);
        laptop.gantiMode(FanLaptop.State.Turbo, FanLaptop.State.Performance, FanLaptop.Trigger.modeDown);

    }
}