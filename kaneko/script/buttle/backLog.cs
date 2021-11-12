using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class backLog : MonoBehaviour
{
    Text logText;
    ScrollRect scrollRect;
    ContentSizeFitter contentSizeFitter;
    // Start is called before the first frame update
    void Start()
    {
        logText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addtext(string newLog){
        string oldLog = logText.text;
        logText.text = newLog+"\n"+oldLog;
        
    }
}
