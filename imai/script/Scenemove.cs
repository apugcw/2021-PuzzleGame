using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemove : MonoBehaviour
{
    string SceneNumber;
    public void nextscene(int SceneNumber)
    {
        /*
        SceneNumber
        0:GameOver
        1:Title
        2:Intro
        3:stage1
        4:stage2
        5:stage3
        6:ED
        */
        SceneManager.LoadScene(SceneNumber);
    }
 }