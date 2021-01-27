using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{


    public Vector3 max;
    public Vector3 min;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        max = Movement.Instance.current;

        max.x += 2;
        max.y = 5;
        max.z -= 10;

        min = max;

        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, min.x, max.x),
          Mathf.Clamp(transform.position.y, min.y, max.y),
          Mathf.Clamp(transform.position.z, min.z, max.z));

    }
}
