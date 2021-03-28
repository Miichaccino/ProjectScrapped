using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class InputController : MonoBehaviour
    {
        private CharacterController charController;
    public bool canMove;

        void Awake()
        {
            charController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if(canMove)
            {
                // Get input values
                int vertical = Mathf.RoundToInt(Input.GetAxis("Vertical"));
                int horizontal = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
                bool jump = Input.GetKey(KeyCode.Space);
                charController.ForwardInput = vertical;
                charController.TurnInput = horizontal;
                charController.JumpInput = jump;
            } 
        }
    }
