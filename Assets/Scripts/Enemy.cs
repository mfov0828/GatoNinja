using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float enemySpeed = -2f;
    Rigidbody2D enemyRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //enemyRigidBody.velocity = new Vector2(-3,enemyRigidBody.velocity.y);

        if(estaMirandoIzq())
        {
            enemyRigidBody.velocity = new Vector2(enemySpeed, enemyRigidBody.velocity.y);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(-enemySpeed, enemyRigidBody.velocity.y);
        }

    }

    bool estaMirandoIzq(){
        return transform.localScale.x > 0;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("No toca piso");
        transform.localScale = new Vector2(enemyRigidBody.velocity.x, transform.localScale.y);
    }
}
