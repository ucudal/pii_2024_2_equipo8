namespace Proyecto_Pokemon
{
    public class Batallas
    {
        public Entrenadores entrenador1;
        public Entrenadores entrenador2;
        public Entrenadores entrenadorActual;
        public Pokemon pokemonActivo1;
        public Pokemon pokemonActivo2;
        private int turno;

        public int Turno
        {
            get => turno;
        }

        // constructor que inicializa entrenadores, pokemones activos y asigna el primer turno al primer entrenador
        public Batallas(Entrenadores entrenador1, Entrenadores entrenador2)
        {
            this.entrenador1 = entrenador1;
            this.entrenador2 = entrenador2;
            pokemonActivo1 = entrenador1.Pokemones[0];
            pokemonActivo2 = entrenador2.Pokemones[0];
            entrenadorActual = entrenador1;
            turno = 1;
        }

        // metodo que marca el inicio de la batalla activando el estado "en batalla" para cada entrenador
        public void Iniciar()
        {
            entrenador1.EnBatalla = true;
            entrenador2.EnBatalla = true;
        }

        // metodo que cambia el turno al otro entrenador y aumenta el contador de turnos
        public void CambiarTurno()
        {
            entrenadorActual = entrenadorActual == entrenador1 ? entrenador2 : entrenador1;
            turno++;
        }

        // metodo que devuelve un string con el estado de vida de los pokemones de cada entrenador
        public string VerVida()
        {
            string vidaPokemones = "";
            vidaPokemones += $"{entrenador1.Nombre}:\n{entrenador1.MostrarPokemones()}\n";
            vidaPokemones += $"{entrenador2.Nombre}:\n{entrenador2.MostrarPokemones()}\n";
            return vidaPokemones;
        }
    }
}