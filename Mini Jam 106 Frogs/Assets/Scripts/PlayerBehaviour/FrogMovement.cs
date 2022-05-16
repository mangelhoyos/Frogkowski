using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [Header("Cash variables")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform cam;
    [SerializeField] private CameraHandler camHandler;
    [SerializeField] private Animator anim;

    [Header("Player prefs")]
    [SerializeField] private float speed = 6;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3;
    Vector3 velocity;
    bool isGrounded;

    [Header("Ground check settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    [Header("Movement turn settings")]
    float turnSmoothVelocity;
    [SerializeField] private float turnSmoothTime = 0.1f;

    [Header("Sound setup")]
    [SerializeField] private AudioClip walkingClip;
    [SerializeField] private AudioClip jumpPushClip;
    [SerializeField] private AudioClip landJumpClip;
    [SerializeField] private AudioSource playerSource;


    void Start()
    {
        camHandler.LockCamera();
    }

    private bool groundPush = false;
    void Update()
    {
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        anim.SetBool("IsGrounded",isGrounded);
        if(isGrounded && groundPush)
        {
            groundPush = false;
            playerSource.clip = landJumpClip;
            playerSource.Play();
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            if(playerSource.clip != jumpPushClip && !groundPush)
            {
                groundPush = true;
                playerSource.clip = jumpPushClip;
                playerSource.Play();
            }
        }
        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        //walk
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f && playerSource.clip != walkingClip && isGrounded)
        {
            playerSource.clip = walkingClip;
            playerSource.Play();
            playerSource.loop = true;
        }
        else
        {
            if(!isGrounded && playerSource.clip == walkingClip || isGrounded && direction.magnitude < 0.1f && playerSource.clip == walkingClip)
            {
                playerSource.Stop();
                playerSource.clip = null;
                playerSource.loop = false;
            }
        }

        anim.SetFloat("Speed", direction.magnitude);

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}