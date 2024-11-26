**LA BATALLA POKEMON
Por Equipo DR. NEFARIO.**

El proyecto de simulación de una batalla Pokémon en C# fue toda una experiencia, que más allá de todos los retos técnicos que tuvimos, nos obligó a ver las cosas de una forma distinta como programadores, pero, sobre todo, como equipo. Al principio, cuando vimos que ganó la batalla Pokemon en la votación, ya vimos que venía un desafío ambicioso, donde todo el sistema de peleas, tabla de tipos, objetos, estados, ataques, etc, tenía que verse reflejado en nuestra entrega final. El proyecto se dividió en tres hitos principales, y cada uno nos llevó a ver nuevas formas de colaborar, aprender y superar obstáculos.

**El inicio: investigación**
El primer hito fueron los cimientos de todo, ya que comenzamos con una lluvia de ideas donde cada uno aportó su perspectiva sobre lo que debía incluirse en la simulación. Queríamos recrear lo esencial de una batalla Pokemon, pero sin perdernos en detalles innecesarios. Decidimos simplificar las mecánicas: descartamos la captura de Pokemon y la compra de objetos, y nos enfocamos en lo que realmente define estos combates: los ataques, los cambios de Pokémon y la estrategia basada en los tipos.
El primer reto fue conceptualizar y modelar el sistema de batalla, siendo clave usar la programación orientada a objetos (POO) para estructurar nuestras ideas. Diseñamos clases para representar a los Pokemon, sus habilidades, los entrenadores y los tipos. Las interfaces jugaron un papel importante, ya que nos permitió crear orden en los diferentes aspectos a la hora de recrear una batalla, teniendo una interface para los entrenadores, tipos y habilidades. También aprovechamos el uso de instancias para representar los diferentes Pokémon y habilidades en el juego, asegurándonos de que cada elemento tuviera su propio comportamiento y atributos únicos.
Otra cosa compleja fue implementar una mecánica especial: las habilidades de dos turnos. Fue todo un reto conceptualizar cómo un ataque como "Hidrobomba" o una acción como "Esquivar" influiría en el flujo de batalla, aprendiendo sobre lo importante que es manejar estados dentro del programa, registrando cuándo un Pokémon estaba "cargando" su habilidad y cómo eso afectaba el turno siguiente. Fue muy difícil hacerlo, pero se logró, y ya todo arrancaba a tomar forma en el código.

**Segunda entrega: cambios**
Para la segunda entrega, las cosas se complicaron. Aunque el primer hito nos dejó con una base sólida, el entusiasmo inicial empezó a bajar, y tuvimos que enfrentarnos a una realidad común en los proyectos de equipo: la coordinación no siempre es perfecta. Tuvimos diferencias en la forma de abordar ciertas funciones, y algunos de nosotros, quizás por falta de comunicación, bajamos un poco el nivel en cuanto a la calidad del código y los avances.
En este punto, la implementación de los diccionarios para manejar la efectividad de los tipos se convirtió en un obstáculo inesperado. Aunque parecía algo sencillo al principio, nos dimos cuenta de que hacerlo dinámico y escalable requería mucho tiempo, y era algo que no teníamos de sobremanera. También surgieron problemas con la lógica detrás del cambio de Pokémon, ya que cómo podíamos garantizar que el sistema iba a reconocer a los Pokemones debilitados y permitiera elegir otro sin romper el flujo de la batalla?
Sin embargo, todos estos aspectos, hicieron que nos diéramos cuenta de la complejidad del proyecto, y también, de nuestra forma de organizarnos. Empezamos a tener reuniones más frecuentes, definimos roles específicos y nos aseguramos de que cada entrega parcial tuviera objetivos claros, dejando toda la carne sobre el asador para la última entrega (me encanta esa frase).

**Última entrega: cierre del proyecto**
Para el último hito, volvimos a apuntar alto y nos metimos de lleno en el proyecto. Sabíamos que el proyecto no solo sería evaluado por su funcionalidad, sino también por su calidad técnica y diseño. Por eso, dedicamos tiempo a pulir detalles que antes habíamos dejado de lado, como el manejo de excepciones, el diseño de interfaces claras y la optimización del código.
Una de las decisiones más acertadas fue implementar el patrón de diseño fachada para simplificar la interacción del usuario con el sistema, lo que nos dejó centralizar la inicialización de datos, la selección de Pokemon y la gestión de batallas en una clase que actuaba como "intermediaria", haciendo que el código fuera más fácil de mantener y extender.
Además, integramos pruebas unitarias para asegurarnos de que cada funcionalidad funcionara como debía. Probar casos como un ataque con ventaja de tipo, un cambio de Pokémon estratégico o la efectividad de "Esquivar" nos hizo comprender la importancia de anticipar errores y mejorar la robustez del programa.

**Reflexión final: lo que aprendimos**
Al final, este proyecto fue una simulación de una batalla Pokemon y una lección sobre trabajo en equipo, resolución de problemas y adaptación. Aprendimos que la programación no es solo técnica, sino también comunicación: entender las ideas de otros, negociar soluciones y apoyarnos cuando las cosas se complican.
Técnicamente, ganamos experiencia en conceptos clave como POO, herencia, uso de instancias y patrones de diseño. También entendimos la importancia de planificar antes de codificar, dividir las tareas de manera equitativa y mantener una visión clara de los objetivos a largo plazo.
Lo más valioso fue ver cómo, a pesar de los altibajos, logramos un producto que nos enorgullece. Como equipo, salimos fortalecidos, y cada uno aportó algo único al proyecto. En retrospectiva, este trabajo nos demostró que, con bastante esfuerzo y colaboración, cualquier idea puede pasar del papel al código.
