using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetailsView : MonoBehaviour
{
    public GameObject Detailstext;
    public void show()
    {
        Detailstext.SetActive(true);
    }
    public void hide()
    {
        Detailstext.SetActive(false);
    }
}
