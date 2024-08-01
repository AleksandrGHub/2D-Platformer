using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(Spawner), typeof(CircleCollider2D))]

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out _))
        {
            Destroy(gameObject);
        }
    }
}