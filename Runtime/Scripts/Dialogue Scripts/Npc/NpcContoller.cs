using UnityEngine;

namespace Pandemonium.Npc 
{
    public class NpcContoller : MonoBehaviour
    {
        [SerializeField] private GameObject dialogue;

        public void ActivateDialogue ()
        {
            dialogue.SetActive(true);
        }

        public bool DialogueActive ()
        {
            return dialogue.activeInHierarchy;
        }
    }
}