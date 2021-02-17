using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Action Limits")]
    [SerializeField] public GolemColor selectedColor = new GolemColor { };
    [SerializeField] public int redMove, redRotate, redPush, redPlace, greenMove, greenRotate, greenPush, greenPlace;
    [HideInInspector] public int exRedMove, exRedRotate, exRedPush, exRedPlace, exGreenMove, exGreenRotate, exGreenPush, exGreenPlace;

    [SerializeField] SawBlock firstSaw;

    private void Start()
    {
        selectedColor = GolemColor.Red;
        exRedMove = redMove;
        exRedRotate = redRotate;
        exRedPush = redPush;
        exRedPlace = redPlace;
        exGreenMove = greenMove;
        exGreenRotate = greenRotate;
        exGreenPush = greenPush;
        exGreenPlace = greenPlace;
    }

    public void StartBelt()
    {
        firstSaw.ReceiveSaw();
    }
}
