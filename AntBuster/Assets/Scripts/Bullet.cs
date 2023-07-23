using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform target;
    public float bulletspeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();       
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void Shoot()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else 
        { 
        
        
        }

    }
}
