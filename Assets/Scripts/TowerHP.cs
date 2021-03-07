using UnityEngine;

public class TowerHP : MonoBehaviour
{
    public float health = 100.0f;
    public static TowerHP instance;

    private void Awake()
    {
        if (instance != null) Destroy(instance);
        instance = this;
    }
    public void GetDMG(float value)
    {
        health -= value;
        if (health <= 0.0f)
        {
            OnDie();
        }
    }

    void OnDie()
    {
        GameLoopMenager.instance.GameOver();
        Destroy(gameObject); //tmp
    }
}
