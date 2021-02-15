using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Action Limits")]
    [SerializeField] public GolemColor selectedColor = new GolemColor { };
    [SerializeField] public int redMove, redRotate, redPush, greenMove, greenRotate, greenPush;
    [HideInInspector] public int exRedMove, exRedRotate, exRedPush, exGreenMove, exGreenRotate, exGreenPush;

    private void Start()
    {
        selectedColor = GolemColor.Red;
        exRedMove = redMove;
        exRedRotate = redRotate;
        exRedPush = redPush;
        exGreenMove = greenMove;
        exGreenRotate = greenRotate;
        exGreenPush = greenPush;
    }

}
