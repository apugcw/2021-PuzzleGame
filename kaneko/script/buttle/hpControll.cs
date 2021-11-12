using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hpControll : MonoBehaviour
{   
    charStatus status;//ステータス
    GameObject chara;
    public int hp,MAXHP;//最大HP
    Text hp_text;//表示HP
    backLog log_text;//バックログスクリプト
    damageEfect DamageEfect;
    //各SE
    public AudioClip dagameSE;
    public AudioClip healSE;
    public AudioClip deffenceSE;
    //AudioSource audioSource;//音スクリプト
    ButtleEnd _buttleEnd;
    // Start is called before the first frame update
    void Awake()
    {   
        //初期HPの設定　初期HPは親オブジェクトにcharStatusをインポートし参照
        GameObject par_char = transform.parent.gameObject;
        chara = par_char;
        status = par_char.GetComponent<charStatus>(); 
        hp = status.hp;
        MAXHP = status.hp;
        hp_text = GetComponent<Text>();
        hp_text.text = "HP:"+hp.ToString("000");
        //バックログ取得
        GameObject logText = GameObject.Find("logText");
        log_text = logText.GetComponent<backLog>();
        //ダメージエフェクト
        DamageEfect = par_char.GetComponent<damageEfect>();
        //SE用
        //audioSource = GetComponent<AudioSource>();
        //gameover
        var gameover_panel = GameObject.Find("ButtleEnd_panel");
        _buttleEnd = gameover_panel.GetComponent<ButtleEnd>();
    }

    //ダメージ処理
    public void Damage(int damage){
        //防御していた場合
        if(status.defenceSwich){
            //テキスト
            string defence_text = status.charName+"は防御した";
            log_text.addtext(defence_text);
            //SE
            //audioSource.PlayOneShot(deffenceSE);
            //防御フラグoff
            status.defence(false);
        }
        else{
            hp = hp - damage;            
            string defence_text = status.charName+"は"+damage+"ダメージを受けた";
            log_text.addtext(defence_text);
            if(hp<=0){
                hp = 0;
                hp_text.text = "HP:"+hp.ToString("000");
                if(chara.tag == "Player"){
                    _buttleEnd.Move_gameOver();
                }
                else if(chara.tag == "enemy"){
                    Debug.Log("敵死亡");
                    _buttleEnd.Move_victory();
                }
            }
            hp_text.text = "HP:"+hp.ToString("000");
            //audioSource.PlayOneShot(dagameSE);
            //DamageEfect.DamageFlash();
        }
    }
    public void ThroughDamage(int damage){
        if(status.defenceSwich){
            string cantText = status.charName+"は防御できなかった";
            log_text.addtext(cantText);
            status.defence(false);
        }
        hp = hp - damage;
        string defence_text = status.charName+"は"+damage+"ダメージを受けた";
        log_text.addtext(defence_text);
        if(hp<=0){
            hp = 0;
            if(chara.tag == "Player"){
                _buttleEnd.Move_gameOver();
            }
            else if(chara.tag == "enemy"){
                _buttleEnd.Move_victory();
            }
        }
        hp_text.text = "HP:"+hp.ToString("000");
        //audioSource.PlayOneShot(dagameSE);
        //DamageEfect.DamageFlash();
    }
    public void Recovery(int recovery){
        hp += recovery;
        if(hp>MAXHP){
            hp = MAXHP;
        }
        hp_text.text = "HP:"+hp.ToString("000");
        //audioSource.PlayOneShot(healSE);
    }

}
