class Persona
{
    public int DNI{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime FechaN{get;set;}
    public string Mail{get;set;}

    public int ObtenerEdad(DateTime fechaN)
    {
        int devolver;
        if (fechaN < DateTime.Today) devolver = DateTime.Today.Year - fechaN.Year;
        else devolver = DateTime.Today.Year - fechaN.Year -1;
        return devolver;
    }
    public bool PuedeVolar(int edad)
    {
        if (edad >= 16) return true;
        else return false;
    }

    public Persona(int dni, string apellido, string nombre, DateTime fechaN, string mail)
    {
        DNI = dni;
        Apellido = apellido;
        Nombre = nombre;
        Mail = mail;
        FechaN = fechaN; 
    }

    public Persona()
    {
        
    }
}
