using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyHP))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;

    private void Awake()
    {
        GetComponent<EnemyMovement>().speed = data.movementSpeed;
        GetComponent<EnemyMovement>().distance = data.attackRange - 0.1f;
        GetComponent<EnemyAttack>().dmg = data.attack;
        GetComponent<EnemyAttack>().reload = data.attackCooldown;
        GetComponent<EnemyAttack>().range = data.attackRange+0.2f;
        GetComponent<EnemyHP>().health = data.health;
        GetComponent<EnemyHP>().reward = data.reward;
    }
}
