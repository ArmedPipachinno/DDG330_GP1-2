using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HpGetter;
    [SerializeField] private GameObject ScoreSetter;
    [SerializeField] private TextMeshProUGUI HpUi;
    [SerializeField] private TextMeshProUGUI ScoreUi;

    private HPManager HpReader;
    private ScoreTrack ScoreReader;

    void Start()//Awake()
    {
        // Assuming HPManager script is attached to the same GameObject as this UIManager script
        HpReader = HpGetter.GetComponent<HPManager>();
        ScoreReader = ScoreSetter.GetComponent<ScoreTrack>();

        if (HpReader == null)
        {
            Debug.LogError("HPManager script not found on the same GameObject as UIManager.");
        }
        if (ScoreReader == null)
        {
            Debug.LogError("ScoreTracker script not found on the same GameObject as UIManager.");
        }

        // Assuming HpGetter contains TextMeshProUGUI component in the Inspector
        //HpUi = HpGetter.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        HpDisplay();
        ScoreDisplay();
    }

    private void HpDisplay()
    {
        if (HpReader != null)
        {
            HpUi.text = ($"HP: {HpReader._HP}");//HpReader._HP.ToString();

            // Optionally, you can check for 0 HP here and set a specific message
            if (HpReader._HP == 0)
            {
                HpUi.text = "Skill Issue";
            }
        }
        else
        {
            Debug.LogError("HpReader is not initialized. HPManager script not found.");
        }
    }
    private void ScoreDisplay()
    {
        if (ScoreReader != null)
        {
            ScoreUi.text = ($"Score: { ScoreReader._PScore}");
        }
        else
        {
            Debug.LogError("ScoreTracker is not initialized.");
        }
    }


}



//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIManager : MonoBehaviour
//{
//    [SerializeField] private GameObject HpGetter;
//    [SerializeField] private TextMeshProUGUI HpUi;

//    HPManager HpReader;
//    void Start()
//    {
//        HpUi = HpGetter.GetComponent<TextMeshProUGUI>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        HpUi.text = HpReader._HP.ToString();
//        if ( HpReader._HP == 0 ) { HpUi.text = "Skill Issue"; }
//    }
//}
