namespace Proyecto_Pokemon;

public interface IHabilidades
{
    string Nombre { set; get; }
    ITipo Tipo { set; get; }
    int Daño { set; get; }
    int Precision { get; set; }
    int PP { get; set; }
    bool EsDobleTurno { get; set; }
    
}