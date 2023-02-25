using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
public class LookAtPlayerMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Vector3 lookAt;
    [SerializeField]
    private float waitDelay = 1f;
    public Transform destination;
    private Vector3 lookAtPosition;
    private Vector2 velocity;
    private Vector2 smoothDeltaPosition;
    private Animator anim;

    private float lookAtWeight = 0.0f;
    [SerializeField] private bool looking = true;
    [SerializeField] private Transform head = null;
    [SerializeField] private float rotationSpeed = 1;
    [SerializeField] private float lookAtCoolTime = 0.2f;
    [SerializeField] private float lookAtHeatTime = 0.2f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = true;
    }

    private void Start()
    {
        GoToDestination();
        if (!head)
        {
            Debug.LogError("No head transform - LookAt disabled");
            enabled = false;
            return;
        }

        anim = GetComponent<Animator>();
        lookAtPosition = head.position + transform.forward;
    }

    public void GoToDestination()
    {
        lookAt = destination.position + transform.forward;

        
        StartCoroutine(DoMoveToDestination());
    }

    private void OnAnimatorMove()
    {
        Vector3 rootPosition = animator.rootPosition;
        rootPosition.y = transform.position.y; // zmiana wartoœci y
        transform.position = rootPosition;
    }

    private void Update()
    {
        
        SynchronizeAnimator();

        // Obróæ postaæ w kierunku punktu docelowego
        Vector3 lookDirection = (destination.position - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(lookDirection.x, 0, lookDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,1 * Time.deltaTime);
    

    }

    private void SynchronizeAnimator()
    {
        Vector3 worldDeltaPosition = destination.position - transform.position;
        worldDeltaPosition.y = 0;
        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1, Time.deltaTime / 0.1f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f;

        animator.SetBool("move", shouldMove);
        animator.SetFloat("velx", Mathf.Clamp(velocity.x, -1 ,1 ));
        animator.SetFloat("vely", Mathf.Clamp(velocity.y, -1, 1));

        // Calculate look direction
        Vector3 lookDirection = (destination.position - transform.position).normalized;
        lookDirection.y = 0;

    }


    public void StopMoving()
    {
        StopAllCoroutines();
        transform.position = destination.position;
    }

    private IEnumerator DoMoveToDestination()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitDelay);

            destination.position = new Vector3(destination.position.x, destination.position.y, destination.position.z);
           
        }
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

