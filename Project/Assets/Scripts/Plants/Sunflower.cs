using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour {

    [SerializeField] //Time between each sun spawned
    float secondsForSunSpawning = 1;

    [SerializeField] //Sun prefab
    GameObject sun;

    IEnumerator Start(){
        while (true){
            yield return new WaitForSeconds(secondsForSunSpawning);
            // Spawn a sun in a random position near the Sunflower
            GameObject go = Instantiate(sun, transform.position + Vector3.up * Random.Range(0f, 1f) + Vector3.left * Random.Range(-1f, 1f), sun.transform.rotation) as GameObject;
            Destroy(go, 10);
        }
    }
}
