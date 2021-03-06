using System.Collections;
using UnityEngine;

public class AntiAirTower : MonoBehaviour
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
        Vector3[] tmp = new Vector3[2];
        tmp[0] = transform.position;
        tmp[1] = transform.position + Vector3.up * 50.0f; ;
        trail.AddPositions(tmp);
    }

    void UpdateTarget()
    {
        if (target == null || Vector3.Distance(target.transform.position, transform.position) > data.range)
        {
            target = null;
            Collider[] enemysInRange = Physics.OverlapSphere(transform.position+Vector3.up*data.range, data.range, mask);
            float shortestDitance = float.MaxValue;
            Collider closestEnemy = null;
            foreach (Collider k in enemysInRange)
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
            trail.Clear();
            trail.transform.position = transform.position;
            StartCoroutine("Fire");
            target.GetDMG(data.damage);
        }
    }

    IEnumerator Fire()
    {
        while(target != null && Vector3.Distance(trail.transform.position, target.transform.position) > 0.2f )
        {
            trail.transform.position += (target.transform.position - transform.transform.position).normalized * 20.0f * Time.deltaTime;
            yield return null;
        }
    }
}
