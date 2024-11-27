namespace Proyecto_Pokemon;
/// <summary>
/// interfaz que define las habilidades de los pokemons
/// </summary>
public interface IHabilidades
{
    /// <summary>
    /// nombre de la habilidad
    /// </summary>
    string Nombre { set; get; }
    
    /// <summary>
    /// tipo de la habilidad
    /// </summary>
    ITipo Tipo { set; get; }
    
    /// <summary>
    /// danio que causa la habilidad
    /// </summary>
    int Danio { set; get; }
    
    /// <summary>
    /// precision de la habilidad
    /// </summary>
    int Precision { get; set; }
    
    /// <summary>
    /// Los PP son los puntos de poder, que serian la cantidad de veces que se puede usar una habilidad, o sea que si se quedan sin PP, no se podrá usar de nuevo la habilidad
    /// </summary>
    int Puntos_de_Poder { get; set; }
    
    /// <summary>
    /// indica si la habilidad es de doble turno
    /// </summary>
    bool EsDobleTurno { get; set; }
    
    /// <summary>
    /// efectos que aplica la habilidad
    /// </summary>
    public IEfectos Efectos { get; set; }
}