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


        VykonejFunkci(
            (text) => Console.Write($"Zadaný text '{text}' má celkem {text.Length} znaků"), 
            "Dávejte sakra pozor!!!"
            );





    }
}
