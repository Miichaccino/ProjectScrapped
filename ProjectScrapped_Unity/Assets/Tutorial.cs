using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] bool blockPlayerAction;
    bool movingTutorialCompleted, EngineTutorialCompleted, cameraTutorialCompleted;
    bool movedW, movedS, movedA, movedD;
    bool enteredEngineMode;
    bool cameraW, cameraS, cameraA, cameraD;

    [Header("Moving")]
    [SerializeField] GameObject MovingTutorial;
    [SerializeField] Toggle moveWToggle, moveSToggle, moveAToggle, moveDToggle;
    [Header("Engine Mode")]
    [SerializeField] GameObject EngineModetutorial;
    [SerializeField] Toggle enteredEngineModeToggle;
    [Header("Camera")]
    [SerializeField] GameObject MovingCameraTutorial;
    [SerializeField] Toggle cameraWToggle, cameraSToggle, cameraAToggle, cameraDToggle;


    CharacterController controller;
    InputController input;

    private void Awake()
    {
        controller = FindObjectOfType<CharacterController>();
        input = FindObjectOfType<InputController>();
        movingTutorialCompleted = false;
        EngineTutorialCompleted = false;
        cameraTutorialCompleted = false;
    }

    private void Start()
    {
        if(blockPlayerAction)
        {
            StartCoroutine(WaitForTutorial(5));
        }
        else
        {
            input.canMove = true;
        }

        MovingTutorial.SetActive(true);
        MovingCameraTutorial.SetActive(false);
        EngineModetutorial.SetActive(false);
        
    }

    private void Update()
    {
        #region Toggles
        if (input.canMove)
        {
            if(MovingTutorial.activeInHierarchy)
            {
                if(Input.GetKeyDown(KeyCode.W))
                {
                    movedW = true;
                    moveWToggle.isOn = true;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    movedS = true;
                    moveSToggle.isOn = true;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    movedA = true;
                    moveAToggle.isOn = true;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    movedD = true;
                    moveDToggle.isOn = true;
                }

            }
        }

        if(EngineModetutorial.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                enteredEngineMode = true;
                enteredEngineModeToggle.isOn = true;
            }
        }

         if (MovingCameraTutorial.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                cameraW = true;
                cameraWToggle.isOn = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                cameraS = true;
                cameraSToggle.isOn = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                cameraA = true;
                cameraAToggle.isOn = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                cameraD = true;
                cameraDToggle.isOn = true;
            }

        }
        #endregion

        if(!movingTutorialCompleted &&movedW &&movedS && movedA &&movedD)
        {
            movingTutorialCompleted = true;
            MovingTutorial.SetActive(false);
            EngineModetutorial.SetActive(true);
        }

        if(!EngineTutorialCompleted && enteredEngineMode)
        {
            EngineTutorialCompleted = true;
            EngineModetutorial.SetActive(false);
            MovingCameraTutorial.SetActive(true);
        }

        if(!cameraTutorialCompleted && cameraW && cameraA && cameraS && cameraD)
        {
            cameraTutorialCompleted = true;
            MovingCameraTutorial.SetActive(false);
        }
    }

    IEnumerator WaitForTutorial(float waitTime)
    {
        input.canMove = false;
        yield return new WaitForSeconds(waitTime);
        input.canMove = true;
    }
}
