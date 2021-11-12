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
    [HideInInspector]public bool defenceSwich=false;//防御状態フラグ
    [SerializeField]GameObject Abuff;
    [SerializeField]GameObject Adebuff;
    [SerializeField]GameObject Dbuff;
    [SerializeField]GameObject Ddebuff;
    bool GameOver_Flag = false;//GameOverかどうか

    
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
        if(hp<=0 && GameOver_Flag==false){
            GameOver_Flag = true;
            Debug.Log("gameOver");
        }
    }
    public void defence(bool d){
        if(d){
            Dbuff.SetActive(true);
            defenceSwich = true;
        }
        else{
            defenceSwich = false;
            Dbuff.SetActive(false);
        }
    }  
}
