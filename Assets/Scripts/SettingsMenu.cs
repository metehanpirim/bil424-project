using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
public class SettingsMenu : MonoBehaviour
{
    public TextMeshProUGUI difficulty;
    public GameObject settingsUI;
    public int choose = 0;
    public PlayerStats stats;
    public EnemyStats enemyStats;
    public NavMeshAgent enemyAgent;
    public Button easy;
    public Button med;
    public Button hard;
    // Start is called before the first frame update
    void Start()
    {
        settingsUI.SetActive(false);
    }
    void Update()
    {
        
        switch(choose)
        {
            case 0:
                easy.interactable = false;
                med.interactable = true;
                hard.interactable = true;
                difficulty.text = "Difficulty: Easy";
                break;
            case 1:
                easy.interactable = true;
                med.interactable = false;
                hard.interactable = true;
                difficulty.text = "Difficulty: Medium";
                break;
            case 2:
                easy.interactable = true;
                med.interactable = true;
                hard.interactable = false;
                difficulty.text = "Difficulty: Hard";
                break;
        }
    }
    // Update is called once per frame
    public void changeDifficulty(int difficulty)
    {
        switch(difficulty)
        {
            case 0:
                stats.maxHealth = 150;
                stats.armor.baseValue = 2;
                enemyStats.maxHealth = 80;
                enemyStats.damage.baseValue = 10;
                enemyAgent.speed = 2.9f;
                choose = 0;
                break;
            case 1:
                stats.maxHealth = 120;
                stats.armor.baseValue = 1;
                enemyStats.maxHealth = 100;
                enemyStats.damage.baseValue = 15;
                enemyAgent.speed = 3.4f;
                choose = 1;
                break;
            case 2:
                stats.maxHealth = 100;
                stats.armor.baseValue = 0;
                enemyStats.maxHealth = 120;
                enemyStats.damage.baseValue = 20;
                enemyAgent.speed = 4.1f;
                choose = 2;
                break;
        }
    }

    public void changeMedium()
    {
        changeDifficulty(1);
    }
    public void changeHard()
    {
        changeDifficulty(2);
    }
    public void changeEasy()
    {
        changeDifficulty(0);
    }
    public void close()
    {
        settingsUI.SetActive(false);
    }
}
