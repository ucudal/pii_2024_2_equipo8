namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public class Efectos : IEfectos
{
    /// <summary>
    /// 
    /// </summary>
    public string Nombre { get; set; }

    // constructor de efectos que solo usa el nombre para determinar cual efecto se usa despues de usar la habilidad
    /// <summary>
    /// 
    /// </summary>
    public Efectos(string nombre)
    {
        Nombre = nombre;
    }
}