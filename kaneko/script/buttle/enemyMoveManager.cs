using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class enemyMoveManager : MonoBehaviour
{
    int nowTurn = 1;
    //敵行動内容スクリプト
    enemyComand EnemyComand;
    //敵行動をまとめたCSVファイル読み込み
    TextAsset csvFile;
    public string filename = "";
    List<string[]> csvDatas = new List<string[]>();
    TurnManager turnmanager;//ターン管理プログラム
    hpControll enemyHP;
    // Start is called before the first frame update
    void Start()
    {   
        enemyHP = GameObject.Find("enemyHP").GetComponent<hpControll>();
        //ターン管理スクリプト取得
        GameObject Turn = GameObject.Find("turn");
        turnmanager = Turn.GetComponent<TurnManager>();
        //的行動スクリプト取得
        EnemyComand = GetComponent<enemyComand>();
        csvFile = Resources.Load(filename) as TextAsset; // Resouces下のCSV読み込み
        StringReader reader = new StringReader(csvFile.text);
        // リストに追加していく
        while (reader.Peek() != -1) // reader.Peaekが-1になるまで
        {
            string line = reader.ReadLine(); // 一行ずつ読み込み
            csvDatas.Add(line.Split(',')); // , 区切りでリストに追加
        }
    }

    public void enemyMove()
    {
        if(enemyHP.hp>0){
            string skillName = csvDatas[nowTurn][1];
            StartCoroutine(NextTurn());
            switch(skillName){
                case "Atack":
                    EnemyComand.Atack();
                    break;
                
                case "LastAtack":
                    EnemyComand.lastAtack();
                    break;
                
                case "Block":
                    EnemyComand.block();
                    break;
                    /*
                case "Atack":
                    EnemyComand.Atack();
                    break;
                case "Atack":
                    EnemyComand.Atack();
                    break;
                case "Atack":
                    EnemyComand.Atack();
                    break;
                case "Atack":
                    EnemyComand.Atack();
                    break;
                    */
                
            };
            nowTurn += 1;
        }
        else{

        }   
    }
    IEnumerator NextTurn()
    {
        yield return new WaitForSeconds(1.0f);
        //遅らせたい処理
        turnmanager.nextturn();//次ターン
    }
}
