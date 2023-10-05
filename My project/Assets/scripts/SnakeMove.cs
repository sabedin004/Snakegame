using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SnakeMove : MonoBehaviour
{
    //variables
    private Vector2 direction; //control direction of movement
    public bool goingUp;
    public bool goingDown;
    public bool goingLeft;
    public bool goingRight; 



    List<Transform> segments;   // stores all parts of the body of the snake
    public Transform bodyPrefab; // variable to store the body


    // Start is called before the first frame update
    void Start()
    {
        segments = new List<Transform>(); //create new list
        segments.Add(transform);            //add head of snake to the list
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && goingDown != true)    //when W key is pressed
        {
            direction = Vector2.up;        //go up
            goingUp = true;
            goingDown = false;
            goingLeft = false;
            goingRight = false;
        }


        else if (Input.GetKeyDown(KeyCode.A))    //when A key is pressed
        {
            direction = Vector2.left;        //go left
            goingUp = false;
            goingDown = false;
            goingLeft = true;   
            goingRight = false;
        }


        else if (Input.GetKeyDown(KeyCode.S) && goingUp != true )    //when S key is pressed
        {
            direction = Vector2.down;        //go down
            goingUp = false;
            goingDown = true;
            goingLeft = false;
            goingRight = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))    //when D key is pressed
        {
            direction = Vector2.right;        //go right
            goingUp = false;
            goingDown = false;
            goingLeft = false;
            goingRight = true;

        }


       
    }
    //FixedUpdate is called at a fix interval
    void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)        //for each segment

        {
            segments[i].position = segments[i - 1].position;  // move the body
        }



        //move the snake
        this.transform.position = new Vector2(                          //get the position
            Mathf.Round(this.transform.position.x) + direction.x,       //round the number add value to x
            Mathf.Round(this.transform.position.y) + direction.y        //round the number add value to Y
            );


    }
    //function to make the snake grow
    void Grow()
    {
        Transform segment = Instantiate(this.bodyPrefab);                  //create a new body part
        segment.position = segments[segments.Count - 1].position;         //position it on the back of the snake 
        segments.Add(segment);                                            //add it to the list

    }

    //Funtion for collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")      // check if the other object is the food
        {
            Grow();             //turn the grow function
            Time.fixedDeltaTime -= 0.001f;
        }
        else if (other.tag == "Obstacle")      //check if the other object is an obstacle
        {
            //Debug.Log("Hit")
            Debug.Log("Hit");
            SceneManager.LoadScene("Endscene");                //change to end scene
            SceneManager.LoadScene("SampleScene");                //change to end scene
        }

    }




}
