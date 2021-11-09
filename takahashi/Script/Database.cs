using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[CreateAssetMenu(fileName = "Shelter", menuName = "CreateShelter")]//  CreateからCreateShelterというメニューを表示し、Shelterを作成する
public class Shelter : ScriptableObject
{
    [SerializeField]
    private Sprite icon;//　避難場所のアイコン
 
    [SerializeField]
    private string shelterName;//　避難場所の名前
    
    [SerializeField]
    private string information;//　避難場所の情報
 
    [SerializeField]
    private float latitude;//  避難場所の緯度
 
    [SerializeField]
    private float longitude;//  避難場所の経度
 
    public Sprite GetIcon()//  アイコンを入力したら、
    {
        return icon;//  iconに返す
    }
 
    public string GetShelterName()//  避難場所の名前を入力したら、
    {
        return shelterName;//  shelterNameに返す
    }
 
    public string GetInformation()//  情報を入力したら、
    {
        return information;//  informationに返す
    }
 
    public float GetLatitude()// 緯度を入力したら、
    {
        return latitude;//  latitude　に返す
    }
 
    public float GetLongitude()//  経度を入力したら、
    {
        return longitude;//  longitudeに返す
    }
}