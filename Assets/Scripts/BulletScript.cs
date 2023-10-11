using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Transform target;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void FixedUpdate()
    {
        if(!target) return;

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * speed;
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col) {
        //take health
        //if(col.gameObject.tag == "Enemy")
        Destroy(gameObject);
    }
}
