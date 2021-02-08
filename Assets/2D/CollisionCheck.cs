using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] bool front;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Button")
        {
            if (front)
            {
                GetComponentInParent<Golem>().objectInFront = true;
            }
            if (!front)
            {
                GetComponentInParent<Golem>().objectInBack = true;
            }

            if (collision.gameObject.tag == "Golem")
            {
                GetComponentInParent<Golem>().golemInFront = true;
                GetComponentInParent<Golem>().frontGolem = collision.gameObject;
            }
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (front)
        {
            GetComponentInParent<Golem>().objectInFront = false;
        }
        if (!front)
        {
            GetComponentInParent<Golem>().objectInBack = false;
        }
        if (collision.gameObject.tag == "Golem")
        {
            GetComponentInParent<Golem>().golemInFront = false;
            GetComponentInParent<Golem>().frontGolem = null;
        }
    }
}
