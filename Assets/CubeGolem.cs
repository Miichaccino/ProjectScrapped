using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeGolem : MonoBehaviour
{
    [SerializeField] static GolemColor selectedColor = new GolemColor { };
    [SerializeField] public GolemColor type = new GolemColor {};

    [SerializeField] float MoveDistance = 1;

    MeshRenderer mesh;
    [SerializeField] Material[] materials;

    [HideInInspector] public bool objectInFront;
    [HideInInspector] public bool objectInBack;
    [HideInInspector] public bool golemInFront;

    public GameObject frontGolem;
    
    [SerializeField] GameObject pushPosition;

    private void Start()
    {
        selectedColor = GolemColor.Red;
        mesh = gameObject.GetComponent<MeshRenderer>();
        
    }


    private void Update()
    {
        switch (type)
        {
            case GolemColor.Red:
                mesh.material = materials[1];
                break;
            case GolemColor.Green:
                mesh.material = materials[2];
                break;
            case GolemColor.Black:
                mesh.material = materials[0];
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.W) && selectedColor.Equals(type) && !objectInFront)
        {
            transform.position += transform.right * MoveDistance; 
        }

        if (Input.GetKeyDown(KeyCode.S) && selectedColor.Equals(type) && !objectInBack)
        {
            transform.position += transform.right * -MoveDistance;
        }

        if (Input.GetKeyDown(KeyCode.A) && selectedColor.Equals(type))
        {
            transform.Rotate(new Vector3(0, -90, 0));
        }

        if (Input.GetKeyDown(KeyCode.D) && selectedColor.Equals(type))
        {
            transform.Rotate(new Vector3(0, 90, 0));
        }

        if (Input.GetKeyDown(KeyCode.E) && selectedColor.Equals(type) && golemInFront && frontGolem != null)
        {
            print("Pushing");
            frontGolem.transform.position = pushPosition.transform.position;
        }
    }

    public void ToggleSelectedGolem()
    {
       switch (selectedColor)
        {
            case GolemColor.Red:
                selectedColor = GolemColor.Green;
                break;
            case GolemColor.Green:
                selectedColor = GolemColor.Red;
                    break;
        }
    }
}
