using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private Vector2 movementInput;
    [SerializeField] SpriteRenderer spriteRenderer;

    protected void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    protected void Update()
    {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        animator.SetBool("IsLeft", false); //모든 기본값을 일단 false로 set
        animator.SetBool("IsRight", false);
        animator.SetBool("IsDown", false);
        animator.SetBool("IsUp", false);

        if (movementInput.x > 0) //x축부터 검사해서 
        {
            animator.SetBool("IsLeft", true); //오른쪽으로 이동하는 Spirte가 없으므로 
            spriteRenderer.flipX = true;   // 왼쪽으로 이동하는 Spirte를 통해서 flip를 이용하여 좌우 반전으로
        }
        else if (movementInput.x < 0)
        {
            animator.SetBool("IsLeft", true);
            spriteRenderer.flipX = false;
        }
        else if (movementInput.y > 0)
            animator.SetBool("IsUp", true);
        else if (movementInput.y < 0)
            animator.SetBool("IsDown", true);
    }

}

