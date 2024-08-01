using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CharacterMover : MonoBehaviour
{
    private float _speedX;
    private float _jumpForce;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _jumpForce = 320;
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move(float direction)
    {
        _speedX = 150;
        _rigidbody.velocity = new Vector2(_speedX * direction * Time.fixedDeltaTime, _rigidbody.velocity.y);
    }
}