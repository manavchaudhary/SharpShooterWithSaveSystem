using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public PlayerData PlayerData;
    public CameraData CameraData;
}

[Serializable]
public struct PlayerData
{
    public int PlayerHealth;
    public bool IsDead;
    public int Score;
    public Vector3 PlayerPos;
    public Quaternion PlayerRotation;
}

[Serializable]
public struct CameraData
{
    public float offset;
    public Vector3 Pos;
    public Quaternion Rotation;
}
