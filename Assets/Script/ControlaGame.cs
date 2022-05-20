using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlaGame : MonoBehaviour
{
    [Header("Cartas")]
    [SerializeField] private GameObject corCarta;
    [SerializeField] private GameObject cartaMolde;
    [SerializeField] private GameObject cartaCofre;
    [SerializeField] private TextMeshProUGUI txt_nameCarta;
    [SerializeField] private TextMeshProUGUI txt_precoCarta;
    [SerializeField] private TextMeshProUGUI txt_casa0Carta;
    [SerializeField] private TextMeshProUGUI txt_casa1Carta;
    [SerializeField] private TextMeshProUGUI txt_casa2Carta;
    [SerializeField] private TextMeshProUGUI txt_casa3Carta;
    [SerializeField] private TextMeshProUGUI txt_casa4Carta;
    [SerializeField] private TextMeshProUGUI txt_casa5Carta;
    
    private Color32 cartaMarrom = new Color32(170, 82, 57, 255);
    private Color32 cartaAzulC = new Color32(126, 206, 247, 255);
    private Color32 cartaRosa = new Color32(203, 93, 170, 255);
    private Color32 cartaLaranja = new Color32(214, 149, 71, 255);
    private Color32 cartaVermelho = new Color32(217, 69, 82, 255);
    private Color32 cartaAmarelo = new Color32(203, 215, 74, 255);
    private Color32 cartaVerde = new Color32(0, 177, 129, 255);
    private Color32 cartaAzul = new Color32(0, 149, 219, 255);

    [Header("Configs")]
    [SerializeField] private Button bt_Comprar;
    [SerializeField] private Button bt_Fechar;
    [SerializeField] private Button bt_Dado;
    [SerializeField] private Button bt_TrocarCartas;
    [SerializeField] private Image img_Player1;
    [SerializeField] private Image img_Player2;
    [SerializeField] private GameObject Ui_TrocarCartas;
    

    //[Header("Material de confirmção de compras ")]
    //[SerializeField] private Material mt_ConfPl1;

    [Header("Prefabs ")]
    [SerializeField] private GameObject ConfPl1;
    [SerializeField] private GameObject ConfPl2;
    [SerializeField] private Button bt_Propriedades;
    
    [Header("Casas")]
    public Vector3[] casas = new Vector3[40];

    [Header("Pode comprar casa em uma Array com todas as cores")]
    private int[] podeComprarCartas = new int[22];
    private int[] podeTrocarCartas = new int[22];
    private int[] podeTrocarCartasMinha = new int[22];

    [Header("Controlador de dado")]
    private int controlaDado = 1;

    [Header("Textos")]
    public TextMeshProUGUI txt_Dado;
    public TextMeshProUGUI txt_MoedaPlayer1;
    public TextMeshProUGUI txt_MoedaPlayer2;
    public TextMeshProUGUI txt_cofre;
    public GameObject txt_TextField;

    [Header("Numero auxiliar para a troca de carta")]
    private int valTroca;



    [Header("Players ")]
    public PlayerMoviment Player1;
    public PlayerMoviment Player2;

    [Header("Numero da casa e qual player ")]
    private int nCasa, nPlayer;

    private void Awake()
    {
        CadastraCasas();
        CadastraCartas();
    }

    void Start()
    {

        //numCasa = 0;
        //print(numCasa);
        bt_Fechar.gameObject.SetActive(false);
        bt_Comprar.gameObject.SetActive(false);
        img_Player1.GetComponent<RectTransform>().localScale = new Vector3(5.110608f, 0.7632443f, 0.7632443f);

        //SeiLa();    
        


        
    
    }

    public void testeTextField(int j)
    {



        if (int.TryParse(txt_TextField.GetComponent<TMP_InputField>().text, out int a))
        {
            if (int.Parse(txt_TextField.GetComponent<TMP_InputField>().text) + j  >= 0)
            {

                valTroca = int.Parse(txt_TextField.GetComponent<TMP_InputField>().text) + j;
                txt_TextField.GetComponent<TMP_InputField>().text = valTroca.ToString();
            
            }
            //print(a);

        }
        else
        {
            if (j > 0)
            {
                valTroca = j;
                txt_TextField.GetComponent<TMP_InputField>().text = valTroca.ToString();
            
            }
        }

        if (j == 0)
        {
            if (int.Parse(txt_TextField.GetComponent<TMP_InputField>().text) >= 0)
            {
                print("enviou a proposta");
                FecharTrocaCarta();

            }
            else
            {
                print("num negativo");
            }

        }



       
    }

    private void TrocarCartasPlayers()
    {
        int k = 0;
        int m = 0;
        resetTrocaCartas();
        for (int i = 0; i < podeComprarCartas.Length; i++)
        {
            if (podeComprarCartas[i] != 0)
            {
                if (podeComprarCartas[i] / 10000 != controlaDado)
                {
                    bt_TrocarCartas.gameObject.SetActive(true);

                    podeTrocarCartas[k] = i;
                    k++;

                }
                else
                {
                    podeTrocarCartasMinha[m] = i;
                    m++;
                }
            }
            
        }
                   
    }

    public void BotaoTrocaAtivado(GameObject sda)
    {
        //print("qq cosia");
        //print(sda);
        Color32 corAtual = sda.GetComponent<Image>().color;
        //print(corAtual.a);

        if (corAtual.a == 255)
        {
            sda.GetComponent<Image>().color = new Color32(255, 61, 83, 100);
        }
        else
        {
            sda.GetComponent<Image>().color = new Color32(255, 61, 83, 255);
        
        }

        //
        //new Color32(255, 61, 83, 255);
    }


    public void AtivaCartasTroca()
    {
        int y = 752 + 80;
        int y2 = 752 + 80;
        GameObject ds;
        Color32 pl_1 = new Color32(255,61,83,100);
        Color32 pl_2 = new Color32(160, 255, 160, 100); 

        //660

        bt_TrocarCartas.gameObject.SetActive(false);    

        //São as cartas do outro player 
        foreach (var item in podeTrocarCartas)
        {
            if (item != -1)
            {
                var teste = Instantiate(bt_Propriedades, new Vector3(1172, y - 80, 0), Quaternion.identity);
                teste.transform.parent = Ui_TrocarCartas.transform;
                teste.GetComponentInChildren<TextMeshProUGUI>().text = ControlaCartas.txt_names[item];
                teste.GetComponent<Image>().color = pl_1;
                ds = teste.gameObject;
                teste.onClick.RemoveAllListeners();
                teste.onClick.AddListener(() => BotaoTrocaAtivado(ds));
                y -= 80;
                //print(teste.name);
            
            }
        }

        foreach (var item in podeTrocarCartasMinha)
        {
            if (item != -1)
            {
                var teste = Instantiate(bt_Propriedades, new Vector3(660, y2 - 80, 0), Quaternion.identity);
                teste.transform.parent = Ui_TrocarCartas.transform;
                teste.GetComponentInChildren<TextMeshProUGUI>().text = ControlaCartas.txt_names[item];
                teste.GetComponent<Image>().color = pl_2;
                y2 -= 80;

            }
        }


        Ui_TrocarCartas.SetActive(true) ;
    }
 

    public void LerCasa( int numCasa , int numPlayer) 
    {
        nCasa = numCasa;
        nPlayer = numPlayer;

        


        //Carta Marrom
        if (nCasa == 1 || nCasa == 3)
        {

            if (nCasa == 1)
            {
                numCasa = 0;
                compraCarta(numCasa, cartaMarrom, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);


            } else
            {
                numCasa = 1;
                compraCarta(numCasa, cartaMarrom, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }


        }

        //Carta Azul Claro
        else if (nCasa == 6 || nCasa == 8 || nCasa == 9)
        {

            if (nCasa == 6)
            {
                numCasa = 2;
                compraCarta(numCasa, cartaAzulC, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else if (nCasa == 8)
            {
                numCasa = 3;
                compraCarta(numCasa, cartaAzulC, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 4;
                compraCarta(numCasa, cartaAzulC, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);

            }

        }

        //Carta Rosa
        else if (nCasa == 11 || nCasa == 13 || nCasa == 14)
        {

            if (nCasa == 11)
            {
                numCasa = 5;
                compraCarta(numCasa, cartaRosa, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else if (nCasa == 13)
            {
                numCasa = 6;
                compraCarta(numCasa, cartaRosa, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 7;
                compraCarta(numCasa, cartaRosa, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);

            }

        }

        //Carta Laranja
        else if (nCasa == 16 || nCasa == 18 || nCasa == 19)
        {

            if (nCasa == 16)
            {
                numCasa = 8;
                compraCarta(numCasa, cartaLaranja, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else if (nCasa == 18)
            {
                numCasa = 9;
                compraCarta(numCasa, cartaLaranja, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 10;
                compraCarta(numCasa, cartaLaranja, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);

            }


        }

        //Carta Vermelho
        else if (nCasa == 21 || nCasa == 23 || nCasa == 24)
        {

            if (nCasa == 21)
            {
                numCasa = 11;
                compraCarta(numCasa, cartaVermelho, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else if (nCasa == 23)
            {
                numCasa = 12;
                compraCarta(numCasa, cartaVermelho, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 13;
                compraCarta(numCasa, cartaVermelho, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);

            }

        }

        //Carta Amarelo
        else if (nCasa == 26 || nCasa == 27 || nCasa == 29)
        {

            if (nCasa == 26)
            {
                numCasa = 14;
                compraCarta(numCasa, cartaAmarelo, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else if (nCasa == 27)
            {
                numCasa = 15;
                compraCarta(numCasa, cartaAmarelo, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 16;
                compraCarta(numCasa, cartaAmarelo, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);

            }
        }

        //Carta Verde
        else if (nCasa == 31 || nCasa == 32 || nCasa == 34)
        {

            if (nCasa == 31)
            {
                numCasa = 17;
                compraCarta(numCasa, cartaVerde, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else if (nCasa == 32)
            {
                numCasa = 18;
                compraCarta(numCasa, cartaVerde, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 19;
                compraCarta(numCasa, cartaVerde, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);

            }

        }

        //Carta Azul
        else if (nCasa == 37 || nCasa == 39)
        {

            if (nCasa == 37)
            {
                numCasa = 20;
                compraCarta(numCasa, cartaAzul, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }
            else
            {
                numCasa = 21;
                compraCarta(numCasa, cartaAzul, ControlaCartas.txt_names[numCasa], int.Parse(ControlaCartas.txt_precos[numCasa]), int.Parse(ControlaCartas.txt_casa0[numCasa]), ControlaCartas.v3_pos[numCasa]);
            }

        }

        //Carta Cofre
        else if (nCasa == 2 || nCasa == 17 || nCasa == 33)
        {
            Cofre();
        }

        //Preso
        else if (nCasa == 30)
        {
            Prisao();
        }
        else
        {
            bt_Dado.gameObject.SetActive(true);
            ControlaHudPlayer();

        }
    }


    private void compraCarta(int podeCompra , Color32 carta ,string nameCarta ,int preco, int custo , Vector3 confirmDaCompra)
    {
       
        if (podeComprarCartas[podeCompra] == 0)
        {
            LigaAHudDeCompra(carta,nameCarta,podeCompra);

            //configura botões 
            bt_Comprar.onClick.RemoveAllListeners();
            bt_Comprar.onClick.AddListener(() => Comprar(carta, preco, nPlayer, custo,podeCompra, confirmDaCompra ));
            
            bt_Fechar.onClick.RemoveAllListeners();
            bt_Fechar.onClick.AddListener(() => Fechar(cartaMolde));

       
        }
        else
        {
            Pagar(podeComprarCartas[podeCompra]);

        }
        
            
    }

   
    void Comprar(Color32 Carta, int preco , int qualPlayer , int custo , int podeCompra , Vector3 ConfirmacaoCompra)
    {
        //Só coloquei o Color 32 para não ter que trocar todas as referencias 

        bt_Comprar.gameObject.SetActive(false);
        bt_Fechar.gameObject.SetActive(false);
        bt_Dado.gameObject.SetActive(true);
        cartaMolde.SetActive(false);
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

        podeComprarCartas[podeCompra] = (nPlayer * 10000) + custo;

        Instantiate(confirm, ConfirmacaoCompra, Quaternion.identity);

        ControlaHudPlayer();



    }


    private void LigaAHudDeCompra(Color32 color, string name , int qualCasa)
    {
        corCarta.GetComponent<RawImage>().color = color;
        cartaMolde.SetActive(true);
        //Debug.Log(name);


        bt_Comprar.gameObject.SetActive(true);
        bt_Fechar.gameObject.SetActive(true);

        txt_nameCarta.text = name;
        txt_precoCarta.text = ControlaCartas.txt_precos[qualCasa];
        txt_casa0Carta.text = ControlaCartas.txt_casa0[qualCasa];
        txt_casa1Carta.text = ControlaCartas.txt_casa1[qualCasa];
        txt_casa2Carta.text = ControlaCartas.txt_casa2[qualCasa];
        txt_casa3Carta.text = ControlaCartas.txt_casa3[qualCasa];
        txt_casa4Carta.text = ControlaCartas.txt_casa4[qualCasa];
        txt_casa5Carta.text = ControlaCartas.txt_casa5[qualCasa];


    }

    void Cofre()
    {

        int precoFrase = Random.Range(-20 , 20) * 10;
        string[] frases = new string[3];
        frases[0] = "Seu pai bateu o carro e você vai ajudar , PAGUE : ";
        frases[1] = "Você ganhou um prêmio no trabalho , GANHE : ";
        frases[2] = "Você é muito sortudo , ganhou um sorteio , GANHE : ";

        //print("entrou aqui");
        cartaCofre.SetActive(true);

        if (nPlayer == 1)
        {
            Player1.moeda += precoFrase;
        }
        else if (nPlayer== 2)
        {
            Player2.moeda += precoFrase;
        }

        if (precoFrase < 0)
        {
            txt_cofre.text = frases[0] + (precoFrase * -1);
        }
        else if (precoFrase == 0)
        {
            txt_cofre.text = "Não aconteceu nada , deu sorte";
        }
        else
        {
            txt_cofre.text = frases[Random.Range(1,2)] + precoFrase;
        }

        bt_Fechar.gameObject.SetActive(true);
        bt_Fechar.onClick.RemoveAllListeners();
        bt_Fechar.onClick.AddListener(() => Fechar(cartaCofre));

    }

    private void Pagar(int qualCasa)
    {
        bt_Dado.gameObject.SetActive(true);

        int playerPraPagar = (qualCasa / 10000);
        int quantoPraPagar = (qualCasa % 10000);

        if (nPlayer == 1)
        {
            Player1.moeda -= quantoPraPagar;
            Player2.moeda += quantoPraPagar;
        }
        else
        {
            Player2.moeda -= quantoPraPagar;
            Player1.moeda += quantoPraPagar;
        }


        print("a casa já tem dono : " + qualCasa);
        print("Qual e o plaher : " + playerPraPagar );
        print("Quanto é pra pagar : " + quantoPraPagar);
        ControlaHudPlayer();

    }

    public void FecharTrocaCarta()
    {
        GameObject[] prosp;
        prosp = GameObject.FindGameObjectsWithTag("prop");
        valTroca = 0;
        txt_TextField.GetComponent<TMP_InputField>().text = "";

        //print(prosp.Length);
        //    print(go.name);
        foreach (GameObject go in prosp)
        {
            Destroy(go);
        }
        
        Ui_TrocarCartas.SetActive(false);
    }

    void Fechar(GameObject carta)
    {
        ControlaHudPlayer();
        bt_Fechar.gameObject.SetActive(false);
        bt_Comprar.gameObject.SetActive(false);
        bt_Dado.gameObject.SetActive(true);
        carta.SetActive(false);

    }

    private void ControlaHudPlayer()
    {
        txt_MoedaPlayer1.text = Player1.moeda.ToString();
        txt_MoedaPlayer2.text = Player2.moeda.ToString();

        TrocarCartasPlayers(); 

        //print(nPlayer);
        if (controlaDado == 1)
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

    private void Prisao()
    {
        if (nPlayer == 1)
        {
            Player1.preso = 3;
            Player1.transform.position = casas[10];
            Player1.casaAtual = 10;

        } else if (nPlayer == 2)
        {
            Player2.preso = 3;
            Player2.transform.position = casas[10];
            Player2.casaAtual = 10;
        
        }
        bt_Dado.gameObject.SetActive(true);
        ControlaHudPlayer();
    }

    public void ControlaDado()
    {
        bt_Dado.gameObject.SetActive(false);
        bt_TrocarCartas.gameObject.SetActive(false);
        
        if (controlaDado == 1)
        {
            if (Player1.preso == 0)
            {
                Player1.jogarDado();
                controlaDado = 2;
                return;
            }
            else
            {
                Player1.preso --;
                
            }
            controlaDado = 2;

            bt_Dado.gameObject.SetActive(true);
            ControlaHudPlayer();
        }
        else
        {
            if (Player2.preso == 0)
            {
                Player2.jogarDado();
                controlaDado = 1;
                return;
            }
            else
            {
                Player2.preso --;
            }
            controlaDado = 1;
            bt_Dado.gameObject.SetActive(true);
            ControlaHudPlayer();
        }

    }
    
    public void trocaTextoDado(string qualTexto, int qtd)
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

    void resetTrocaCartas()
    {
        for (int i = 0; i < podeTrocarCartas.Length; i++)
        {
            podeTrocarCartas[i] = -1;
            podeTrocarCartasMinha[i] = -1;

        }
    }

    void CadastraCartas()
    {
        for (int i = 0; i < podeComprarCartas.Length; i++)
        {
            podeComprarCartas[i] = 0;
            podeTrocarCartas[i] = -1;
        }
    }
}
