using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Vector3 target;
    public float speed = 5.0f;
    float distance = 1.5f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("EnemyTarget").transform.position - (GameObject.FindGameObjectWithTag("EnemyTarget").transform.position - transform.position).normalized*distance;
    }

    // Update is called once per frame
    void Update()
    {
        Ray leftRay = new Ray(transform.position - transform.right * 0.5f, TowerHP.instance.transform.position - transform.position + transform.right);
        Ray leftRay2 = new Ray(transform.position - transform.right * 0.5f, TowerHP.instance.transform.position - transform.position - transform.right);
        Ray rightRay = new Ray(transform.position + transform.right*0.5f, TowerHP.instance.transform.position - transform.position - transform.right );
        Ray rightRay2 = new Ray(transform.position + transform.right * 0.5f, TowerHP.instance.transform.position - transform.position + transform.right);
       /* Debug.DrawLine(leftRay.origin, leftRay.direction * 10.0f + leftRay.origin, Color.blue);
        Debug.DrawLine(leftRay2.origin, leftRay2.direction * 10.0f + leftRay2.origin, Color.green);
        Debug.DrawLine(rightRay.origin, rightRay.direction * 10.0f + rightRay.origin, Color.blue);
        Debug.DrawLine(rightRay2.origin, rightRay2.direction * 10.0f + rightRay2.origin, Color.green);*/
        if (Physics.Raycast(leftRay, speed))
        {
          //  Debug.DrawLine(leftRay.origin, leftRay.direction*speed+ leftRay.origin, Color.red);
            transform.Translate(ShortNormal((target - transform.position).normalized * 0.5f + transform.right * 0.5f) * speed * Time.deltaTime, Space.World);
        }
        else if (Physics.Raycast(leftRay2, speed))
        {
          //  Debug.DrawLine(leftRay2.origin, leftRay2.direction * speed + leftRay2.origin, Color.red);
            transform.Translate(ShortNormal((target - transform.position).normalized * 0.5f + transform.right * 0.5f) * speed * Time.deltaTime, Space.World);
        }
        else if (Physics.Raycast(rightRay, speed))
        {
          //  Debug.DrawLine(rightRay.origin, rightRay.direction * speed + rightRay.origin, Color.red);
            transform.Translate(ShortNormal((target - transform.position).normalized * 0.5f - transform.right * 0.5f) * speed * Time.deltaTime, Space.World);
        }
        else if (Physics.Raycast(rightRay2, speed))
        {
           // Debug.DrawLine(rightRay2.origin, rightRay2.direction * speed + rightRay2.origin, Color.red);
            transform.Translate(ShortNormal((target - transform.position).normalized * 0.5f - transform.right * 0.5f) * speed * Time.deltaTime, Space.World);
        }
        else { transform.Translate(ShortNormal(target - transform.position) * speed * Time.deltaTime, Space.World); }
    }

    Vector3 ShortNormal(Vector3 vec)
    {
        if (vec.magnitude < 1.0f)
            return vec;
        else return vec.normalized;
    }
}
