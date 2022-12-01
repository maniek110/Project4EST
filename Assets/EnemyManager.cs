using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> EnemyPrefab = new List<GameObject>();

    public float RateOfSpawn = 1;

    private float nextSpawn = 0;

    private List<GameObject> enemyList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + RateOfSpawn;
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            GameObject obj = GameObject.Instantiate(GetEnemy());
            obj.transform.position = rndPosWithin;
            obj.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); 
        }
    }
    private GameObject GetEnemy()
    {
        if (enemyList.Count == 0)
        {
            GameObject enemy = GameObject.Instantiate(GetRandomEnemyGameobject());
            enemyList.Add(enemy);
            return enemy;
        }
        else
        {
            GameObject enemy = null;
            foreach (GameObject gameObject in enemyList)
            {
                if (gameObject.active == false)
                {
                    enemy = gameObject;
                }
            }
            if (enemy != null)
            {
                enemy.SetActive(true);
                return enemy;
            }

            enemy = GameObject.Instantiate(GetRandomEnemyGameobject());
            enemyList.Add(enemy);
            return enemy;
        }
    }
    public GameObject GetRandomEnemyGameobject()
    {
        return EnemyPrefab[Random.Range(0, EnemyPrefab.Count-1)];
    }
}

