namespace Proyecto_Pokemon;

public class Pokemon
{
    public string Nombre { get; }
    public int Vida { get; set; }
    public int VidaBase { get; set; }
    public List<IHabilidades> Habilidades { get; }
    public ITipo TipoPrincipal { get; }
    public ITipo TipoSecundario { get; }
    public IHabilidades HabilidadCargando { get; set; }
    public string Estado { get; set; }

    public Pokemon(string nombre, int vida, ITipo tipoPrincipal, ITipo tipoSecundario = null, string estado = null)
    {
        Nombre = nombre;
        Vida = vida;
        VidaBase = Vida;
        TipoPrincipal = tipoPrincipal;
        TipoSecundario = tipoSecundario;
        Habilidades = new List<IHabilidades>();
        HabilidadCargando = null;
        Estado = estado;
    }
    
    // metodo que permite al pokemon aprender las habilidades
    public void AprenderHabilidad(IHabilidades habilidad)
    {
        Habilidades.Add(habilidad);
    }
    
    // metodo que devuelve una lista con las habilidades del pokemon
    public string MostrarHabilidades()
    {
        string resultado = "";

        for (int i = 0; i < Habilidades.Count; i++)
        {
            var habilidad = Habilidades[i];
            resultado += $"**{i + 1}. {habilidad.Nombre}** | Daño: {habilidad.Danio} | Precisión: {habilidad.Precision} | Tipo: {habilidad.Tipo.Nombre} | PP: {habilidad.Puntos_de_Poder} | Ataque Cargado: *{habilidad.EsDobleTurno}*\n"; // añade cada habilidad a la lista que se va a devolver
        }

        return resultado;
    }
    
    public static string EjecutarAtaque(Pokemon atacante, Pokemon defensor, IHabilidades habilidad, bool esquivo)
    {
        Random random = new Random();
        string mensajeCritico = "";
        string mensajeEstado = "";
        
        if (atacante.Estado == "paralizado" && random.Next(0, 100) < 20)
        {
            Console.WriteLine($"{atacante.Nombre} está paralizado. No se puede mover.");
        }
        
        double efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoPrincipal);
        int danio = (int)(habilidad.Danio * efectividad);

        if (defensor.TipoSecundario != null)
        {
            efectividad = habilidad.Tipo.EsEfectivoOPocoEfectivo(defensor.TipoSecundario);
            danio = (int)(danio * efectividad);
        }

        int probabilidad = random.Next(0, 100);
        int precisionFinal = habilidad.Precision;
        Console.WriteLine(precisionFinal);
        if (esquivo)
        {
            precisionFinal -= 30;
            Console.WriteLine(precisionFinal);
        }

        if (probabilidad <= precisionFinal)
        {
            if (random.Next(0, 100) < 10 && habilidad.EsDobleTurno)
            {
                danio = (int)(danio * 1.2);
                mensajeCritico = "\n¡PIÑA CRÍTICA!";
            }

            defensor.Vida -= danio;
            if (defensor.Vida < 0)
            {
                defensor.Vida = 0;
            }

            if (habilidad.Efectos != null && random.Next(0, 100) < 100 && string.IsNullOrEmpty(defensor.Estado))
            {
                defensor.Estado = habilidad.Efectos.Nombre;
                mensajeEstado = $"\n{defensor.Nombre} ahora está {defensor.Estado}.";
            }
            
            return $"{mensajeCritico} \n{atacante.Nombre} usó {habilidad.Nombre}, causando {danio} puntos de daño. Vida actual de {defensor.Nombre} = {defensor.Vida} / {defensor.VidaBase} {mensajeEstado}";
        }

        return $"\n{atacante.Nombre} falló el ataque.";
    }

}