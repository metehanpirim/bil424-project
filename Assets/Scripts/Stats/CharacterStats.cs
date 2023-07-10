using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int curentHealth { get; private set; }
    public Stat damage;
    public Stat armor;

    void Awake()
    {
        curentHealth = maxHealth;
    }
    void Update()
    {
        
    }
    public void TakeDamage(int damage) {

        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        curentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage);
        if(curentHealth <= 0)
        {
            Die();
        }
           
    }

    public virtual void Die()
    {
        //Die
        Debug.Log(transform.name + " diied ");

    }
}
