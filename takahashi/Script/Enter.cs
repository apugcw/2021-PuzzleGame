using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
// Use this for initialization
void Start()
{

    }

    // Update is called once per frame
 void Update () {
   // 左
  if (Input.GetKey(KeyCode.Return)) {
   //音(sound1)を鳴らす
    GetComponent<AudioSource>().Play();
   }
 }
}