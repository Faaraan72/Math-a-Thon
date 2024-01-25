using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class homepagebuttons : MonoBehaviour
{
    public GameObject parentpannel;
    public GameObject settingspannel;
 public void settings()
    {
        parentpannel.SetActive(true);
        settingspannel.SetActive(true);

    }
    public void cross()
    {
        parentpannel.SetActive(false);
        
    }
}
