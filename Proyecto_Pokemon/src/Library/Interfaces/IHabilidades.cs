namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public interface IHabilidades
{
    /// <summary>
    /// 
    /// </summary>
    string Nombre { set; get; }
    /// <summary>
    /// 
    /// </summary>
    ITipo Tipo { set; get; }
    /// <summary>
    /// 
    /// </summary>
    int Danio { set; get; }
    /// <summary>
    /// 
    /// </summary>
    int Precision { get; set; }
    /// <summary>
    /// 
    /// </summary>
    int Puntos_de_Poder { get; set; }
    /// <summary>
    /// 
    /// </summary>
    bool EsDobleTurno { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public IEfectos Efectos { get; set; }
    
}