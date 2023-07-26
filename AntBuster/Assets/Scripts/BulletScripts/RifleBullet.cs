using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RifleBullet : MonoBehaviour
{
    // followBullet 스크립트를 3개 만들어서 전부다 따로 적용..
    public float bulletspeed = 5f;
    public GameObject umaru;
    public GameObject rifle;
    private Vector3 targetPosition;



    private void Start()
    {

        umaru = FindObjectOfType<UmaruMovement>().gameObject;
        rifle = FindObjectOfType<Rifle>().gameObject; // shotgun, rifle
        targetPosition = umaru.transform.position;
        if (umaru == null || targetPosition == Vector3.zero)
        {
            Debug.Log("작동중?");
            gameObject.SetActive(false);

            return;
        }
    }


    private void Update()
    {

        if (umaru == null || targetPosition == Vector3.zero)
        {
            gameObject.SetActive(false);

            return;
        }


        BulletMove();

        if (umaru != null)
        {
            targetPosition = umaru.transform.position;
        }

        if (targetPosition != null)
        {
            StartCoroutine(TargetMove());
        }

        Destroy(gameObject, 3f);
    }

    private void BulletMove()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        gameObject.transform.position += direction * bulletspeed * Time.deltaTime;
    }


    IEnumerator TargetMove()
    {
        Vector3 target = (umaru.transform.position - transform.position).normalized;
        while (umaru != null)
        {
            float dot = Vector3.Dot(transform.up, target);
            if (dot < 1.0f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, target);
                transform.rotation = targetRotation;

                #region LEGACY
                //float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                //Vector3 cross = Vector3.Cross(transform.up, target);
                //if (cross.z < 0)
                //{
                //    angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                //}
                //else if (cross.z > 0)
                //{
                //    angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                //}
                //transform.rotation = Quaternion.Euler(0f, 0f, angle);
                #endregion
            }
            yield return new WaitForSeconds(0.04f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Umaru")
        {
            int damage = rifle.GetComponent<Rifle>().damage;
            umaru.GetComponent<UmaruMovement>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
        //if (collision.tag == "DownToRight" || collision.tag == "UpToDown"
        //    || collision.tag == "UpToLeft" || collision.tag == "DownToUp")
        //{ 
        //    Destroy(gameObject);
        //}
    }
}
