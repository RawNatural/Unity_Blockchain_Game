using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 100f;

    Transform cameraT;
    Transform player;
    float verticalLookRotation;
    bool firstPerson;

    Rigidbody rb;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    void Start()
    {
        cameraT = Camera.main.transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        firstPerson = true; //change this to be settable in settings menu.
        changeView();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraT.localEulerAngles = Vector3.left * verticalLookRotation;

        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        Vector3 targetMoveAmount = moveDir * walkSpeed;
        moveAmount = Vector3.SmoothDamp(targetMoveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);


        //CURRENTLY I AM HERE. IF DELETED FROM CHROME HISTORY, USE LINK https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#jump_without_rigidbody,
        //AND SEARCH "TRANSFORM" TO FIND WHERE I AM AT. SEE BELOW WHERE AT...

        if (Input.GetKeyDown(KeyCode.P))
        {
            changeView();
        }
    }


    void changeView()
    {
        if (firstPerson)
        {
            cameraT.localPosition -= new Vector3(0, -1, 10); // set camera postion to slightly behind player position;
            cameraT.LookAt(player);
            firstPerson = false;
        }
        else if (!firstPerson)
        {
            cameraT.localPosition = Vector3.zero; // set camera to players position.
            firstPerson = true;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    private void LateUpdate()
    {
        cameraT.LookAt(player);
    }
}
