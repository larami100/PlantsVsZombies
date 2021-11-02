# PlantsVsZombies
Plants vs Zombies Unity clone

Unity version: 2021.1.26f1

El juego consiste en impedir que un zombie llegue a la casa que se encuentra a la izquierda de la pantalla. Para eso se colocan plantas en el tablero del juego (el pasto que está enfrente de la casa). En cuanto se colocan, las plantas comienzan a disparar chícharos a los zombies para destruirlos.

Las plantas que se pueden escoger para colocar en el pasto son las que se muestran en el deck de la parte de arriba. Para colocarlas en el pasto, primero se debe dar click en la carta y después en la posición del pasto donde se quiera colocar.

Para poder colocar plantas en el pasto, se debe de contar con la suficiente cantidad de soles que cuesta cada planta. En este momento, los soles sólo los puede generar la planta Sunflower.

La velocidad y vida tanto de la planta como del Zombie se pueden modificar en el Editor de Unity.

Las plantas que aparecen en el deck y la manera en la que aparecen los zombies en el juego se establece en el archivo levels.json
En el archivo, para la parte de los zombies se establece la fila en la que se colocará el zombie (0 es la más arriba de la pantalla, 4 la más baja), el tiempo de espera entre un zombie y otro para colocarlo y el nombre del Prefab del zombie que se colocará. Para las plantas se escribe el nombre del Prefab de las planta que se quiere colocar en el deck.

Tipos de zombies disponibles: Zombie, ConeZombie y BucketHeadZombie
Tipos de plantas disponibles: PeaShooter, Repeater y Sunflower

Las imágenes y animaciones se crearon tomando de base los archivos de la página https://plantsvszombies.fandom.com/wiki/Plants_vs._Zombies_Online/Gallery/Assets

Cada GIF se descompuso en imágenes consecutivas en la página https://ezgif.com/split

Y después cada imagen se redujo de tamaño con la página https://www.iloveimg.com/resize-image


Esta es una breve descripción de la ejecución del juego:

<img width="381" alt="FlowChart" src="https://user-images.githubusercontent.com/9325600/139775205-c23f2d2d-9a76-4341-8347-94af6490bb23.png">

Y este es un diagrama de las clases:

<img width="812" alt="ClassesChart" src="https://user-images.githubusercontent.com/9325600/139775151-4a816980-d23b-4643-a085-8ccefef22d90.png">


