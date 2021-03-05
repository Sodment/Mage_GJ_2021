using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 target;
    public float speed = 5.0f;
    public LayerMask towerMask;
    float distance = 1.5f;
    List<Vector3> towersPoints = new List<Vector3>();
    void Start()
    {
        InvokeRepeating("UpdateState", 0.0f, 1 / speed);
        target = GameObject.FindGameObjectWithTag("EnemyTarget").transform.position - (GameObject.FindGameObjectWithTag("EnemyTarget").transform.position - transform.position).normalized*distance;
    }

    void UpdateState()
    {
        towersPoints.RemoveRange(0,towersPoints.Count);
        Collider[] towers = Physics.OverlapSphere(transform.position, speed + 1, towerMask);
        foreach(Collider k in towers)
        {
            towersPoints.Add(k.transform.position);
        }
    }
    void Update()
    {
        if (TowerHP.instance != null)
        {
            Vector3 direction = TowerHP.instance.transform.position - transform.position;
            direction.y = 0;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

            Vector3 missTowers = Vector3.zero;
            for (int i = 0; i < towersPoints.Count; i++)
            {
                if (Vector3.Distance(transform.position, TowerHP.instance.transform.position) < Vector3.Distance(TowerHP.instance.transform.position, towersPoints[i])) continue;
                float tmp = Vector3.Magnitude(transform.position - towersPoints[i]);
                Vector3 additive = Vector3.Cross((transform.position - towersPoints[i]).normalized, Vector3.up) * 20.0f / (tmp * tmp);

                if (Vector3.Distance(transform.position + additive, TowerHP.instance.transform.position) < Vector3.Distance(transform.position - additive, TowerHP.instance.transform.position))
                { missTowers += Vector3.Cross((transform.position - towersPoints[i]).normalized, Vector3.up) * 20.0f / (tmp * tmp); }
                else { missTowers -= Vector3.Cross((transform.position - towersPoints[i]).normalized, Vector3.up) * 20.0f / (tmp * tmp); }
            }
            transform.Translate(ShortNormal((target - transform.position) * 0.5f + missTowers * 0.5f) * speed * Time.deltaTime, Space.World);
        }
    }

    Vector3 ShortNormal(Vector3 vec)
    {
        if (vec.magnitude < 1.0f)
            return vec;
        else return vec.normalized;
    }
}
