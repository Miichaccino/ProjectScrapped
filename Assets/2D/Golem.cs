using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GolemColor {Red, Green, Black}

public class Golem : MonoBehaviour
{
    [SerializeField] static GolemColor selectedColor = new GolemColor { };
    [SerializeField] public GolemColor type = new GolemColor {};

    [SerializeField] float MoveDistance = 1;

    SpriteRenderer sprite;

    [HideInInspector] public bool objectInFront;
    [HideInInspector] public bool objectInBack;
    [HideInInspector] public bool golemInFront;

    public GameObject frontGolem;
    
    [SerializeField] GameObject pushPosition;

    private void Start()
    {
        selectedColor = GolemColor.Red;
        sprite = gameObject.GetComponent<SpriteRenderer>();

        
    }


    private void Update()
    {
        switch (type)
        {
            case GolemColor.Red:
                sprite.color = Color.red;
                break;
            case GolemColor.Green:
                sprite.color = Color.green;
                break;
            case GolemColor.Black:
                sprite.color = Color.grey;
                break;
            default:
                break;
        }

        if (Input.GetKeyDown(KeyCode.W) && selectedColor.Equals(type) && !objectInFront)
        {
            transform.position += transform.up * MoveDistance; 
        }

        if (Input.GetKeyDown(KeyCode.S) && selectedColor.Equals(type) && !objectInBack)
        {
            transform.position += transform.up * -MoveDistance;
        }

        if (Input.GetKeyDown(KeyCode.A) && selectedColor.Equals(type))
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }

        if (Input.GetKeyDown(KeyCode.D) && selectedColor.Equals(type))
        {
            transform.Rotate(new Vector3(0, 0, -90));
        }

        if (Input.GetKeyDown(KeyCode.E) && selectedColor.Equals(type) && golemInFront && frontGolem != null)
        {
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
