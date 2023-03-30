class persona
{
public int dni{get;set;}
public string apellido{get;set;}
public string nombre{get;set;}
public DateTime fechaN{get;set;}
public string mail{get;set;}

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
}
