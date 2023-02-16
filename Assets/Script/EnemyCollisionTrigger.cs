using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionTrigger : MonoBehaviour
{
    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = gameObject.GetComponentInParent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyController.CollionEnter(gameObject.name, collision.gameObject);
    }
}
