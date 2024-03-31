using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the value of the Horizontal input axis.
        float horizontalInput = -Input.GetAxis("Horizontal");

        //Get the value of the Vertical input axis.
        float verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 10);
        }

        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
        transform.Translate(new Vector3(verticalInput, 0, horizontalInput) * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("yellow") || 
            collision.transform.CompareTag("blue") || 
            collision.transform.CompareTag("pink"))
        {
            Debug.Log("entre en collision");
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("yellow") ||
            collision.transform.CompareTag("blue") ||
            collision.transform.CompareTag("pink"))
        {
            Debug.Log("stay in collision");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("yellow") ||
            collision.transform.CompareTag("blue") ||
            collision.transform.CompareTag("pink"))
        {
            Debug.Log("exit to collision");
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("pink"))
        {
            collision.transform.gameObject.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("yellow") ||
            collision.transform.CompareTag("blue") ||
            collision.transform.CompareTag("pink"))
        {
            Debug.Log("stay in Trigger");
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("yellow") ||
            collision.transform.CompareTag("blue") ||
            collision.transform.CompareTag("pink"))
        {
            Debug.Log("exit to Trigger");
        }
    }
}
