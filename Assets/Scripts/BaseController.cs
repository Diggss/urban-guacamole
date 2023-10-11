using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour
{
    [SerializeField] int vida = 10;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Color[] baseColor;
    
    void Awake() {
        sr.color = baseColor[4];
    }
    void FixedUpdate()
    {
        if (vida <= 0) {
            vida = 0;
            SceneManager.LoadScene("Game Over");
        }

        if(vida <= 10 && vida > 8)
            sr.color = baseColor[4];
        else if(vida <= 8 && vida > 6)
            sr.color = baseColor[3];
        else if(vida <= 6 && vida > 4)
            sr.color = baseColor[2];
        else if(vida <= 4 && vida > 2)
            sr.color = baseColor[1];
        else if(vida <= 2 && vida > 0)
            sr.color = baseColor[0];
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy") {
            vida--;
        }
    }

}
