using System.Collections;
using UnityEngine;
using TMPro;

//Youtube totorial uses Legacy Text: https://www.youtube.com/watch?v=8eJ_gxkYsyY
//Youtube Second video of tutorial: https://www.youtube.com/watch?v=iCybBI9_M2E
namespace Pandemonium.DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        public bool finished { get; protected set; }
        protected IEnumerator WriteText (string input, TextMeshProUGUI textHolder, Color textColor, TMP_FontAsset textFont, float delay, AudioClip sound, float delayBetweenLines)
        {
            textHolder.color = textColor;
            textHolder.font = textFont;
            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                Pandemonium.Sound.SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }
            
            //Wait for Input to activate next line of dialogue
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            finished = true;
        }
    }
}