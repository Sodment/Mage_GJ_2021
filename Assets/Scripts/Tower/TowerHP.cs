using UnityEngine;

public class TowerHP : MonoBehaviour
{
    float maxHP;
    public float health = 100.0f;
    public static TowerHP instance;

    private void Awake()
    {
        maxHP = health;
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
        UIMenager.instance.UpdateHealthBar((float)health / (float)maxHP);
    }

    void OnDie()
    {
        GameLoopMenager.instance.GameOver();
        Destroy(gameObject); //tmp
    }
}
