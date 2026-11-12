using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMenu : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    public bool isStopped;
    public bool WalkRight;
    public float walkTime;
    public float idleTimeMax;

    private float timer;
    private float idleTime;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= walkTime && !isStopped)
        {
            WalkRight = !WalkRight;
            anim.SetInteger("Iddle", 0);
            timer = 0f;
            isStopped = true;
        }
        if (WalkRight && !isStopped)
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.linearVelocity = Vector2.right * speed;
        }
        if (!WalkRight && !isStopped)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.linearVelocity = Vector2.left * speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isStopped && idleTime >= idleTimeMax)
        {
            rig.linearVelocity = Vector2.zero;
            anim.SetInteger("Iddle", 1);
        }
        idleTime += Time.deltaTime;
        if (idleTime >= idleTimeMax + 1f)
        {
            idleTime = 0;
            isStopped = false;
            anim.SetInteger("Iddle", 0);
        }
    }
}
