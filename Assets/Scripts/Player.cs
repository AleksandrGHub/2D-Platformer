using UnityEngine;

[RequireComponent(typeof(GroundDetector), typeof(InputReader), typeof(CharacterMover))]
[RequireComponent(typeof(CharacterRenderer))]

public class Player : MonoBehaviour
{
    private GroundDetector _groundDetector;
    private InputReader _inputReader;
    private CharacterMover _mover;
    private CharacterRenderer _characterRenderer;


    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<CharacterMover>();
        _characterRenderer = GetComponent<CharacterRenderer>();
    }

    private void Update()
    {
        _characterRenderer.FlipSprite(_inputReader.Direction);
        _characterRenderer.SetStateRun(_inputReader.Direction);
    }

    private void FixedUpdate()
    {
        if (_inputReader.Direction != 0)
        {
            _mover.Move(_inputReader.Direction);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
            _characterRenderer.SetStateJump();
        }
    }
}