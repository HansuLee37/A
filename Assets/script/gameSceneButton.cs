using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameSceneButton : MonoBehaviour {
    public GameObject fire;
    public Transform firePos;
    
    public void shoot()
    {
        Instantiate(fire, firePos.position, firePos.rotation);
    }
}
