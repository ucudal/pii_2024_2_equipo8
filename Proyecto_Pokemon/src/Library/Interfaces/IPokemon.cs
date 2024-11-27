namespace Proyecto_Pokemon;
/// <summary>
/// 
/// </summary>
public interface IPokemon
{
    /// <summary>
    /// 
    /// </summary>
    string Nombre { get; }
    /// <summary>
    /// 
    /// </summary>
    int Vida { get; }
    /// <summary>
    /// 
    /// </summary>
    List<IHabilidades> Habilidades { get; }
    /// <summary>
    /// 
    /// </summary>
    ITipo TipoPrincipal { get; }
    /// <summary>
    /// 
    /// </summary>
    ITipo TipoSecundario { get; }
    /// <summary>
    /// 
    /// </summary>
    IHabilidades HabilidadCargando { get; set; }
    /// <summary>
    /// 
    /// </summary>
    void AprenderHabilidad(IHabilidades habilidad);
}