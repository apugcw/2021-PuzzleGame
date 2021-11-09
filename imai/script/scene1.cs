using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//シーンごとにシーンの名前を保存
public class scene1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
       Data.Instance.referer = SceneManager.GetActiveScene().name; 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}