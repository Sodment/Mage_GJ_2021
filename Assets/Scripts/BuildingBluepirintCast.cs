using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBluepirintCast : MonoBehaviour
{

    RaycastHit hit;
    Vector3 movePoint;
    public GameObject buildingBlueprint;
    public MeshRenderer myRenderer;
    public Material buildingBlockedMaterial;
    public Material buildingPossibleMaterial;
    int layerMask = 1 << 6;
    // Start is called before the first frame update
    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 0)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool building_colliding = Physics.CheckBox(transform.position + new Vector3Int(0, 1, 0), new Vector3(4.0f, 0.0f, 4.0f), Quaternion.identity, layerMask);
        //Debug.DrawLine(ray.origin, ray.origin + ray.direction, Color.red);
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 0)))
        {
            transform.position = hit.point;
        }
        if (building_colliding)
        {
            BuildingBlocked();
        }
        else
        {
            BuildingPossible();
        }
        if (Input.GetMouseButtonDown(0) && !building_colliding)
        {
            BuildBuilding();
        }
    }

    public void BuildBuilding()
    {
        Instantiate(buildingBlueprint, transform.position + new Vector3Int(0, 1, 0), transform.rotation);
        Destroy(gameObject);
    }

    public void BuildingBlocked()
    {
        myRenderer.material = buildingBlockedMaterial;
    }

    public void BuildingPossible()
    {
        myRenderer.material = buildingPossibleMaterial;
    }
}
