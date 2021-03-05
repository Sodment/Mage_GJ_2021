using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float interval = 3.5f;
    public float distanceFromTower = 7.0f;
    float reload;

    private void Update()
    {
        if (reload <= 0 && TowerHP.instance!=null)
        {
            int enemyToSpawn = Random.Range(3, 10);
            Vector3 tmp;
            for (int i = 0; i < enemyToSpawn; i++)
            {
                tmp = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
                tmp = tmp.normalized * distanceFromTower;
                Instantiate(
                    enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
                    TowerHP.instance.transform.position + tmp,
                    Quaternion.LookRotation(-tmp)
                    );
            }
            reload = interval;
        }
        else
            reload -= Time.deltaTime;
    }
}
