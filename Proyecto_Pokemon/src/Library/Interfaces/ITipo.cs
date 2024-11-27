namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public interface ITipo
{
    /// <summary>
    /// 
    /// </summary>
    string Nombre { get; }
    /// <summary>
    /// 
    /// </summary>
    double EsEfectivoOPocoEfectivo(ITipo otroTipo);
}