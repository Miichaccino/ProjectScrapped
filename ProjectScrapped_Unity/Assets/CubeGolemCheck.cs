using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGolemCheck : MonoBehaviour
{
    [SerializeField] bool front;

    private void OnTriggerEnter(Collider collision)
    {
            if (collision.gameObject.tag != "Button")
        {
            if (front)
            {
                GetComponentInParent<CubeGolem>().objectInFront = true;
            }
            if (!front)
            {
                GetComponentInParent<CubeGolem>().objectInBack = true;
            }

            if (collision.gameObject.tag == "Golem" || collision.gameObject.tag == "SawBlock")
            {
                GetComponentInParent<CubeGolem>().golemInFront = true;
                GetComponentInParent<CubeGolem>().frontObject = collision.gameObject;
            }
        }
       
    }

    private void OnTriggerExit(Collider collision)
    {
        if (front)
        {
            GetComponentInParent<CubeGolem>().objectInFront = false;
        }
        if (!front)
        {
            GetComponentInParent<CubeGolem>().objectInBack = false;
        }
        if (collision.gameObject.tag == "Golem")
        {
            GetComponentInParent<CubeGolem>().golemInFront = false;
            GetComponentInParent<CubeGolem>().frontObject = null;
        }
    }
}
