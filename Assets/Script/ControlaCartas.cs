using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ControlaCartas : MonoBehaviour
{
    //[SerializeField] public static int[] precos = new int[22];
    //[SerializeField] public static int[] casa0 = new int[22];
    //[SerializeField] public static int[] casa1 = new int[22];
    //[SerializeField] public static int[] casa2 = new int[22];
    //[SerializeField] public static int[] casa3 = new int[22];
    //[SerializeField] public static int[] casa4 = new int[22];
    //[SerializeField] public static int[] casa5 = new int[22];
    [SerializeField] public static Vector3[] v3_pos = new Vector3[22];
    [SerializeField] public static string[] txt_names = new string[22];
    [SerializeField] public static string[] txt_precos = new string[22];
    [SerializeField] public static string[] txt_casa0= new string[22];
    [SerializeField] public static string[] txt_casa1= new string[22];
    [SerializeField] public static string[] txt_casa2= new string[22];
    [SerializeField] public static string[] txt_casa3= new string[22];
    [SerializeField] public static string[] txt_casa4= new string[22];
    [SerializeField] public static string[] txt_casa5= new string[22];

    public string teste;


    private void Start()
    {
        teste = File.ReadAllText("Assets\\texto.txt");
        

        //print(teste.Length);
        //print(teste[3]);
        //print(teste[4]);

        LerTxt(teste);
        cadastraCasasConfirm();


    }

    void LerTxt(string texto)
    {
        int k = -1;
        int l = -1;

        for (int i = 0; i < texto.Length; i++)
        {
            //print(teste[i]);
            //if (texto[i].Equals(""))

            //print(texto[i]);

            if (texto[i].Equals("Z"[0]) || texto[i].Equals("X"[0]) || texto[i].Equals("W"[0]))
            {
                l++;
                k = -1;
                //print("entrou aqui");
            }
            else if (texto[i].Equals(texto[0]))
            {
                k++;
            }
            else if (texto[i].Equals(texto[1]))
            {
                
            }
            else
            {
                switch (l)
                {
                    case -1:

                        Debug.Log((teste[i]));
                        
                        break;
                    
                    case 0:

                        txt_precos[k] += "" + (teste[i] - 48) ;
                        break;

                    case 1:
                        txt_casa0[k] += "" + (teste[i] - 48);

                        break;
                    case 2:
                        txt_casa1[k] += "" + (teste[i] - 48);

                        break;
                    case 3:
                        txt_casa2[k] += "" + (teste[i] - 48);

                        break;
                    case 4:
                        txt_casa3[k] += "" + (teste[i] - 48);

                        break;
                    case 5:
                        txt_casa4[k] += "" + (teste[i] - 48);

                        break;
                    case 6:
                        txt_casa5[k] += "" + (teste[i] - 48);

                        break;
                    case 7:
                        txt_names[k] += "" + teste[i];

                        break;
 
                }
                
            }

            
        }

        //for (int i = 0; i < txt_names.Length; i++)
        //{
        //    print(txt_names[i]);    
        //}
    }

    void cadastraCasasConfirm()
    {
        v3_pos[0] = new Vector3(6.667f, 0.122f, -14.645f);
        v3_pos[1] = new Vector3(5.036f, 0.122f, -14.645f);
        v3_pos[2] = new Vector3(2.557f, 0.122f, -14.645f);
        v3_pos[3] = new Vector3(0.924f, 0.122f, -14.645f);
        v3_pos[4] = new Vector3(0.122f, 0.122f, -14.645f);
        v3_pos[5] = new Vector3(-1.64f, 0.122f, -12.81f);
        v3_pos[6] = new Vector3(-1.64f, 0.122f, -11.131f);
        v3_pos[7] = new Vector3(-1.64f, 0.122f, -10.314f);
        v3_pos[8] = new Vector3(-1.64f, 0.122f, -8.667f);
        v3_pos[9] = new Vector3(-1.64f, 0.122f, -7.032f);
        v3_pos[10] = new Vector3(-1.64f, 0.122f, -6.219f);
        v3_pos[11] = new Vector3(0.119f, 0.122f, -4.49f);
        v3_pos[12] = new Vector3(1.737f, 0.122f, -4.49f);
        v3_pos[13] = new Vector3(2.556f, 0.122f, -4.49f);
        v3_pos[14] = new Vector3(4.212f, 0.122f, -4.49f);
        v3_pos[15] = new Vector3(5.031f, 0.122f, -4.49f);
        v3_pos[16] = new Vector3(6.665f, 0.122f, -4.49f);
        v3_pos[17] = new Vector3(8.363f, 0.122f, -6.178f);
        v3_pos[18] = new Vector3(8.363f, 0.122f, -7.033f);
        v3_pos[19] = new Vector3(8.363f, 0.122f, -8.669f);
        v3_pos[20] = new Vector3(8.363f, 0.122f, -11.124f);
        v3_pos[21] = new Vector3(8.363f, 0.122f, -12.761f);
    }

}