using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    PlayerManager manager;
    CharacterStats myStats;
    private void Start()
    {
        manager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat playercombat = manager.player.GetComponent<CharacterCombat>();
        if (playercombat != null)
        {
            playercombat.Attack(myStats);

        }
    }
}
