using System.Collections;
using System.Collections.Generic;
using AliveObject.Enemy;
using AliveObject.Player;
using Pool;
using Trap;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;
    
    /*
     * Pools
     */
    [SerializeField]private FloorPool _floorPool;
    [SerializeField]private TrapPool _trapPool;
    [SerializeField]private EnemyPool _enemyPool;
    [SerializeField]private PlayerPool _playerPool;
    
    /*
     * For generate Road
     */
    private int _lengthRoad;
    private int _defaultDistanceBeetwenTraps;
    private int _distanceBeetwenTraps;
    
    /*
     * For Spawn
     */
    private int _amountEnemys;
    private int _amountPlayers;
    
    public void Awake()
    {
        if (LM == null)
        {
            LM = this;
        }
        ProtectedInit();
        InitSettingVar();
        _distanceBeetwenTraps = _defaultDistanceBeetwenTraps;
    }

    public void Start()
    {
        GenerateRoad();
//        GenerateEnemys();
//        GeneratePlayers();
    }

    private void InitSettingVar()
    {
        Settings settings = Resources.Load("Settings/Settings") as Settings;
        if (settings == null)
        {
            Debug.Log("Not found settings");
            return;
        }
        _lengthRoad = settings.LengthRoad;
        _defaultDistanceBeetwenTraps = settings.DistanceBeetwenTraps;
        _amountEnemys = settings.SizeEnemyPool;
        _amountPlayers = settings.SizePlayerPool;
    }

    private void ProtectedInit()
    {
        if (_floorPool == null)
        {
            _floorPool = GameObject.Find("FloorPool").GetComponent<FloorPool>();
        }
        if (_trapPool == null)
        {
            _trapPool = GameObject.Find("TrapPool").GetComponent<TrapPool>();
        }
        if (_enemyPool == null)
        {
            _enemyPool = GameObject.Find("EnemyPool").GetComponent<EnemyPool>();
        }
        if (_playerPool == null)
        {
            _playerPool = GameObject.Find("PlayerPool").GetComponent<PlayerPool>();
        }
    }

    private void GenerateRoad()
    {
        Floor f;
        BaseTrap baseTrap;
        Vector3 old = Vector3.zero;
        int distanceRange = 0;

        for (int i = 0; i < _lengthRoad; i++)
        {
            if (distanceRange != _distanceBeetwenTraps)
            {
                f = _floorPool.Get();
                f.transform.position = new Vector3(f.transform.position.x, f.transform.position.y,
                    old.z - f.transform.localScale.z);
                f.gameObject.SetActive(true);
                old = f.transform.position;
                Debug.Log(old);
                distanceRange += 1;
            }
            else if (distanceRange == _distanceBeetwenTraps)
            {
                baseTrap = _trapPool.Get();
                baseTrap.transform.position = new Vector3(baseTrap.transform.position.x, baseTrap.transform.position.y,
                    old.z - baseTrap.transform.localScale.z);
                baseTrap.gameObject.SetActive(true);
                distanceRange = 0;
                old = baseTrap.transform.position;
                Debug.Log(old);
                _distanceBeetwenTraps = _defaultDistanceBeetwenTraps + Random.Range(0, _defaultDistanceBeetwenTraps);
            }
        }
    }

    private void GeneratePlayers()
    {
        Player player;
        Vector3 old = Vector3.zero;

        for (int i = 0; i < _amountPlayers; i++)
        {
            player = _playerPool.Get();
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,
                old.z - player.transform.localScale.z);
            player.gameObject.SetActive(true);
            old = player.transform.position;
            Debug.Log("Spawn Players");
        } 
    }

    private void GenerateEnemys()
    {
        Enemy enemy;
        Vector3 old = Vector3.zero;

        for (int i = 0; i < _amountEnemys; i++)
        {
            enemy = _enemyPool.Get();
            enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y,
                old.z - enemy.transform.localScale.z);
            enemy.gameObject.SetActive(true);
            old = enemy.transform.position;
            Debug.Log("Spawn Enemy");
        }
    }
}
