using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_prophecy : MonoBehaviour
{
    GameObject Prophecy;//預言書
    skillActiveManager SAManager;//スキルのアクティブ管理

    // Start is called before the first frame update
    void Awake()
    {
        //スキルのアクティブ管理
        var SM = GameObject.Find("playerComandManager");
        SAManager = SM.GetComponent<skillActiveManager>();
    }
    void Start()
    {
        //預言書の取得
        Prophecy = GameObject.Find("Prophecy");
        Prophecy.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void close(){
        //預言書を閉じる
        Prophecy.SetActive(false);
        //スキルをアクティブに
        SAManager.deActivePanel();
    }
}
