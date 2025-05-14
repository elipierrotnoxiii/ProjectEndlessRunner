using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float ySpawnRange = 2f;
    private float timer = 0f;
    private Transform player;

    [SerializeField]
    private float spawnXOffset = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    void Update()
    {
        if (GameManager.Instance == null || !GameManager.Instance.IsGameRunning()) return;

        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy() 
    {
        Vector3 spawnPos = new Vector3(player.transform.position.x + spawnXOffset, player.transform.position.y, 0);
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
