using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impale : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyDeath enemyDeath = other.gameObject.GetComponent<EnemyDeath>();
        if (!enemyDeath)
            return;
        GameObject newWeaponPiece = enemyDeath.SpawnDeadEnemy();
        Transform newTransform = newWeaponPiece.transform;
        newTransform.position = transform.position + transform.localToWorldMatrix.MultiplyVector(Vector3.right);
        newTransform.rotation = transform.rotation;
        newTransform.SetParent(transform);
    }
}
