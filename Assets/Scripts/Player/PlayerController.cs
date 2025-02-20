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

    private float minX = -10f, maxX = 38f;
    private float minY = -5f, maxY = 25f;
    protected virtual void Awake()
    {
            maincamera = Camera.main;
            _rigidbody = GetComponent<Rigidbody2D>();
    }
    protected void Start()
    {
        if(cameraFollow != null)
        {
            cameraFollow.SetCamera(transform); // cameraFollow ��ũ��Ʈ�� ���ؼ� player�� ����
        }
    }
    protected void Update()
    {
        HandleAction();
       
    }
    protected void FixedUpdate()
    {
        Movement(movementDirection);
    }
    protected void HandleAction()       
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;
    }
    private void Movement(Vector2 direction)
    {
        Vector2 newPosition = _rigidbody.position + direction * speed * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        _rigidbody.MovePosition(newPosition);
        //_rigidbody.velocity = direction * speed ; //player�� �̵��ӵ�
    }
}
