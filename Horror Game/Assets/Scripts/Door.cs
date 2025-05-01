using UnityEngine;

public class Door : MonoBehaviour
{
    void OnMouseOver()
    {
        UIController.commandText = "Open";
        UIController.uiActive = true;
    }

    void OnMouseExit()
    {
        UIController.commandText = "";
        UIController.uiActive = false;
    }
}
