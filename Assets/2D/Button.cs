using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool pressed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            pressed = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Golem")
        {
            pressed = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }
}
