using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private ClickToMove _clickToMove;
    [FormerlySerializedAs("agent")] [SerializeField] private NavMeshAgent _agent;
    public bool clickToMoveMechanic;

    private Vector2 input;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _clickToMove = GetComponent<ClickToMove>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_animator != null && _clickToMove != null && _agent != null)
        {
            _animator.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }
}