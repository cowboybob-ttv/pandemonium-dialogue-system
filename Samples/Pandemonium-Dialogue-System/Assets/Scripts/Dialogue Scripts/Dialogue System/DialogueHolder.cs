using System.Collections;
using UnityEngine;

namespace Pandemonium.DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        private bool dialogueFinished;
        private void OnEnable ()
        {
            dialogueSeq = DialogueSequence();
            StartCoroutine(dialogueSeq);
        }

        private void Update ()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
            }
        }
        private IEnumerator DialogueSequence ()
        {
            if (!dialogueFinished)
            {
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    Deactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
            }

            //sets the last line after reading all dialogues
            else 
            {
                int index = transform.childCount - 1;

                Deactivate();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(index).GetComponent<DialogueLine>().finished);
            }

            dialogueFinished = true;
            //turns off holder when complete
            gameObject.SetActive(false);
            
        }

        private void Deactivate ()
        {
            for (int i = 0; i < transform.childCount; i++)
            {          
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
