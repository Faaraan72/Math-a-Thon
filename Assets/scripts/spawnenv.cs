
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnenv : MonoBehaviour
{
    
    public GameObject[] props;


    private float movespeed = 30f;
    private int i = 0;
    public float instantiationInterval = 1f;
    private void Update()
    {
        if (GameManager.startgame==true && i== 0) {
                StartCoroutine(SpawnObjects()); i++;
        }
           

    }
  
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(instantiationInterval);

            int a = Random.Range(0, props.Length);

            GameObject spawnedclouds = Instantiate(props[a], transform.position, Quaternion.identity);


            StartCoroutine(MoveObjectDown(spawnedclouds));

        }

    }
    IEnumerator MoveObjectDown(GameObject obj)
    {
        while (obj != null && movement.dead ==false)
        {

            obj.transform.Translate(Vector3.back * movespeed * Time.deltaTime);
            if (obj.transform.position.z <= 0)
            {
                Destroy(obj);
            }
            yield return null;
        }
    }

}