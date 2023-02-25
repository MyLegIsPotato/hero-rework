using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class Movement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float rotationSpeed;

    [Header("Look At")]
    [SerializeField] private Transform head = null;
    [SerializeField] private float lookAtCoolTime = 0.2f;
    [SerializeField] private float lookAtHeatTime = 0.2f;
    [SerializeField] private bool looking = true;

    private Vector3 lookAtPosition;
    private Animator anim;
    private float lookAtWeight = 0.0f;

    private void Start()
    {
        if (!head)
        {
            Debug.LogError("No head transform - LookAt disabled");
            enabled = false;
            return;
        }

        anim = GetComponent<Animator>();
        lookAtPosition = head.position + transform.forward;
    }

    private void Update()
    {
        Vector3 movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        Turn();
        Move();
    }

    private void Turn()
    {
        float turnInput = Input.GetAxis("Horizontal");
        turnInput = Mathf.Lerp(anim.GetFloat("velx"), turnInput, Time.deltaTime * 3f);
        anim.SetFloat("velx", turnInput);
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Vertical");
        moveInput = Mathf.Lerp(anim.GetFloat("vely"), moveInput, Time.deltaTime * 2f);
        anim.SetFloat("vely", moveInput);
      
        bool isMoving = Mathf.Abs(moveInput) > 0.01f;
        anim.SetBool("move", isMoving);
    }

    private void OnAnimatorIK()
    {
        lookAtPosition = head.position + transform.forward;
        float lookAtTargetWeight = looking ? 1.0f : 0.0f;

        Vector3 curDir = transform.forward;
        Vector3 futDir = lookAtPosition - head.position;

        curDir = Vector3.RotateTowards(curDir, futDir, 6.28f * Time.deltaTime, float.PositiveInfinity);
        lookAtPosition = head.position + curDir;

        float blendTime = lookAtTargetWeight > lookAtWeight ? lookAtHeatTime : lookAtCoolTime;
        lookAtWeight = Mathf.MoveTowards(lookAtWeight, lookAtTargetWeight, Time.deltaTime / blendTime);
        anim.SetLookAtWeight(lookAtWeight, 0.2f, 0.5f, 0.7f, 0.5f);
        anim.SetLookAtPosition(lookAtPosition);
    }
}
