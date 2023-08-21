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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
