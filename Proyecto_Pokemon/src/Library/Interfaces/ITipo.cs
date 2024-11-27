namespace Proyecto_Pokemon;
/// <summary>
/// interfaz que define las operaciones para los tipos de los pokemon
/// </summary>
public interface ITipo
{
    /// <summary>
    /// nombre del tipo de pokemon
    /// </summary>
    string Nombre { get; }
    /// <summary>
    /// metodo que calcula si el tipo es efectivo o poco efectivo contra otro tipo de pokemon
    /// </summary>
    double EsEfectivoOPocoEfectivo(ITipo otroTipo);
}