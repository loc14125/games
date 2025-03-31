using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed= 0.5f;
    public Transform _player;
    public SpriteRenderer enemySR;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("player");
        if(playerObject == null){
            playerObject = FindObjectOfType<GameObject>();
        }
        if(playerObject != null){
            _player = playerObject.transform;
        }else{
            Debug.Log("khong co player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(_player !=null){
            Vector2 dir = (_player.position - transform.position ).normalized;
            Vector3 faceEnemy = dir * moveSpeed *  Time.deltaTime;
            transform.Translate(faceEnemy);
            if(faceEnemy.x !=0){
                if(faceEnemy.x < 0 ){
                    enemySR.transform.localScale = new Vector3(-1,1,1);

                }else{
                    enemySR.transform.localScale = new Vector3(1,1,1);
                }
            }
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
