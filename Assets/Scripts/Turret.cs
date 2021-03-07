using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    TowerData data;
    EnemyHP target;
    public LayerMask mask;
    TrailRenderer trail;
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, data.reload);
        trail = GetComponentInChildren<TrailRenderer>();
    }

    void UpdateTarget()
    {
        if((target == null || Vector3.Distance(target.transform.position, transform.position) > data.range) && TowerHP.instance!=null)
        {
            target = null;
            Collider[] enemysInRange = Physics.OverlapSphere(transform.position, data.range, mask);
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
            trail.transform.position = transform.position + Vector3.up * 1.2f;
            trail.Clear();
            StartCoroutine("Fire");
        }
    }

    IEnumerator Fire()
    {
        float lastDist = float.MaxValue;
        Vector3 dir = (target.transform.position - trail.transform.position).normalized * 20.0f;
        while (target != null)
        {
            float dist = Vector3.Distance(trail.transform.position, target.transform.position);
            if (dist > lastDist)
            {
                target.GetDMG(data.damage);
                break;
            }
            lastDist = dist;
            trail.transform.position += dir * Time.deltaTime;
            yield return null;
        }
    }
}