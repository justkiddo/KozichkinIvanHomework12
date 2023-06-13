using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Tools/EnemyInfo", fileName = "EnemyInfo")]

public class EnemyInfo : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public float FollowDistance { get; private set; }
    [field: SerializeField] public int Health { get; private set; } = 10;
    [field: SerializeField] public float Speed { get; private set; }
    
    
    
    
}
