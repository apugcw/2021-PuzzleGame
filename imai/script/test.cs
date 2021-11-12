using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
     [SerializeField] private UGUI tmp;
    void Start()
    {
        int lineCnt = GetLine(tmp.text);
        Debug.Log(lineCnt);
    }
    /// <summary>
    /// 改行数を取得
    /// </summary>
    int GetLine(string str)
    {
        string before = str;
        string after = str.Replace("\n", "");
        int ret = before.Length - after.Length;
        return ret;
    }
}
