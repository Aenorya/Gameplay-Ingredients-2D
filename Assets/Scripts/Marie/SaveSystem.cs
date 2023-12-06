using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public PlayerInfo player;
    
    void Start()
    {
        instance = this;
        Load();
    }

    public void Load()
    {

        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            player = JsonUtility.FromJson<PlayerInfo>(json);
            PlayerMovement.instance.transform.position = new Vector3(player.x, player.y, player.z);
            foreach(SaveItem i in player.inventory) {
                Item item = new Item();
                item.uniqueID = i.id;
                item.icon = Resources.Load<Sprite>("Inventory Icons/"+ i.spriteName);
                PlayerInventory.Instance.AddItemToInventory(item);
            }
        }
       
    }

    public void Save()
    {
        Vector3 position = PlayerMovement.instance.transform.position;
        player.x = position.x;
        player.y = position.y;
        player.z = position.z;

        player.inventory.Clear();
        foreach(Item item in PlayerInventory.Instance.GetInventory())
        {
            player.inventory.Add(new SaveItem() { id = item.uniqueID, spriteName = item.icon.name }); 
            Debug.Log(item.icon.name);
        }


        Debug.Log(Application.persistentDataPath + "/data.save");
        string json = JsonUtility.ToJson(player);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);

    }
}
