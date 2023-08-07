using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPersonaje : MonoBehaviour
{
    
    public int vida;
    public string[] tagElemento;
    
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(gameObject.CompareTag("SubirVida") && other.CompareTag("Player")){
            other.GetComponent<MovimientoSaltoPlayer>().Vida(vida);            
            Destroy(gameObject);
        }

        if(gameObject.CompareTag("BajarVida") && other.CompareTag("Player")){
            other.GetComponent<MovimientoSaltoPlayer>().Vida(-vida);            
            //Destroy(gameObject);
        }
    }

}
