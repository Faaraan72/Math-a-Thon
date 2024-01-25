using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundries : MonoBehaviour
{
    // Start is called before the first frame update
    public static float leftlimit;
    public static float rightlimit;
    public float left=-1f, right=1f;

    void Start()
    {
        leftlimit = left;
        rightlimit = right;
    }


}
