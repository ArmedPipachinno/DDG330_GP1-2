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
    private int ItemPrice;
    public int _ItemPrice => ItemPrice;

    [SerializeField] private TextMeshProUGUI[] ItemName;
    [SerializeField] private TextMeshProUGUI[] ItemValue;
    [SerializeField] private TextMeshProUGUI[] ItemDescription;
    [SerializeField] private Image[] ItemImages;

    [SerializeField] private ScoreTrack UseScore;
    //private BallSpawnHandler BallItem;

    [SerializeField] private AbilitiesManager PlayerAbilities;
    [SerializeField] private AudioManager PlayerPurchase;

    void Start()
    {
        UseScore = FindObjectOfType<ScoreTrack>();
        //BallItem = FindObjectOfType<BallSpawnHandler>();
        ItemManager itemManager = ItemManager._Instance;// Assume the ItemManager is attached to the same GameObject or is accessible
        ShopItems = itemManager.GetItems();// Retrieve the list of items from the ItemManager
        DisplayItems();// Display the initial set of items in the shop UI

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
        
        if(UseScore._PScore > ItemPrice)
        {
            ItemPrice = ShopItems[CurrentItemIndex]._Value;
            PlayerPurchase.PlayPurcaseSound();
            //Debug.Log($"Current item: {ItemPrice}");
            var item = ShopItems[CurrentItemIndex];
            PlayerAbilities.ActiveAbilities(item);
            UseScore.MinusScore();
            ShopItems.RemoveAt(CurrentItemIndex);
            DisplayItems();
        }
        else
        {
            PlayerPurchase.PlayCanNotPurcaseSound();
            //Debug.Log("Not enough score");
        }

        //BallItem.AddItem();
        //Debug.Log("Purchase a ball");
        //DisplayItems();

    }

    private void DisplayItems()
    {
        // Ensure the index is within bounds
        for (int i = 0; i < ItemName.Length; i++)
        {
            if (ShopItems.Count > 0)
            {
                int itemIndex = (CurrentItemIndex + i) % ShopItems.Count;
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
                ////else
                ////{
                ////    // If there are no more items, clear the UI elements
                ////    ItemName[i].text = null;
                ////    ItemValue[i].text = null;
                ////    ItemDescription[i].text = null;
                ////    ItemImages[i].sprite = null;
                ////}

                Debug.Log($"Current item: {itemIndex}");
            }
            else
            {
                ItemName[i].text = "";
                ItemValue[i].text = "";
                ItemDescription[i].text = "";
                ItemImages[i].sprite = null;
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
        CurrentItemIndex %= ShopItems.Count;
        
        // Display the updated set of items
        DisplayItems();
    }

    public void PreviousSetOfItems()
    {
        // Move to the previous set of items
        CurrentItemIndex -= ItemName.Length;
        CurrentItemIndex += ShopItems.Count;
        CurrentItemIndex %= ShopItems.Count;
        
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

