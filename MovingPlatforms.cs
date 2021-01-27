using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public Vector3 current;
    public Vector3 min;
    public Vector3 max;

    public float minX;
    public float maxX;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        current = this.transform.position;
        min = current;
        max = current;
        min.x += minX;
        max.x += maxX;
    }

    // Update is called once per frame
    void Update()
    {

        current = this.transform.position;

        if (ChangeVelocity())
        {
            speed *= -1;
        }

        current.x += speed * Time.deltaTime;

        this.transform.position = current;

    }

    public bool ChangeVelocity()
    {

        if(current.x <= min.x)
        {
            return true;
        }
        else if (current.x >= max.x)
        {
            return true;
        }

        return false;
    }

}
