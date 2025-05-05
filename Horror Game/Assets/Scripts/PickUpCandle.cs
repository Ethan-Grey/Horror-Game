using UnityEngine;
using System.Collections;

public class PickUpCandle : MonoBehaviour
{
    [SerializeField] bool canPickUp;
    [SerializeField] GameObject textOnScreen;
    [SerializeField] GameObject playerCandle;
    [SerializeField] GameObject tableCandle;
    private Camera mainCamera;
    private RaycastHit hit;
    private float interactionDistance = 5f;
  
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check if we're looking at the candle
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                if (PlayerCasting.distanceFromTarget < interactionDistance)
                {
                    UIController.commandText = "Pick up";
                    UIController.uiActive = true;
                    canPickUp = true;
                }
                else
                {
                    UIController.uiActive = false;
                    canPickUp = false;
                }
            }
            else
            {
                UIController.uiActive = false;
                canPickUp = false;
            }
        }
        else
        {
            UIController.uiActive = false;
            canPickUp = false;
        }

        if (canPickUp && Input.GetKeyDown(KeyCode.F))
        {
            tableCandle.SetActive(false);
            playerCandle.SetActive(true);
            UIController.commandText = "";
            UIController.uiActive = false;
            canPickUp = false;
        }
    }

    void OnMouseExit()
    {
        UIController.commandText = "";
        UIController.uiActive = false;
        canPickUp = false;
    }
}