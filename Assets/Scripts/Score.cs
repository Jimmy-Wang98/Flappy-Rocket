using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GUISkin tekstOpmaak;
    static int score = 0;
    static int highScore = 0;

    static public void AddPoint()
    {
        score++;
        if (score > highScore)
        {

            highScore = score;
        }

    }

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("highscore", 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highScore);
    }

    private void OnGUI()
    {
        GUI.skin = tekstOpmaak;
        GUI.Label(new Rect(10, 10, 300, 100), "Score: " + score + "\nHigh Score: " + highScore);
    }

    void Update()
    {

 
    }
}