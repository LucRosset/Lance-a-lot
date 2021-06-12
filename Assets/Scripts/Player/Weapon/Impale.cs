using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impale : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyDeath enemyDeath = other.gameObject.GetComponent<EnemyDeath>();
        if (!enemyDeath)
            return;
        GameObject newWeaponPiece = enemyDeath.SpawnDeadEnemy();
        HingeJoint2D myFixedJoint = gameObject.AddComponent<HingeJoint2D>();
        myFixedJoint.connectedBody = newWeaponPiece.GetComponent<Rigidbody2D>();
    }
}
