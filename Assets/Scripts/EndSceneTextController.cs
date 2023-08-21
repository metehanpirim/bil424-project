using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSceneTextController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string playerName = InfoUI.Player;

        Debug.Log(playerName);
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null)
        {
            TextMeshProUGUI[] textMeshPros = canvas.GetComponentsInChildren<TextMeshProUGUI>();

            foreach (TextMeshProUGUI textMeshPro in textMeshPros)
            {

                if (textMeshPro.name.Contains(playerName))
                    textMeshPro.gameObject.SetActive(true);
                else
                    textMeshPro.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.LogError("No Canvas component found.");
        }

    }
}
