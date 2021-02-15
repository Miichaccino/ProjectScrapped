using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public ObjectiveButton[] buttonPressed;
    public Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(checkAllButtons() == true)
        {
            gameObject.transform.position += transform.up * 0.01f;
        }

        if(checkAllButtons() == false)
        {
            gameObject.transform.position = originalPosition;
        }
    }

    public bool checkAllButtons()
    {
        foreach (var button in buttonPressed)
        {
            if(button.pressed == false)
            {
                return false;
            }
        }
        return true;
    }
}
