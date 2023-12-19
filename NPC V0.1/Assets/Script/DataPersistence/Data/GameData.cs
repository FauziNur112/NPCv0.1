using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int currentSenter;
    public int currentSanity;
    public int storyID;
    public Vector3 Playerpos;
    public List<Item> items ;
    public float intentsitasLampuGlobal;
    public SeriableDictionary<string, bool> itemcollected;

    public GameData()
    {
        items = new List<Item>();
        itemcollected = new SeriableDictionary<string, bool>();
        currentSanity = 100;
        currentSenter = 100;
        intentsitasLampuGlobal = 11.2f;
        storyID = -1;
    }
}