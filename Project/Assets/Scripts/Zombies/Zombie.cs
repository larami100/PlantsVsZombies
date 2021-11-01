using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    [SerializeField] //Times which Zombie could be shot by a pea before being destroyed
    int lives = 4;

    [SerializeField] // Zombie Movement speed 
    float speed;

    [SerializeField] // Layer where Plants reside
    LayerMask plantLayer;

    static int totalZombies = 0; // Total zombies spawned in the level

    [SerializeField] // Time between each Bite function call
    float timeForBite = 1f;

    float timeForBiteTemp = 0; // Auxiliary variable to handle bite time

    // Set total zombies of each level
    public static void SetTotalZombies(int total){
        totalZombies = total;
    }

    void FixedUpdate(){
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, .5f, plantLayer);
        if (hit.collider != null){ // If a Plant is in front of the Zombie, call Bite function
            timeForBiteTemp += Time.deltaTime;
            if (timeForBiteTemp >= timeForBite){
                timeForBiteTemp = 0;
                hit.collider.SendMessage("Bite");
            }
        }
        else { // If any plant is in front of the Zombie, walk to the left
            timeForBiteTemp = 0;
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        // If a Pea touches the Zombie, decrease live and destroy it when it gets to 0.
        // If any zombie is left, display Win message
        if (collider.CompareTag("Pea")){
            lives--;
            Destroy(collider.gameObject);
            if (lives <= 0){
                Destroy(gameObject);
                totalZombies--;
                if(totalZombies == 0){
                    GameObject.FindObjectOfType<Level>().SetWin();
                }
            }
        } // If a Zombie reaches the house, display lose message
        if (collider.CompareTag("LoseState")){
            Destroy(gameObject);
            GameObject.FindObjectOfType<Level>().SetLose();
        }
    }
}
