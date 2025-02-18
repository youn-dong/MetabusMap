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

        animator.SetBool("IsLeft", false); //��� �⺻���� �ϴ� false�� set
        animator.SetBool("IsRight", false);
        animator.SetBool("IsDown", false);
        animator.SetBool("IsUp", false);

        if (movementInput.x > 0) //x����� �˻��ؼ� 
        {
            animator.SetBool("IsLeft", true); //���������� �̵��ϴ� Spirte�� �����Ƿ� 
            spriteRenderer.flipX = true;   // �������� �̵��ϴ� Spirte�� ���ؼ� flip�� �̿��Ͽ� �¿� ��������
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

