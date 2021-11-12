using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageEfect : MonoBehaviour
{
    Image charaSprite;//キャラクターイメージ
    private float _flashAlpha = 1;//点滅用透過度
    bool flashFlag = false;
    void Start()
    {
        //キャラの見た目取得
        charaSprite = this.GetComponent<Image>();
    }
    void Update()
    {
        if(flashFlag){
            // 透明度を時間によってサイン派で決める
            _flashAlpha = Mathf.Sin(Time.time * 100) / 2 + 0.5f;
            // 透明度を適用する
            Color _color = charaSprite.color;
            _color.a = _flashAlpha;
            charaSprite.color = _color;
        }
    }
    //点滅アニメ
    public void DamageFlash()
    {
        StartCoroutine("finishFlash");//1秒後に再生終了
        flashFlag = true;
    }
    //時限でフラグ変更
    IEnumerator finishFlash(){
        yield return new WaitForSeconds(1);
        flashFlag = false;
        charaSprite.color = new Color(255, 255, 255, 255);
    }
}