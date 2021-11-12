using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerComand : MonoBehaviour
{
    charStatus status;//プレイヤーステータススクリプト
    comandValue comandValue;//各コマンドの値データベース
    //Dictionary<string,int[]> comandDic;//データベース内のコマンド値辞書<key,[効果値，コスト]> 使わないかも
    hpControll e_hp_c;//敵HP管理スクリプト
    hpControll p_hp_c;//プレイヤーHP管理スクリプト
    mpControll p_mp_c;//プレイヤーMP管理スクリプト
    backLog log_text;//バックログスクリプト
    int atackPower;//「戦う」の攻撃力
    enemyMoveManager emManager;//敵の行動開始
    skillActiveManager SAManager;//スキルのアクティブ管理
    skillSE SE;//SE
    // Start is called before the first frame update
    void Awake()
    {
        //コマンドデータベース取得
        GameObject comandManager = transform.parent.gameObject;
        comandValue = comandManager.GetComponent<comandValue>();
        //敵HP管理スクリプトの取得
        GameObject enemyHP = GameObject.Find("enemyHP");
        e_hp_c = enemyHP.GetComponent<hpControll>();
        //プレイヤー関係
        //攻撃力
        GameObject player = GameObject.Find("player_status");
        status = player.GetComponent<charStatus>();
        atackPower = status.atackPower;
        //HP
        GameObject playerHP = GameObject.Find("playerHP");
        p_hp_c = playerHP.GetComponent<hpControll>();
        //MP
        GameObject playerMP = GameObject.Find("playerMP");
        p_mp_c = playerMP.GetComponent<mpControll>();
        //ログテキストのテキストスクリプト取得
        GameObject logText = GameObject.Find("logText");
        log_text = logText.GetComponent<backLog>();
        //敵行動スクリプトの取得
        GameObject enemy = GameObject.Find("enemy");
        emManager = enemy.GetComponent<enemyMoveManager>();
        //スキルのアクティブ管理
        var SM = GameObject.Find("playerComandManager");
        SAManager = SM.GetComponent<skillActiveManager>();
        //SE
        SE = GameObject.Find("SEManager").GetComponent<skillSE>();
    }
    void ChangeColor(){
        Image image = GetComponent<Image>();
        image.color = new Color(130.0f/255.0f,130.0f/255.0f,130.0f/255.0f);
    }

    //たたかう
    public void Atack(){
        string resultlog = "たたかうで攻撃";
        log_text.addtext(resultlog);
        e_hp_c.Damage(atackPower);
        StartCoroutine(enemyMoveStart());
        SAManager.activePanel();
        SE.playSE(2);
    }
    //防御
    public void block(){
        string resultlog = "防御した";
        log_text.addtext(resultlog);
        status.defence(true);
        StartCoroutine(enemyMoveStart());
        SAManager.activePanel();
        SE.playSE(6);
    }
    //ファイア
    public void fire(){
        int mp_cost = 15;//消費MP
        int damage = 30;//ダメージ
        if(p_mp_c.mpUse(mp_cost)){
            string resultlog = "ファイアで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(damage);
            SE.playSE(3);
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
        
    }
    //アイス
    public void ice(){
        int mp_cost = 25;
        int damage = 45;
        if(p_mp_c.mpUse(mp_cost)){
            string resultlog = "アイスで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(damage);
            SE.playSE(3);
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }   
    }
    //サンダー
    public void thunder(){
        int mp_cost = 40;
        int damage = 60;
        if(p_mp_c.mpUse(mp_cost)){
            string resultlog = "サンダーで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(damage);
            SE.playSE(3);
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
    }
    //ヒール
    public void heal(){
        int mp_cost = 10;//消費MP
        int recovery_point = 20;//回復量
        //MP消費，足りなければ実行しない
        if(p_mp_c.mpUse(mp_cost)){
            p_hp_c.Recovery(recovery_point);
            string resultlog = "HPを"+recovery_point+"回復した";
            log_text.addtext(resultlog);
            SE.playSE(4);
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
    }
    //薬草
    public void medicinalHerbs(){
        int count = comandValue.medicinalHerbs_count;//使用回数
        int recovery = comandValue.medicinalHerbs_recover;//回復量
        if(count>0){
            comandValue.medicinalHerbs_count -= 1;//使用回数消費
            p_hp_c.Recovery(recovery);
            string resultlog = "HPを"+recovery+"回復した";
            SE.playSE(5);
            log_text.addtext(resultlog);
            if(count <= 0){
                ChangeColor();
            }
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "薬草がありません";
            log_text.addtext(resultlog);
        }
    }
    //MP回復薬
    public void MPrecovery(){
        int count= comandValue.MPrecovery_count;//使用回数
        int recovery = comandValue.MPrecovery_recover;//補正値
        if(count>0){
            comandValue.MPrecovery_count -= 1;//使用回数消費
            p_mp_c.mpFluctuation(recovery*-1);
            string resultlog = "MPを"+recovery+"回復した";
            SE.playSE(5);
            log_text.addtext(resultlog);
            if(count <= 0){
                ChangeColor();
            }
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "MP回復薬がありません";
            log_text.addtext(resultlog);
        }
    }
    //丸薬
    public void atackpill(){
        int count= comandValue.atackpill_count;//使用回数
        int buff_point = comandValue.atackpill_correction;//補正値

        if(count>0){
            comandValue.atackpill_count -= 0;
            atackPower += buff_point;
            string resultlog = "丸薬を使った\n攻撃力が"+buff_point+"上昇した";
            SE.playSE(5);
            log_text.addtext(resultlog);
            count -= 1;
            if(count <= 0){
                ChangeColor();
            }
            //1秒後敵の行動開始
            StartCoroutine(enemyMoveStart());
            SAManager.activePanel();
        }
        else{
            string resultlog = "丸薬がありません";
            log_text.addtext(resultlog);
        }       
    }

    IEnumerator enemyMoveStart()
    {
        yield return new WaitForSeconds(1.5f);
        //遅らせたい処理
        emManager.enemyMove();//敵の行動
    }
}
