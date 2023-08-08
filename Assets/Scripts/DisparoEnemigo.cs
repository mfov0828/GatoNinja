using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    [Header("Balas")]
    public GameObject bala;
    public float tiempoVidaBala;
    public float tiempoEntreDisparos;
    float tiempo;
        

    // Start is called before the first frame update
    void Start()
    {     
        tiempo = 0f;  
        if (tiempoVidaBala <= 0) {tiempoVidaBala = 1f;}
        if (tiempoEntreDisparos <= 0) {tiempoEntreDisparos = 1f;}
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = tiempo +1f *Time.deltaTime;
        
        if(tiempo >= tiempoEntreDisparos)
        {
            tiempo = 0f;
            Destroy( Instantiate(bala, transform.position, Quaternion.identity), tiempoVidaBala);        
        }
    }
}
