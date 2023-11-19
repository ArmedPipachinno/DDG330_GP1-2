using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item
{
    public string Name { get; set; }
    public int Value { get; set; }
    public string Picture { get; set; }
    public string Description { get; set; }

    public Item (string name, int value, string picture, string desctiption)
    {
        Name = name;
        Value = value;
        Picture = picture;
        Description = desctiption;
    }

}

public class ItemManager : MonoBehaviour
{
   private static ItemManager Instance;
    [SerializeField] private const string ItemManage = "ItemManager";
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

    private List<Item> ItemsList;

    private void Awake()
    {
         //making sure only one instance exist
         if (ItemsList == null)
         {
            Instance = this;
            ItemsList = new List<Item>();
         }
         else
         { Destroy(gameObject); }

        // Creating preexisting items
        Item sword = new Item("Sword", 50, "Fork", "A sword");
        Item shield = new Item("Shield", 30, "Fork", "A shield");
        Item Dummy = new Item("Dummy", 00, "", "A Dummy");
        Item Dummy2 = new Item("Dummy2", 00, "Why are we still here", "A Dummy");
        Item Dummy3 = new Item("Dummy3", 00, "", "A Dummy");
        Item Dummy4 = new Item("Dummy4", 00, "", "A Dummy");

        // Adding preexisting items to the list
        Instance.AddItem(sword);
        Instance.AddItem(shield);
        Instance.AddItem(Dummy);
        Instance.AddItem(Dummy2);
        Instance.AddItem(Dummy3);
        Instance.AddItem(Dummy4);

        //// Retrieving items
        //List<Item> itemsList = Instance.GetItems();
        //foreach (Item item in itemsList)
        //{
        //    Debug.Log($"Name: {item.Name}, Value: {item.Value}, Picture: {item.Picture}");
        //}
    }

    public void AddItem(Item additem) 
    {
        //check to avoid dupe
        if(!ItemsList.Contains(additem))
        {
            ItemsList.Add(additem);
        }
    }

    public List<Item> GetItems()
    { return ItemsList; }

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
}
