using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuy1 : MonoBehaviour
{
    public float speed;
    public float walkTime;

    private float timer;
    public bool WalkRight;

    public int health;
    public int damage;

    private Animator anim;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        damage = PlayerPrefs.GetInt("EnemyDamage");
        health = PlayerPrefs.GetInt("EnemyHealth");
    }



    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer >= walkTime)
        {
            WalkRight = !WalkRight;
            timer = 0f;
        }

        if(WalkRight )
        {
            transform.eulerAngles = new Vector2(0,180);
            rig.linearVelocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.linearVelocity = Vector2.left * speed;
        }
        
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("hit");

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<Player>().damage(damage);
        }
    }
}
