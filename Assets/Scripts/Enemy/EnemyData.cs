using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public float movementSpeed;
    public float attack;
    public float attackCooldown;
    public float attackRange;
    public float health;
    public float reward;
}