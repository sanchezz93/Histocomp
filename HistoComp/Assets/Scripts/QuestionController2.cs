using UnityEngine;
using UnityEngine.EventSystems;


public class QuestionController2 : MonoBehaviour
{

    //ESTO SE MODIFICA PARA CADA PUERTA
    //Dos arreglos, preguntas (3), respuestas (4 por cada pregunta)
    public string[] arrPreguntas = new string[] {"¿En qué año se desarrolló la ENIAC", "¿Quién propuso la utilizacion del sistema binario?", "¿Qué significa ENIAC?" };
    public string[] arrRespuestas = new string[] { "1948", "1949", "1947", "1950", "John Mauchly", "Charles Babagge", "John Eckert", "Von Neumann", "Electronic Numerical Integrator And Compilator", "Electronic Numerical Integrator And Calculator", "Electronic Numerical Information And Compilator", "Electric Numerical Integrator And Calculator"};
    public bool flag;
    //0 -3 (2, 3ra)
    // 4 -7 (7, 4ta)
    //8 - 11 (9, 2da)
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
    void Start()
    {
        resetButtonColors();
        /*
		 *Al iniciar el programa, se carga una pregunta aleatoria para mi puerta. 
		 */
        flag = false;
        //Generamos números aleatorios entre 0 y 3
        System.Random random = new System.Random();
        iPregunta = random.Next(0, 3);

        //Pasamos la pregunta del arreglo a una variable
        string sPregunta = arrPreguntas[iPregunta];
        //Mostramos la pregunta aleatoria en pantalla.
        pregunta.text = sPregunta;

        //Desplegamos la respuesta
        switch (iPregunta)
        {
            case 0:
                respuesta1.text = "a)" + arrRespuestas[0];
                respuesta2.text = "b)" + arrRespuestas[1];
                respuesta3.text = "c) " + arrRespuestas[2];
                respuesta4.text = "d)" + arrRespuestas[3];
                break;
            case 1:
                respuesta1.text = "a)" + arrRespuestas[4];
                respuesta2.text = "b)" + arrRespuestas[5];
                respuesta3.text = "c) " + arrRespuestas[6];
                respuesta4.text = "d)" + arrRespuestas[7];
                break;
            case 2:
                respuesta1.text = "a)" + arrRespuestas[8];
                respuesta2.text = "b)" + arrRespuestas[9];
                respuesta3.text = "c) " + arrRespuestas[10];
                respuesta4.text = "d)" + arrRespuestas[11];
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            switch (iPregunta)
            {
                case 0:
                    if (bt2.GetComponent<Renderer>().material.color == answer)
                    {
                        rightAnswer();
                    }
                    else
                    {
                        Start();
                        MovementSystem.speed = 1.5f;
                        MovementSystem.direction = -1;
                    }
                    break;
                case 1:
                    if (bt4.GetComponent<Renderer>().material.color == answer)
                    {
                        rightAnswer();
                    }
                    else
                    {
                        Start();
                        MovementSystem.speed = 1.5f;
                        MovementSystem.direction = -1;
                    }
                    break;
                case 2:
                    if (bt3.GetComponent<Renderer>().material.color == answer)
                    {
                        rightAnswer();
                    }
                    else
                    {
                        Start();
                        MovementSystem.speed = 1.5f;
                        MovementSystem.direction = -1;
                    }
                    break;
            }
        }
    }

    void resetButtonColors()
    {
        bt1.GetComponent<Renderer>().material.color = option;
        bt2.GetComponent<Renderer>().material.color = option;
        bt3.GetComponent<Renderer>().material.color = option;
        bt4.GetComponent<Renderer>().material.color = option;
    }

    void rightAnswer()
    {
        MovementSystem.speed = 1.5f;
        MovementSystem.direction = 1;
        pregunta.text = "Correcto!";
    }

    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("OnPointerClick called.");
    }

}