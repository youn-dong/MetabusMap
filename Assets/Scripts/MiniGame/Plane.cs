using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    float deathCoolDown = 0f;

    bool isFlap = false;

    public bool GodMode = false;

    private void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if(animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }
        if(_rigidbody == null)
        {
            Debug.LogError("Not Founded RigidBody2D");
        }
    }
    private void Update()
    {
        if(isDead)
        {
            if(deathCoolDown<=0)
            {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
                {
                    //���� ����� �Լ� ȣ��
                }
            }
            else
            {
                deathCoolDown -= Time.deltaTime; 
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;
        
        if(isFlap)
        {
            _rigidbody.velocity = velocity;

            float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90); // y�࿡ �ִ� �߷��� �ӵ��� -90���� 90f ���̷� ����
            float lerpAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angle, Time.fixedDeltaTime * 5f);
            transform.rotation = Quaternion.Euler(0, 0, lerpAngle);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (GodMode) return;
        if (isDead) return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCoolDown = 1f;
    }
}
