using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charStatus : MonoBehaviour
{
    public string charName;
    public int hp;//HP
    public int mp;//MP
    public int atackPower = 0;//たたかうコマンドの攻撃力
    //各状態変化の画像
    [HideInInspector]public int blockTurn=0;//防御状態フラグ
    [SerializeField]GameObject Abuff;
    [SerializeField]GameObject Adebuff;
    [SerializeField]GameObject Dbuff;
    [SerializeField]GameObject Ddebuff;
    
    // Start is called before the first frame update
    void Awake()
    {
        /*
        Abuff = GameObject.Find("attack_buff");
        Adebuff = GameObject.Find("attack_debuff");
        Dbuff = GameObject.Find("deffence_buff");
        Ddebuff = GameObject.Find("deffence_debuff");
        */
        Abuff.SetActive(false);
        Adebuff.SetActive(false);
        Dbuff.SetActive(false);
        Ddebuff.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    //防御状態制御
    public void blockStatus(int Turn){
        if(Turn>0){
            Dbuff.SetActive(true);
            blockTurn = Turn;
        }
        else{
            blockTurn = 0;
            Dbuff.SetActive(false);
        }
    }  
}
