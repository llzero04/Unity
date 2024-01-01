using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset = new Vector3(0, 3f, -8f);
    public float smoothSpeed = 0.075f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // this.transform.position = new Vector3(player.transform.position.x , player.transform.position.y + 3f , player.transform.position.z - 8f);

        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // LookAt makes the game goofy to play
        // transform.LookAt(player.transform);
    }
}
