using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float playerScore = 0f;
    public float playerLive = 100f;
    bool haveKey = false;
    //Define the speed at which the object moves.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Vertical");
        //Get the value of the Horizontal input axis.

        float verticalInput = Input.GetAxis("Horizontal");
        //Get the value of the Vertical input axis.

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * 4);
        }

        //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
        //transform.Translate(new Vector3(verticalInput, 0, horizontalInput) * moveSpeed * Time.deltaTime);

        if (verticalInput > 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-verticalInput * moveSpeed, 0, horizontalInput * moveSpeed));
            //Orienté le joueur dans la direction où il se déplace. 

            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
            transform.Translate(new Vector3(verticalInput, 0, horizontalInput) * moveSpeed * Time.deltaTime);
        }

        if (verticalInput < 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-verticalInput * moveSpeed, 0, horizontalInput * moveSpeed));
            //Orienté le joueur dans la direction où il se déplace. 

            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
            transform.Translate(new Vector3(-verticalInput, 0, -horizontalInput) * moveSpeed * Time.deltaTime);
        }

        if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(verticalInput * moveSpeed, 0, -horizontalInput * moveSpeed));
            //Orienté le joueur dans la direction où il se déplace.

            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
            transform.Translate(new Vector3(horizontalInput, 0, verticalInput) * moveSpeed * Time.deltaTime);
        }

        if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(verticalInput * moveSpeed, 0, -horizontalInput * moveSpeed));
            //Orienté le joueur dans la direction où il se déplace.

            //Move the object to XYZ coordinates defined as horizontalInput, 0, and verticalInput respectively.
            transform.Translate(new Vector3(-horizontalInput, 0, -verticalInput) * moveSpeed * Time.deltaTime);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Pick"))
        {
            Debug.Log("Le joueur à touché un piège.");
            Debug.Log("- 5 points de vie!");
            playerLive -= 5f;
        }

        if (collision.transform.CompareTag("DoorClose"))
        {
            if (haveKey)
            {
                Debug.Log("Le joueur a une clé pour ouvir la porte.");
                Destroy(collision.transform.gameObject);
                Debug.Log("La porte s'ouvre !");
                haveKey = false;
            }
            else
            {
                Debug.Log("Le joueur n'a de clé pour ouvir la porte.");
                Debug.Log("Allez chercher la clé !");
            }
        }
    }

    public void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Pick"))
        {
            Debug.Log("- 1 points de vie!");
            playerLive -= 1f;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Pick"))
        {
            Debug.Log("exit to collision");
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("coinSilver"))
        {
            Debug.Log("Le joueur à touché la pièce d'argent.");
            Destroy(collision.transform.gameObject);
            Debug.Log("+ 10 points !");
            playerScore += 10f;
        }

        if (collision.transform.CompareTag("coinGold"))
        {
            Debug.Log("Le joueur à touché la pièce d'or.");
            Destroy(collision.transform.gameObject);
            Debug.Log("+ 20 points !");
            playerScore += 20f;
        }

        if (collision.transform.CompareTag("BigCoinGold"))
        {
            Debug.Log("Le joueur à touché la pièce d'or géante.");
            Destroy(collision.transform.gameObject);
            Debug.Log("+ 100 points !");
            playerScore += 100f;
        }

        if (collision.transform.CompareTag("Key"))
        {
            Debug.Log("Le joueur à récuperer une clé.");
            Destroy(collision.transform.gameObject);
            haveKey = true;
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

//Faire un script pour la camera pour suivre la souris 
//Faire que lorsque le personnage vas vers l'arrière il se retourne 
//Générer la suppresion d'un objet (Des pièce ramassé)
//Ajouter au terrain du platformer 