using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillSE : MonoBehaviour
{
    [HideInInspector]public AudioClip PhysicAtack;
    [HideInInspector]public AudioClip SwordAtack;
    [HideInInspector]public AudioClip MagicAtack;
    [HideInInspector]public AudioClip heal;
    [HideInInspector]public AudioClip Item;
    [HideInInspector]public AudioClip Gurd;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playSE(int SENumber){
        switch(SENumber){
            case 1:
                audioSource.PlayOneShot(PhysicAtack);
                break;
            case 2:
                audioSource.PlayOneShot(SwordAtack);
                break;
            case 3:
                audioSource.PlayOneShot(MagicAtack);
                break;
            case 4:
                audioSource.PlayOneShot(heal);
                break;
            case 5:
                audioSource.PlayOneShot(Item);
                break;
            case 6:
                audioSource.PlayOneShot(Gurd);
                break;
        }

    }
}
