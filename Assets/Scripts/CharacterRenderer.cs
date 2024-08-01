using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]

public class CharacterRenderer : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _sprite;

    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            _sprite.flipX = true;
        }

        if (direction < 0)
        {
            _sprite.flipX = false;
        }
    }

    public void SetStateRun(float direction)
    {
        _animator.SetBool(AnimatorController.State.Run, direction != 0);
    }

    public void SetStateJump()
    {
        _animator.SetTrigger(AnimatorController.State.Jump);
    }
}