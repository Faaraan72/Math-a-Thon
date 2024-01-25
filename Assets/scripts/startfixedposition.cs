using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class startfixedposition : MonoBehaviour
{

    public Button playbutton;
    public Button cross;
    public Text title;
    void Start()
    {
        playbutton.transform.position = new Vector3(300, 300, 0);
      //title.rectTransform.position = new Vector3(0, -200, 0);
        cross.transform.position = new Vector3(1000,2250, 0);
    }
    private void Update()
    {
       // title.rectTransform.position = new Vector3(0, -200, 0);
    }


}
