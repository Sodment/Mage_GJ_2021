using UnityEngine;
[CreateAssetMenu(fileName = "TowerData", menuName = "Tower", order = 1)]
public class TowerData : ScriptableObject
{
    public float range;
    public float reload;
    public float damage;
    public LayerMask targetMask;
}
