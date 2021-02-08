using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float moveDistance = 1f;
    CubeGolem golem;

    // Start is called before the first frame update
    void Start()
    {
        golem = FindObjectOfType<CubeGolem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Golem")
        {
            golem = other.gameObject.GetComponent<CubeGolem>();
            StartCoroutine("MovePlayer");
            
            //other.gameObject.transform.position += -transform.forward * moveDistance; 
        }
    }

    IEnumerator MovePlayer()
    {
        yield return new WaitForSeconds(1f);
        golem.gameObject.transform.position += -transform.forward * moveDistance;
        
    }
}
