using UnityEngine;
using System.Collections;

public class WebBurn : MonoBehaviour
{
    [SerializeField] bool canBurn;
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject webCam;
    [SerializeField] GameObject fadeIn;
    [SerializeField] GameObject flameObject;
    [SerializeField] GameObject WebObjects;
    [SerializeField] GameObject WebEvent;
    [SerializeField] GameObject playerCandle; // Reference to the player's candle
    
    private Camera mainCamera;
    private RaycastHit hit;
    private float interactionDistance = 5f;
  
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("No main camera found in the scene!");
            enabled = false;
            return;
        }
    }

    void Update()
    {
        // Check if we're looking at the webs
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, interactionDistance))
        {
            if (hit.collider.gameObject == this.gameObject)
            {
                if (PlayerCasting.distanceFromTarget < interactionDistance)
                {
                    // Only show prompt if player has the candle
                    if (playerCandle != null && playerCandle.activeSelf)
                    {
                        UIController.commandText = "Burn Webs";
                        UIController.uiActive = true;
                        canBurn = true;
                    }
                    else
                    {
                        UIController.uiActive = false;
                        canBurn = false;
                    }
                }
                else
                {
                    UIController.uiActive = false;
                    canBurn = false;
                }
            }
            else
            {
                UIController.uiActive = false;
                canBurn = false;
            }
        }
        else
        {
            UIController.uiActive = false;
            canBurn = false;
        }

        if (canBurn && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(BurnWeb());
        }
    }

    void OnMouseExit()
    {
        UIController.commandText = "";
        UIController.uiActive = false;
        canBurn = false;
    }

    IEnumerator BurnWeb()
    {
        UIController.commandText = "";
        UIController.uiActive = false;
        canBurn = false;

        webCam.SetActive(true);
        thePlayer.SetActive(false);
        flameObject.SetActive(true);

        yield return new WaitForSeconds(3);

        fadeIn.SetActive(false);
        fadeIn.SetActive(true);

        webCam.SetActive(false);
        thePlayer.SetActive(true);
        WebObjects.SetActive(false);
        flameObject.SetActive(false);
        WebEvent.SetActive(false);
    }
}