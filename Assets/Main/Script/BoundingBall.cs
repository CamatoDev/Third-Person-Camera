using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBall : MonoBehaviour
{
    public int size;
    private int speed; 


    // Start is called before the first frame update
    void Start()
    {
        Transform t = gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * Time.deltaTime * 2;
        
    }
}
