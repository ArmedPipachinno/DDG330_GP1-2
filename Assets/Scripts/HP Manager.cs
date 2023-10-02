using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField] GameObject ObjectWithHP;//
    [SerializeField] private int MaxHP = 3;
    [SerializeField] private int HP;
    [SerializeField] private float InvincibleDuration = 4f;
    private bool IsInvincible = false;

    private void Start()
    {
        //ObjectWithHP = GetComponent<GameObject>();
        HP = MaxHP;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsInvincible && collision.gameObject.CompareTag("Ball")) { Debug.Log("Hit!"); HP--; }
        StartInvincibility();
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Dead();
            
        }
        
    }

    void Dead()
    {
        ObjectWithHP.SetActive(false);
    }

    private void StartInvincibility()
    {
        IsInvincible = true;
        StartCoroutine(InvincibilityCooldown());
    }

    private IEnumerator InvincibilityCooldown()
    {
        yield return new WaitForSeconds(InvincibleDuration);
        IsInvincible = false;
    }

}