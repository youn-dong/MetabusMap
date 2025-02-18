using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Camera maincamera;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 5f;
    protected Rigidbody2D _rigidbody;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    [SerializeField] CameraFollow cameraFollow;
    protected virtual void Awake()
    {
            maincamera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
    }
    protected void Start()
    {
        if(cameraFollow != null)
        {
            cameraFollow.SetCamera(transform); // cameraFollow 스크립트를 통해서 player와 연결
        }
    }
    protected void Update()
    {
        HandleAction();
        Movement(movementDirection);
    }
    protected void HandleAction()       
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = maincamera.ScreenToWorldPoint(mousePosition);
    }
    private void Movement(Vector2 direction)
    {
        _rigidbody.velocity = direction * speed ; //player의 이동속도
    }
}
