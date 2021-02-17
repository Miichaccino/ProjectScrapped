using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlock : MonoBehaviour
{
    [SerializeField] Material[] stateColor;
    [SerializeField] public SawBlock[] connectedBlocks = new SawBlock[2];

    MeshRenderer mesh;
    public bool hasSaw;

    private void Start()
    {
        hasSaw = false;
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.material = stateColor[0];
    }
    public void ReceiveSaw()
    {
        foreach (var item in connectedBlocks)
        {
            hasSaw = true;
            mesh.material = stateColor[1];
            if (item != null)
                {
                if (item.hasSaw == true)
                {
                    SawBlock sendingBlock = item;
                }
                if (item.hasSaw == false)
                {
                    StartCoroutine(GiveSaw(item));
                }
            } 
        }

    }

    IEnumerator GiveSaw(SawBlock sawBlock)
    {
        yield return new WaitForSeconds(1);
        sawBlock.ReceiveSaw();
        mesh.material = stateColor[0];
        yield return new WaitForSeconds(0.1f);
        hasSaw = false;
    }

}
