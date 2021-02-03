using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject expAnimation;

    public Vector3 current;
    public Vector3 min;
    public Vector3 max;

    public float minX;
    public float maxX;
    public float speed;

    public float expForce;
    public float expRadius;

    // Start is called before the first frame update
    void Start()
    {
        current = this.transform.position;

        min = current;
        max = current;

        min.x -= 10;
        max.x += 10;
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

        if (current.x <= min.x)
        {
            return true;
        }
        else if (current.x >= max.x)
        {
            return true;
        }

        return false;
    }


    private void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            Movement.Instance.rb.AddExplosionForce(expForce, this.transform.position, expRadius);
            Movement.Instance.disabledTimer = .5f;

            Instantiate(expAnimation, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
           
        }


        if(col.gameObject.tag == "Bullet")
        {
            Instantiate(expAnimation, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }

    }




}