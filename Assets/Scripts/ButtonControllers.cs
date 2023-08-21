using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllers : MonoBehaviour
{
    public void startPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void quitPressed()
    {
        Application.Quit();
    }
    public void selectedPhysicist()
    {
        InfoUI.setPlayer("Physicist");
        LoadSceneByName("Physicist");
    }

    public void selectedChemist()
    {
        InfoUI.setPlayer("Chemist");
        LoadSceneByName("Chemist");
    }

    public void selectedBiologist()
    {
        InfoUI.setPlayer("Biologist");
        LoadSceneByName("Biologist");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
