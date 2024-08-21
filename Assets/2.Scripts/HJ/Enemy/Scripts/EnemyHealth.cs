using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    private SpriteRenderer spriteRenderer;
    private EnemyMove enemyMove;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyMove = GetComponent<EnemyMove>();
    }


    public void HealthSet(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            spriteRenderer.color = Color.white;
            gameObject.layer = LayerMask.NameToLayer("DeathEnemy");
            enemyMove.end = true;
            health = 0;
        }
    }

}
