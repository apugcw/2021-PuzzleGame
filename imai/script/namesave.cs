using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//シーンごとにシーンの名前を保存
<<<<<<< HEAD:imai/script/sceneSave.cs
public class sceneSave : MonoBehaviour
=======
public class namesave : MonoBehaviour
>>>>>>> cb06f0145970bcb8c93e394fe26fa889b7e9835e:imai/script/namesave.cs
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
