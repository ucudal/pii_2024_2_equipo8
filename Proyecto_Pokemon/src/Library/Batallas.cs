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

        public Batallas(Entrenadores entrenador1, Entrenadores entrenador2)
        {
            this.entrenador1 = entrenador1;
            this.entrenador2 = entrenador2;
            pokemonActivo1 = entrenador1.Pokemones[0];
            pokemonActivo2 = entrenador2.Pokemones[0];
            entrenadorActual = entrenador1;
            turno = 1;
        }

        public void Iniciar()
        {
            entrenador1.EnBatalla = true;
            entrenador2.EnBatalla = true;
        }

        public void CambiarTurno()
        {
            entrenadorActual = entrenadorActual == entrenador1 ? entrenador2 : entrenador1;
            turno++;
        }

        public string VerVida()
        {
            string vidaPokemones = "";
            vidaPokemones += $"{entrenador1.Nombre}:\n{entrenador1.MostrarPokemones()}\n";
            vidaPokemones += $"{entrenador2.Nombre}:\n{entrenador2.MostrarPokemones()}\n";
            return vidaPokemones;
        }
    }
}