using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler 
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName) 
    {
    this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    } 

    public GameData Load()
    {
        string FullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if (File.Exists(FullPath))
        {
            try 
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(FullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Error ketika loading data game" + FullPath + "\n" + e);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string FullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(FullPath));
            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(FullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error Occured when abt to Save:" + FullPath + "\n" + e);
        }
    }
    
}
