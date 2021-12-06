using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{   //Room Camera style Code
    public float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //Follow Player Style Camera
    public Transform Player;
    public float aheadDistance;
    public float cameraSpeed;
    private float lookAhead;
    private void Update()
    {   // Room Camera style Code
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z),  ref velocity, speed);

        //Follow Player
        transform.position = new Vector3(Player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * Player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;

    }
}
