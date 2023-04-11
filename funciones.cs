public static class Funciones
{
    public static string IngresarString(string txt)
    {
        string devolver;
        Console.WriteLine(txt);
        devolver = Console.ReadLine();
        return devolver;
    }

    public static int IngresarInt(string txt)
    {
        int devolver;
        Console.WriteLine(txt);
        devolver = int.Parse(Console.ReadLine());
        return devolver;
    }

    public static double IngresarDouble(string txt)
    {
        double devolver;
        Console.WriteLine(txt);
        devolver = double.Parse(Console.ReadLine());
        return devolver;
    }

    public static char IngresarChar(string txt)
    {
        char devolver;
        Console.WriteLine(txt);
        devolver = char.Parse(Console.ReadLine());
        return devolver;
    }

    public static DateTime IngresarDateTime(string txt)
    {
        DateTime devolver = new DateTime();
        string a = IngresarString(txt);
        while(!(DateTime.TryParse(a, out devolver)))
        {
            a = IngresarString(txt);
        }
        return devolver;
    }
}

