using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIintroduce : MonoBehaviour
{
    public Image introduceImage;
    public TMP_Text introduceText;

    private void OnEnable()
    {
        Event.Instance.IntroduceOnUI += OnIntroduceOnUI;
    }
    private void OnDisable()
    {
        Event.Instance.IntroduceOnUI -= OnIntroduceOnUI;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnIntroduceOnUI(IntroduceContentSO introduceContent)
    { introduceImage.gameObject.SetActive(true);
        introduceText.gameObject.SetActive(true);
        introduceImage.sprite=introduceContent.introduceImage;
        introduceText.text=introduceContent.introduceText;
    
    }
}
