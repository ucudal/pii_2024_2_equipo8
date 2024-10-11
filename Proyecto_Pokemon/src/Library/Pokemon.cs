namespace Proyecto_Pokemon;

public class Pokemon : IPokemon
{
    public string Nombre { get; }
    public int Vida { get; set; }
    public List<IHabilidades> Habilidades { get; }
    public ITipo TipoPrincipal { get; }
    public ITipo TipoSecundario { get; }

    public Pokemon(string nombre, int vida, ITipo tipoPrincipal, ITipo tipoSecundario = null)
    {
        Nombre = nombre;
        Vida = vida;
        TipoPrincipal = tipoPrincipal;
        TipoSecundario = tipoSecundario;
        Habilidades = new List<IHabilidades>();
    }

    public void AprenderHabilidad(IHabilidades habilidad)
    {
        Habilidades.Add(habilidad);
    }
    
    public void MostrarHabilidades()
    {
        for (int i = 0; i < Habilidades.Count; i++)
        {
            var habilidad = Habilidades[i];
            Console.WriteLine($"{i + 1}. {habilidad.Nombre} - Daño: {habilidad.Daño}, Precisión: {habilidad.Precision}, Tipo: {habilidad.Tipo.Nombre}, PP: {habilidad.PP}, Doble turno: {habilidad.EsDobleTurno}");
        }
    }

}