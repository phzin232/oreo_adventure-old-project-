using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //vida
    public int health = 10;
    public int maxHealth;
    private bool isHealthmax;

    public float speed;
    public float jumpForce =10;
    public float doubleForce = 2;

    public GameObject bow;
    public Transform firePoint;

    private bool isJumping;
    private bool doubleJump;
    private bool isfire;

    //fisica,anima��o
    private Rigidbody2D rig;
    private Animator anim;

    private float movement;

    //som
    public AudioClip soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        health = maxHealth;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        Game_Controller.instance.UpdateLives(health);
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
        maxHealth = PlayerPrefs.GetInt("maxHealth");
        Jump();
        Bowfire();

  
    }

    void FixedUpdate()
    {
        Move();
    }
    //Movemento
    void Move()
    {
        movement = Input.GetAxis("horizontal");

        //add vel ao corpo no eixo x e y
        rig.linearVelocity = new Vector2(movement * speed, rig.linearVelocity.y);

        if (movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector3(0, 180, 0);

        }

        if (movement == 0 && !isJumping && !isfire)
        {
            anim.SetInteger("Transition", 0);
        }
    }
    //Pulo
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = false;
                isJumping = true;
            }
            else
            {
                if (!doubleJump)
                {
                    anim.SetInteger("Transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce * doubleForce), ForceMode2D.Impulse);
                    doubleJump = true;
                }
            }

        }
    }
    //Arco
    void Bowfire()
    {
        
        StartCoroutine("Fire");
        
    }
    //TIro
    IEnumerator Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(soundEffect);
            isfire = true;
            anim.SetInteger("Transition", 3);
            GameObject Bow = Instantiate(bow, firePoint.position, firePoint.rotation);

            if (transform.rotation.y == 0)
            {
                Bow.GetComponent<Bow>().isRIght = true;
            }

            if (transform.rotation.y == 180)
            {
                Bow.GetComponent<Bow>().isRIght = false;
            }

            yield return new WaitForSeconds(1.2f);
            isfire = false;
            anim.SetInteger("Transition", 0);
        }
    }
    //Apenas dois pulo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            isJumping = false;
            doubleJump = false;
        }

        if (collision.gameObject.layer == 9)
        {
            Game_Controller.instance.GameOver();
        }
    }
    //Dano
    public void damage(int dmg)
    {
        health -= dmg;
        Game_Controller.instance.UpdateLives(health);
        anim.SetTrigger("hit");

        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }

        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }

        if (health <= 0)
        {
            Game_Controller.instance.GameOver();

        }


    }
    //Vida
    public void IncreaseLife(int value)
    {
        health += value;
        

        if (health >= maxHealth && isHealthmax)
        {
            health = maxHealth;
            isHealthmax = true;
            Game_Controller.instance.HealthMax();
        }
        else
        {
            isHealthmax = false;
        }
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        Game_Controller.instance.UpdateLives(health);


    }
    }



