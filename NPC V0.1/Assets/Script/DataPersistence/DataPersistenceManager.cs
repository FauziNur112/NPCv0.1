using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    public GameObject AssignName;
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceObjects;
    public static DataPersistenceManager Instance { get; private set; }

    private FileDataHandler dataHandler;

    public TMP_Text TextInput;

    private void Awake()
    {
        Instance = this; 
        
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame ()
    {
        this.gameData = new GameData();
        AssignName.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();
        if (this.gameData == null)
        {
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }

        Debug.Log("Load currentSenter =  " + gameData.currentSenter);
    }
   
    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        Debug.Log("Save currentSenter =  " + gameData.currentSenter);

        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public void CreatePlayerName()
    {
        PlayerPrefs.SetString("namaplayer", TextInput.text);
        PlayerPrefs.Save();
        Time.timeScale = 1f;
        AssignName.SetActive(false);
    }
}

