
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
    public Transform cloudpoint;
    public GameObject[] cloudprefabs;
    
    
    private float movespeed = 100f;
   
    public float instantiationInterval = 1f;
    private void Start()
    {
        StartCoroutine(SpawnObjects());
       

    }
    IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(instantiationInterval);
           
            int a = Random.Range(0, cloudprefabs.Length);

            GameObject spawnedclouds = Instantiate(cloudprefabs[a], cloudpoint.position, Quaternion.identity);

                
            StartCoroutine(MoveObjectLeft(spawnedclouds)); 
        
        }

    }
    IEnumerator MoveObjectLeft(GameObject obj)
    {
        while (obj != null && movement.dead == false)
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