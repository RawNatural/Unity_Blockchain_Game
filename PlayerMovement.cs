using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** There's a really nice use of classes involved in this script
 * See below in groundcheck class
 */


/**The normal movement class
 */
public class PlayerMovement : MonoBehaviour
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

    void Start() {
        cameraT = Camera.main.transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        firstPerson = true; //change this to be settable in settings menu.
        changeView();
    }

    public float jumpForce = 2000;
    public float gravity = -9.81f;
    public float gravityScale = 5;
    public GroundCheck groundCheck;
    float velocityVertical;
    void Update() {
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

        velocityVertical += gravity * gravityScale * Time.deltaTime;
        //If is grounded, no velocityVertical
        if (groundCheck.isGrounded && velocityVertical < 0)
        {
            print("velocityVertical < 0");
            velocityVertical = 0;
        }
        //JUMP
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocityVertical = jumpForce;
        }
    
        
        player.Translate(new Vector3(0, velocityVertical, 0) * Time.deltaTime);
    }

    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
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
    private void LateUpdate()
    {
        cameraT.LookAt(player);
    }

    






}

/**The nice class usage thing*/
public class GroundCheck : MonoBehaviour
{
    public float distanceToCheck = 2.0f;
    public bool isGrounded;
    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, distanceToCheck))
        {
            isGrounded = true;
            print("IS GROUNDED");
        }
        else
        {
            isGrounded = false;
        }
    }
}