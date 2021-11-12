using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtleEnd : MonoBehaviour
{
    //Scene遷移
    public string NextSceneName;
    Scenemove GameoverScene;
    //SE
    public AudioClip gameOverSE;
    public AudioClip victorySE;
    AudioSource audioSource;
    //text
    GameObject gameOver_txt;
    GameObject victory_txt;

    int HP;
    void Start()
    {
        gameOver_txt = transform.GetChild(0).gameObject;
        gameOver_txt.SetActive(false);
        victory_txt = transform.GetChild(1).gameObject;
        victory_txt.SetActive(false);
        //非表示に
        this.gameObject.SetActive(false);
        //ゲームオーバーscene遷移
        GameoverScene=GetComponent<Scenemove>();
        //プレイヤーステータスの取得
        var CharStatus = GameObject.Find("player_status").GetComponent<charStatus>();
        HP = CharStatus.hp;
        //SEスクリプト
        audioSource = GetComponent<AudioSource>();
    }
    public void Move_victory(){
        Debug.Log("勝利判定");
        this.gameObject.SetActive(true);
        victory_txt.SetActive(true);
        audioSource.PlayOneShot(victorySE);
        StartCoroutine(sceneMove(true));
    }
    public void Move_gameOver()
    {
        this.gameObject.SetActive(true);
        gameOver_txt.SetActive(true);
        audioSource.PlayOneShot(gameOverSE);
        StartCoroutine(sceneMove(false));
    }
    
    IEnumerator sceneMove(bool flag){     
        if(flag){
            yield return new WaitForSeconds(3.0f);
            Debug.Log("次シーン遷移");
            GameoverScene.nextscene(NextSceneName);            
        }
        else{
            yield return new WaitForSeconds(2.0f);
            GameoverScene.nextscene("GameOver");
        }
    }
}
