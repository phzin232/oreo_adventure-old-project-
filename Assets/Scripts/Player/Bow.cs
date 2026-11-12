using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Rigidbody2D rig;
    public float speed;

    public int damage;

    public bool isRIght;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        
        Destroy(gameObject,10);
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRIght) 
        { 
        rig.linearVelocity = Vector2.right * speed;
        }
        else
        {
            rig.linearVelocity = Vector2.left * speed;
        }
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyGuy1>().Damage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }

}
