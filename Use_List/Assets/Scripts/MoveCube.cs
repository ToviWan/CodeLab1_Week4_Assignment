using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MoveCube : MonoBehaviour
{
    public float speed = 1f;

    public List<Color> ballColors = new List<Color>();
    public int index = 0;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))//move left
        {
            rb.velocity= new (-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))//move right
        {
            rb.velocity= new (speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            rb.velocity = Vector3.zero;//stop move when no keys being pressed
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            speed++; //increase player speed if you get a ball
            
            //color rotating logic
            Material ballMat = other.gameObject.GetComponent<Renderer>().material;
            ballMat.color = ballColors[index];
            Debug.Log("hitting ball");
            if (index < ballColors.Count-1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            float randX = Random.Range(-28.5f,16f);
            other.gameObject.transform.position = new Vector3(
                randX,
                other.transform.position.y,
                other.transform.position.z);


        }

        if (other.gameObject.CompareTag("blocker"))
        {
            SceneManager.LoadScene(2); //go to EndGame scene when green cube and the red blockers hit together 
        }
        
        
    }


}
