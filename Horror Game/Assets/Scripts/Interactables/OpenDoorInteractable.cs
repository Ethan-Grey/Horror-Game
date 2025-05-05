using UnityEngine;
using System.Collections;

namespace VHS
{
    public class OpenDoorInteractable : InteractableBase
    {
        [SerializeField] bool canOpen;
        [SerializeField] GameObject thePlayer;
        [SerializeField] GameObject theCam;
        [SerializeField] AudioSource lockedDoor;
        
        public override void OnInteract()
        {
            base.OnInteract(); 

            StartCoroutine(OpeningDoor());
        }

        IEnumerator OpeningDoor()
        {
            theCam.SetActive(true);
            thePlayer.SetActive(false);
            lockedDoor.Play();
            yield return new WaitForSeconds(3);
            theCam.SetActive(false);
            thePlayer.SetActive(true);
        }
    }
}