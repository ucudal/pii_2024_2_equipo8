namespace Proyecto_Pokemon;
/// <summary>
/// Clase que representa un tipo de pokemon, como agua, fuego o planta.
/// Almacena ventajas y desventajas frente a otros tipos.
/// </summary>
public class Tipo : ITipo
{
    /// <summary>
    /// Define el nombre del tipo
    /// </summary>
    public string Nombre { get; }

    private Dictionary<string, double> ventaja;

    /// <summary>
    /// constructor de la clase tipo, se usa para darle nombre y una lista de ventajas contra otros tipos
    /// </summary>
    public Tipo(string nombre, Dictionary<string, double> ventajas)
    {
        Nombre = nombre;
        ventaja = ventajas;
    }
    
    /// <summary>
    /// metodo para verificar la efectividad de este tipo contra otro tipo.
    /// si existe ventaja en el diccionario, la usa, si no, devuelve una efectividad neutral de 1.0
    /// </summary>
    public double EsEfectivoOPocoEfectivo(ITipo otroTipo)
    {
        string nombreDelOtroElemento = otroTipo.Nombre;
        bool existeVentaja = ventaja.ContainsKey(nombreDelOtroElemento);
        double efectividad;
        if (existeVentaja)
        {
            efectividad = ventaja[nombreDelOtroElemento];
        }
        else
        {
            efectividad = 1.0;
        }
        return efectividad;
    }
}