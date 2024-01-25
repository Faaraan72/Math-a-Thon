
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spawnanswer : MonoBehaviour
{

    public GameObject answercube;
    private int i = 0;
    
    private float movespeed = 50f;
    int a;
    private float instantiationInterval = 3f;
    private void Start()
    {
        instantiationInterval = diffculty_selector.game_speed;
        if (gameObject.name == "4") { a = 0; } else { a = 1; }
    }
    private void Update()
    {
        if(GameManager.startgame==true && i == 0) { StartCoroutine(SpawnObjects()); i++; }
       

    }

    IEnumerator SpawnObjects()
    {
        while (true)

        {

            yield return new WaitForSeconds(instantiationInterval);

          //GameObject anscube = (GameObject)Resources.Load("prefabs/cube", typeof(GameObject));
            GameObject cube = Instantiate(answercube, transform.position, Quaternion.identity);
            if (questionGen.selected == 0) { if (a == 0) { setRandomnumber(cube); } else { setanswertext(cube); } }
            if(questionGen.selected == 1) { if (a == 1) { setRandomnumber(cube); } else { setanswertext(cube); } }
            //gettextobject(cube);
            StartCoroutine(MoveObjectDown(cube));

        }

    }
    IEnumerator MoveObjectDown(GameObject obj)
    {
        while (obj != null && movement.dead == false)
        {

            obj.transform.Translate(Vector3.back * movespeed * Time.deltaTime);
            if (obj.transform.position.z < -10)
            {
                Destroy(obj);
            }
            yield return null;
        }
    }
    private void setanswertext(GameObject g)
    {
       // Debug.Log("getting text!------------------------->");
        Text t = g.GetComponentInChildren<Text>();
       // if (t == null) { Debug.Log("404"); }
        t.text = ""+ questionGen.answer;
        g.tag = "correctanswer";
    }
    private void setRandomnumber(GameObject g)
    {
        Text t = g.GetComponentInChildren<Text>();
        t.text = "" + generateRandom();
        g.tag = "enemy";
    }
   private int generateRandom()
    {
        int number;
        int a = Random.Range(0, 2);
        if (a == 0) { number = questionGen.answer + 1; } else { number = questionGen.answer - 1; }
        return number;
    }

}
