using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bala : MonoBehaviour
{
    public float velocidadBala;
         GameObject player;
         int direccion;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.transform.rotation.y == 0){direccion = -1;}
        else{direccion = 1;}


        if (velocidadBala <= 0) {velocidadBala = 1;}
    }


// Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * velocidadBala * direccion * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if(gameObject.CompareTag("BajarVida") && other.CompareTag("Player")){
            other.GetComponent<MovimientoSaltoPlayer>().Vida(-20);            
            //Destroy(gameObject);
        }
    }

}
