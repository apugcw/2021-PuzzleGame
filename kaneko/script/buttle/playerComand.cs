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
    TurnManager turnmanager;//ターン管理プログラム
    skillSE SE;//SE
    // Start is called before the first frame update
    void Awake()
    {
        //ターン管理スクリプト取得
        GameObject Turn = GameObject.Find("turn");
        turnmanager = Turn.GetComponent<TurnManager>();
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
        SAManager.activePanel();
        emManager.enemyMove();//敵の行動
        StartCoroutine(AtackCoroutine());
    }
    IEnumerator AtackCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        //遅らせたい処理
        if(p_hp_c.hp>0){
            string resultlog = "たたかうで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(atackPower);
            StartCoroutine(NextTurn());
            SE.playSE(2);
        }
    }
    //防御
    public void block(){
        string resultlog = "防御した";
        log_text.addtext(resultlog);
        status.blockStatus(2);
        StartCoroutine(blockCoroutine());
        SAManager.activePanel();
        SE.playSE(6);
    }
    IEnumerator blockCoroutine(){
        yield return new WaitForSeconds(1.5f);
        emManager.enemyMove();
        StartCoroutine(NextTurn());
    }
    //ファイア
    public void fire(){
        SAManager.activePanel();
        int mp_cost = comandValue.fire_cost;//消費MP
        int damage = comandValue.fire_dmg;//ダメージ
        if(p_mp_c.mpUse(mp_cost)){
            emManager.enemyMove();//敵の行動
            StartCoroutine(fireCoroutine(damage));
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
    }
    IEnumerator fireCoroutine(int damage){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){      
            string resultlog = "ファイアで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(damage);
            SE.playSE(3);
            StartCoroutine(NextTurn());
        }
          
    }
    //アイス
    public void ice(){
        SAManager.activePanel();
        int mp_cost = comandValue.ice_cost;//消費MP
        int damage = comandValue.fire_dmg;//ダメージ
        if(p_mp_c.mpUse(mp_cost)){
            emManager.enemyMove();//敵の行動
            StartCoroutine(iceCoroutine(damage));
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
    }
    IEnumerator iceCoroutine(int damage){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){      
            string resultlog = "アイスで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(damage);
            SE.playSE(3);
            StartCoroutine(NextTurn());
        } 
    }
    //サンダー
    public void thunder(){
        SAManager.activePanel();
        int mp_cost = comandValue.thunder_cost;//消費MP
        int damage = comandValue.thunder_dmg;//ダメージ
        if(p_mp_c.mpUse(mp_cost)){
            emManager.enemyMove();//敵の行動
            StartCoroutine(thunderCoroutine(damage));
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
    }
    IEnumerator thunderCoroutine(int damage){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){       
            string resultlog = "サンダーで攻撃";
            log_text.addtext(resultlog);
            e_hp_c.Damage(damage);
            SE.playSE(3);
            StartCoroutine(NextTurn());
        }
    }
    //ヒール
    public void heal(){
        SAManager.activePanel();
        int mp_cost = comandValue.heal_cost;//消費MP
        int recovery_point = comandValue.heal_recover;//回復量
        //MP消費，足りなければ実行しない
        if(p_mp_c.mpUse(mp_cost)){
            emManager.enemyMove();//敵の行動
            StartCoroutine(healCoroutine(recovery_point));    
        }
        else{
            string resultlog = "MPが足りません";
            log_text.addtext(resultlog);
        }
    }
    IEnumerator healCoroutine(int recovery_point){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){
            p_hp_c.Recovery(recovery_point);
            string resultlog = "HPを"+recovery_point+"回復した";
            log_text.addtext(resultlog);
            SE.playSE(4);
            StartCoroutine(NextTurn());
        }
         
    }
    //薬草
    public void medicinalHerbs(){
        SAManager.activePanel();
        int count = comandValue.medicinalHerbs_count;//使用回数
        int recovery = comandValue.medicinalHerbs_recover;//回復量
        if(count>0){
            emManager.enemyMove();//敵の行動
            StartCoroutine(medicinalHerbsCoroutine(recovery,count)); 
        }
        else{
            string resultlog = "薬草がありません";
            log_text.addtext(resultlog);
        }
    }
    IEnumerator medicinalHerbsCoroutine(int recovery,int count){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){
            comandValue.medicinalHerbs_count -= 1;//使用回数消費
                p_hp_c.Recovery(recovery);
                string resultlog = "HPを"+recovery+"回復した";
                SE.playSE(5);
                log_text.addtext(resultlog);
                if(count <= 0){
                    ChangeColor();
                }
                StartCoroutine(NextTurn());
        }
    }
    //MP回復薬
    public void MPrecovery(){
        SAManager.activePanel();
        int count= comandValue.MPrecovery_count;//使用回数
        int recovery = comandValue.MPrecovery_recover;//補正値
        if(count>0){
            emManager.enemyMove();//敵の行動
            StartCoroutine(MPrecoveryCoroutine(recovery,count));
        }
        else{
            string resultlog = "MP回復薬がありません";
            log_text.addtext(resultlog);
        }
    }
    IEnumerator MPrecoveryCoroutine(int recovery,int count){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){
            comandValue.MPrecovery_count -= 1;//使用回数消費
            p_mp_c.mpFluctuation(recovery*-1);
            string resultlog = "MPを"+recovery+"回復した";
            SE.playSE(5);
            log_text.addtext(resultlog);
            if(count <= 0){
                ChangeColor();
            }
            StartCoroutine(NextTurn());
        }
         
    }
    //丸薬
    public void atackpill(){
        SAManager.activePanel();
        int count= comandValue.atackpill_count;//使用回数
        int buff_point = comandValue.atackpill_correction;//補正値

        if(count>0){
            emManager.enemyMove();//敵の行動
            StartCoroutine(atackpillCoroutine(buff_point,count));
        }
        else{
            string resultlog = "丸薬がありません";
            log_text.addtext(resultlog);
        }       
    }
    IEnumerator atackpillCoroutine(int buff_point,int count){
        yield return new WaitForSeconds(1.5f);
        if(p_hp_c.hp>0){
            comandValue.atackpill_count -= 1;
            atackPower += buff_point;
            string resultlog = "丸薬を使った\n攻撃力が"+buff_point+"上昇した";
            SE.playSE(5);
            log_text.addtext(resultlog);
            count -= 1;
            if(count <= 0){
                ChangeColor();
            }
            StartCoroutine(NextTurn());
        }
    }

    IEnumerator NextTurn()
    {
        yield return new WaitForSeconds(1.5f);
        //遅らせたい処理
        turnmanager.nextturn();//次ターン
    }
}
