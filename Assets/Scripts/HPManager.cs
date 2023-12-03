using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] private GameObject ObjectWithHP;//
    [SerializeField] private int MaxHP = 3;
    [SerializeField] private int HP;
    [SerializeField] private float InvincibleDuration = 4f;
    [SerializeField] private const string BallTag = "Ball";
    [SerializeField] private const string TargetTag = "Target";
    [SerializeField] private const string PlayerTag = "Player";
    private bool IsInvincible = false;

    [SerializeField] private SceneManagement LLoader;
    private ScoreTrack ScoreAdder;

    public float _HP => HP;

    private void Awake()
    {
        //ObjectWithHP = GetComponent<GameObject>();
        HP = MaxHP;
        ScoreAdder = FindObjectOfType<ScoreTrack>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!IsInvincible && collision.gameObject.CompareTag(BallTag)) { Debug.Log("Hit!"); HP--; }
        StartInvincibility();
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Dead();
            if (ObjectWithHP.CompareTag(PlayerTag))
            {
                LLoader.EndL();
            }
        }
    }

    public void Healplayer()
    {
        if (ObjectWithHP.CompareTag(PlayerTag)) { HP = HP + 3; }
        
    }

    void Dead()
    {
        ObjectWithHP.SetActive(false);
        ScoreAdder.AddScore();
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