using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlaGame : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private GameObject cartaMarrom;
    [SerializeField] private Button bt_Comprar;
    [SerializeField] private Button bt_Fechar;
    [SerializeField] private Button bt_Dado;
    [SerializeField] private Image img_Player1;
    [SerializeField] private Image img_Player2;

    [Header("Material de confirmção de compras ")]
    [SerializeField] private Material mt_ConfPl1;

    [Header("Prefabs ")]
    [SerializeField] private GameObject ConfPl1;
    [SerializeField] private GameObject ConfPl2;
    
    [Header("Casas")]
    public Vector3[] casas = new Vector3[40];

    [Header("Pode Comprar Cartas Marrons ")]
    private int podeComprarCartaMarrom01 = 0;
    private int podeComprarCartaMarrom02 = 0;

    [Header("Controlador de dado")]
    private int controlaDado = 1;

    [Header("Textos")]
    public TextMeshProUGUI txt_Dado;
    public TextMeshProUGUI txt_MoedaPlayer1;
    public TextMeshProUGUI txt_MoedaPlayer2;


    [Header("Players ")]
    public PlayerMoviment Player1;
    public PlayerMoviment Player2;

    [Header("Numero da casa e qual player ")]
    private int nCasa, nPlayer;

    private void Awake()
    {
        CadastraCasas();

    }

    void Start()
    {
        bt_Fechar.gameObject.SetActive(false);
        bt_Comprar.gameObject.SetActive(false);
        cartaMarrom.SetActive(false);
        img_Player1.GetComponent<RectTransform>().localScale = new Vector3(5.110608f, 0.7632443f, 0.7632443f);
    }


 

    public void LerCasa( int numCasa , int numPlayer) 
    {
        nCasa = numCasa;
        nPlayer = numPlayer;
        //print(nPlayer);

        if (nCasa == 1 || nCasa == 3)
        {
            CartaMarrom();

            //print("entrou antes");
        }
        else
        {
            bt_Dado.gameObject.SetActive(true);
            ControlaHudPlayer();

        }
    }

    public void CartaMarrom()
    {

        bt_Dado.gameObject.SetActive(false); 

        if (nCasa == 1)
        {
            if (podeComprarCartaMarrom01 == 0)
            {
                cartaMarrom.SetActive(true);
                bt_Comprar.gameObject.SetActive(true);
                bt_Fechar.gameObject.SetActive(true);


                switch (nPlayer){
                    case 1:
                        bt_Comprar.onClick.RemoveAllListeners();
                        bt_Comprar.onClick.AddListener(() => Comprar(cartaMarrom, 500, Player1 , 1 , ConfPl1));
                        break;


                    case 2:
                        bt_Comprar.onClick.RemoveAllListeners();
                        bt_Comprar.onClick.AddListener(() => Comprar(cartaMarrom, 500, Player2 , 1 , ConfPl2));
                        break;


                }
               
               
                bt_Fechar.onClick.AddListener(() => Fechar(cartaMarrom));
            }
            else
            {

                Pagar(podeComprarCartaMarrom01);
            }

        }
        else if (nCasa == 3)
        {
            if (podeComprarCartaMarrom02 == 0)
            {
                cartaMarrom.SetActive(true);
                bt_Comprar.gameObject.SetActive(true);
                bt_Fechar.gameObject.SetActive(true);


                switch (nPlayer)
                {
                    case 1:
                        bt_Comprar.onClick.RemoveAllListeners();
                        bt_Comprar.onClick.AddListener(() => Comprar(cartaMarrom, 800, Player1, 2, ConfPl1));
                        break;


                    case 2:
                        bt_Comprar.onClick.RemoveAllListeners();
                        bt_Comprar.onClick.AddListener(() => Comprar(cartaMarrom, 800, Player2, 2, ConfPl2));
                        break;
                }

                bt_Fechar.onClick.AddListener(() => Fechar(cartaMarrom));
            }
            else
            {
                Pagar(podeComprarCartaMarrom02);
            }
        }

               
    }


    



    void Comprar(GameObject Carta, int preco , PlayerMoviment qualPlayer , int qualCarta,GameObject confirm )
    {
        
        bt_Comprar.gameObject.SetActive(false);
        bt_Fechar.gameObject.SetActive(false);
        bt_Dado.gameObject.SetActive(true);
        Carta.SetActive(false);




        qualPlayer.moeda -= preco;

        switch (qualCarta)
        {
            case 1:
                podeComprarCartaMarrom01 = (nPlayer*10000) + 50 ;
                Instantiate(confirm, new Vector3(6.667f, 0.122f, -14.645f), Quaternion.identity);



                break;

            case 2:
                podeComprarCartaMarrom02 = (nPlayer * 10000) + 100;
                Instantiate(confirm, new Vector3(5.036f, 0.122f, -14.645f), Quaternion.identity);

                break;


        }


        ControlaHudPlayer();

    }


    private void Pagar(int qualCasa)
    {
        bt_Dado.gameObject.SetActive(true);

        int playerPraPagar = (qualCasa / 10000);
        int quantoPraPagar = (qualCasa % 10000);


        print("a casa já tem dono : " + qualCasa);
        print("Qual e o plaher : " + playerPraPagar );
        print("Quanto é pra pagar : " + quantoPraPagar);

    }

    void Fechar(GameObject Carta)
    {
        ControlaHudPlayer();
        bt_Fechar.gameObject.SetActive(false);
        bt_Comprar.gameObject.SetActive(false);
        bt_Dado.gameObject.SetActive(true);
        Carta.SetActive(false);

    }

    private void ControlaHudPlayer()
    {
        txt_MoedaPlayer1.text = Player1.moeda.ToString();
        txt_MoedaPlayer2.text = Player2.moeda.ToString();


        //print(nPlayer);
        if (nPlayer == 2)
        {
            img_Player1.GetComponent<RectTransform>().localScale = new Vector3(5.110608f, 0.7632443f, 0.7632443f);
            img_Player2.GetComponent<RectTransform>().localScale = new Vector3(4.215977f, 0.6296356f, 0.6296356f);

        }
        else
        {
            img_Player1.GetComponent<RectTransform>().localScale = new Vector3(4.215977f, 0.6296356f, 0.6296356f);
            img_Player2.GetComponent<RectTransform>().localScale = new Vector3(5.110608f, 0.7632443f, 0.7632443f);
        }
    }

    public void ControlaDado()
    {
        bt_Dado.gameObject.SetActive(false);
        
        if (controlaDado == 1)
        {
            controlaDado = 2;
            Player1.jogarDado();
        }
        else
        {
            controlaDado = 1;
            Player2.jogarDado();
        }

    }
    
    public void trocaTexto(string qualTexto, int qtd)
    {
        if (qualTexto.ToLower().Equals("dado"))
        {
            txt_Dado.text = "Tirou " + qtd + " no Dado";
        }
    }

    void CadastraCasas()
    {
        casas[0] = new Vector3(7.764f, 0.135f, -13.853f);
        casas[1] = new Vector3(6.679f, 0.135f, -14.115f);
        casas[2] = new Vector3(5.852f, 0.135f, -14.115f);
        casas[3] = new Vector3(5.029f, 0.135f, -14.115f);
        casas[4] = new Vector3(4.2f, 0.135f, -14.115f);
        casas[5] = new Vector3(3.394f, 0.135f, -14.115f);
        casas[6] = new Vector3(2.569f, 0.135f, -14.115f);
        casas[7] = new Vector3(1.753f, 0.135f, -14.115f);
        casas[8] = new Vector3(0.928f, 0.135f, -14.115f);
        casas[9] = new Vector3(0.124f, 0.135f, -14.115f);
        casas[10] = new Vector3(-1.425f, 0.135f, -14.256f);
        casas[11] = new Vector3(-1.18f, 0.135f, -12.76f);
        casas[12] = new Vector3(-1.18f, 0.135f, -11.96f);
        casas[13] = new Vector3(-1.18f, 0.135f, -11.13f);
        casas[14] = new Vector3(-1.18f, 0.135f, -10.31f);
        casas[15] = new Vector3(-1.18f, 0.135f, -9.49f);
        casas[16] = new Vector3(-1.18f, 0.135f, -8.68f);
        casas[17] = new Vector3(-1.18f, 0.135f, -7.82f);
        casas[18] = new Vector3(-1.18f, 0.135f, -7.04f);
        casas[19] = new Vector3(-1.18f, 0.135f, -6.23f);
        casas[20] = new Vector3(-0.77f, 0.135f, -4.96f);
        casas[21] = new Vector3(0.112f, 0.135f, -4.96f);
        casas[22] = new Vector3(0.96f, 0.135f, -4.96f);
        casas[23] = new Vector3(1.75f, 0.135f, -4.96f);
        casas[24] = new Vector3(2.56f, 0.135f, -4.96f);
        casas[25] = new Vector3(3.41f, 0.135f, -4.96f);
        casas[26] = new Vector3(4.22f, 0.135f, -4.96f);
        casas[27] = new Vector3(5.045f, 0.135f, -4.96f);
        casas[28] = new Vector3(5.87f, 0.135f, -4.96f);
        casas[29] = new Vector3(6.665f, 0.135f, -4.96f);
        casas[30] = new Vector3(7.966f, 0.135f, -5.247f);
        casas[31] = new Vector3(7.966f, 0.135f, -6.194f);
        casas[32] = new Vector3(7.966f, 0.135f, -7.017f);
        casas[33] = new Vector3(7.966f, 0.135f, -7.854f);
        casas[34] = new Vector3(7.966f, 0.135f, -8.659f);
        casas[35] = new Vector3(7.966f, 0.135f, -9.47f);
        casas[36] = new Vector3(7.966f, 0.135f, -10.3f);
        casas[37] = new Vector3(7.966f, 0.135f, -11.117f);
        casas[38] = new Vector3(7.966f, 0.135f, -11.96f);
        casas[39] = new Vector3(7.966f, 0.135f, -12.768f);

    }

}
