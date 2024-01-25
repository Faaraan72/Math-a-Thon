using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diffculty_selector : MonoBehaviour
{
    public static float game_speed;
    public static bool enemies_enabled = false;
    public void easy()
    {
        game_speed = 4;
    }
    public void medium()
    {
        game_speed = 3;
    }
    public void hard()
    {
        game_speed = 2;
    }
    public void expert()
    {
        game_speed = 2;
        enemies_enabled = true;
    }
}
