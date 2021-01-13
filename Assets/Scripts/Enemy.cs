using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float health = 100;
	public int worth = 50;
	public int damage = 0;

	private bool isDead = false;

	public void TakeDamage (float amount)
	{
		health -= amount;

		if (health <= 0 && !isDead)
		{
			Die();
		}
	}


	void Die ()
	{
		isDead = true;

		PlayerStats.Money += worth;

		WaveSpawner.EnemiesAlive--;

		Destroy(gameObject);
	}

}
