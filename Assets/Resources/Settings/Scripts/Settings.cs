using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Settings Data", order = 51)]
public class Settings : ScriptableObject
{
    [SerializeField]private int _distanceBeetwenTraps;
    [SerializeField]private int _lengthRoad;
    [SerializeField]private int _sizeFloorPool;
    [SerializeField]private int _sizeEnemyPool;
    [SerializeField]private int _sizeTrapPool;
    [SerializeField]private int _sizePlayerPool;
    [SerializeField] private Vector3 _directionMainMove;
    [SerializeField] private int _speedMain;

    public int DistanceBeetwenTraps => _distanceBeetwenTraps;
    
    public int SizeFloorPool => _sizeFloorPool;

    public int LengthRoad => _lengthRoad;

    public int SizeEnemyPool => _sizeEnemyPool;

    public int SizeTrapPool => _sizeTrapPool;

    public int SizePlayerPool => _sizePlayerPool;

    public Vector3 DirectionMainMove => _directionMainMove;
    public int SpeedMain => _speedMain;
}
