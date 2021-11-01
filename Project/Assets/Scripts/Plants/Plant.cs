using UnityEngine;

public class Plant: MonoBehaviour{
    public Sprite sprite;
    public int sunPrice;
    public int lives;

    // When a PLant is hit by a Zombie. This function is called.
    void Bite(){
        lives--;
        if (lives <= 0)
            Destroy(gameObject);
    }
}
