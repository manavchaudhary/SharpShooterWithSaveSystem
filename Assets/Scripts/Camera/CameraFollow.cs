using UnityEngine;

public class CameraFollow : MonoBehaviour, IDataPersistance
{

    public Transform target;
    public float smoothing = 5f;

    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCameraPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position,
            targetCameraPos, smoothing * Time.deltaTime);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData.PlayerData.PlayerHealth > 0)
        {
            transform.position = gameData.CameraData.Pos;
            transform.rotation = gameData.CameraData.Rotation;
        }
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.CameraData.Pos = transform.position;
        gameData.CameraData.Rotation = transform.rotation;
    }
}