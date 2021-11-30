using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : Enemy
{
   
    
    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        enemyHead.player = player;
    }

    private void Update()
    {
        Attack();
    }

}
