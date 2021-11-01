using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pea : MonoBehaviour {

    public int speed = 10;
    public int damage = 1;

    // Move Pea to the right of the screen
    void FixedUpdate(){
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
