using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{

    public static Movement Instance;

    public Vector3 current;

    public Rigidbody rb;

    public GameObject deathAnimation;

    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode sprint;

    public float speed;
    public float xMov;
    public float yMov;
    public float jump;
    public float grav;
    public float gravityTimer;
    public float disabledTimer;

    public int health;

    public bool canJump;
    
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        speed = 5;
        jump = 750;
        grav = -20;
        Physics.gravity = new Vector3(0, grav, 0);
        health = 3;

        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

        disabledTimer -= Time.deltaTime;
        gravityTimer -= Time.deltaTime;
        current = this.transform.position;

        if (disabledTimer <= 0.0f)
        {

            //sprint speed modifier
            if (Input.GetKeyDown(sprint))
            {
                speed *= 2.0f;
            }

            if (Input.GetKeyUp(sprint))
            {
                speed /= 2.0f;
            }

            //movement
            if (Input.GetKey(right))
            {
                current.x += speed * Time.deltaTime;
            }

            if (Input.GetKey(left))
            {
                current.x -= speed * Time.deltaTime;
            }

            if (Input.GetKeyDown(up) && canJump)
            {
                rb.velocity = new Vector3(0, 0, 0);
                rb.AddForce(transform.up * jump);
                canJump = false;
            }

            if (Input.GetKeyDown(down) && gravityTimer < 0)
            {
                grav *= -1;
                jump *= -1;
                gravityTimer = 1.0f;

                Physics.gravity = new Vector3(0, grav, 0);
            }

            
        }

        //update position
        this.transform.position = current;

        if (health <= 0)
        {
            Instantiate(deathAnimation, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }

    }

    

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            canJump = true;
        }

        if (col.gameObject.tag == "Enemy")
        {
            health--;
        }

        if (col.gameObject.tag == "DeathPlane")
        {
            health = 0;
        }

        if (col.gameObject.tag == "ExitDoor")
        {
            SceneManager.LoadScene("WinScreen");
        }

    }

    public void OnDestroy()
    {
        SceneManager.LoadScene("GameOver");
    }

}