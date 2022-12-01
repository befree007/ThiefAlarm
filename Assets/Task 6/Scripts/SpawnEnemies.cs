using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            int randomPoint = Random.Range(0, _spawnPoints.Count);
            Instantiate(_enemy, _spawnPoints[randomPoint].transform.position, Quaternion.identity);

            yield return new WaitForSeconds(_delay);
        }        
    }
}
