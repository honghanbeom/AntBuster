using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    public GameObject umaruPrefab;
    public GameObject umaru;
    public UmaruMovement UmaruMovement;

    private float spawnTime = 4f;
    private float timeAfterSpawn;
    public int spawnCount = 0;
    private int spawnLimit = 11; //12¸¶¸®
    public int stageCount = 1;
    float nextStageTimer = 5f;
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
        if (timeAfterSpawn >= spawnTime && spawnCount <= spawnLimit)
        {
            GameObject Umaru = Instantiate(umaruPrefab, transform.position, 
                transform.rotation);
            UmaruMovement umaruMovement = Umaru.GetComponent<UmaruMovement>();
            float addHP = 5;
            float addSpeed = 0.3f;
            float updateHP = umaruMovement.umaruHP + addHP * (stageCount - 1);
            float updateSpeed = umaruMovement.speed + addSpeed * (stageCount - 1);

            umaruMovement.UpdateValues(updateHP, updateSpeed);

            //UIManager.instance.umaruMovement.umaruHP = addHP * (stageCount - 1);
            //UIManager.instance.umaruMovement.umaruHP = addSpeed * (stageCount - 1); 
            //UIManager.instance.HP = umaruMovement.umaruHP;
            //UIManager.instance.Speed = umaruMovement.speed;
            timeAfterSpawn = 0f;
            spawnCount++;   
        }
        if (spawnCount == spawnLimit)
        {
            StartCoroutine(WaitForNextStage());
            spawnCount = 0;
            stageCount++;
            nextStageTimer += 5f;
        }

    }

    private IEnumerator WaitForNextStage()
    {
        yield return new WaitForSeconds(nextStageTimer); 
    }
}
