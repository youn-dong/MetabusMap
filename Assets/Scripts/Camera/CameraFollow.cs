using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed = 0.1f;
    private Camera maincamera;

    protected void Start()
    {
        maincamera = Camera.main;
    }
    public void SetCamera(Transform target) //ī�޶� ����ٴ� ��ü
    {
        target = player;
    }

    public void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            playerPosition.z = transform.position.z; //���� ������ 2D�����̹Ƿ�, z���� ����

            transform.position = Vector3.Lerp(transform.position, playerPosition, cameraSpeed); //�ִϸ��̼��� �ڿ��������� �����ϱ� ���� 
                                                                                                // Lerp�Լ��� ����
        }
        if (player.transform.position.x < -8f)
        {
            Vector3 cameraPosition = new Vector3(-8f, player.position.y, 0);
        }
        else if (player.transform.position.x > 30f)
        {
            Vector3 cameraPosition = new Vector3(30f, player.position.y, 0);
        }
        if (player.transform.position.y < -2.6f)
        {
            Vector3 cameraPosition = new Vector3(player.position.x, -2f, 0);
        }
        else if (player.transform.position.y > 29f)
        {
            Vector3 cameraPosition = new Vector3(player.position.x, 29.5f, 0);
        }
    }
}
