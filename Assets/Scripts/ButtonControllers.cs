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
        LoadSceneByName("GameScene");
    }

    public void selectedChemist()
    {
        InfoUI.setPlayer("Chemist");
        LoadSceneByName("GameScene");
    }

    public void selectedBiologist()
    {
        InfoUI.setPlayer("Biologist");
        LoadSceneByName("GameScene");
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
