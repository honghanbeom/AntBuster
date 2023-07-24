using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject umaruPrefab;
    private float spawnTime = 4f;
    private float timeAfterSpawn;
    public int spawnCount = 0;
    private int spawnLimit = 12;
    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();        
    }

    void Spawn()
    {
        timeAfterSpawn += Time.deltaTime;
        if (timeAfterSpawn >= spawnTime && spawnCount < spawnLimit)
        {
            GameObject Umaru = Instantiate(umaruPrefab, transform.position, transform.rotation);
            timeAfterSpawn = 0f;
            spawnCount++;   
        }
    }
}
