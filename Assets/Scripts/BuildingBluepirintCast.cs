using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBluepirintCast : MonoBehaviour
{

    RaycastHit hit;
    public GameObject buildingPrefab;
    public MeshRenderer blueprintRenderer;
    public Material buildingBlockedMaterial;
    public Material buildingPossibleMaterial;
    int layerMask = 1 << 8;
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
        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 0)))
        {
            transform.position = hit.point;
        }
        bool building_colliding = Physics.CheckBox(transform.position, new Vector3(2.0f, 0.0f, 2.0f), Quaternion.identity, layerMask);
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
        Instantiate(buildingPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void BuildingBlocked()
    {
        blueprintRenderer.material = buildingBlockedMaterial;
    }

    public void BuildingPossible()
    {
        blueprintRenderer.material = buildingPossibleMaterial;
    }
}
