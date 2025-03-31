using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speedMove , attackSpeed , countEnd=0;
    [SerializeField] private GameObject bullet;
    private Rigidbody2D _rb;
    private Animator _anim;
    private string currentAnim;
    [SerializeField] Transform firePoint;
    public Slider healthSlider;
    public int maxHealth =10;
     public int currentHealth;



    [SerializeField] private float _enlargeScale = 2f;
    [SerializeField] private float _enlargeDuration = 3f;
    private bool _isEnlarged = false;
    private float _originalScale;
    private int _destroyedEnemyCount = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = this.GetComponent<Animator>();
         currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        _originalScale = transform.localScale.x;

    }
    
     public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }
     public void EnemyDestroyed()
    {
        _destroyedEnemyCount++;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Attack();
        if (_destroyedEnemyCount >= 3 && !_isEnlarged)
        {
            EnlargePlayer();
        }
    }

    private void Move(){
       float horizontal = Input.GetAxisRaw("Horizontal");
       float vertical = Input.GetAxisRaw("Vertical");
       Vector2 movement = new Vector2(horizontal,vertical).normalized;
       
       if(Math.Abs(horizontal) > 0.1f || Math.Abs(vertical) > 0.1f){
        changeAnim("run");
        transform.rotation = Quaternion.Euler(new Vector3(0,(horizontal > 0.1f)? 0:-180,0));
        _rb.velocity = movement * _speedMove * Time.deltaTime;
       }else{
         changeAnim("idle");
        _rb.velocity = Vector2.zero;
       }
    }

    private void Attack(){
        countEnd -= Time.deltaTime;
        if(countEnd>0){
        
        }

        if(Input.GetKeyDown(KeyCode.J)){
            changeAnim("attack");
            Instantiate(bullet,firePoint.position,transform.rotation);  
            countEnd = attackSpeed;
        }
    }
    private void changeAnim(String AnimName){
        if(currentAnim != AnimName){
            _anim.ResetTrigger(AnimName);
            currentAnim = AnimName;
            _anim.SetTrigger(currentAnim);
        }

    }
     private void EnlargePlayer()
    {
        _isEnlarged = true;
        transform.localScale = new Vector3(_originalScale * _enlargeScale, _originalScale * _enlargeScale, 1f);
        Invoke("ResetPlayerScale", _enlargeDuration);
    }

    private void ResetPlayerScale()
    {
        _isEnlarged = false;
        transform.localScale = new Vector3(_originalScale, _originalScale, 1f);
        _destroyedEnemyCount = 0;
    }   
}

