using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour,IDataPersistance
{

    public static int score;

    Text text;

    public void LoadData(GameData gameData)
    {
        if (gameData.PlayerData.IsDead)
            return;
        score = gameData.PlayerData.Score;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.PlayerData.Score = score;
    }

    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }

    void Update ()
    {
        text.text = "Score: " + score;
    }

}