using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scenemove : MonoBehaviour
{
    string SceneNumber;
    public void nextscene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
 }