using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : MonoBehaviour
{

    public float bulletspeed = 7f;
    public GameObject umaru;
    public GameObject pistol;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        umaru = FindObjectOfType<UmaruMovement>().gameObject;
        pistol = FindObjectOfType<Pistol>().gameObject;
        rigidBody = GetComponent<Rigidbody2D>();
        if (umaru != null)
        { 
            BulletMove();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void BulletMove()
    {
        Vector3 target = (umaru.transform.position - transform.position).normalized;
        rigidBody.velocity = target * bulletspeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Umaru")
        {
            int damage = pistol.GetComponent<Pistol>().damage;
            umaru.GetComponent<UmaruMovement>().TakeDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
