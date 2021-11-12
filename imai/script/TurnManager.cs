using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public int Turn=5;
    int startTurn;
    Text Turntext;
    backLog log_text;//バックログスクリプト
    Scenemove Gameover;
    GameOver _gameover;//ゲームオーバー画面
    skillActiveManager SAManager;
    // Start is called before the first frame update
    void Awake()
    {
        startTurn = Turn+1;
        Turntext=GetComponent<Text>();
        Turntext.text="残りターン数:"+Turn;
        Gameover=GetComponent<Scenemove>();
        //ログテキストのテキストスクリプト取得
        GameObject logText = GameObject.Find("logText");
        log_text = logText.GetComponent<backLog>();
        //ゲームオーバーシーン移動
        var gameover_panel = GameObject.Find("gameOver_panel");
        _gameover = gameover_panel.GetComponent<GameOver>();
        //スキル使用可能にする
        var panel = GameObject.Find("playerComandManager");
        SAManager = panel.GetComponent<skillActiveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //次ターンへ移行，残りターンが0ならgameover
    public void nextturn(){
        Turn-=1;
        int nextTrun = startTurn-Turn;
        string nextTurnS = nextTrun.ToString();
        string resultlog = nextTurnS+"ターン目";
        log_text.addtext(resultlog);
        Turntext.text="残りターン数:"+Turn;
        if(Turn == 0)
        {
           //Gameover.nextscene("GameOver");
        }
        SAManager.deActivePanel();
    }
}
