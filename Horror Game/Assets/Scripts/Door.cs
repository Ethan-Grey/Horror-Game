using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField] bool canOpen;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject theCam;
    [SerializeField] GameObject commandBox;
    [SerializeField] GameObject interactCross;
    [SerializeField] GameObject Cross;
    [SerializeField] GameObject textDesc;
    [SerializeField] AudioSource lockedDoor;
 
    void Update()
    {
        if (canOpen == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(OpeningDoor());
            }
        }
    }

    void OnMouseOver()
    {
        if (PlayerCasting.distanceFromTarget < 5)
        {
            UIController.commandText = "Open";
            UIController.uiActive = true;
            canOpen = true;
        }
        else
        {
            UIController.uiActive = false;
            canOpen = false;
        }
    }

    void OnMouseExit()
    {
        UIController.commandText = "";
        UIController.uiActive = false;
        canOpen = false;
    }

    IEnumerator OpeningDoor()
    {
        theCam.SetActive(true);
        thePlayer.SetActive(false);
        commandBox.SetActive(false);
        interactCross.SetActive(false);
        Cross.SetActive(false);
        textDesc.SetActive(true);
        lockedDoor.Play();
        yield return new WaitForSeconds(3);
        theCam.SetActive(false);
        thePlayer.SetActive(true);
        Cross.SetActive(true);
        textDesc.SetActive(false);
    }
}