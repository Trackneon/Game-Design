using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform enemyObj;
    public Transform spawnLocation;
    public float frequency = 6f;
    private float count = 2f;

    private int waveNum = 0;

    void Update()
    {
        if (count <= 0f)
        {
            StartCoroutine(Wave());
            count = frequency;
        }

        count -= Time.deltaTime;
    }

    IEnumerator Wave()
    {
        waveNum++;

        for (int i = 0; i < waveNum; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

    }

    void SpawnEnemy()
    {
        Instantiate(enemyObj, spawnLocation.position, spawnLocation.rotation);
        
    }

}
