using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public void LaadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void StopSpel()
    {
        Application.Quit();
    }
}
