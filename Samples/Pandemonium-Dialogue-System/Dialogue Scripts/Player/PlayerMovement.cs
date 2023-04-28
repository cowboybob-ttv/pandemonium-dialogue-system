using UnityEngine;
using Pandemonium.Npc;

namespace Pandemonium.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private NpcContoller npc;
        [SerializeField] private float speed;
        private Rigidbody2D body;

        private bool inNpcCollider;

        private void Awake ()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void Update ()
        {
            if (!InDialogue())
            {
                InputUpdate();
            }

            if (inNpcCollider)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    npc.ActivateDialogue();
                }
            }          
        }

        private void InputUpdate ()
        {
            float verticalInput = Input.GetAxisRaw("Vertical");
            float horizontalInput = Input.GetAxisRaw("Horizontal");

            Vector3 inputDir = new Vector3(horizontalInput, verticalInput, 0);
            transform.Translate(inputDir.normalized * speed * Time.deltaTime);
        }

        private bool InDialogue ()
        {
            if (npc != null) return npc.DialogueActive();

            else return false;
        }

        private void OnTriggerEnter2D (Collider2D other)
        {
            if (other.gameObject.CompareTag("Npc"))
            {
                inNpcCollider = true;

                npc = other.gameObject.GetComponent<NpcContoller>();
            }
        }

        private void OnTriggerExit2D (Collider2D other)
        {
            npc = null;
            inNpcCollider = false;
        }
    }
}