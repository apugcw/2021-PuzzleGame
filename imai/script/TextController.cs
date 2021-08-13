using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour 
{
	public string[] scenarios; // シナリオを格納する
	[SerializeField] Text uiText; // uiTextへの参照を保つ

	[SerializeField][Range(0.001f, 0.3f)]
	float intervalForCharacterDisplay = 0.05f; // 1文字の表示にかかる時間

	private string currentText = string.Empty; // 現在の文字列
    private float timeUntilDisplay = 0; // 表示にかかる時間
	private float timeElapsed = 1; // 文字列の表示を開始した時間
	private int currentLine = 0; // 現在の行番号
	private int lastUpdateCharacter = -1; // 表示中の文字数

	// 文字の表示が完了しているかどうか
	public bool IsCompleteDisplayText 
	{
		get { return  Time.time > timeElapsed + timeUntilDisplay; }
	}
    Scenemove Nextscene;
    public string scenename; //scenenameをunityから参照する
	void Start()
	{
		SetNextLine();
        Nextscene=GetComponent<Scenemove>(); //Scenemove.csの機能を Nextsceneに付与
	}

	void Update () 
	{

         if (currentLine == scenarios.Length)
          {
			nextscene(scenename);
		  }
		// 文字の表示が完了してるならクリック時に次の行を表示する
		if( IsCompleteDisplayText ){
		// 現在の行番号がラストまで行ってない状態でクリックすると、テキストを更新する
            if(currentLine < scenarios.Length && Input.GetMouseButtonDown(0)){
				SetNextLine();
			}
		}else{
		// 完了してないなら文字をすべて表示する
			if(Input.GetMouseButtonDown(0)){
				timeUntilDisplay = 0;
			}
		}
        // クリックから経過した時間が想定表示時間の何%か確認し、表示文字数を出す
		int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
		if( displayCharacterCount != lastUpdateCharacter ){
            uiText.text = currentText.Substring(0, displayCharacterCount);
			lastUpdateCharacter = displayCharacterCount;
		}
	}


	void SetNextLine()
	{
		currentText = scenarios[currentLine];
		// 想定表示時間と現在の時刻をキャッシュ
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
		timeElapsed = Time.time;
		currentLine ++;
        // 文字カウントを初期化
		lastUpdateCharacter = -1;
	}
         public void nextscene(string scenename)
     {        

              Nextscene.nextscene(scenename);
     }
}