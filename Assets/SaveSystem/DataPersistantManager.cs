using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class DataPersistantManager : MonoBehaviour
{
    public static DataPersistantManager instance { get; private set;}
    private List<IDataPersistance> dataPersistancesObjects;

    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    FileDataHandler fileDataHandler;

    private GameData gameData;
    private DataPersistantManager()
    {

    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistancesObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }
    public void SaveGame()
    {
        foreach (IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        fileDataHandler.Save(gameData);
    }
    public void LoadGame()
    {
        gameData = fileDataHandler.Load();
        if (gameData == null)
        {
            NewGame();
        }
        foreach(IDataPersistance dataPersistanceObj in dataPersistancesObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistancesObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistancesObjects);
    }
}
