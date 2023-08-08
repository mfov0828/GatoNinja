using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ObjetoAMover;

    public Transform PuntoInicio;
    public Transform PuntoFin;

    public float Velocidad;

    private Vector3 MoverHacia;


    void Start()
    {
        MoverHacia = PuntoFin.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoAMover.transform.position = Vector3.MoveTowards(ObjetoAMover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

        if(ObjetoAMover.transform.position == PuntoFin.position)
        {
            MoverHacia = PuntoInicio.position;
        }

        if(ObjetoAMover.transform.position == PuntoInicio.position)
        {
            MoverHacia = PuntoFin.position;
        }
    }
}
