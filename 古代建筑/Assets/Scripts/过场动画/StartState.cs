using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : MonoBehaviour
{
    [SerializeField] private GameObject IntroduceGameUI;
    [SerializeField] private GameObject IntroduceGameThings;
    void Start()
    {
        IntroduceGameThings.SetActive(false);
        IntroduceGameUI.SetActive(false);
    }

    // Update is called once per frame
   
}
