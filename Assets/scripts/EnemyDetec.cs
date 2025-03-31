using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetec : MonoBehaviour
{
     public float detectionRange = 5f; 
    public float moveSpeed = 2f; 

    private Transform player; // 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").transform; 
    }

    private void Update()
    {
        // khoang cach cua enemy voi player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        //nho hon hoac bang khoang cach bi phat hien
        if (distanceToPlayer <= detectionRange)
        {
            // di chuyen den nhan vat
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(new Vector3(0, -180,0));
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(1); //  1 sat thuong
            }
        }
    }
}
