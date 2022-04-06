using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkOpener : MonoBehaviour
{
    public string link;
    private Button button;
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenLink);
    }
    
    void OpenLink()
    {
        Application.OpenURL(link);
    }
    
}
