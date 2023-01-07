using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public int waveNumber = 0;
    public int enemySpawnAmount = 0;
    public int enemiesKilled = 0;

    public GameObject[] spawners;
    public GameObject BigZombie;
    public GameObject MediumZombie;
    public GameObject FastZombie;
    public GameObject[] Zombies;

    // Start is called before the first frame update
    void Start()
    {
        Zombies = new GameObject[3];
        Zombies[0] = BigZombie;
        Zombies[1] = MediumZombie;
        Zombies[2] = FastZombie;

        spawners = new GameObject[5];

        for (int i = 0; i < spawners.Length; i++) {
            spawners[i] = transform.GetChild(i).gameObject; 
        }

        StartWave();
    }

    private void Update()
    {
        if (enemiesKilled >= enemySpawnAmount) {
            NextWave();
        }
    }

    private void SpawnEnemy() {
        int SpawnerID = Random.Range(0, spawners.Length);
        int ZombieType = Random.Range(0, 3);
        Instantiate(Zombies[ZombieType], spawners[SpawnerID].transform.position, spawners[SpawnerID].transform.rotation);
    }

    private void StartWave() {
        waveNumber = 1;
        enemySpawnAmount = 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++) {
            SpawnEnemy();
        }
    }


    public void NextWave()
    {
        waveNumber++;

        if (waveNumber == 6) {
            SceneManager.LoadScene("Win");
        }

        waveNumber++;
        enemySpawnAmount += 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    public void EnemyKilled() {
        enemiesKilled = enemiesKilled + 1;
    }

}
