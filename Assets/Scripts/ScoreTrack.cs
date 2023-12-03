using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
    [SerializeField] private GameObject Score;
    [SerializeField] private TextMeshProUGUI ScoreUi;

    [SerializeField] private ShopManager ItemPirceReductor;

    private int PlayerScore = 0;
    public int _PScore => PlayerScore;

    void Start()
    {
        ItemPirceReductor = GetComponent<ShopManager>();

        //if (ItemPirceReductor == null)
        //{
        //    Debug.LogError("ItemPirceReductor is not assigned!");
        //}
        //else
        //{
        //    Debug.Log("ItemPirceReductor is assigned!");
        //}

        ItemPirceReductor = FindObjectOfType<ShopManager>();

        //if (ItemPirceReductor == null)
        //{
        //    Debug.LogError("No ShopManager found in the scene!");
        //}
        //else
        //{
        //    Debug.Log("ShopManager found!");
        //}
    }

    void Update()
    {

    }

    public int AddScore()
    {
        PlayerScore += 100;
        return PlayerScore;
    }

    public int MinusScore()
    {
        PlayerScore -= ItemPirceReductor._ItemPrice;
        //PlayerScore -= 100;
        return PlayerScore;
    }

}
