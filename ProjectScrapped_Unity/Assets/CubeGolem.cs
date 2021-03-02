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

    [SerializeField] GameObject sawMill;
    [SerializeField] GameObject frontCheck;
    public GameObject frontObject;
    
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
                    gameManager.exRedMove -= 1;
                }
                if (Input.GetKeyDown(KeyCode.S) && gameManager.selectedColor.Equals(type) && !objectInBack && gameManager.exRedMove > 0)
                {
                    transform.position += transform.right * -MoveDistance;
                    gameManager.exRedMove -= 1;
                }

                if (Input.GetKeyDown(KeyCode.A) && gameManager.selectedColor.Equals(type) && gameManager.exRedRotate > 0)
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                    gameManager.exRedRotate -= 1;
                }

                if (Input.GetKeyDown(KeyCode.D) && gameManager.selectedColor.Equals(type) && gameManager.exRedRotate > 0 )
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                    gameManager.exRedRotate -= 1;
                }
                if (Input.GetKeyDown(KeyCode.E) && gameManager.selectedColor.Equals(type) && golemInFront && frontObject != null && gameManager.exRedPush > 0 )
                {
                    frontObject.transform.position = pushPosition.transform.position;
                    gameManager.exRedPush -= 1;
                }
                if (Input.GetKeyDown(KeyCode.Q) && gameManager.selectedColor.Equals(type) && !objectInFront && gameManager.exRedPlace > 0)
                {
                    GameObject saw = sawMill;
                    Instantiate(saw, frontCheck.transform.position, Quaternion.identity);
                    gameManager.exRedPlace -= 1;

                }
                break;
            case GolemColor.Green:
                if (Input.GetKeyDown(KeyCode.W) && gameManager.selectedColor.Equals(type) && !objectInFront && gameManager.exGreenMove > 0)
                {
                    transform.position += transform.right * MoveDistance;
                    gameManager.exGreenMove -= 1;
                }

                if (Input.GetKeyDown(KeyCode.S) && gameManager.selectedColor.Equals(type) && !objectInBack && gameManager.exGreenMove > 0)
                {
                    transform.position += transform.right * -MoveDistance;
                    gameManager.exGreenMove -= 1;
                }

                if (Input.GetKeyDown(KeyCode.A) && gameManager.selectedColor.Equals(type) && gameManager.exGreenRotate > 0)
                {
                    transform.Rotate(new Vector3(0, -90, 0));
                            gameManager.exGreenRotate -= 1;
                }

                if (Input.GetKeyDown(KeyCode.D) && gameManager.selectedColor.Equals(type) && gameManager.exGreenRotate > 0)
                {
                    transform.Rotate(new Vector3(0, 90, 0));
                            gameManager.exGreenRotate -= 1;
                }
                if (Input.GetKeyDown(KeyCode.E) && gameManager.selectedColor.Equals(type) && golemInFront && frontObject != null && gameManager.exGreenPush > 0)
                {
                    frontObject.transform.position = pushPosition.transform.position;
                            gameManager.exGreenPush -= 1;
                }

                if (Input.GetKeyDown(KeyCode.Q) && gameManager.selectedColor.Equals(type) && !objectInFront && gameManager.exGreenPlace > 0)
                {
                    GameObject saw = sawMill;
                    Instantiate(saw, frontCheck.transform.position, Quaternion.identity);
                    saw.transform.Rotate(0, 90, 0);
                    gameManager.exGreenPlace -= 1;
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
