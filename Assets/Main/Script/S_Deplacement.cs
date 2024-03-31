using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Deplacement : MonoBehaviour
{
    float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speedZ = Input.GetAxis("Horizontal");
        float speedX = -Input.GetAxis("Vertical");


        transform.position += new Vector3(speedX, 0, speedZ) * Time.deltaTime * speed;
    }
}
