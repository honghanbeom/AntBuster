using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Guns : MonoBehaviour 
{
    public int damage;
    public float range;
    public float attackSpeed;
    private float delayTime;

    public GameObject gun;
    public Transform target;
    public GameObject bulletPrefab;
    public Animator animator;


    public void Start()
    {
        gun = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        delayTime = 0f;
    }

    public void Update()
    {
        Attack();
    }

    public void Attack()
    {
        delayTime += Time.deltaTime;
        if (VectorDis(target.transform.position) < range)
        {
            if (delayTime > attackSpeed)
            {
                //isFire = true;
                //Debug.LogFormat("isFire : {0}", isFire);
                //animator.SetBool("isFire1", isFire);
                animator.SetTrigger("isFire");
                GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position,
                    gameObject.transform.rotation);
                delayTime = 0f;

                //animator.ResetTrigger("isFire");

            }

        }
        else
        {
        }
    }

    public float VectorDis(Vector2 position)
    {
        float disVec = Vector2.Distance(position , transform.position);
        return disVec;
    }


}

