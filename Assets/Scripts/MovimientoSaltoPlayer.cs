using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class MovimientoSaltoPlayer : MonoBehaviour
{
    
    [Header("Control Personaje")]
    [Header("Vida Personaje")]
    public int vidaTotal;
    public int vidaActual;
    public TMP_Text textoVidaPlayer;

    public Vector3 posicionInicial;
    
    [Header("MovimientoHorizontal")]
    public float fuerzaHorizontal;
    public int giroBala=1;        
        float valorHorizontal;   
        Animator animator;

    [Header("Salto")]
    public float fuerzaSalto;
    public float alturaRayo;
    public LayerMask capaPiso;
        Rigidbody2D playerRigidBody;
        SpriteRenderer spriteRenderer;

    [SerializeField] float velocidadEscalada = 3f;
    Collider2D playerCollider;
    BoxCollider2D boxCollider;

    bool tocaEscaleras;
    bool tocaPiso;
    bool estaVivo = true;

    public float tiempoVidaBala;
    public float tiempoEntreDisparos;
    float tiempo;


    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerCollider = gameObject.GetComponent<Collider2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        
        tiempo = 0f;

        if (fuerzaHorizontal <= 0) {fuerzaHorizontal = 1;}
        if (fuerzaSalto <= 0){fuerzaSalto = 5f;}
        if (alturaRayo <= 0){alturaRayo = 1.5f;}

        vidaActual=vidaTotal;


    }

    // Update is called once per frame
    void Update()
    {

        if(estaVivo)
        {
            //MoviminetoHorizontal
            valorHorizontal = Input.GetAxisRaw("Horizontal");
            if (valorHorizontal != 0) {
                if (valorHorizontal > 0)
                {
                    //transform.rotation= Quaternion.Euler(0,0,0);
                    spriteRenderer.flipX = false;
                    giroBala = 1;
                    //transform.localScale =  new Vector3(1,1,1);

                }
                else if (valorHorizontal < 0) {
                    //transform.rotation = Quaternion.Euler(0, 180, 0);
                    spriteRenderer.flipX = true;
                    giroBala = -1;
                    //transform.localScale = new Vector3(-1, 1, 1);
                }
                transform.position += Vector3.right * valorHorizontal * fuerzaHorizontal *  Time.deltaTime;
            }
            animator.SetFloat("Correr", Mathf.Abs(valorHorizontal));

            //MovimientoVertical
            Debug.DrawRay(transform.position, Vector2.down * alturaRayo, Color.red, 0.01f);
            if (Physics2D.Raycast(transform.position, Vector2.down, alturaRayo, capaPiso)) {
                //Debug.Log("Tocando Piso");
                animator.SetFloat("velocidadSalto",playerRigidBody.velocity.y);
                if(!playerCollider.IsTouchingLayers(capaPiso))
                {
                    Debug.Log("Toca Piso");
                } else if (Input.GetKeyDown(KeyCode.UpArrow)) 
                {
                    playerRigidBody.velocity = Vector2.up * fuerzaSalto;
                    Debug.Log("Salta");
                    
                }
            }
            //VerificarPiso
            if(playerCollider.IsTouchingLayers(capaPiso))
            {
                animator.SetBool("tocaPiso", true); 
            }
            else
            {
                animator.SetBool("tocaPiso", false); 
            }

            //VerificarEscaleras
            if(boxCollider.IsTouchingLayers(LayerMask.GetMask("Escaleras")))
            {
                Debug.Log("Toca Escaleras");
                
                tocaPiso = true;
            }
            else
            {
                
                tocaPiso = false;
            }

            //Escalada
            var obtenerDireccion = Input.GetAxis("Vertical");
            if (!tocaPiso)
            {
                //Debug.Log("Toca Piso");
                boxCollider.isTrigger = false;
                playerRigidBody.gravityScale = 1;
                animator.SetBool("escalando", false);
            }
            else if (tocaPiso && Input.GetAxis("Vertical") != 0)
            {
                animator.SetBool("escalando", true);
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,velocidadEscalada*obtenerDireccion);
                boxCollider.isTrigger = true;
                playerRigidBody.gravityScale = 0;
                Debug.Log("Escalando");
            }


        //Morir

            if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                if(vidaActual<=0)
                {
                animator.SetTrigger("morir");
                //estaVivo = false; 
                }  

            }
            if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Pinchos"))){
                
                animator.SetTrigger("morir");

                tiempo = tiempo +1f *Time.deltaTime;
        
                if(tiempo >= tiempoEntreDisparos)
                {
                    tiempo = 0f;
                }

                vidaActual= -100;
                //estaVivo = false;
            }

            PlayerDead();

        }

    }

    public void Vida(int vidaRecibe)
    {
        vidaActual+=vidaRecibe;
        Debug.Log(vidaActual+"vida actual");
        textoVidaPlayer.text= "Vida:"+ vidaActual.ToString(); 
        Debug.Log("Cambio de vida: " +vidaRecibe );
    }

    public void PlayerDead(){
        if(vidaActual<=0)
        {

            animator.Rebind();
            animator.Update(0f);
            
            vidaActual= 100;
            transform.position= posicionInicial;
            textoVidaPlayer.text= "Vida:"+ vidaActual.ToString();  
            
        }       
    }
}
