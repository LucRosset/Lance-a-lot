using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private GameObject deadEnemyPrefab = null;
    [SerializeField] private AudioClip deathCry = null;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public GameObject SpawnDeadEnemy()
    {
        GameObject deadEnemy = Instantiate(
            deadEnemyPrefab,
            transform.position,
            transform.rotation
        );
        audioSource.PlayOneShot(deathCry);
        Destroy(gameObject);
        return deadEnemy;
    }
}
