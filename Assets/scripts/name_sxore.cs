using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class name_sxore : MonoBehaviour
{
    public GameObject InputArea;
    public GameObject submitButton;
    public InputField inputfield;
    public Text message;
    private string User;
    int entered = 0;
    
    void Start()
    {
        int i = PlayerPrefs.GetInt("entered");
        if (i == 1)
        {
            message.text = "Hi," + PlayerPrefs.GetString(User) + ".Welcome to Math-A-Thon, lets see your Maths Skills";
            inputfield.enabled = false;
            InputArea.SetActive(false);
            submitButton.SetActive(false);
        }
        
       
    }

    // Update is called once per frame
    public void submit()
    {
        saveusername();
        message.text = "Hi," +PlayerPrefs.GetString(User)+".Welcome to Math-A-Thon, lets see your Maths Skills";
        inputfield.enabled = false;
        InputArea.SetActive(false);
        submitButton.SetActive(false);

    }
   
    private void saveusername()
    {
        entered = 1;
        PlayerPrefs.SetInt("entered", entered);
        PlayerPrefs.SetString(User, inputfield.text);
        PlayerPrefs.Save();
    }
   
}
