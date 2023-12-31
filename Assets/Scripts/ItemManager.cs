using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private static ItemManager Instance;
    private const string ItemManage = "ItemManager";
    public static ItemManager _Instance
    {
        get { if (Instance == null)
            {
                Instance = new GameObject(ItemManage).AddComponent<ItemManager>();
                Instance.ItemsList = new List<Item>();
            }
            return Instance;
        }
    }

    [SerializeField] private List<Item> ItemsList;

    private void Awake()
    {
         //making sure only one instance exist
         if (Instance == null)
         {
            Instance = this;
         }
         else
         { Destroy(gameObject); }

    }

    public List<Item> GetItems()
    { return ItemsList; }

}

[System.Serializable]
public class Item
{
    [SerializeField] private string Name;
    public string _Name => Name;
    [SerializeField] private int Value;
    public int _Value => Value;
    [SerializeField] private Sprite Picture;
    public Sprite _Picture => Picture;
    [SerializeField] private string Description;
    public string _Description => Description;

}



//public void AddItem(Item additem) 
//{
//    //check to avoid dupe
//    if(!ItemsList.Contains(additem))
//    {
//        ItemsList.Add(additem);
//    }
//}

//private void Start()
//{
//    // Creating preexisting items
//    Item sword = new Item("Sword", 50, "sword_picture.jpg", "A sword");
//    Item shield = new Item("Shield", 30, "shield_picture.jpg", "A shield");

//    // Adding preexisting items to the list
//    Instance.AddItem(sword);
//    Instance.AddItem(shield);

//    // Retrieving items
//    List<Item> itemsList = Instance.GetItems();
//    foreach (Item item in itemsList)
//    {
//        Debug.Log($"Name: {item.Name}, Value: {item.Value}, Picture: {item.Picture}");
//    }
//}