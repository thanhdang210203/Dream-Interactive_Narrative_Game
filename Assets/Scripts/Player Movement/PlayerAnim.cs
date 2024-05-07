using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _playerMovement;
    private Vector2 input;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
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