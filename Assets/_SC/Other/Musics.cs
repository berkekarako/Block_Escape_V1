using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _SC.Other
{
    public class Musics : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip startAudioClip;
        public AudioMixerGroup audioMixerGroup;
        
        public Slider volumeSlider;
        
        void Start()
        {
            if(startAudioClip)
                PlayMusic(startAudioClip);
        }
        
        public void PlayMusic(AudioClip audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void ChangeVolume()
        {
            print(volumeSlider.value);
            audioMixerGroup.audioMixer.SetFloat("musicVolume", volumeSlider.value);
        }
    }
}
