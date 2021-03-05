using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float health = 100.0f;

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
        //Tutaj wszelkie metody zwi¹zanie z pokonaniem przeciwnika.
        Destroy(gameObject); //tmp
    }
}
