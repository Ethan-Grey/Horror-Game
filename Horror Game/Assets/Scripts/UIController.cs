using System;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public static string commandText;
    public static bool uiActive;
    [SerializeField] GameObject commandBox;
    [SerializeField] GameObject interactCross;

    
    void Update()
    {
        if (uiActive == true)
        {
            commandBox.SetActive(true);
            interactCross.SetActive(true);
            commandBox.GetComponent<TMPro.TextMeshProUGUI>().text = "[F] " + commandText;
        }
        else
        {
            commandBox.SetActive(false);
            interactCross.SetActive(false);
        }
    }
}
