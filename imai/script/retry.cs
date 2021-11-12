using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retry : MonoBehaviour
{
    //リトライ時ひとつ前のシーンを読み込み
public void RetryButton()
    {
        SceneManager.LoadScene(Data.Instance.referer);
    }
}