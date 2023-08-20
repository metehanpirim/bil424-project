using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour

{
    public GameObject cubePrefab;
    public void SpawnObject(){
        Instantiate(cubePrefab,transform.position,Quaternion.identity);
    }
        
    
}
