using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintSkilDetails : MonoBehaviour
{
    Text text;
    comandValue comandV;
    charStatus status;
    public string comandName;
    void Awake()
    {
        GameObject comandManager = GameObject.Find("playerComandManager");
        comandV = comandManager.GetComponent<comandValue>();
        GameObject player = GameObject.Find("player_status");
        status = player.GetComponent<charStatus>();
        text = GetComponent<Text>(); 
    }
    void OnEnable()
    {
        printDetails();
    }
    void printDetails(){
        if(comandName == "Atack"){
            int dmg = status.atackPower;
            text.text = "ダメージ:"+ dmg;
        }
        else if(comandName == "Fire"){
            int dmg = comandV.fire_dmg;
            int cost = comandV.fire_cost;
            text.text = "ダメージ:"+ dmg +"\n消費MP:"+ cost;
        }
        else if(comandName == "Ice"){
            int dmg = comandV.ice_dmg;
            int cost = comandV.ice_cost;
            text.text = "ダメージ:"+ dmg +"\n消費MP:"+ cost;
        }
        else if(comandName == "Thunder"){
            int dmg = comandV.thunder_dmg;
            int cost = comandV.thunder_cost;
            text.text = "ダメージ:"+ dmg +"\n消費MP:"+ cost;
        }
        else if(comandName == "Heal"){
            int recover = comandV.heal_recover;
            int cost = comandV.heal_cost;
            text.text = "回復量:"+ recover +"\n消費MP:"+cost;
        }
        else if(comandName == "Herbs"){
            int recover = comandV.medicinalHerbs_recover;
            int having = comandV.medicinalHerbs_count;
            text.text = "回復量:"+ recover +"\n所持数:"+ having;
        }
        else if(comandName == "AtackPill"){
            int effect = comandV.atackpill_correction;
            int turn = comandV.atackpill_turn;
            int having = comandV.atackpill_count;
            text.text = "物理攻撃力上昇値:"+ effect +"\n効果ターン:"+ turn　
            +"\n所持数:"+ having;
        }
        else if(comandName == "Diffence"){
            int turn = comandV.diffence_turn;
            text.text = turn +"ターン\n物理ダメージを防ぐ";
        }
    }
}
