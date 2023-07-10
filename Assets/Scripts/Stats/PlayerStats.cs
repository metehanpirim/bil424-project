using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }
    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(oldItem != null)
        {
            armor.removeModifiers(oldItem.armorModifier);
            damage.removeModifiers(oldItem.damageModifier);
        }
        if(newItem != null)
        {
            armor.addModifiers(newItem.armorModifier);
            damage.addModifiers(newItem.damageModifier);
        }



    }
    public override void Die()
    {
        base.Die();
        //kill
        PlayerManager.instance.Kill();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
