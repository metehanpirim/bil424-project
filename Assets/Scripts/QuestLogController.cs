using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QuestLogController : MonoBehaviour
{
    public GameObject[] Quests;
    public TextMeshProUGUI playerText;

    public TextMeshProUGUI infotext;

    public Sprite yesIcon;
    public Sprite noIcon;

    public int choose;

    public Item[] requiredItems0;
    public Item[] requiredItems1;
    public Item[] requiredItems2;

    public string[] questsForPhysicist = { "Collect Armors", "Kill Skeleton", "Craft Telescope"};
    public string[] questsForPhysicistInfos = {"Collect the all armors including Helmet, Platebody, Plateleg.", "Kill the skeleton.", "Craft a telescope using glass, wood and iron"};
    
    public string[] questsForChemist = { "Collect Armors", "Kill Skeleton", "Craft Soap"};
    public string[] questsForChemistInfos= {"Collect the all armors including Helmet, Platebody, Plateleg.", "Kill the skeleton.", "Craft a soap using ash and animal fat."};

    public string[] questsForBiologist = { "Collect Armors", "Kill Skeleton", "Craft Antibiotic" };
    public string[] questsForBiologistInfos = {"Collect the all armors including Helmet, Platebody, Plateleg.", "Kill the skeleton.", "Craft a antibiotic using water, herbal plants and cooked mushrooms."};
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(playerText.text);
        if(playerText.text == "Player: Physicist")
        {
            choose = 0;
            for(int i = 0; i < 3; i++)
            {
                Quests[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questsForPhysicist[i];
            }
        }
        else if(playerText.text == "Player: Chemist")
        {
            choose = 1;
            for (int i = 0; i < 3; i++)
            {
                Quests[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questsForChemist[i];
            }
        }
        else
        {
            choose = 2;
            for (int i = 0; i < 3; i++)
            {
                Quests[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questsForBiologist[i];
            }
        }
    }
    public void clickedBtn(int i)
    {
        switch (choose)
        {
            case 0:
                infotext.text = questsForPhysicistInfos[i];
                break;
            case 1:
                infotext.text = questsForChemistInfos[i];

                break;
            case 2:
                infotext.text = questsForBiologistInfos[i];
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        bool[] check = { true, false, false };
        switch (choose)
        {
            case 0:
                
                for(int i = 0; i < 3; i++)
                {
                    if (!Inventory.instance.items.Contains(requiredItems0[i]))
                    {
                        check[0] = false;
                    }
                }
                if (check[0])
                {
                    Quests[0].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                if (Inventory.instance.items.Contains(requiredItems0[3]))
                {
                    Quests[1].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                if (Inventory.instance.items.Contains(requiredItems0[4]))
                {
                    Quests[2].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                break;
            case 1:
                for (int i = 0; i < 3; i++)
                {
                    if (!Inventory.instance.items.Contains(requiredItems1[i]))
                    {
                        check[0] = false;
                    }
                }
                if (check[0])
                {
                    Quests[0].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                if (Inventory.instance.items.Contains(requiredItems1[3]))
                {
                    Quests[1].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                if (Inventory.instance.items.Contains(requiredItems1[4]))
                {
                    Quests[2].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                
                break;

            case 2:
                for (int i = 0; i < 3; i++)
                {
                    if (!Inventory.instance.items.Contains(requiredItems2[i]))
                    {
                        check[0] = false;
                    }
                }
                if (check[0])
                {
                    Quests[0].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                if (Inventory.instance.items.Contains(requiredItems2[3]))
                {
                    Quests[1].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                if (Inventory.instance.items.Contains(requiredItems2[4]))
                {
                    Quests[2].transform.GetChild(1).GetComponent<Image>().sprite = yesIcon;
                }
                break;
        }
        bool a = true;
        for(int i = 0; i < 3; i++)
        {
            if (check[i] == false)
            {
                a = false;
                   break;
            }
        }
        if(a == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
