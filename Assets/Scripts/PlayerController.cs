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

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

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
            cameraFollow.SetCamera(transform); // cameraFollow ��ũ��Ʈ�� ���ؼ� player�� ����
        }
    }
    protected void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        Movement(movementDirection);
    }
    protected void HandleAction()       
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = maincamera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);
    }
    private void Movement(Vector2 direction)
    {
        _rigidbody.velocity = direction * speed ; //player�� �̵��ӵ�
    }
    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
        spriteRenderer.flipX = rotZ > 90f || rotZ < -90f; // ��ȯ�� Rad���� 90���� �ʰ��ϸ� true�� ������ ������
                                                          // ��ȯ�� ���� -90�� �̸��̶�� false�� �������� ������
    }
}
