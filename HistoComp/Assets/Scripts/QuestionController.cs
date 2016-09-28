using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;


public class QuestionController : MonoBehaviour {
	
	//ESTO SE MODIFICA PARA CADA PUERTA
	//Dos arreglos, preguntas (3), respuestas (4 por cada pregunta)
	string[] arrPreguntas = new string[] {"En que siglo se elaboro la maquina analitica?","Cual es el nombre del creador de la maquina analitica","Como inicio esta idea"};
	string[] arrRespuestas = new string[] {"XVII","XVIII","XIX","XX","Charles Barlow","Chad Barnett","Chad Barlow","Charles Babbage","Para enviar mensajes","Para elaborar tablas matematicas","Para guardar informacion","Para analizar textos"};

    public bool flag;

	public TextMesh pregunta;
	public TextMesh respuesta1;
	public TextMesh respuesta2;
	public TextMesh respuesta3;
	public TextMesh respuesta4;

	public GameObject bt1;
	public GameObject bt2;
	public GameObject bt3;
	public GameObject bt4;

    int iPregunta;
    Color option = new Color(0.66f, 0.1f, 0.24f);
    Color answer = new Color(0f, 0.191f, 0.60f);

    // Use this for initialization
    void Start () {
        resetButtonColors();
        /*
		 *Al iniciar el programa, se carga una pregunta aleatoria para mi puerta. 
		 */
        flag = false;
		//Generamos números aleatorios entre 0 y 3
		System.Random random = new System.Random();
	    iPregunta = random.Next(0, 3);

		//Pasamos la pregunta del arreglo a una variable
		string sPregunta = arrPreguntas [iPregunta];
		//Mostramos la pregunta aleatoria en pantalla.
		pregunta.text = sPregunta;

		//Desplegamos la respuesta
		switch (iPregunta)
		{
		case 0:
			respuesta1.text = "a)" + arrRespuestas [0]; 
			respuesta2.text = "b)" + arrRespuestas [1];
			respuesta3.text = "c) " + arrRespuestas [2]; 
			respuesta4.text = "d)"+ arrRespuestas[3];
			break;
		case 1:
			respuesta1.text = "a)" + arrRespuestas [4]; 
			respuesta2.text = "b)" + arrRespuestas [5];
			respuesta3.text = "c) " + arrRespuestas [6]; 
			respuesta4.text = "d)"+ arrRespuestas[7];
			break;
		case 2:
			respuesta1.text = "a)" + arrRespuestas [8]; 
			respuesta2.text = "b)" + arrRespuestas [9];
			respuesta3.text = "c) " + arrRespuestas [10]; 
			respuesta4.text = "d)"+ arrRespuestas[11];
			break;
		default:
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
        if(flag)
        {
            switch (iPregunta)
            {
                case 0:
                    if (bt2.GetComponent<Renderer>().material.color == answer)
                        rightAnswer();
                    else
                       Start();
                    break;
                case 1:
                    if (bt4.GetComponent<Renderer>().material.color == answer)
                        rightAnswer();
                    else
                        Start();
                    break;
                case 2:
                    if (bt3.GetComponent<Renderer>().material.color == answer)
                        rightAnswer();
                    else
                       Start();
                    break;
            }
        }
	}

    void resetButtonColors() {
        bt1.GetComponent<Renderer>().material.color = option;
        bt2.GetComponent<Renderer>().material.color = option;
        bt3.GetComponent<Renderer>().material.color = option;
        bt4.GetComponent<Renderer>().material.color = option;
    }

    void rightAnswer() {
        pregunta.text = "Correcto!";
        Destroy(bt1);
        Destroy(bt2);
        Destroy(bt3);
        Destroy(bt4);
        Destroy(respuesta1);
        Destroy(respuesta2);
        Destroy(respuesta3);
        Destroy(respuesta4);
    }

	public void OnPointerClick( PointerEventData data )
	{
		Debug.Log( "OnPointerClick called." );
	}

}
