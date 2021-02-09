using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveButton : MonoBehaviour
{
    public GameObject dataHole1;
    public GameObject dataHole2;
    public GameObject dataHole3;

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
            dataHole1.GetComponent<CubeDataHole>().type = GolemColor.Green;
            dataHole2.GetComponent<CubeDataHole>().type = GolemColor.Green;
            dataHole3.GetComponent<CubeDataHole>().type = GolemColor.Red;
        }
    }
}
