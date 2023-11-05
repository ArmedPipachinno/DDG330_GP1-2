using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTrack : MonoBehaviour
{
    [SerializeField] private GameObject Score;
    [SerializeField] private TextMeshProUGUI ScoreUi;

    private int PlayerScore = 0;

    public int _PScore => PlayerScore;

    void Awake()
    {

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
        PlayerScore -= 100;
        return PlayerScore;
    }

}
