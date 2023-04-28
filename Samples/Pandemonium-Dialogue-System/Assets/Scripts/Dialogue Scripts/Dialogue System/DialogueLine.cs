using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pandemonium.DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private TextMeshProUGUI textHolder;

        [Header ("Text Options")]
        [TextArea(3, 10)]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private TMP_FontAsset textFont;

        [Header("Time Parameters")]
        [SerializeField] private float delay;
        [SerializeField] private float delayBetweenLines;

        [Header("Sound")]
        [SerializeField] private AudioClip sound;

        [Header("Character Image")]
        [SerializeField] Sprite characterSprite;
        [SerializeField] Image imageHolder;

        private IEnumerator lineAppear;

        private void Awake ()
        {   
            imageHolder.sprite = characterSprite;
            
            imageHolder.preserveAspect = true; //Might be needed
        }

        private void OnEnable ()
        {
            ResetLine();
            lineAppear = WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLines);
            StartCoroutine(lineAppear);
        }

        private void Update ()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textHolder.text != input) 
                {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;
                }
                
                else finished = true;
            }
        }

        private void ResetLine ()
        {
            textHolder = GetComponent<TextMeshProUGUI>();
            textHolder.text = "";
            finished = false;
        }
    }
}