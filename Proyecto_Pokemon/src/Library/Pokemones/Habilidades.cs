namespace Proyecto_Pokemon;

public class Habilidades : IHabilidades
{
    /// <summary>
    /// 
    /// </summary>
    public string Nombre { set; get; }
    /// <summary>
    /// 
    /// </summary>
    public ITipo Tipo { set; get; }
    /// <summary>
    /// 
    /// </summary>
    public int Danio { set; get; }
    /// <summary>
    /// 
    /// </summary>
    public int Precision { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int Puntos_de_Poder { get; set; } // Los PP son los puntos de poder, que serian la cantidad de veces que se puede usar una habilidad, o sea que si se quedan sin PP, no se podrá usar de nuevo la habilidad
    /// <summary>
    /// 
    /// </summary>
    public bool EsDobleTurno { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public IEfectos Efectos { get; set; }
    

    // constructor de las habilidades
    /// <summary>
    /// 
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