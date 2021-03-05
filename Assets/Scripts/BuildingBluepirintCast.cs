using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBluepirintCast : MonoBehaviour
{

    RaycastHit hit;
    Vector3 movePoint;
    public GameObject buildingBlueprint;
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            Debug.Log(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawLine(ray.origin, ray.origin + ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            Debug.Log(transform.position);
        }
        if (Input.GetMouseButtonDown(0))
        {
            BuildBuilding();
        }
    }

    public void BuildBuilding()
    {
        Instantiate(buildingBlueprint, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
