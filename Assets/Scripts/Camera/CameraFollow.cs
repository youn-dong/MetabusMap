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
    public void SetCamera(Transform target) //카메라가 따라다닐 객체
    {
        target = player;
    }

    public void Update()
    {
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            playerPosition.z = transform.position.z; //현재 게임이 2D게임이므로, z값은 고정

            transform.position = Vector3.Lerp(transform.position, playerPosition, cameraSpeed); //애니메이션의 자연스러움을 연출하기 위해 
                                                                                                // Lerp함수를 적용
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
