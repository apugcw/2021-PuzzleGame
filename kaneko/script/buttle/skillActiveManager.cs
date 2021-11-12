using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillActiveManager : MonoBehaviour
{
    GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Comand_OverPanel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activePanel(){
        panel.SetActive(true);
    }
    public void deActivePanel(){
        panel.SetActive(false);
    }
}
