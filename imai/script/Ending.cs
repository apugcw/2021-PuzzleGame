using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class Ending : MonoBehaviour
{
    //　テキストのスクロールスピード
    [SerializeField]
    private float textScrollSpeed = 0.9f;
    //　テキストの制限位置
    [SerializeField]
    private float limitPosition = 13.5f;
    //　エンドロールが終了したかどうか
    private bool isStopEndRoll;
    //　シーン移動用コルーチン
    private Coroutine endRollCoroutine;
    Scenemove GoTitle;
        void Start()
    {
        GoTitle=GetComponent<Scenemove>();        
    }
    // Update is called once per frame
    void Update()
    {
        //　エンドロールが終了した時
        if (isStopEndRoll) {
            endRollCoroutine = StartCoroutine(GoToNextScene());
        } else {
            //　エンドロール用テキストがリミットを越えるまで動かす
            if (transform.position.y <= limitPosition) {
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            } else {
                isStopEndRoll = true;
            }
        }
    }
 
    IEnumerator GoToNextScene() {
        //　5秒間待つ
        yield return new WaitForSeconds(0.1f);
 
        if (Input.GetKey(KeyCode.Return)) {
            StopCoroutine(endRollCoroutine);
            GoTitle.nextscene("TitleScene");
        }
 
        yield return null;
    }
}