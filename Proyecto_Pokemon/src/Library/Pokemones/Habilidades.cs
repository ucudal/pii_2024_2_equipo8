namespace Proyecto_Pokemon;

/// <summary>
/// clase que representa las habilidades en el juego
/// </summary>
public class Habilidades : IHabilidades
{
    /// <summary>
    /// nombre de la habilidad
    /// </summary>
    public string Nombre { set; get; }
    /// <summary>
    /// tipo de la habilidad (agua, fuego, etc.)
    /// </summary>
    public ITipo Tipo { set; get; }
    /// <summary>
    /// daño que causa la habilidad
    /// </summary>
    public int Danio { set; get; }
    /// <summary>
    /// precisión de la habilidad, indica la probabilidad de acierto
    /// </summary>
    public int Precision { get; set; }
    /// <summary>
    /// Los PP son los puntos de poder, que serian la cantidad de veces que se puede usar una habilidad, o sea que si se quedan sin PP, no se podrá usar de nuevo la habilidad
    /// </summary>
    public int Puntos_de_Poder { get; set; }
    /// <summary>
    /// indica si la habilidad ocupa dos turnos para ejecutarse
    /// </summary>
    public bool EsDobleTurno { get; set; }
    /// <summary>
    /// efectos adicionales para los ataques dobles
    /// </summary>
    public IEfectos Efectos { get; set; }
    

    /// <summary>
    /// constructor de las habilidades
    /// </summary>
    public Habilidades(string nombre, ITipo tipo, int danio, int precision, int puntosdepoder, bool esdobleturno, IEfectos efectos = null)
    {
        Nombre = nombre;
        Tipo = tipo;
        Danio = danio;
        Precision = precision;
        Puntos_de_Poder = puntosdepoder;
        EsDobleTurno = esdobleturno;
        Efectos = efectos;
    }
}