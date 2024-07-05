using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private InputAction mouseClickAction;
    private NavMeshAgent _agent;
    private Animator _animator;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        mouseClickAction.Enable();
        mouseClickAction.performed += OnMouseClick;
    }

    private void OnDisable()
    {
        mouseClickAction.Disable();
        mouseClickAction.performed -= OnMouseClick;
    }
    
    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }


    private void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0) // Check if the left mouse button is clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _agent.SetDestination(hit.point);
                AudioManager.instance.PlaySoundEffect(7);
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (_agent != null && _agent.hasPath)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < _agent.path.corners.Length - 1; i++)
            {
                Gizmos.DrawLine(_agent.path.corners[i], _agent.path.corners[i + 1]);
            }
        }
    }
}