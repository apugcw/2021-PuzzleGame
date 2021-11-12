using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    /*
    Color ImColor;
    Color TxtColor;
    float addAlpha = 0.1f;
    float ImAlpha = 0;
    float TxtAlpha = 0;
    */
    GameObject GOtext;
    Scenemove GameoverScene;

    int HP;
    void Start()
    {
        //非表示に
        this.gameObject.SetActive(false);
        /*
        //アタッチしたパネルのalpha取得
        var Im = GetComponent<Image>();
        ImColor = Im.color;
        //子のテキストのalpha取得
        GOtext = transform.GetChild(0).gameObject;
        var text = GOtext.GetComponent<Text>();
        TxtColor = text.color;
        */
        //ゲームオーバーscene遷移
        GameoverScene=GetComponent<Scenemove>();
        //プレイヤーステータスの取得
        var CharStatus = GameObject.Find("player_status").GetComponent<charStatus>();
        HP = CharStatus.hp;
    }
    public void Move_gameOver()
    {
        this.gameObject.SetActive(true);
        StartCoroutine("sceneMove");
    }
    IEnumerator sceneMove(){
        yield return new WaitForSeconds(2.0f);
        GameoverScene.nextscene("GameOver");
        //Debug.Log("gameOver");
    }
}
