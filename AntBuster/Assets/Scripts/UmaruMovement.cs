using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class UmaruMovement : MonoBehaviour
{
    public float speed = 3f;
    public float umaruHP = 10f;

    public float colorChangeDuration = 0.2f;
    public float deadAniDuration = 2f;
    public float coinAniDuration = 4f;
    private Color originColor;
    //private bool isDamaged = false; 
    public Rigidbody2D umaruBody;
    private Renderer umaruColor;
    public Animator animator;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (umaruHP > 0)
            { 
                StartCoroutine(ChangeColor());
            }
            else if (umaruHP <= 0)
            {
                Dead();
            }
        }
    }

    public float TakeDamage(float damage)
    {
        umaruHP -= damage;
        return umaruHP;
    }

    public (float HP, float Speed) UpdateValues(float updateHP, float updateSpeed)
    {
        umaruHP = updateHP;
        speed = updateSpeed;

        return (umaruHP, speed);
    }





    void Dead()
    {
        if (umaruHP <= 0)
        {
            UIManager.instance.score += 50;
            //isDead = true;
            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(DeadAnimation());
            GameObject coins;
            float silverProb = 0.5f;
            float goldProb = 0.3f;
            float rubyProb = 0.2f;

            float randomValue = Random.value;

            if (randomValue < silverProb)
            {
                coins = Instantiate(coinsPreb[0], gameObject.transform.position, 
                    gameObject.transform.rotation);
            }
            else if (randomValue < silverProb + goldProb)
            {
                coins = Instantiate(coinsPreb[2], gameObject.transform.position, 
                    gameObject.transform.rotation);
            }
            else
            {
                coins = Instantiate(coinsPreb[1], gameObject.transform.position,
                    gameObject.transform.rotation);
            }

        }
    }

    private IEnumerator ChangeColor()
    { 
        umaruColor.material.color = Color.red;
        yield return new WaitForSeconds(colorChangeDuration);
        umaruColor.material.color = originColor;
    }

    private IEnumerator DeadAnimation()
    {
        umaruBody.velocity = Vector3.zero;  
        animator.SetTrigger("isDead");
        yield return new WaitForSeconds(deadAniDuration);
        gameObject.SetActive(false);

    }

    //private IEnumerator CoinAnimation()
    //{
    //    yield return new WaitForSeconds(coinAniDuration);
    //    Dead();
    //}
}
