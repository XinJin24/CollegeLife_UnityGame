using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y = -4.3f, max_Y = 4.3f;
    public float center_Y=0.0f;

    public GameObject[] asteroid_Prefabs;
    public GameObject enemyPrefab;
    public GameObject bossPrefab;

    public float timer = 2f;
    public int totalEnemy=20;
    public int counter=0;

    // Start is called before the first frame update
    void Start() {
        Invoke("SpawnEnemies", timer);
    }

    void Update()
    {
        
    }

    void SpawnEnemies() {
        if(counter<totalEnemy)
        {
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;

        if(Random.Range(0, 2) > 0) {

            Instantiate(asteroid_Prefabs[Random.Range(0, asteroid_Prefabs.Length)],
            temp, Quaternion.identity);
            counter+=1;
            
        } else {

            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
            counter+=1;
        }
   
        Debug.Log(counter);
        Invoke("SpawnEnemies", timer);
        }
        else if(counter==totalEnemy)
        {
            Debug.Log("Bosssssssssssssssss");
            Vector3 temp = transform.position;
            temp.y = center_Y;                
            Instantiate(bossPrefab, temp, Quaternion.Euler(0f, 0f, 90f));
        }
    }


}
