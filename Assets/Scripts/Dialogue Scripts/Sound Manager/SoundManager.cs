using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pandemonium.Sound
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance { get; private set;}

        private AudioSource source;

        private void Awake ()
        {
            instance = this;

            source = GetComponent<AudioSource>();
        }

        public void PlaySound (AudioClip sound)
        {
            source.PlayOneShot(sound);
        }
    }
}