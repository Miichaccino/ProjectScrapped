using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveButton : MonoBehaviour
{
    public GameObject dataHole1;
    public GameObject dataHole2;
    public GameObject dataHole3;

    public bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Golem")
        {
            pressed = true;

            dataHole1.GetComponent<CubeDataHole>().type = GolemColor.Green;
            dataHole2.GetComponent<CubeDataHole>().type = GolemColor.Green;
            dataHole3.GetComponent<CubeDataHole>().type = GolemColor.Red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressed = false;
    }
}
