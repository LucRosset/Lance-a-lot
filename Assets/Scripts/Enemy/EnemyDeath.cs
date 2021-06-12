using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject deadEnemyPrefab = null;

    public GameObject SpawnDeadEnemy()
    {
        GameObject deadEnemy = Instantiate(
            deadEnemyPrefab,
            transform.position,
            transform.rotation
        );
        Destroy(gameObject);
        return deadEnemy;
    }
}
