using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]public int baseValue;
    private List<int> modifiers = new List<int>();
    public int getValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(modifier => finalValue += modifier);
        return finalValue;

    }
    public void addModifiers(int modifier)
    {
        if(modifier != 0)
            modifiers.Add(modifier);
    }
    public void removeModifiers(int modifier) { 
        if(modifier != 0)
            modifiers.Remove(modifier);
    }
}
