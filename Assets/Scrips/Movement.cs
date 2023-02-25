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
     

        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
   
        Turn();
        Move();
    }

    private void Turn()
    {
        float turnInput = Input.GetAxis("Horizontal");
        turnInput = Mathf.Lerp(anim.GetFloat("velx"), turnInput, Time.deltaTime * 2f);
        anim.SetFloat("velx", turnInput);
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Vertical");
        moveInput = Mathf.Lerp(anim.GetFloat("vely"), moveInput, Time.deltaTime * 1f);
        anim.SetFloat("vely", moveInput);
      
        bool isMoving = Mathf.Abs(moveInput) > 0.01f;
        anim.SetBool("move", isMoving);
    }


}
