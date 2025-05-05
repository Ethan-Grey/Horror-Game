using UnityEngine;

namespace VHS
{
    public class DestroyInteractable : InteractableBase
    {
        public override void OnInteract()
        {
            base.OnInteract();

            Destroy(gameObject);
        }
    }
}