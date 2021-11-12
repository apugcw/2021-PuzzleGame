using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyComand : MonoBehaviour
{
    comandValue comandValue;
    hpControll e_hp_c;//敵HP管理スクリプト
    hpControll p_hp_c;//プレイヤーHP管理スクリプト
    mpControll p_mp_c;//プレイヤーMP管理スクリプト
    backLog log_text;//バックログスクリプト
    TurnManager turnmanager;//ターン管理プログラム
    charStatus status;//プレイヤーステータススクリプト
    skillSE SE;
    // Start is called before the first frame update
    void Start()
    {   
        //ステータス
        GameObject player = GameObject.Find("enemy_status");
        status = player.GetComponent<charStatus>();
        //各コマンドの値
        GameObject comandManager = transform.parent.gameObject;
        comandValue = comandManager.GetComponent<comandValue>();
        //HP管理スクリプトの取得
        GameObject playerHP = GameObject.Find("playerHP");
        p_hp_c = playerHP.GetComponent<hpControll>();
        GameObject enemyHP = GameObject.Find("enemyHP");
        e_hp_c = enemyHP.GetComponent<hpControll>();
        //ログテキストのテキストスクリプト取得
        GameObject logText = GameObject.Find("logText");
        log_text = logText.GetComponent<backLog>();
        //ターン管理スクリプト取得
        GameObject Turn = GameObject.Find("turn");
        turnmanager = Turn.GetComponent<TurnManager>();
        //SE
        SE = GameObject.Find("SEManager").GetComponent<skillSE>();
    }

    public void Atack(){
        int atackPower = status.atackPower;
        string resultlog = "たたかうで攻撃した";
        log_text.addtext(resultlog);
        p_hp_c.Damage(atackPower);
        SE.playSE(1);
    }
    public void block(){
        string resultlog = "防御した";
        log_text.addtext(resultlog);
        status.defence(true);
        SE.playSE(6);
    }
    public void lastAtack(){
        int atackPower = p_hp_c.hp;
        string resultlog = "会心の一撃を放った";
        log_text.addtext(resultlog);
        p_hp_c.ThroughDamage(atackPower);
        SE.playSE(1);
    }
    
}
