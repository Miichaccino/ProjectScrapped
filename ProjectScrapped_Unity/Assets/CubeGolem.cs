using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeGolem : MonoBehaviour
{
    
    [SerializeField] public GolemColor type = new GolemColor {};

    [SerializeField] float MoveDistance = 1;

    MeshRenderer mesh;
    [SerializeField] Material[] materials;

    GameManager gameManager;

    [HideInInspector] public bool objectInFront;
    [HideInInspector] public bool objectInBack;
    [HideInInspector] public bool golemInFront;
    

    
    //[SerializeField] Text exRedMoveText, exRedRotateText, exRedPushText, exGreenMoveText, exGreenRotateText, exGreenPushText;

    public GameObject frontGolem;
    
    [SerializeField] GameObject pushPosition;

    private void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();

        gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    { 
        /*exRedMoveText.text = exRedMove.ToString();
        exRedRotateText.text = exRedRotate.ToString();
        exRedPushText.text = exRedPush.ToString();
        exGreenMoveText.text = exGreenMove.ToString();
        exGreenRotateText.text = exGreenRotate.ToString();
        exGreenPushText.text = exGreenPush.ToString();*/

        switch (type)
        {
            case GolemColor.Red:
                mesh.material = materials[1];
                break;
            case GolemColor.Green:
                mesh.material = materials[2];
                break;
            case GolemColor.Black:
                mesh.material = materials[0];
                break;
            default:
                break;
        }

        

        switch(type)
        {
            case GolemColor.Red:
                if (Input.GetKeyDown(KeyCode.W) && gameManager.selectedColor.Equals(type) && !objectInFront && gameManager.exRedMove > 0)
                {
                    transform.position += transform.right * MoveDistance;
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedMove -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenMove -= 1;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.S) && gameManager.selectedColor.Equals(type) && !objectInBack && gameManager.exRedMove > 0)
                {
                    transform.position += transform.right * -MoveDistance;
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedMove -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenMove -= 1;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.A) && gameManager.selectedColor.Equals(type) && gameManager.exRedRotate > 0)
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedRotate -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenRotate -= 1;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.D) && gameManager.selectedColor.Equals(type) && gameManager.exRedRotate > 0 )
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedRotate -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenRotate -= 1;
                            break;
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && gameManager.selectedColor.Equals(type) && golemInFront && frontGolem != null && gameManager.exRedPush > 0 )
                {
                    frontGolem.transform.position = pushPosition.transform.position;
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedPush -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenPush -= 1;
                            break;
                    }
                }
                break;
            case GolemColor.Green:
                if (Input.GetKeyDown(KeyCode.W) && gameManager.selectedColor.Equals(type) && !objectInFront && gameManager.exGreenMove > 0)
                {
                    transform.position += transform.right * MoveDistance;
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedMove -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenMove -= 1;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.S) && gameManager.selectedColor.Equals(type) && !objectInBack && gameManager.exGreenMove > 0)
                {
                    transform.position += transform.right * -MoveDistance;
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedMove -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenMove -= 1;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.A) && gameManager.selectedColor.Equals(type) && gameManager.exGreenRotate > 0)
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedRotate -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenRotate -= 1;
                            break;
                    }
                }

                if (Input.GetKeyDown(KeyCode.D) && gameManager.selectedColor.Equals(type) && gameManager.exGreenRotate > 0)
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedRotate -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenRotate -= 1;
                            break;
                    }
                }
                if (Input.GetKeyDown(KeyCode.E) && gameManager.selectedColor.Equals(type) && golemInFront && frontGolem != null && gameManager.exGreenPush > 0)
                {
                    frontGolem.transform.position = pushPosition.transform.position;
                    switch (type)
                    {
                        case GolemColor.Red:
                            gameManager.exRedPush -= 1;
                            break;
                        case GolemColor.Green:
                            gameManager.exGreenPush -= 1;
                            break;
                    }
                }
                break;
        }
        
    }

    public void ToggleSelectedGolem()
    {
       switch (gameManager.selectedColor)
        {
            case GolemColor.Red:
                gameManager.selectedColor = GolemColor.Green;
                break;
            case GolemColor.Green:
                gameManager.selectedColor = GolemColor.Red;
                    break;
        }
    }
}
