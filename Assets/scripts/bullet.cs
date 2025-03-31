using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed;
    public float lifeTime;
    public GameObject effect_bullet;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);  
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = transform.right * _speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other){
      if(other.gameObject.CompareTag("enemy")){
 //(tieu diet quai)
          Destroy(this.gameObject);
          GameObject Explode = Instantiate(effect_bullet,transform.position,Quaternion.identity);
          Destroy(Explode,0.1f);
          var name = other.attachedRigidbody.name;
          Destroy(GameObject.Find(name));

 if (other.CompareTag("enemy"))
        {
            Destroy(other.gameObject);
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.EnemyDestroyed();
            }
            Destroy(gameObject);
       
      }
    }
}
}
