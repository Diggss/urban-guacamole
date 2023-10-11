using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TurretController : MonoBehaviour
{
	[SerializeField] private float targetingRange = 5f, angle = 0f;
	[SerializeField] private LayerMask enemyMask;	//layer da Unity
	[SerializeField] Vector3 from = new Vector3(33.6500015f,-1548.80005f,0f);
	[SerializeField] GameObject bullet;
	[SerializeField] Transform firingPoint;
	[SerializeField] float bps = 1f; //balas por segundo

	[SerializeField] float tempoDeFogo;

	void OnDrawGizmosSelected() {
		Handles.color = Color.cyan;		
		Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
			//Handles.DrawWireArc(transform.position, transform.forward, from, angle, targetingRange, 1f);
	}

	Transform target;
	
	void Update() {
		if(target == null) {
			FindTarget();
			return;
		}

		if (!CheckTargetIsInRange()) {
			target = null;
		}
		else {
			tempoDeFogo += Time.deltaTime;
			if(tempoDeFogo >= (1f/bps)){ 
				Shoot();
				tempoDeFogo = 0;
			}
		}
	}

	void FindTarget() {
		RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

		if(hits.Length > 0) {
			target = hits[0].transform;
			//Debug.Log("Funfou!!!!!1!");
		}
	}

	bool CheckTargetIsInRange() {
		return Vector2.Distance(target.position, transform.position) <= targetingRange;
	}

	void Shoot() {
		GameObject bulletObj = Instantiate(bullet, firingPoint.position, Quaternion.identity);
		BulletScript bulletScript = bulletObj.GetComponent<BulletScript>();
		bulletScript.SetTarget(target);
	}
}
