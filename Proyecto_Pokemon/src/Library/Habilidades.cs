namespace Proyecto_Pokemon;

public class Habilidades : IHabilidades
{
    public string Nombre { set; get; }
    public ITipo Tipo { set; get; }
    public int Daño { set; get; }
    public int Precision { get; set; }
    public int PP { get; set; }
    public bool EsDobleTurno { get; set; }

    public Habilidades(string nombre, ITipo tipo, int daño, int precision, int pp, bool esdobleturno)
    {
        Nombre = nombre;
        Tipo = tipo;
        Daño = daño;
        Precision = precision;
        PP = pp;
        EsDobleTurno = esdobleturno;
    }
}