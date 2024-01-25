using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class questionGen : MonoBehaviour
{
    public static  int a, b,answer,selected;
    [SerializeField] private Text question;
    [SerializeField] private Text score;
   private void Start()
    {
        answer = 0;
        question.text = "Get into 0";
    }
    private void Update()
    {

        if (movement.answered == true)
        {
            generateadd();
        }
        if (movement.dead == true)
        {
            question.text = "LOL!";
        }
        
    }
    private void generateadd()
    {
        a = Random.Range(1, 10);
        b = Random.Range(1, 10);
        answer = a + b;
        question.text = a + "+" + b + "=?";
        movement.answered = false;
        selected= Random.Range(0, 2);
    }



}
