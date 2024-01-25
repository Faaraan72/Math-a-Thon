
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spawnenemies : MonoBehaviour
{

    public GameObject[] enemy_prefab;
    private int i = 0;
    public Transform[] enemyspawnpoints;

    private float movespeed = 75f;
    int a;
    private float instantiationInterval = 3f;
    private void Start()
    {
        instantiationInterval = diffculty_selector.game_speed;
        i = 0;
      
    }
    private void Update()
    {
        if (GameManager.startgame == true && i == 0) { StartCoroutine(SpawnObjects()); i++; }
        if (diffculty_selector.enemies_enabled == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
      


    }

    IEnumerator SpawnObjects()
    {
        while (true)

        {
            int b= Random.Range(0, enemy_prefab.Length);
            a = Random.Range(0, enemyspawnpoints.Length);
            GameObject cube = Instantiate(enemy_prefab[b], enemyspawnpoints[a].position, Quaternion.identity);
            StartCoroutine(MoveObjectDown(cube));
            yield return new WaitForSeconds(instantiationInterval);

           

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
   

}
