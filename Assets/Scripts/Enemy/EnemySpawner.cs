using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int poolCount;
    [SerializeField] private float secondsToSpawn;
    [SerializeField] private int maxAliveEnemies;
    private GameObject _enemyObject;
    private List<GameObject> _enemyPool;
    private int _currentAliveEnemies;

    private void Start()
    {
        _currentAliveEnemies = 0;

        _enemyPool = new List<GameObject>();

        for (int i = 0; i < poolCount; i++)
        {
            _enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            _enemyObject.transform.SetParent(transform);
            _enemyObject.SetActive(false);
            _enemyPool.Add(_enemyObject);
        }

        StartCoroutine(SpawnCoroutine());
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemy.activeSelf != false)
        {
            enemy.SetActive(false);
            _currentAliveEnemies--;
            StartCoroutine(SpawnCoroutine());
        }
    }

    private void SpawnEnemy()
    {
        while (maxAliveEnemies > _currentAliveEnemies)
        {
            foreach (GameObject enemy in _enemyPool)
            {
                if (enemy.activeSelf == false)
                {
                    enemy.SetActive(true);
                    enemy.transform.position = gameObject.transform.position;
                    enemy.GetComponent<Enemy>().ReturnHealth();
                    _currentAliveEnemies++;
                    break;
                }
            }
        }
    }

    public List<GameObject> GetTargets()
    {
        return targets;
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(secondsToSpawn);
        SpawnEnemy();
    }
}
