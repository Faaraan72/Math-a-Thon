using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject cloudpoints;
    public GameObject[] answerspawnpoints;
    public GameObject[] envpoints;
    public static bool startgame = false;
    public GameObject menupannel;
    public GameObject scorepannel;
   
    

    void Start()
    {
        cloudpoints.SetActive(false);

        answerspawnpoints[0].SetActive(false);
        answerspawnpoints[1].SetActive(false);

        envpoints[0].SetActive(false);
        envpoints[1].SetActive(false);

        startgame = false;
        scorepannel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (startgame)
        {
            cloudpoints.SetActive(true);
            envpoints[0].SetActive(true);
            envpoints[1].SetActive(true);

           


        }
        if (movement.dead == true)
        {
            cloudpoints.SetActive(false);
            answerspawnpoints[0].SetActive(false);
            answerspawnpoints[1].SetActive(false);

            envpoints[0].SetActive(false);
            envpoints[1].SetActive(false);

        }

    }
   
    public void play_levelselected()
    {
        startgame = true;
        menupannel.SetActive(false);
        Invoke(nameof(startscore), 2f);
        Invoke(nameof(startanswer), 2f);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void startscore()
    {
        scorepannel.SetActive(true);
    }
    
    public void startanswer()
    {
        answerspawnpoints[0].SetActive(true);
        answerspawnpoints[1].SetActive(true);
    }
  
}
