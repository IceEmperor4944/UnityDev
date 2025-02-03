using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Range(0, 10)] public float speed = 3;
    [Range(0, 10)] public float jumpHeight = 2;
    [Range(-10, 10)] public float gravity = -9.0f;
    [Range(1, 5)] public float turnRate = 1;
}