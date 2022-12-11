using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirectoryPath;
    private string dataFileName;

    public FileDataHandler(string path , string fileName)
    {
        dataDirectoryPath = path;
        dataFileName = fileName;
    }
    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirectoryPath, dataFileName);//dataDirectoryPath + "/" + dataFileName;
        GameData loadedData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //desealarize data to c#
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch(Exception ex)
            {
                Debug.Log("Exception : " + ex.Message);
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirectoryPath, dataFileName);//dataDirectoryPath + "/" + dataFileName;
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataToStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }catch(Exception ex)
        {
            Debug.LogError("Exception : "+ex.Message);
        }
    }
}
