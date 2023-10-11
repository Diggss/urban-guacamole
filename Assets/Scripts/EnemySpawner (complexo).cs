using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner_1 : MonoBehaviour
{
	/*[SerializeField] private GameObject[] enemyPrefabs;

	[SerializeField] private int baseEnemies = 8;
	[SerializeField] private float enemiesPerSecond = 0.5f;
	[SerializeField] private float timeBetweenWaves = 5f;
	[SerializeField] private float difficultyScalingFactor = .75f;

	public static UnityEvent onEnemyDestroy = new UnityEvent();

	private int currentWave = 1;
	private float timeSinceLastSpawn;
	private int enemiesAlive;
	private int enemiesLeftToSpawn;
	private bool isSpawning = false;

	void Awake() {
		onEnemyDestroy.AddListener(EnemyDestroyed);
	}

	void Start() {
		StartCoroutine(StartWave());	//começar só chamando;
	}

	private IEnumerator StartWave() {	//começar como void
		yield return new WaitForSeconds(timeBetweenWaves);
		isSpawning = true;
		enemiesLeftToSpawn = EnemiesPerWave();
	}

	void Update() {
		if(!isSpawning) return;

		timeSinceLastSpawn += Time.deltaTime;
		if(timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) {
			SpawnEnemy();
			enemiesLeftToSpawn--;
			enemiesAlive++;
			timeSinceLastSpawn = 0f;
		}

		if (enemiesAlive == 0 && enemiesLeftToSpawn == 0) {
			EndWave();
		}
	}

	private int EnemiesPerWave() {
		return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
	}

	private void SpawnEnemy() {
		GameObject prefabToSpawn = enemyPrefabs[0];
		Instantiate(prefabToSpawn, transform.position, Quaternion.identity);	//criar uma GameObject enemySpawner com o Spawner
	}

	private void EnemyDestroyed() {	//adicionar "EnemySpawner.onEnemyDestroy.Invoke();" onde o inimigo for destruído
		enemiesAlive--;
	}

	private void EndWave() {
		isSpawning = false;
		timeSinceLastSpawn = 0;
		currentWave++;
		StartCoroutine(StartWave());
	}*/
}
