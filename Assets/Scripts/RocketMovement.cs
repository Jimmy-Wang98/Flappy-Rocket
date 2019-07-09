using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    float FlySpeed = 450f;
    float forwardSpeed = 5.5f;
    bool didFly = false;
    Animator animator;
    bool dead = false;
    float deathCooldown;

	void Start () {
        animator = transform.GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Didn't find animator!");
        }
	}

    void Update()
    {
        if (dead)
        {
            deathCooldown -= Time.deltaTime;
            if(deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                    Application.LoadLevel(Application.loadedLevel);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFly = true;
        }
    }

    private void FixedUpdate()
    {
        if (dead)
            return;
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
        if (didFly)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * FlySpeed);
            didFly = false;
        }
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }
        else
        {
            float angle = Mathf.Lerp(0, 30, (GetComponent<Rigidbody2D>().velocity.y) / 4f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
        animator.SetTrigger("Death");
        dead = true;
        deathCooldown = 0.5f; ;
        }
}
