internal class Program
{

    public delegate void Vypis(string text);

    public static void Uloz(string text)
    {
        string cesta = "Soubor.txt";
        using (StreamWriter sw = new StreamWriter(cesta, true))
        {
            sw.WriteLine(text);
            sw.Flush();
        }
    }


    static void VykonejFunkci(Vypis vypis, string text)
    {
        if (!string.IsNullOrEmpty(text) && vypis is not null)
        {
            vypis(text);
        }
    }


    private static void Main(string[] args)
    {

        //Delegát - zapouzdřený odkaz na nějakou funkci/metodu

        Vypis konzole = Console.WriteLine;

        konzole("Nazdárek Havlíku, co zuby?");

        VykonejFunkci(Uloz, "Dávejte sakra pozor!!!");

        Vypis LambdaFce = (text) => Console.Write($"Zadaný text '{text}' má celkem {text.Length} znaků");


        VykonejFunkci(
            delegate(string text) { Console.Write($"Zadaný text '{text}' má celkem {text.Length} znaků"); }, 
            "Dávejte sakra pozor!!!"
            );

        //předpřipravené delegáty

        //1. delegát typou void - akce - "public delegate void jmeno ();"
        Action akce = () => Console.WriteLine("Hello Teeths");
        akce();

        Action<string> action = Console.WriteLine;
        action("Čus Havlík, co zoubky?");

        //2. delegát typu bool - predikát - "public delegate bool predikát (parametry)

        Predicate<int> Sude = (num) => num % 2 == 0; //  True/False
        Console.WriteLine(Sude(22)); // True

        //3. delegát libovolného návratového typu funkce - Func - public delegate <typ> func (parametry)

        Func<int, string> IntParser = (num) => num.ToString();
        var value = IntParser(22);
        Console.WriteLine($"proměnná value s hodnotou {value} je datového typu: {value.GetType().Name}");

    }
}
