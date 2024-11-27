namespace Proyecto_Pokemon;
/// <summary>
/// clase que representa los efectos que puede tener una habilidad
/// </summary>
public class Efectos : IEfectos
{
    /// <summary>
    /// nombre del efecto (ejemplo: paralizar, noqueado, etc.)
    /// </summary>
    public string Nombre { get; set; }

    /// <summary>
    /// constructor de efectos que solo usa el nombre para determinar cual efecto se usa despues de usar la habilidad
    /// </summary>
    public Efectos(string nombre)
    {
        Nombre = nombre;
    }
}