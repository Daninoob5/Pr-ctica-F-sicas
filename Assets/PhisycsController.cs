using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhisycsController : MonoBehaviour
{
    //Propiedades Publicas
    public bool moverBolaAlInicio;
    public bool moverBolaAlRebote;
    public float bounceForce;
    public float powerBounceForce;
    public Rigidbody ballRB;
    public Material ballMaterial;
    public Transform indicador;
    //Propiedades Privadas 
    float xInicial;
    float zInicial;
    //Métodos
    void Start()
    {
        moverBolaAlInicio = false;
        moverBolaAlRebote = false;
        moverBolaInicio();
    }
    void Update()
    {
        if (moverBolaAlInicio)
        {
            moverBolaInicio();
            moverBolaAlInicio=false;
        }
        if (moverBolaAlRebote)
        {
            moverBolaRebote();
            moverBolaAlRebote = false;
        }
        indicador.position = gameObject.transform.position;
        if (ballRB.velocity.x > 10 || ballRB.velocity.y > 10 || ballRB.velocity.z > 10)
        {
            ballMaterial.color = Color.red;
        }
        else
        {
            ballMaterial.color = Color.white;
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Escenario1")
        {
            ballRB.AddForce(collision.gameObject.transform.up * bounceForce);       
        }     
        if (collision.gameObject.tag == "Escenario2")
        {
            ballRB.AddForce(collision.gameObject.transform.up * powerBounceForce);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Limite")
        {
            Debug.Log("La bola ha salido del límite");
            moverBolaInicio();
        }  
    }
    private void moverBolaInicio()
    {
        xInicial = Random.Range(-8, +8);
        zInicial = Random.Range(-7, +7);
        gameObject.transform.position = new Vector3(xInicial, 5, zInicial);
        Debug.Log("La bola ha sido movida a la sección inicio");
    }
    private void moverBolaRebote()
    {
        xInicial = Random.Range(-3.5f,3.5f);
        zInicial = Random.Range(45,55);
        gameObject.transform.position = new Vector3(xInicial, 5, zInicial);
        Debug.Log("La bola ha sido movida a la zona de rebote");
    }
}
