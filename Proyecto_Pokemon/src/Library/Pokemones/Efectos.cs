namespace Proyecto_Pokemon;

public class Efectos : IEfectos
{
    public string Nombre { get; set; }

    // constructor de efectos que solo usa el nombre para determinar cual efecto se usa despues de usar la habilidad
    public Efectos(string nombre)
    {
        Nombre = nombre;
    }
}