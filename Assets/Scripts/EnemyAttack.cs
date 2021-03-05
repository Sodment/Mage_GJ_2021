using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float range = 2.0f;
    public float dmg = 1.0f;
    public float reload = 1.0f;
    float tmpReload;

    private void Update()
    {
        tmpReload -= Time.deltaTime;
        if (tmpReload <= 0)
        {
            Attack();
        }
    }

    void Attack()
    {
        if(TowerHP.instance != null)
        {
            if(Vector3.Distance(transform.position, TowerHP.instance.gameObject.transform.position) < range)
            {
                TowerHP.instance.GetDMG(dmg);
            }
        }
        tmpReload = reload;
    }
}
