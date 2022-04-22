using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlaGame : MonoBehaviour
{
    [Header("Cartas")]
    [SerializeField] private GameObject cartaMarrom;
    [SerializeField] private GameObject cartaAzulC;
    [SerializeField] private GameObject cartaRosa;
    [SerializeField] private GameObject cartaLaranja;
    [SerializeField] private GameObject cartaVermelho;
    [SerializeField] private GameObject cartaAmarelo;
    [SerializeField] private GameObject cartaVerde;
    [SerializeField] private GameObject cartaAzul;

    [Header("Configs")]
    [SerializeField] private Button bt_Comprar;
    [SerializeField] private Button bt_Fechar;
    [SerializeField] private Button bt_Dado;
    [SerializeField] private Image img_Player1;
    [SerializeField] private Image img_Player2;

    //[Header("Material de confirmção de compras ")]
    //[SerializeField] private Material mt_ConfPl1;

    [Header("Prefabs ")]
    [SerializeField] private GameObject ConfPl1;
    [SerializeField] private GameObject ConfPl2;
    
    [Header("Casas")]
    public Vector3[] casas = new Vector3[40];


    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Marrons ")]
    private int podeComprarCartaMarrom01 = 0;
    private int podeComprarCartaMarrom02 = 0;
    
    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Azul Claro ")]
    private int podeComprarCartaAzulC01 = 0;
    private int podeComprarCartaAzulC02 = 0;
    private int podeComprarCartaAzulC03 = 0;

    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Rosa ")]
    private int podeComprarCartaRosa01= 0;
    private int podeComprarCartaRosa02= 0;
    private int podeComprarCartaRosa03= 0;

    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Laranja ")]
    private int podeComprarCartaLaranja01= 0;
    private int podeComprarCartaLaranja02= 0;
    private int podeComprarCartaLaranja03= 0;

    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Vermelho ")]
    private int podeComprarCartaVermelho01 = 0;
    private int podeComprarCartaVermelho02 = 0;
    private int podeComprarCartaVermelho03 = 0;

    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Amarelo ")]
    private int podeComprarCartaAmrelo01= 0;
    private int podeComprarCartaAmrelo02= 0;
    private int podeComprarCartaAmrelo03= 0;

    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Verde ")]
    private int podeComprarCartaVerde01 = 0;
    private int podeComprarCartaVerde02 = 0;
    private int podeComprarCartaVerde03 = 0;

    //TROCAR POR UMA ARRAY COM TODOS INTS 
    [Header("Pode Comprar Cartas Amarelo ")]
    private int podeComprarCartaAzul01 = 0;
    private int podeComprarCartaAzul02 = 0;
    


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
        else if (nCasa == 6 || nCasa == 8 || nCasa == 9)
        {
            CartaAzulClaro();
        }
        else if (nCasa == 11 || nCasa == 13 || nCasa == 14)
        {
            CartaRosa();
        }
        else if (nCasa == 16 || nCasa == 18 || nCasa == 19)
        {
            CartaLaranja();
        }
        else if (nCasa == 21 || nCasa == 23 || nCasa == 24)
        {
            CartaVermelho();
        }
        else if (nCasa == 26 || nCasa == 27 || nCasa == 29)
        {
            CartaAmarelo();
        }
        else if (nCasa == 31 || nCasa == 32 || nCasa == 34)
        {
            CartaVerde();
        }
        else if (nCasa == 37 || nCasa == 39 )
        {
            CartaAzul();
        }

        else
        {
            bt_Dado.gameObject.SetActive(true);
            ControlaHudPlayer();

        }
    }

    private void CartaMarrom()
    {

        bt_Dado.gameObject.SetActive(false); 

        if (nCasa == 1)
        {
            if (podeComprarCartaMarrom01 == 0)
            {
                //lIGA A HUD    
                LigaAHudDeCompra(cartaMarrom);

                //configura os botões 
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaMarrom, 101, nPlayer , 1 , 50));
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
                LigaAHudDeCompra(cartaMarrom);



                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaMarrom, 102, nPlayer, 2 , 100));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaMarrom));
            }
            else
            {
                Pagar(podeComprarCartaMarrom02);
            }
        }

               
    }

    private void CartaAzulClaro()
    {
        //print("entrou na azul claro");
        //bt_Dado.gameObject.SetActive(true);
        //ControlaHudPlayer();


        if (nCasa == 6)
        {
            if (podeComprarCartaAzulC01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAzulC);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAzulC, 201, nPlayer, 3, 200));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAzulC));

            }
            else
            {
                Pagar(podeComprarCartaAzulC01);
            }


        } 
        else if (nCasa == 8)
        {
            if (podeComprarCartaAzulC02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAzulC);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAzulC, 202, nPlayer, 4, 200));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAzulC));

            }
            else
            {
                Pagar(podeComprarCartaAzulC02);
            }

        }
        else if (nCasa == 9)
        {
            if (podeComprarCartaAzulC03 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAzulC);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAzulC, 203, nPlayer, 5, 200));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAzulC));

            }
            else
            {
                Pagar(podeComprarCartaAzulC03);
            }

        }


    }

    private void CartaRosa()
    {
        if (nCasa == 11)
        {
            if (podeComprarCartaRosa01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaRosa);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaRosa, 301, nPlayer, 6, 300));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaRosa));

            }
            else
            {
                Pagar(podeComprarCartaRosa01);
            }


        }
        else if (nCasa == 13)
        {
            if (podeComprarCartaRosa02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaRosa);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaRosa, 302, nPlayer, 7, 300));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaRosa));

            }
            else
            {
                Pagar(podeComprarCartaRosa02);
            }

        }
        else if (nCasa == 14)
        {
            if (podeComprarCartaRosa03 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaRosa);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaRosa, 303, nPlayer, 8, 300));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaRosa));

            }
            else
            {
                Pagar(podeComprarCartaRosa03);
            }

        }

    }

    private void CartaLaranja()
    {

        if (nCasa == 16)
        {
            if (podeComprarCartaLaranja01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaLaranja);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaLaranja, 401, nPlayer, 9, 400));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaLaranja));

            }
            else
            {
                Pagar(podeComprarCartaLaranja01);
            }


        }
        else if (nCasa == 18)
        {
            if (podeComprarCartaLaranja02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaLaranja);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaLaranja, 402, nPlayer, 10, 400));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaLaranja));

            }
            else
            {
                Pagar(podeComprarCartaLaranja02);
            }

        }
        else if (nCasa == 19)
        {
            if (podeComprarCartaLaranja03 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaLaranja);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaLaranja, 403, nPlayer, 11 , 400));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaLaranja));

            }
            else
            {
                Pagar(podeComprarCartaLaranja03);
            }

        }
    }

    private void CartaVermelho()
    {

        if (nCasa == 21)
        {
            if (podeComprarCartaVermelho01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaVermelho);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaVermelho, 501, nPlayer, 12, 500));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaVermelho));

            }
            else
            {
                Pagar(podeComprarCartaVermelho01);
            }


        }
        else if (nCasa == 23)
        {
            if (podeComprarCartaVermelho02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaVermelho);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaVermelho, 502, nPlayer, 13, 500));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaVermelho));

            }
            else
            {
                Pagar(podeComprarCartaVermelho02);
            }

        }
        else if (nCasa == 24)
        {
            if (podeComprarCartaVermelho03 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaVermelho);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaVermelho, 503, nPlayer, 14, 500));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaVermelho));

            }
            else
            {
                Pagar(podeComprarCartaVermelho03);
            }

        }
    }

    private void CartaAmarelo()
    {
        if (nCasa == 26)
        {
            if (podeComprarCartaAmrelo01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAmarelo);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAmarelo, 601, nPlayer, 15, 600));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAmarelo));

            }
            else
            {
                Pagar(podeComprarCartaAmrelo01);
            }


        }
        else if (nCasa == 27)
        {
            if (podeComprarCartaAmrelo02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAmarelo);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAmarelo, 602, nPlayer, 16, 600));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAmarelo));

            }
            else
            {
                Pagar(podeComprarCartaAmrelo02);
            }

        }
        else if (nCasa == 29)
        {
            if (podeComprarCartaAmrelo03 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAmarelo);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAmarelo, 603, nPlayer, 17, 600));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAmarelo));

            }
            else
            {
                Pagar(podeComprarCartaAmrelo03);
            }

        }
    }

    private void CartaVerde()
    {
        if (nCasa == 31)
        {
            if (podeComprarCartaVerde01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaVerde);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaVerde, 701, nPlayer, 18, 700));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaVerde));

            }
            else
            {
                Pagar(podeComprarCartaVerde01);
            }


        }
        else if (nCasa == 32)
        {
            if (podeComprarCartaVerde02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaVerde);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaVerde, 702, nPlayer, 19, 700));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaVerde));

            }
            else
            {
                Pagar(podeComprarCartaVerde02);
            }

        }
        else if (nCasa == 34)
        {
            if (podeComprarCartaVerde03 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaVerde);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaVerde, 703, nPlayer, 20, 700));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaVerde));

            }
            else
            {
                Pagar(podeComprarCartaVerde03);
            }

        }
    }

    private void CartaAzul()
    {
        if (nCasa == 37)
        {
            if (podeComprarCartaAzul01 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAzul);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAzul, 801, nPlayer, 21, 800));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAzul));

            }
            else
            {
                Pagar(podeComprarCartaAzul01);
            }


        }
        else if (nCasa == 39)
        {
            if (podeComprarCartaAzul02 == 0)
            {
                //Liga a Hud
                LigaAHudDeCompra(cartaAzul);

                //configura botões
                bt_Comprar.onClick.RemoveAllListeners();
                bt_Comprar.onClick.AddListener(() => Comprar(cartaAzul, 802, nPlayer, 22, 800));
                bt_Fechar.onClick.AddListener(() => Fechar(cartaAzul));

            }
            else
            {
                Pagar(podeComprarCartaAzul02);
            }

        }
        

    }


    private void LigaAHudDeCompra(GameObject carta)
    {
        carta.SetActive(true);
        bt_Comprar.gameObject.SetActive(true);
        bt_Fechar.gameObject.SetActive(true);

    }

    //PlayerMoviment


    void Comprar(GameObject Carta, int preco , int qualPlayer , int qualCarta, int custo)
    {
        
        bt_Comprar.gameObject.SetActive(false);
        bt_Fechar.gameObject.SetActive(false);
        bt_Dado.gameObject.SetActive(true);
        Carta.SetActive(false);
        GameObject confirm ;


        //print(qualPlayer);

        if (qualPlayer == 1)
        {
            Player1.moeda -= preco;
            confirm = ConfPl1;
        }
        else if (qualPlayer == 2)
        {
            Player2.moeda -= preco;
            confirm = ConfPl2;
        }
        else
        {
            confirm = ConfPl1;

        }

        //qualPlayer.moeda -= preco;

        switch (qualCarta)
        {
                //azul marrom
            case 1:
                podeComprarCartaMarrom01 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(6.667f, 0.122f, -14.645f), Quaternion.identity);
                
                break;

            case 2:
                podeComprarCartaMarrom02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(5.036f, 0.122f, -14.645f), Quaternion.identity);

                break;
                //azul Claro
            case 3:
                podeComprarCartaAzulC01 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(2.557f, 0.122f, -14.645f), Quaternion.identity);

                break;
            case 4:
                podeComprarCartaAzulC02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(0.924f, 0.122f, -14.645f), Quaternion.identity);

                break;
            case 5:
                podeComprarCartaAzulC03 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(0.122f, 0.122f, -14.645f), Quaternion.identity);

                break;
                //rosa
            case 6:
                podeComprarCartaRosa01 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(-1.64f, 0.122f, -12.81f), Quaternion.identity);

                break;
            case 7:
                podeComprarCartaRosa02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(-1.64f, 0.122f, -11.131f), Quaternion.identity);

                break;
            case 8:
                podeComprarCartaRosa03= (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(-1.64f, 0.122f, -10.314f), Quaternion.identity);

                break;

                //Laranja
            case 9:
                podeComprarCartaLaranja01 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(-1.64f, 0.122f, -8.667f), Quaternion.identity);

                break;
            case 10:
                podeComprarCartaLaranja02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(-1.64f, 0.122f, -7.032f), Quaternion.identity);

                break;
            case 11:
                podeComprarCartaLaranja03 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(-1.64f, 0.122f, -6.219f), Quaternion.identity);

                break;

            //Vermelho 
            case 12:
                podeComprarCartaVermelho01 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(0.119f, 0.122f, -4.49f), Quaternion.identity);

                break;
            case 13:
                podeComprarCartaVermelho02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(1.737f, 0.122f, -4.49f), Quaternion.identity);

                break;
            case 14:
                podeComprarCartaVermelho03 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(2.556f, 0.122f, -4.49f), Quaternion.identity);

                break;

            //Amarelo
            case 15:
               podeComprarCartaAmrelo01  = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(4.212f, 0.122f, -4.49f), Quaternion.identity);

                break;
            case 16:
                podeComprarCartaAmrelo02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(5.031f, 0.122f, -4.49f), Quaternion.identity);

                break;
            case 17:
                podeComprarCartaAmrelo03 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(6.665f, 0.122f, -4.49f), Quaternion.identity);

                break;

            //Verde
            case 18:
                podeComprarCartaVerde01= (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(8.363f, 0.122f, -6.178f), Quaternion.identity);

                break;
            case 19:
                podeComprarCartaVerde02= (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(8.363f, 0.122f, -7.033f), Quaternion.identity);

                break;
            case 20:
                podeComprarCartaVerde03 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(8.363f, 0.122f, -8.669f), Quaternion.identity);

                break;


            //Azul 
            case 21:
                podeComprarCartaAzul01= (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(8.363f, 0.122f, -11.124f), Quaternion.identity);

                break;
            case 22:
                podeComprarCartaAzul02 = (nPlayer * 10000) + custo;
                Instantiate(confirm, new Vector3(8.363f, 0.122f, -12.761f), Quaternion.identity);

                break;
           

            default:

                print("entrou na Default");

                break;

        }


        ControlaHudPlayer();

    }

    //private void ColocarConfirm(int podeComprar , Vector3 lugar)
    //{
        
    //}


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
