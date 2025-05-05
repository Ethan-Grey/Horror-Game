using UnityEngine;

namespace VHS
{
    public class PickUpInteractable : InteractableBase
    {
        [SerializeField] GameObject playerCandle;
        [SerializeField] GameObject pickedUpObject;
        public override void OnInteract()
        {
            base.OnInteract();

            Destroy(pickedUpObject);
            playerCandle.SetActive(true);
        }
    }
}