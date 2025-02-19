using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed = 0.1f;

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
    }
}
