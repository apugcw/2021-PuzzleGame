using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//各シーンのデータを収納
public class Data
{
    public readonly static Data Instance = new Data();
 
    public string referer = string.Empty;
}
