using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    public Vector3 dir;
    public Vector3 bulletPos;

    public Quaternion rotation;

    public GameObject bullet;

    public float angle;
    public float shotClock;

    
    // Start is called before the first frame update
    void Start()
    {
        rotation = Quaternion.identity;        
    }

    // Update is called once per frame
    void Update()
    {

        shotClock -= Time.deltaTime;

        bulletPos = Movement.Instance.current;
        //currentPos.y += 2;

        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x);

        
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("BANG \n");

            if (shotClock < 0)
            {
                MakeBullet();
                shotClock = .5f;
            }
        }
        //Potentially add right click to create a platform for bonus mobility or whatever

    }


    public void MakeBullet()
    {

        bulletPos.x += Mathf.Cos(angle);
        bulletPos.y += Mathf.Sin(angle);

        Instantiate(bullet, bulletPos, Quaternion.identity);

    }



}
