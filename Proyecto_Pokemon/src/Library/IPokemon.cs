namespace Proyecto_Pokemon;

public interface IPokemon
{
    string Nombre { get; }
    int Vida { get; }
    List<IHabilidades> Habilidades { get; }
    ITipo TipoPrincipal { get; }
    ITipo TipoSecundario { get; }
    void AprenderHabilidad(IHabilidades habilidad);
}