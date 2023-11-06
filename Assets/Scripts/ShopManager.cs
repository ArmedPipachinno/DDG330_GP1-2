using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopUi;

    public static bool ShopOpen = false;

    private ScoreTrack UseScore;
    private BallSpawnHandler BallItem;

    [SerializeField] private List<ShopEntry> _shopEntries = new List<ShopEntry>();

    void Awake()
    {
        UseScore = FindObjectOfType<ScoreTrack>();
        BallItem = FindObjectOfType<BallSpawnHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShopUi != null)
        { 
            if (!ShopOpen)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ShopOpen = true;
                    ShopUi.SetActive(true);
                }
            }
            else if (ShopOpen)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ShopOpen = false;
                    ShopUi.SetActive(false);
                }
            }
        }
        else { Debug.Log("No shop!"); }
    }

    public void ShopPurchase()
    {
        //make public reader to send Item price to Ui manager
        UseScore.MinusScore();
        BallItem.AddItem();
        Debug.Log("Purchase a ball");
    }

}

[System.Serializable]
public class ShopEntry
{
    public string Name;
    public string Description;
    public Sprite Pic;
    public int Price;
}
//singleton class
