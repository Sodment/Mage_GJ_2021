using UnityEngine;

public class EndlessWaveGenerator : MonoBehaviour
{
    public static EndlessWaveGenerator instance;
    public GameObject[] enemyTypes;
    void Start()
    {
        instance = this;
    }

    public EnemySpawner.Wave RandomWaveGen(int level)
    {
        EnemySpawner.Wave ret = new EnemySpawner.Wave();
        ret.SubWave = new EnemySpawner.Subwave[Random.Range(level / 2, level + (level / 2))];

        for(int i=0; i < ret.SubWave.Length; i++)
        {
            ret.SubWave[i].Count = Random.Range(level, level * 2);
            int enemy = (Random.Range(0, enemyTypes.Length) + Random.Range(0, enemyTypes.Length)) / 2;
            ret.SubWave[i].Enemy = enemyTypes[enemy];
        }

        return ret;
    }
}
