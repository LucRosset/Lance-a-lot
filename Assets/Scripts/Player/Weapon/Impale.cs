using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impale : MonoBehaviour
{
    [SerializeField] private float impaleDistance = 1f;
    [SerializeField] SpriteRenderer[] spikes = null;
    public PlayerPivot pivot {get; set;}
    public Impale previousElement {get; set;}
    public Impale nextElement {get; set;}
    public int index {get; set;}

    void Start()
    {
        if (tag == "Lance")
        {
            pivot = GetComponent<PlayerPivot>();
            index = 0;
        }
    }

    void Update()
    {
        if (index != 0 && pivot.lastIndex != index)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyDeath enemyDeath = other.gameObject.GetComponent<EnemyDeath>();
        if (!enemyDeath || pivot.lastIndex != index)
            return;

        GameObject newWeaponPiece = enemyDeath.SpawnDeadEnemy();
        Transform newTransform = newWeaponPiece.transform;
        newTransform.position = pivot.lastElement.position
            + pivot.lastElement.localToWorldMatrix.MultiplyVector(impaleDistance * Vector3.right);
        newTransform.rotation = pivot.lastElement.rotation;
        newTransform.SetParent(pivot.lastElement);

        nextElement = newWeaponPiece.GetComponent<Impale>();
        nextElement.pivot = pivot;
        nextElement.previousElement = this;
        nextElement.index = index + 1;
        pivot.lastElement = newTransform;
        pivot.lastIndex = nextElement.index;

        if (tag != "Lance")
            foreach (SpriteRenderer spikeSprite in spikes)
                spikeSprite.enabled = false;
    }
}
