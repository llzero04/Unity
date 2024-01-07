using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTracker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Input.mousePosition);
        // Look At does not work well in 2D, the fire point is being attached to pivot point when running
        // gameObject.transform.LookAt(new Vector3(Input.mousePosition.x, Input.mousePosition.y));

        // float opp = Input.mousePosition.y - transform.position.y;
        // float adj = Input.mousePosition.x - transform.position.x;
        // float hypo = Mathf.Sqrt(opp * opp + adj * adj);

        // float angle = Mathf.Atan2(hypo, opp) * Mathf.Rad2Deg;

        // transform.Rotate(0, 0, angle, Space.Self);

        Vector3 look = transform.InverseTransformPoint(Input.mousePosition);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        transform.Rotate(0 , 0 , angle, Space.Self);
    }
}
