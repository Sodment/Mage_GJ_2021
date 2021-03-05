using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickBuild : MonoBehaviour
{
    public GameObject prefab;
    public void Place()
    {
        Instantiate(prefab);
    }
}
