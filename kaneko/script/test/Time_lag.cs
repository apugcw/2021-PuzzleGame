using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_lag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void corutine_print(){
        var coroutine = StartCoroutine(print_debug());
    }
    IEnumerator print_debug()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("実行された");
    }
}
