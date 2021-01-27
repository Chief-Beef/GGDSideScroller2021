using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Vector3 dir;
    public Vector3 startVelocity;

    public GameObject explosionAnimation;

    public Rigidbody rbody;

    public float angle;
    public float xSpeed;
    public float ySpeed;
    public float bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x);

        xSpeed = Mathf.Cos(angle);
        ySpeed = Mathf.Sin(angle);

        //Debug.Log("xSpeed: " + xSpeed + "   ySpeed" + ySpeed + "    bulletVelocity: " + bulletVelocity * xSpeed);

        startVelocity = new Vector3(bulletVelocity * xSpeed, bulletVelocity * ySpeed, 0);

        rbody.velocity = startVelocity;

    }

    // Update is called once per frame
    void Update()
    {
        
        if(HitAnything())
        {
            Debug.Log("HitSomething");

            Instantiate(explosionAnimation, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }


    public bool HitAnything()
    {

        if (rbody.velocity == startVelocity)
        {
            return false;
        }
        return true;

    }
       

}
