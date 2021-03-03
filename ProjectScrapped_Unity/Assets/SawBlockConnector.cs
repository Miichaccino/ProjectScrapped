using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlockConnector : MonoBehaviour
{
    SawBlock sawBlock;
    private void Start()
    {
        sawBlock = gameObject.GetComponentInParent<SawBlock>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "SawBlockCheck")
        {
            if(sawBlock.connectedBlocks[0] == null)
            {
                sawBlock.connectedBlocks[0] = other.gameObject.GetComponentInParent<SawBlock>();
            }
            else if (sawBlock.connectedBlocks[1] == null)
            {
                sawBlock.connectedBlocks[1] = other.gameObject.GetComponentInParent<SawBlock>();
            }
            else if (sawBlock.connectedBlocks[2] == null)
            {
                sawBlock.connectedBlocks[2] = other.gameObject.GetComponentInParent<SawBlock>();
            }
            else if (sawBlock.connectedBlocks[3] == null)
            {
                sawBlock.connectedBlocks[3] = other.gameObject.GetComponentInParent<SawBlock>();
            }
        }
    }
}
