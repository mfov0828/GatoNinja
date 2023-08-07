using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class VidaSegundoEnemigo : MonoBehaviour
{

    public int vidaTotalEnemigo;
    public int vidaActualEnemigo;
    public int danoRecibeEnemigo;
    bool enemigoRecuperaVida;

    Animator animator;
  


    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        if (vidaTotalEnemigo <= 0) { vidaTotalEnemigo = 10; }
        vidaActualEnemigo = vidaTotalEnemigo;

        if (danoRecibeEnemigo <= 0) { danoRecibeEnemigo = 1; }
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaActualEnemigo <= 2)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            enemigoRecuperaVida = true;
        }
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white; 
        }

        if (enemigoRecuperaVida == true)
        {
            StartCoroutine("TiempoRecueracionVida");
        }
        Debug.Log(vidaActualEnemigo+"Prueba");

        if (vidaActualEnemigo <= 0) 
        { 
            Debug.Log(vidaActualEnemigo+"Esta muerto");
            animator.SetBool("estaMuerto", true);
            this.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,1); 
        }
    }



    public void EnemigoRecibeGolpe(int danoRecibidoBala) {
       vidaActualEnemigo -= danoRecibidoBala * danoRecibeEnemigo; 
    }

    IEnumerator TiempoRecueracionVida() {
        yield return new WaitForSeconds(3);
        if (vidaActualEnemigo < 10) {
            vidaActualEnemigo += 1;
        }
        else if (vidaActualEnemigo >= 10) {            
            enemigoRecuperaVida = false; 
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="hit(Clone)") 
        {            
            EnemigoRecibeGolpe(1);

            Debug.Log("hit");
            // Destroy(gameObject);
        }
    }
}
