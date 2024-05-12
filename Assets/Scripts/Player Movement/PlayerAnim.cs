using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private ClickToMove _clickToMove;
    [FormerlySerializedAs("agent")] [SerializeField] private NavMeshAgent _agent;
    public bool clickToMoveMechanic;

    private Vector2 input;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
        _clickToMove = GetComponent<ClickToMove>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (clickToMoveMechanic)
        {
            _playerMovement.enabled = false;
            _clickToMove.enabled = true;
            _animator.SetTrigger("ClickToMove");
            //ClickToMoveAnim();
        }
        else
        {
            _playerMovement.enabled = true;
            _clickToMove.enabled = false;
            PlayerMovementAnim();
        }
    }

    private void ClickToMoveAnim()
    {
        if (_animator != null && _clickToMove != null && _agent != null)
        {
            _animator.SetFloat("Speed", _agent.velocity.magnitude);
        }
    }

    private void PlayerMovementAnim()
    {
        if (_animator != null && _playerMovement != null)
        {
            input.x = Keyboard.current.aKey.isPressed ? -1 : (Keyboard.current.dKey.isPressed ? 1 : 0);
            input.y = Keyboard.current.wKey.isPressed ? 1 : (Keyboard.current.sKey.isPressed ? -1 : 0);
            if (_animator != null && _playerMovement != null)
            {
                _animator.SetFloat("InputX", input.x);
                _animator.SetFloat("InputY", input.y);
            }
        }
    }
}