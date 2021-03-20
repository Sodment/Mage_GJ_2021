using UnityEngine;

public class EnemySkyMovement : EnemyMovement
{
    EnemyAnimationController animControl;
    EnemyParticleController particleControl;

    Vector3 target;
    void Start()
    {
        animControl = GetComponent<EnemyAnimationController>();
        particleControl = GetComponent<EnemyParticleController>();
        Vector3 tmp = TowerHP.instance.transform.position - transform.position;
        tmp.y = 0;
        target = TowerHP.instance.transform.position - tmp.normalized * (distance-4);
        target.y = transform.position.y;
    }

    void Update()
    {
        if (Vector3.Distance(target, transform.position) > 0.7f)
        {
            Vector3 direction = (target - transform.position).normalized;
            direction.y = 0;
            transform.Translate(ShortNormal(direction) * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
        else
        {
            particleControl.EnableParticle();
            animControl.SwitchToState("Attack");
        }
    }
    Vector3 ShortNormal(Vector3 vec)
    {
        if (vec.magnitude < 1.0f)
            return vec;
        else return vec.normalized;
    }
}
