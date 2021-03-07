using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreeRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            child.rotation = Quaternion.Euler(new Vector3(0.0f, Random.Range(0.0f, 13.0f), 0.0f));
        }
    }
}
