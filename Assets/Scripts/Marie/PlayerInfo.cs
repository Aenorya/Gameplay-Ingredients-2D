using System;
using System.Collections.Generic;

[Serializable]
public class PlayerInfo
{
    public float x, y, z;
    public List<SaveItem> inventory = new List<SaveItem>();
}

[Serializable]
public struct SaveItem
{
    public string id;
    public string spriteName;
}