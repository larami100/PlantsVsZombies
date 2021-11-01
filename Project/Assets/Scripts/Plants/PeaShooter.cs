using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : MonoBehaviour {

    [SerializeField] //Time between each pea shot
    float secondsForPeaSpawning = 3;

    [SerializeField] // How many peas are shot at the same time
     int peasToShoot = 1;

    [SerializeField] // Pea prefab
    GameObject pea;

    [SerializeField] // Plant cannon prefab
    Transform cannon;

    [SerializeField] // Layer where all the Zombies reside
    LayerMask layerZombie;

    // Code for Plant to shoot peas after being spawned.
    IEnumerator Start(){
        GameObject[] peas = new GameObject[peasToShoot];
        while (true){
            yield return new WaitForSeconds(secondsForPeaSpawning);
             RaycastHit2D hit = Physics2D.Raycast(cannon.position, Vector3.right, 12, layerZombie);
            //  Peas are only shot if a Zombie is in front of the Plant.
            if (hit.collider != null){
                for (int i = 0; i < peasToShoot; i++){
                    peas[i] = Instantiate(pea, cannon.position, pea.transform.rotation) as GameObject;
                    // Destroy the Pea when it is outside the camera
                    Destroy(peas[i], 10);
                    yield return new WaitForSeconds(.25f);
                }
            }
        }
    }
 }
