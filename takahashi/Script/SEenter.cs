using UnityEngine;
using System.Collections;

public class SEenter : MonoBehaviour {
    public bool DontDestroyEnabled = true;

    // Use this for initialization
    void Start () {
        if (DontDestroyEnabled) {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad (this);
        }
            // 左
        if (Input.GetKey(KeyCode.Return)) {
            //音(sound1)を鳴らす
            GetComponent<AudioSource>().Play();
        }
        /*
        if ( Input.GetKeyDown(KeyCode.Return) == true ) {
            Debug.Log("Now scene is " + Application.loadedLevelName);
            // Aキーを押すとシーンが遷移する
            Application.LoadLevel("StartScene");
        }
        */
    }

    // Update is called once per frame
    void Update () {

    }
}
