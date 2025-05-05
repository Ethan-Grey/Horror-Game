using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace VHS
{
    [CreateAssetMenu(fileName = "Interaction Data", menuName = "InteractionSystem/InteractionData")]
    public class InteractionData : ScriptableObject
    {
        private InteractableBase m_interactable;

        public InteractableBase Interactable
        {
            get => m_interactable;
            set => m_interactable = value;
        }

        public void Interact()
        {
            Interactable.OnInteract();
            ResetData();
        }

        public bool IsSameInteractable(InteractableBase _newinteractable) => m_interactable == _newinteractable;
        
        public bool IsEmpty() => m_interactable == null;

        public void ResetData() => m_interactable = null;
    }
}