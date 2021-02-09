using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDataHole : MonoBehaviour
{
    [SerializeField] public GolemColor type = new GolemColor { };
    MeshRenderer mesh;
    [SerializeField] Material[] materials;
    private void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();

        //switch (type)
        //{
        //   case GolemColor.Red:
        //        mesh.material = materials[0];
        //        break;
        //    case GolemColor.Green:
        //        mesh.material = materials[1];
        //       break;
        //    default:
        //        break;
        //}
    }

    private void Update()
    {
        switch (type)
        {
            case GolemColor.Red:
                mesh.material = materials[0];
                break;
            case GolemColor.Green:
                mesh.material = materials[1];
                break;
            default:
                break;
        }
    }
    void ChangeGolem(CubeGolem golem)
    {
        golem.type = type;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Golem")
        {
            ChangeGolem(collision.gameObject.GetComponent<CubeGolem>());
        }
    }
}
