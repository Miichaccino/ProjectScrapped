using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHole : MonoBehaviour
{
    [SerializeField] GolemColor type = new GolemColor { };
    SpriteRenderer sprite;
    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();

        switch (type)
        {
            case GolemColor.Red:
                sprite.color = Color.red;
                break;
            case GolemColor.Green:
                sprite.color = Color.green;
                break;
            default:
                break;
        }
    }
    void ChangeGolem(Golem golem)
    {
        golem.type = type;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Golem")
        {
            ChangeGolem(collision.gameObject.GetComponent<Golem>());
        }
    }
}
