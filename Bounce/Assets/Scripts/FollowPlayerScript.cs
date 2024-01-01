using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 2, -10);
    public float smoothSpeed = 0.075f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        // this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z - 10f);
    }

    private void FixedUpdate()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2f, player.transform.position.z - 10f);

        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(player.transform);
    }
}
