   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMove : MonoBehaviour
{
    //variables
    private Vector2 direction; //control direction of movement


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))    //when W key is pressed
        {
            direction = Vector2.up;        //go up
        }


        else if (Input.GetKeyDown(KeyCode.A))    //when A key is pressed
        {
            direction = Vector2.left;        //go left
        }


        else if (Input.GetKeyDown(KeyCode.S))    //when S key is pressed
        {
            direction = Vector2.down;        //go down
        }


        else if (Input.GetKeyDown(KeyCode.D))    //when D key is pressed
        {
            direction = Vector2.right;        //go right
        }
    }
    //FixedUpdate is called at a fix interval
    void FixedUpdate()
    {
        //move the snake
        this.transform.position = new Vector2(                          //get the position
            Mathf.Round(this.transform.position.x) + direction.x,       //round the number add value to x
            Mathf.Round(this.transform.position.y) + direction.y        //round the number add value to Y
            );
        //function to make the snake grow
        void Grow()
        {
            Transform segment = Instantiate(this.bodyPrefab);                  //create a new body part
            segmant.position = segments[segments.Count - 1].position;         //position it on the back of the snake 
            segments.Add(segment);                                            //add it to the list

        }

        //Funtion for collision
        void OnTriggerEnter2D(Collider2D other)


    }


        


}