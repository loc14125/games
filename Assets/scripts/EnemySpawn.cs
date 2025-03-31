using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab, player;
    [SerializeField] float spawnRate = 2.5f, spawnRadius = 4f;
    private float spawnTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnRate ) {
            spawnEnemy();
            spawnTimer = 0;
         }
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.transform.position, spawnRadius);
        
    }
    void spawnEnemy() {
        Vector2 randomPosition = (Vector2)transform.position + 
            Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
            }

}
