namespace Proyecto_Pokemon;

public class Tipo : ITipo
{
    public string Nombre { get; }

    private Dictionary<string, double> ventaja;

    // constructor de la clase tipo, se usa para darle nombre y una lista de ventajas contra otros tipos
    public Tipo(string nombre, Dictionary<string, double> ventajas)
    {
        Nombre = nombre;
        ventaja = ventajas;
    }

    // metodo para verificar la efectividad de este tipo contra otro tipo.
    // si existe ventaja en el diccionario, la usa, si no, devuelve una efectividad neutral de 1.0
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