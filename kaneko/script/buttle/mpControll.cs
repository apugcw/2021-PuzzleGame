using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mpControll : MonoBehaviour
{
    // Start is called
    charStatus status;
    int mp,MAXMP;
    Text mp_text;//表示HP before the first frame update
    void Start()
    {
        //初期MPの設定　初期MPは親オブジェクトにcharStatusをインポートし参照
        GameObject par_char = transform.parent.gameObject;
        status = par_char.GetComponent<charStatus>(); 
        mp = status.mp;
        MAXMP = status.mp;
        mp_text = GetComponent<Text>();
        mp_text.text = "MP:"+mp.ToString("000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool mpUse(int loss_mp){
        int chack_mp = mp;
        chack_mp -= loss_mp;
        if(chack_mp<0){
            return false;
        }
        else{
            mpFluctuation(loss_mp);
            mp_text.text = "MP:"+mp.ToString("000");
            return true;
        }
    }
    public void mpFluctuation(int change_mp){
        mp -= change_mp;
        mp_text.text = "MP:"+mp.ToString("000");
    }
}
