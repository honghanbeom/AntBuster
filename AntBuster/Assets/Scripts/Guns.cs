using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour 
{
    public float damages;
    public float range;
    public float attackSpeed;
    private float delayTime;

    public GameObject gun;
    public GameObject umaru;
    public GameObject bulletPrefab;
    public Animator animator;

    private bool isFire = false;

    public void Start()
    {
        gun = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        umaru = GameObject.Find("NormalUmaru");
        delayTime = 0f;
    }

    public void Update()
    {
        Attack();
    }

    public void Attack()
    {
        delayTime += Time.deltaTime;
        if (VectorDis(umaru.transform.position) < range)
        {
            if (delayTime > attackSpeed)
            {
                isFire = true;
                animator.SetBool("isFire", isFire);
                GameObject gunFire = Instantiate(bulletPrefab, gameObject.transform.position,
                    gameObject.transform.rotation);

                Bullet bullet = gunFire.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.SetTarget(umaru.transform);
                }
                delayTime = 0f;
            }

        }
        else { isFire = false; }

    }

    public float VectorDis(Vector2 position)
    {
        float disVec = Vector2.Distance(position , transform.position);

        return disVec;
    }
}

