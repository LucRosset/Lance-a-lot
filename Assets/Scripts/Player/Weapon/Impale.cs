using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impale : MonoBehaviour
{
    [SerializeField] private float impaleDistance = 1f;
    public PlayerPivot pivot {set; get;}
    public Impale previousElement {set; get;}
    public Impale nextElement {set; get;}

    void Start()
    {
        if (tag == "Lance")
            pivot = GetComponent<PlayerPivot>();
        Debug.Log("pivot", pivot.lastElement.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyDeath enemyDeath = other.gameObject.GetComponent<EnemyDeath>();
        if (!enemyDeath || pivot.lastElement.GetInstanceID() != transform.GetInstanceID())
            return;

        GameObject newWeaponPiece = enemyDeath.SpawnDeadEnemy();
        Transform newTransform = newWeaponPiece.transform;
        newTransform.position = pivot.lastElement.position
            + pivot.lastElement.localToWorldMatrix.MultiplyVector(impaleDistance * Vector3.right);
        newTransform.rotation = pivot.lastElement.rotation;
        newTransform.SetParent(pivot.lastElement);

        pivot.lastElement = newTransform;
        nextElement = newWeaponPiece.GetComponent<Impale>();
        nextElement.pivot = pivot;
        nextElement.previousElement = this;
    }
}
