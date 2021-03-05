using UnityEngine;

public class Turret : MonoBehaviour
{
    EnemyHP target;
    public float range = 5.0f;
    public LayerMask mask;

    public float reload;
    public float dmg;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, reload);
    }

    void UpdateTarget()
    {
        if(target == null || Vector3.Distance(target.transform.position, transform.position) > range)
        {
            target = null;
            Collider[] enemysInRange = Physics.OverlapSphere(transform.position, range, mask);
            float shortestDitance = float.MaxValue;
            Collider closestEnemy=null;
            foreach(Collider k in enemysInRange)
            {
                float tmp = Vector3.Distance(k.transform.position, TowerHP.instance.transform.position);
                if (tmp < shortestDitance)
                {
                    shortestDitance = tmp;
                    closestEnemy = k;
                }
            }
            if (closestEnemy != null)
            {
                target = closestEnemy.gameObject.GetComponent<EnemyHP>(); 
            }
        }

        if (target != null)
        {
            target.GetDMG(dmg);
        }
    }
}
