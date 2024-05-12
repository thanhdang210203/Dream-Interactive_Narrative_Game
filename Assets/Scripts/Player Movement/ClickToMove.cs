using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private InputAction mouseClickAction;
    private NavMeshAgent agent;
    private Animator _animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        _animator.SetFloat("Speed", agent.velocity.magnitude);
    }


    private void OnMouseClick(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() > 0) // Check if the left mouse button is clicked
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (agent != null && agent.hasPath)
        {
            Gizmos.color = Color.red;
            for (int i = 0; i < agent.path.corners.Length - 1; i++)
            {
                Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i + 1]);
            }
        }
    }
}