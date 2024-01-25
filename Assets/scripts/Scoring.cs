using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    public Text scoretext;
    public Text highscoretext;

    public static int points;
    public AudioClip highScoreAudio;
    public AudioSource sfxaudiosource;
    int AudioPlayed = 0;
    private static int highScore = 0;
    private string highScoreKey = "HighScore";
    // Update is called once per frame
    private void Start()
    {
        points = 0;
        AudioPlayed = 0;
        LoadHighScore();
       // PlayerPrefs.SetInt(highScoreKey, 20);
    }
    void Update()
    {
        scoretext.text = "Score:" + points;
        highscoretext.text = "HighScore:" + highScore; ;

        if (points > highScore)
        {
            highScore = points; //sfxaudiosource.PlayOneShot(highScoreAudio);
            SaveHighScore();
        }
        if(points == highScore && AudioPlayed ==0)
        {
            sfxaudiosource.PlayOneShot(highScoreAudio);
            AudioPlayed++;
        }
    

}
private void LoadHighScore()
    {
       
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }
    private void SaveHighScore()
    {
        
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();
    }
}
