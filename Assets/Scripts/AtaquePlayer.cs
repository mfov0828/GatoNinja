using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Text;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AtaquePlayer : MonoBehaviour
{
    // [Header("Balas")]
    // public GameObject bala;
    // public float tiempoVidaBala;
    Animator animator;
    Collider2D playerCollider;
    private bool ataque = false; 
    public GameObject hitBox;
    public GameObject hit;

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        playerCollider = gameObject.GetComponent<Collider2D>();

        // if (tiempoVidaBala <= 0) {tiempoVidaBala = 1f;}
    }

    // Update is called once per frame
    void Update()
    {
        Handleinput();
        Handleattack();
        ResetValues();
    }


    private void Handleinput()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { 
            ataque = true;
            CrearHitBox();
            //animator.SetTrigger("estaAtacando");
        }
    }
    private void Handleattack()
    {
        if (ataque)
        {
            animator.SetTrigger("estaAtacando");
        }
    }

    private void ResetValues()
    {
        ataque = false;
    }

    public void CrearHitBox()
    {
        if(GameObject.Find("hit(Clone)"))
        {
            return;
        }else
        {
            Vector3 positionHit = new Vector3(hitBox.transform.position.x,hitBox.transform.position.y,0);
            GameObject temphit = Instantiate(hit,positionHit,Quaternion.identity);
            Destroy(temphit,2);
        }
        
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (other.gameObject.CompareTag("Enemigo")) 
    //     {
    //         other.gameObject.GetComponent<VidaEnemigo>().EnemigoRecibeGolpe(1);

    //         Debug.Log("hit");
    //         //Destroy(gameObject);
    //     }
    // }
    
}
