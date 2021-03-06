using UnityEngine;
public class StormTower : MonoBehaviour
{
    [SerializeField]
    TowerData data;
    public LayerMask mask;
    LineRenderer[] bolts = new LineRenderer[10];

    private void Start()
    {
        for(int i=0; i<10; i++)
        {
            bolts[i] = transform.GetChild(i).gameObject.GetComponent<LineRenderer>();
            bolts[i].positionCount = 7;
        }
        InvokeRepeating("UpdateTarget", 0.0f, data.reload);
        InvokeRepeating("Cleanup", 0.2f, data.reload);

    }

    void UpdateTarget()
    {
        Collider[] enemysInRange = Physics.OverlapSphere(transform.position, data.range, mask);
        int enemyCount = Mathf.Min(10, enemysInRange.Length);
        for(int i=0; i< enemyCount; i++)
        {
            GeneratePath(bolts[i], enemysInRange[i].transform.position, 6);
            enemysInRange[i].GetComponent<EnemyHP>().GetDMG(data.damage / (float)enemyCount);
        }
    }

    void Cleanup()
    {
        for (int i = 0; i < 10; i++)
        {
            bolts[i].SetPosition(0, transform.position);
            bolts[i].SetPosition(1, transform.position);
            bolts[i].SetPosition(2, transform.position);
            bolts[i].SetPosition(3, transform.position);
            bolts[i].SetPosition(4, transform.position);
            bolts[i].SetPosition(5, transform.position);
            bolts[i].SetPosition(6, transform.position);
        }
    }

    void GeneratePath(LineRenderer line, Vector3 EndPos, float points)
    {
        line.SetPosition(0, transform.position + Vector3.up);
        float magnitude = Vector3.Magnitude(EndPos)/ points;
        for (int i = 1; i < points; i++)
        {
            Vector3 tmp = Random.insideUnitSphere * magnitude;
            tmp.y = Mathf.Abs(tmp.y)+1.0f;
            line.SetPosition(i, transform.position + (EndPos*i)/points+tmp);
        }
        line.SetPosition(Mathf.RoundToInt(points), EndPos);
    }
}
