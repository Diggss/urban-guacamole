using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] enemyPrefabs;

	[SerializeField] private int baseEnemies = 8;
	[SerializeField] private float enemiesPerSecond = 0.5f;
	[SerializeField] private float timeBetweenWaves = 5f;

	public static UnityEvent onEnemyDestroy = new UnityEvent();

	[SerializeField] private int currentWave = 1;
	[SerializeField] private float timeSinceLastSpawn;
	[SerializeField] private int enemiesAlive;
	[SerializeField] private int enemiesLeftToSpawn;
	[SerializeField] private bool isSpawning = false;

	void Awake() {
		onEnemyDestroy.AddListener(EnemyDestroyed);
	}

	void Start() {
		StartCoroutine(StartWave());	//começar só chamando;
	}

	private IEnumerator StartWave() {	//começar como void
		Debug.Log("Wave iniciada");
		yield return new WaitForSeconds(timeBetweenWaves);
		isSpawning = true;
		enemiesLeftToSpawn = baseEnemies;
	}

	void Update() {
		if(!isSpawning) return;

		timeSinceLastSpawn += Time.deltaTime;
		if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) {
			SpawnEnemy();
			enemiesLeftToSpawn--;
			enemiesAlive++;
			timeSinceLastSpawn = 0f;
			Debug.Log("Spawnou");
		}

		if (enemiesAlive == 0 && enemiesLeftToSpawn == 0) {
			EndWave();
		}
	}

	private void SpawnEnemy() {
		GameObject prefabToSpawn = enemyPrefabs[0];
		Instantiate(prefabToSpawn, transform.position, Quaternion.identity);	//criar uma GameObject enemySpawner com o Spawner
	}

	private void EnemyDestroyed() {	//adicionar "EnemySpawner.onEnemyDestroy.Invoke();" onde o inimigo for destruído
		enemiesAlive--;
	}

	private void EndWave() {
		Debug.Log("Wave finalizada");
		isSpawning = false;
		timeSinceLastSpawn = 0;
		currentWave++;
		StartCoroutine(StartWave());
	}
}
