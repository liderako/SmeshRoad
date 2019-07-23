using System.Collections;
using System.Collections.Generic;
using AliveObject.Enemy;
using AliveObject.Player;
using AliveObject.State;
using Managers;
using Pool;
using Trap;
using UnityEngine;


public class LevelManager : MonoBehaviour
{
    public static LevelManager LM;
    public delegate void MethodContainer();
    public event MethodContainer Clear;
    
    #region Inspector Var
    /*
     * Pools
     * */
    [SerializeField]private FloorPool floorPool = null;
    [SerializeField]private TrapPool trapPool = null;
    [SerializeField]private EnemyPool enemyPool = null;
    [SerializeField]private PlayerPool playerPool = null;
    [SerializeField]private List<Crowd> crowdsEnemy = null;
    [SerializeField]private List<Crowd> crowdsPlayer = null;
    [SerializeField]private GameObject finalFloor;
    [SerializeField]private GameObject weaponFloorEnemy;
    #endregion

    #region Member var

    /*
     * * For generate Road
     * */
    private int _lengthRoad;
    private int _defaultDistanceBeetwenTraps;
    private int _distanceBeetwenTraps;
    private int _lengthSafeZone;
    
    /*
     * For Spawn
     */
    private int _amountEnemys;
    private int _amountPlayers;

    #endregion

    #region Unity methods

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
        NewLevel();
        GameManager.Gm.Clear += NewLevel;
    }

    #endregion

    #region Private Methods

    #region Init

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
        _lengthSafeZone = settings.SafeZoneLenght;
    }

    private void ProtectedInit()
    {
        if (floorPool == null)
        {
            floorPool = GameObject.Find("FloorPool").GetComponent<FloorPool>();
        }
        if (trapPool == null)
        {
            trapPool = GameObject.Find("TrapPool").GetComponent<TrapPool>();
        }
        if (enemyPool == null)
        {
            enemyPool = GameObject.Find("EnemyPool").GetComponent<EnemyPool>();
        }
        if (playerPool == null)
        {
            playerPool = GameObject.Find("PlayerPool").GetComponent<PlayerPool>();
        }
    }

    #endregion

    #region Generate game object

    private void NewLevel()
    {
        if (Clear != null)
        {
            Clear();
        }
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        yield return new WaitForSeconds(0.1f);
        GenerateRoad();
        GenerateEnemys();
        GeneratePlayers();
    }

    
    private void GenerateRoad()
    {
        Floor f;
        BaseTrap baseTrap;
        Vector3 old = Vector3.zero;
        int distanceRange = 0;

        // safe zone
        for (int i = 0; i < _lengthSafeZone; i++)
        {
            f = floorPool.Get();
            f.transform.position = new Vector3(f.transform.position.x, f.transform.position.y,
                    old.z - f.transform.localScale.z);
            f.GetComponent<Renderer>().material.color = ColorManager.CM.GetLevelColor;
            f.gameObject.SetActive(true);
            old = f.transform.position;
        }

        for (int i = 0; i < _lengthRoad - _lengthSafeZone; i++)
        {
            if (distanceRange != _distanceBeetwenTraps)
            {
                f = floorPool.Get();
                f.transform.position = new Vector3(f.transform.position.x, f.transform.position.y,
                    old.z - f.transform.localScale.z);
                f.GetComponent<Renderer>().material.color = ColorManager.CM.GetLevelColor;
                f.gameObject.SetActive(true);
                old = f.transform.position;
                distanceRange += 1;
            }
            else if (distanceRange == _distanceBeetwenTraps)
            {
                baseTrap = trapPool.Get();
                baseTrap.transform.position = new Vector3(baseTrap.transform.position.x, baseTrap.transform.position.y,
                    old.z - baseTrap.transform.localScale.z);
                baseTrap.gameObject.SetActive(true);
                distanceRange = 0;
                old = baseTrap.transform.position;
                _distanceBeetwenTraps = _defaultDistanceBeetwenTraps + Random.Range(0, _defaultDistanceBeetwenTraps);
            }
        }
        GameObject prewFinish = Instantiate(weaponFloorEnemy);
        prewFinish.transform.position = new Vector3(prewFinish.transform.position.x, prewFinish.transform.position.y,
            old.z - prewFinish.transform.localScale.z);
        
        
        GameObject finish = Instantiate(finalFloor);
        finish.transform.position = new Vector3(finish.transform.position.x, finish.transform.position.y,
            prewFinish.transform.position.z - finish.transform.localScale.z);

        old = finish.transform.position;
        for (int i = 0; i < 5; i++)
        {
            finish = Instantiate(finalFloor);
            finish.transform.position = new Vector3(finish.transform.position.x, finish.transform.position.y,
                old.z - finish.transform.localScale.z);
            old = finish.transform.position;
            Destroy(finish.GetComponent<Finish>());
        }
    }

    private void GeneratePlayers()
    {
        Player player;
        Crowd crowdTmp = crowdsPlayer[Random.Range(0, crowdsPlayer.Count)];
        crowdTmp.gameObject.SetActive(true);
        for (int i = 0; i < crowdTmp.positions.Count; i++)
        {
            player = playerPool.Get();
            player.transform.position = crowdTmp.positions[i].position;
            player.gameObject.name = "Player:" + i;
            player.gameObject.SetActive(true);
        }
        crowdTmp.gameObject.SetActive(false);
    }



    private void GenerateEnemys()
    {
        Enemy enemy;
        Crowd crowdTmp = crowdsEnemy[Random.Range(0, crowdsEnemy.Count)];
        crowdTmp.gameObject.SetActive(true);
        for (int i = 0; i < crowdTmp.positions.Count; i++)
        {
            enemy = enemyPool.Get();
            enemy.transform.position = crowdTmp.positions[i].position;
            enemy.gameObject.SetActive(true);
        }
        crowdTmp.gameObject.SetActive(false);
    }

    #endregion


    #region Returned object in Pool

    public void DeadPlayer(GameObject player)
    {
        PlayerManager.PM.DeadPlayer();
        playerPool.ReturnObject(player.GetComponent<Player>());
    }
    
    public void DeadEnemy(GameObject enemy)
    {
        enemyPool.ReturnObject(enemy.GetComponent<Enemy>());
    }

    public void ReturnFloor(GameObject floor)
    {
        floorPool.ReturnObject(floor.GetComponent<Floor>());
    }

    public void ReturnTrap(GameObject trap)
    {
        trapPool.ReturnObject(trap.GetComponent<BaseTrap>());
    }

    #endregion
    
    #endregion
}
