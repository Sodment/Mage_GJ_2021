using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public Wave[] GameScenario;
    public float distnce = 7.0f;

    [System.Serializable]
    public struct Wave
    {
        public Subwave[] SubWave;
    }
    [System.Serializable]
    public struct Subwave
    {
        public GameObject Enemy;
        public int Count;
    }

    public int Level=0;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    public void SpawnLevel()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        if (Level < GameScenario.Length)
        {
            for (int i = 0; i < GameScenario[Level].SubWave.Length; i++)
            {
                for (int j = 0; j < GameScenario[Level].SubWave[i].Count; j++)
                {
                    GameObject go = (GameObject)Instantiate(GameScenario[Level].SubWave[i].Enemy);
                    float Alpha = Random.Range(60.0f, 240.0f) * Mathf.Deg2Rad;
                    go.transform.position = new Vector3(Mathf.Sin(Alpha) * distnce, go.transform.position.y, Mathf.Cos(Alpha) * distnce);
                    yield return new WaitForSecondsRealtime(0.2f);
                }
            }
        }
        else
        {
            Wave randomWave = EndlessWaveGenerator.instance.RandomWaveGen(Level);
            for (int i = 0; i < randomWave.SubWave.Length; i++)
            {
                for (int j = 0; j < randomWave.SubWave[i].Count; j++)
                {
                    GameObject go = (GameObject)Instantiate(randomWave.SubWave[i].Enemy);
                    float Alpha = Random.Range(60.0f, 240.0f) * Mathf.Deg2Rad;
                    go.transform.position = new Vector3(Mathf.Sin(Alpha) * distnce, go.transform.position.y, Mathf.Cos(Alpha) * distnce);
                    yield return new WaitForSecondsRealtime(0.2f);
                }
            }
        }
        Level++;
    }
}
