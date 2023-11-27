using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject ShopUi;
    private static bool ShopOpen = false;

    private List<Item> ShopItems;
    private int CurrentItemIndex = 0;

    [SerializeField] private TextMeshProUGUI[] ItemName;
    [SerializeField] private TextMeshProUGUI[] ItemValue;
    [SerializeField] private TextMeshProUGUI[] ItemDescription;
    [SerializeField] private Image[] ItemImages;

    private ScoreTrack UseScore;
    private BallSpawnHandler BallItem;

    //[SerializeField] private List<ShopEntry> _shopEntries = new List<ShopEntry>();

    void Awake()
    {
        UseScore = FindObjectOfType<ScoreTrack>();
        BallItem = FindObjectOfType<BallSpawnHandler>();

        // Assume the ItemManager is attached to the same GameObject or is accessible
        ItemManager itemManager = ItemManager._Instance;

        // Retrieve the list of items from the ItemManager
        ShopItems = itemManager.GetItems();

        // Display the initial set of items in the shop UI
        DisplayItems();

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
    private void DisplayItems()
    {
        // Ensure the index is within bounds
        if (CurrentItemIndex >= 0 && CurrentItemIndex < ShopItems.Count)
        {
            for (int i = 0; i < ItemName.Length; i++)
            {
                int itemIndex = CurrentItemIndex + i;

                // Update UI elements with item information
                if (itemIndex < ShopItems.Count)
                {
                    Item currentItem = ShopItems[itemIndex];
                    ItemName[i].text = "Name: " + currentItem._Name;
                    ItemValue[i].text = "Value: " + currentItem._Value.ToString();
                    ItemDescription[i].text = "Description: \n" + currentItem._Description;

                    // Load and display the item image from the Assets folder
                    LoadImage(currentItem._Picture, ItemImages[i]);
                    // Load and display the item image (assuming the image path is correct)
                    //StartCoroutine(LoadImage(currentItem.Picture, ItemImages[i]));
                }
                else
                {
                    // If there are no more items, clear the UI elements
                    ItemName[i].text = "";
                    ItemValue[i].text = "";
                    ItemDescription[i].text = "";
                    ItemImages[i].sprite = null;
                }
            }
        }
    }

    private void LoadImage(Sprite sprite, Image image)
    {
        // Load the image directly from the Resources folder
        //Sprite loadedSprite = Resources.Load<Sprite>(imageName) as Sprite;

        // Set the sprite of the Image component
        if (sprite != null)
        {
            image.sprite = sprite;
        }
        else
        {
            //Debug.LogError($"Failed to load image: {imageName}");
        }
    }

    public void NextSetOfItems()
    {
        // Move to the next set of items
        CurrentItemIndex += ItemName.Length;

        // Display the updated set of items
        DisplayItems();
    }

    public void PreviousSetOfItems()
    {
        // Move to the previous set of items
        CurrentItemIndex -= ItemName.Length;

        // Ensure the index does not go below zero
        CurrentItemIndex = Mathf.Max(CurrentItemIndex, 0);

        // Display the updated set of items
        DisplayItems();
    }

}

//[System.Serializable]
//public class ShopEntry
//{
//    public string Name;
//    public string Description;
//    public Sprite Pic;
//    public int Price;
//}

//singleton class
