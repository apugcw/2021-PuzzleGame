using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int Turn=5;//残りターン数
    int nowTurn=0;//開始時残りターン数
    Text Turntext;//ターンテキスト
    backLog log_text;//バックログスクリプト
    ButtleEnd _gameover;//ゲームオーバー画面
    skillActiveManager SAManager;//スキル画面のアクティブ化
    charStatus p_status;
    charStatus e_status;
    // Start is called before the first frame update
    void Awake()
    {
        //キャラ状態
        p_status = GameObject.Find("player_status").GetComponent<charStatus>();
        e_status = GameObject.Find("enemy_status").GetComponent<charStatus>();
        //開始時の残りターン表示
        Turntext=GetComponent<Text>();
        Turntext.text="残りターン数:"+Turn;
        //ログテキストのテキストスクリプト取得
        GameObject logText = GameObject.Find("logText");
        log_text = logText.GetComponent<backLog>();
        //ゲームオーバーシーン移動
        var gameover_panel = GameObject.Find("ButtleEnd_panel");
        _gameover = gameover_panel.GetComponent<ButtleEnd>();
        //スキル使用可能にする
        var panel = GameObject.Find("playerComandManager");
        SAManager = panel.GetComponent<skillActiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //次ターンへ移行
    public void nextturn(){
        //防御状態解除
        p_status.blockStatus(p_status.blockTurn-1);
        e_status.blockStatus(e_status.blockTurn-1);
        //ターン管理
        nowTurn += 1;
        string resultlog = nowTurn+"ターン目";
        log_text.addtext(resultlog);
        Turntext.text="残りターン数:"+(Turn-nowTurn);
        if(Turn == 0)
        {
           //Gameover.nextscene("GameOver");
        }
        SAManager.deActivePanel();
    }
}
