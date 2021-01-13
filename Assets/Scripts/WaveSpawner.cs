using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

	public static int EnemiesAlive = 0;

	public GameObject enemy;

	public Transform spawnPoint;

	private bool waveStarted;

	public GameManager gameManager;

	public int waysAmount;

	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waysAmount)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

		if (!waveStarted)
		{
			StartCoroutine(SpawnWave());
			waveStarted = true;
		}
	}

	IEnumerator SpawnWave ()
	{
		yield return new WaitForSeconds(5);

		PlayerStats.Rounds++;

		EnemiesAlive = waveIndex * 2 + 3;

		for (int i = 0; i < waveIndex * 2 + 3; i++)
		{
			SpawnEnemy(enemy);
			Debug.Log(i);
			yield return new WaitForSeconds(1f);
		}

		waveStarted = false;
		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		GameObject enemyObj = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;

		// Increase enemy stats
		enemyObj.GetComponent<Enemy>().damage += waveIndex;
		enemyObj.GetComponent<Enemy>().health += waveIndex * 50;
		enemyObj.GetComponent<Enemy>().worth += waveIndex * 100;
	}

}
