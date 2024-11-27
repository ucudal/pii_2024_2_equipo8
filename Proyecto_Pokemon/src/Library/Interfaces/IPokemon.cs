namespace Proyecto_Pokemon;

/******************* ESTA CLASE NO FUE USADA PERO NO FUE BORRADA PORQUE NOS DIÓ MIEDITO *******************/

/// <summary>
/// interfaz que define las operaciones para los pokemons
/// </summary>
public interface IPokemon
{
    /// <summary>
    /// nombre del pokemon
    /// </summary>
    string Nombre { get; }
    /// <summary>
    /// vida del pokemon
    /// </summary>
    int Vida { get; }
    /// <summary>
    /// lista de habilidades que tiene el pokemon
    /// </summary>
    List<IHabilidades> Habilidades { get; }
    /// <summary>
    /// tipo principal del pokemon
    /// </summary>
    ITipo TipoPrincipal { get; }
    /// <summary>
    /// tipo secundario del pokemon
    /// </summary>
    ITipo TipoSecundario { get; }
    /// <summary>
    /// habilidad que esta siendo cargada por el pokemon
    /// </summary>
    IHabilidades HabilidadCargando { get; set; }
    /// <summary>
    /// metodo para aprender una nueva habilidad
    /// </summary>
    void AprenderHabilidad(IHabilidades habilidad);
}