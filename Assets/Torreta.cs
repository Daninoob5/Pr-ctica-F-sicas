using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 10f, transform.forward, out hit, 7f) && hit.transform.gameObject.tag == "Player")
        {
            hit.transform.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 10);
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
