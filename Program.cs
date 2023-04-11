using System.Collections.Generic;
using System.Text.RegularExpressions;

List<Persona> listaPersonas = new List<Persona>();
int menu = 0, cantV = 0, iDni = 0, posDNI = -1, edad;
double edadP = 0;
do{
    menu = Funciones.IngresarInt("Ingrese la opcion que quiera ejecutar (1-Cargar una nueva persona, 2-Obtener estadisticas, 3-Buscar persona, 4-Modificar mail de una persona, 5-salir)");
    switch(menu)
    {
        case 1:
            Persona personante = new Persona();
            personante.Nombre = Funciones.IngresarString("Ingrese el nombre de la persona");
            personante.Apellido = Funciones.IngresarString("Ingrese el apellido de la persona");
            personante.DNI = VerificarDNI(listaPersonas, "Ingrese el DNI de la persona");
            personante.FechaN = Funciones.IngresarDateTime("Ingrese la fecha de nacimiento de la persona (yy/mm/dd)");
            personante.Mail = Funciones.IngresarString("Ingrese el mail de la persona");
            listaPersonas.Add(personante); 
        break;
        case 2:
            Console.WriteLine("Cantidad de personas: " + listaPersonas.Count);
            cantV = CalcularVotos(listaPersonas, ref edadP);
            Console.WriteLine("Cantidad de personas habilitadas para votar: " + cantV);
            Console.WriteLine("Edad promedio: " + edadP/listaPersonas.Count);
        break;
        case 3:
            iDni = Funciones.IngresarInt("Ingrese el DNI de la persona que quire buscar");
            posDNI = BuscarPosIngreso(iDni, listaPersonas);
            if(posDNI == -1)
                {
                    Console.WriteLine("No se encuentra el DNI");
                }
            else
            {
                Console.WriteLine("Nombre: " + listaPersonas[posDNI].Nombre);
                Console.WriteLine("Apellido: " + listaPersonas[posDNI].Apellido);
                Console.WriteLine("Mail: " + listaPersonas[posDNI].Mail);
                edad = listaPersonas[posDNI].ObtenerEdad(listaPersonas[posDNI].FechaN);
                Console.WriteLine("Edad: " + edad);
                if (listaPersonas[posDNI].PuedeVolar(edad)) Console.WriteLine("Puede votar");
                else Console.WriteLine("No puede votar"); 
            }
        break;
        case 4:
            iDni = Funciones.IngresarInt("Ingrese el DNI de la persona que quire cambiar el mail");
            posDNI = BuscarPosIngreso(iDni, listaPersonas);
            if(posDNI == -1)
            {
                Console.WriteLine("No se encuentra el DNI");
            }
            else 
            {
                listaPersonas[posDNI].Mail = Funciones.IngresarString("Ingrese el nuevo mail");
            }
        break;
    }
    Console.ReadLine();    
    Console.Clear();
}while(menu!=5);

static int VerificarDNI(List<Persona> lista, string txt)
{
    int devolver, i = 0;
    bool repetido = false;
    do
    {
        devolver = Funciones.IngresarInt(txt);
        if (lista.Count > 0)
        {
            do
            {
                if(devolver == lista[i].DNI)
                {
                    repetido = true;
                }
                else i++;
            } while(!repetido && i > lista.Count);  
        }      
    } while(repetido);
    return devolver;
}

/*static string VerificarMail(string txt)
{
    string devolver = "", cosa = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
    do
    {
        devolver = Funciones.IngresarString(txt);
    } while(!(Regex.IsMatch(devolver, cosa) && Regex.Replace(devolver, cosa, string.Empty).Length == 0));
    return devolver;
}*/

static int CalcularVotos(List<Persona> lista, ref double edadP)
{
    int devolver = 0, edad = 0;
    edadP = 0;
    foreach(Persona i in lista)
    {
        edad = i.ObtenerEdad(i.FechaN);
        if(edad>0 && edad < 120) edadP += edad;
        if(i.PuedeVolar(edad))
        {
            devolver++;
        }
    }
    return devolver;
}

static int BuscarPosIngreso(int idni, List<Persona> lista)
        {
            int devolver = -1;
            int i = 0;
            while (i < lista.Count && devolver == -1)
            {
                if (idni == lista[i].DNI)
                {
                    devolver = i;
                }
                else { i++; }
            }
            return devolver;
        }