using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{

    public int moeda = 1000;

    
    private int casaAtual = 0;
    private int dado= 0 ;
    public ControlaGame ControlaGame;


    [SerializeField]
    private float tempoMovi = 5, tempoEspera = 1;

    [SerializeField]
    private int playerInt;

    public int dadoTeste;
    

    

    private void Start()
    {
        transform.position = ControlaGame.casas[casaAtual];
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (casaAtual == 39)
            {
                casaAtual = -1;
            }

            //transform.position = casas[casaAtual+1];

            StartCoroutine(MoviLerp(ControlaGame.casas[casaAtual+1], tempoMovi));
            casaAtual++;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (casaAtual == 0)
            {
                casaAtual = 40;
            }
            transform.position = ControlaGame.casas[casaAtual-1];
            casaAtual--;
            //print(casaAtual);
            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoviDuration());
            //teste();
            //print("acabou o movi");
        }

    }

    //Botão de jogar dado
    public void jogarDado()
    {
        StartCoroutine(MoviDuration()); 
        //print("Moeda Player : " + playerInt + "Quantidade de moeda : " + moeda);
    }

    public IEnumerator MoviDuration()
    {

        dado = dadoTeste;
        if (dadoTeste == 0)
        {
            dado = Random.Range(1, 6) + Random.Range(1, 6);
        }

        //print(dado);
        ControlaGame.trocaTexto("dado", dado);
        
        for (int i = 0; i < dado; i++)
        {
            if (casaAtual == 39)
            {
                casaAtual = -1;
            }

            StartCoroutine(MoviLerp(ControlaGame.casas[casaAtual + 1], tempoMovi));
            casaAtual++;
            yield return new WaitForSeconds(tempoEspera);

        }

        ControlaGame.LerCasa(casaAtual,playerInt);
    }


    IEnumerator MoviLerp(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        
    }

    


    
}
