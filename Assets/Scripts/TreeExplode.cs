using UnityEngine;

public class TreeExplode : MonoBehaviour
{
    public void Explode(Vector3 origin)
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        //Vector3 direction = transform.position - origin;
        rb.AddExplosionForce(500, origin, 5);
        Destroy(gameObject, 2);
    }
}
