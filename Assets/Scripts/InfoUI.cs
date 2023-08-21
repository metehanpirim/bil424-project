using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InfoUI : MonoBehaviour
{
    public static string Player;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.text = "Player: " + Player;
    }
    public static void setPlayer(string player)
    {
        Player = player;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
