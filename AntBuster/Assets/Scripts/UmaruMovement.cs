using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UmaruMovement : MonoBehaviour
{
    private float speed = 3f;
    public int umaruHP = 10;
    public float colorChangeDuration = 0.3f;
    private Color originColor;
    private bool isDead = false;
    private bool isDamaged = false; 
    private Rigidbody2D umaruBody;
    private Renderer umaruColor;
    private Animator animator;
    public GameObject[] coinsPreb;

    // Start is called before the first frame update
    void Start()
    {
        umaruBody = GetComponent<Rigidbody2D>();
        umaruColor = GetComponent<Renderer>();
        originColor = umaruColor.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("DownToRight"))
        {
            umaruBody.velocity = Vector2.right * speed;
        }
        else if (collision.collider.tag.Equals("UpToDown"))
        {
            umaruBody.velocity = Vector2.down * speed;
        }
        else if (collision.collider.tag.Equals("UpToLeft"))
        {
            umaruBody.velocity = Vector2.left * speed;
        }
        else if (collision.collider.tag.Equals("DownToUp"))
        {
            umaruBody.velocity = Vector2.up * speed;
        }
        else if (collision.collider.tag.Equals("Bullet"))
        {
            if (umaruHP > 0)
            {
                StartCoroutine(ChangeColor());
                isDamaged = true;
                animator.SetBool("isDamaged", isDamaged);
                isDamaged = false;
            }
            else
            { 
                isDead = true;
                animator.SetBool("isDead", isDead);
                Dead();
            }
        }
    }

    void Dead()
    {
        if (umaruHP <= 0)
        {
            GameObject coins;
            Destroy(gameObject);
            // sliver 0,1,2 gold 3,4 ruby 5
            int coinNumber = Random.Range(0,6);
            if (coinNumber < 3)
            {
                coins = Instantiate(coinsPreb[coinNumber],
                   gameObject.transform.position, gameObject.transform.rotation);
            }
            else if (coinNumber == 5)
            {
                coins = Instantiate(coinsPreb[coinNumber],
                  gameObject.transform.position, gameObject.transform.rotation);
            }
            else
            {
                coins = Instantiate(coinsPreb[coinNumber],
                   gameObject.transform.position, gameObject.transform.rotation);
            }
        }
    }

    private IEnumerator ChangeColor()
    { 
        umaruColor.material.color = Color.red;
        yield return new WaitForSeconds(colorChangeDuration);
        umaruColor.material.color = originColor;
    }
}
