using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvements : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    float moveSpeed = 10f;
    public float playerScore = 0f;
    //Define the speed at which the object moves.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Vertical");
        //Get the value of the Vertical input axis.

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
            controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 10);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("coinSilver") ||
            collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("entre en collision");
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("coinSilver") ||
            collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("stay in collision");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("coinSilver") ||
            collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("exit to collision");
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("coinSilver") ||
            collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("Le joueur à touché la pièce.");
            Destroy(collision.transform.gameObject);
            Debug.Log("+ 10 points !");
            playerScore += 10f;
        }
    }

    public void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("coinSilver") ||
            collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("stay in Trigger");
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("coinSilver") ||
            collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("exit to Trigger");
        }
    }
}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMouvement : MonoBehaviour
//{
//    float moveSpeed = 10f;
//    public float playerScore = 0f; 
//    //Define the speed at which the object moves.

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        float horizontalInput = -Input.GetAxis("Horizontal");
//        //Get the value of the Horizontal input axis.

//        float verticalInput = Input.GetAxis("Vertical");
//        //Get the value of the Vertical input axis.

//        if (Input.GetKey(KeyCode.Space))
//        {
//            Rigidbody rb = GetComponent<Rigidbody>();
//            rb.AddForce(Vector3.up * 10);
//        }

//        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
//        //transform.Translate(new Vector3(verticalInput, 0, horizontalInput) * moveSpeed * Time.deltaTime);

//        if (verticalInput > 0)
//        {
//            transform.rotation = Quaternion.LookRotation(new Vector3(-verticalInput * moveSpeed, 0, horizontalInput * moveSpeed));
//            //Orienté le joueur dans la direction où il se déplace. 

//            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
//            transform.Translate(new Vector3(verticalInput, 0, horizontalInput) * moveSpeed * Time.deltaTime);
//        }

//        if (verticalInput < 0)
//        {
//            transform.rotation = Quaternion.LookRotation(new Vector3(-verticalInput * moveSpeed, 0, horizontalInput * moveSpeed));
//            //Orienté le joueur dans la direction où il se déplace. 

//            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
//            transform.Translate(new Vector3(-verticalInput, 0, -horizontalInput) * moveSpeed * Time.deltaTime);
//        }

//        if (horizontalInput > 0)
//        {
//            transform.rotation = Quaternion.LookRotation(new Vector3(verticalInput * moveSpeed, 0, -horizontalInput * moveSpeed));
//            //Orienté le joueur dans la direction où il se déplace.

//            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
//            transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
//        }

//        if (horizontalInput < 0)
//        {
//            transform.rotation = Quaternion.LookRotation(new Vector3(verticalInput * moveSpeed, 0, -horizontalInput * moveSpeed));
//            //Orienté le joueur dans la direction où il se déplace.

//            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
//            transform.Translate(new Vector3(-horizontalInput, 0, -verticalInput) * moveSpeed * Time.deltaTime);
//        }

//    }

//    public void OnCollisionEnter(Collision collision)
//    {
//        if (collision.transform.CompareTag("coinSilver") ||
//            collision.transform.CompareTag("coinGold"))
//        {
//            Debug.Log("entre en collision");
//        }
//    }

//    public void OnCollisionStay(Collision collision)
//    {
//        if (collision.transform.CompareTag("coinSilver") ||
//            collision.transform.CompareTag("coinGold"))
//        {
//            Debug.Log("stay in collision");
//        }
//    }

//    public void OnCollisionExit(Collision collision)
//    {
//        if (collision.transform.CompareTag("coinSilver") ||
//            collision.transform.CompareTag("coinGold"))
//        {
//            Debug.Log("exit to collision");
//        }
//    }

//    public void OnTriggerEnter(Collider collision)
//    {
//        if (collision.transform.CompareTag("coinSilver") ||
//            collision.transform.CompareTag("coinGold"))
//        {
//            Debug.Log("Le joueur à touché la pièce.");
//            Destroy(collision.transform.gameObject);
//            Debug.Log("+ 10 points !");
//            playerScore += 10f;
//        }
//    }

//    public void OnTriggerStay(Collider collision)
//    {
//        if (collision.transform.CompareTag("coinSilver") ||
//            collision.transform.CompareTag("coinGold"))
//        {
//            Debug.Log("stay in Trigger");
//        }
//    }

//    public void OnTriggerExit(Collider collision)
//    {
//        if (collision.transform.CompareTag("coinSilver") ||
//            collision.transform.CompareTag("coinGold"))
//        {
//            Debug.Log("exit to Trigger");
//        }
//    }
//}

//Faire un script pour la camera pour suivre la souris 
//Faire que lorsque le personnage vas vers l'arrière il se retourne 
//Générer la suppresion d'un objet (Des pièce ramassé)
//Ajouter au terrain du platformer 
