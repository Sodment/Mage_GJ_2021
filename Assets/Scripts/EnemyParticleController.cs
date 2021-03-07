using UnityEngine;

public class EnemyParticleController : MonoBehaviour
{
    [SerializeField]
    GameObject particle;
    
    public void EnableParticle()
    {
        particle.SetActive(true);
    }
}
