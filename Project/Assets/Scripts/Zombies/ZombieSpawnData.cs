// Normal class to store zombie kind, time and position where it is going to be spawned.
public class ZombieSpawnData{
    public string zombie { get; private set; }
    public int time { get; private set; }
    public int position { get; private set; }

    public ZombieSpawnData(string zombie, int time, int position){
        this.zombie = zombie;
        this.time = time;
        this.position = position;
    }
}
