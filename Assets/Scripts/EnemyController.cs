using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float vel = 2f;
	[SerializeField] int vida = 3;

    void Start()
    {
        
    }

	void Update() {
		transform.Translate(Vector3.left * vel * Time.deltaTime);

		if(vida < 0)
		{
			vida = 0;
			Destroyed();
		}

	}

	void Destroyed(){
		EnemySpawner.onEnemyDestroy.Invoke();
		Destroy(gameObject);
	}

    void OnTriggerEnter2D(Collider2D col) {
		if(col.gameObject.tag == "Bullet")
			vida--;
		if(col.gameObject.tag == "Base")
			Destroyed();
	}
}