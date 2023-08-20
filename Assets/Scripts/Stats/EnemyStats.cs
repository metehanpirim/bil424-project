using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{   
    public GameObject cubePrefab;
    public void SpawnObject(){
        Instantiate(cubePrefab,transform.position,Quaternion.identity);
    }
    public override void Die()
    {
        base.Die();
        SpawnObject();
        Destroy(gameObject);
    }
}
