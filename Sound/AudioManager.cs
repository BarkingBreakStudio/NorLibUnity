using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [Header("Music")]
    [SerializeField]
    private AudioManager4Music musicMgr;
    public AudioCueEventChannelSO MusicRequestChannel;
    public AudioMixerGroup MusicMixer;
    private GameObject MusicGo;

    [Header("Sound Effect")]
    [SerializeField]
    private AudioManager4Sfx SfxMgr;
    public AudioCueEventChannelSO SfxRequestChannel;
    public AudioMixerGroup SfxMixer;
    private GameObject SfxGo;

    private void Awake()
    {
        musicMgr = GetComponentInChildren<AudioManager4Music>();
        if (musicMgr == null)
        {
            MusicGo = new GameObject("Music");
            MusicGo.transform.parent = transform;
            musicMgr = MusicGo.AddComponent<AudioManager4Music>();
            musicMgr.SetAudioMixerGrp(MusicMixer);
        }

        SfxMgr = GetComponentInChildren<AudioManager4Sfx>();
        if (SfxMgr == null)
        {
            SfxGo = new GameObject("Sfx");
            SfxGo.transform.parent = transform;
            SfxMgr = SfxGo.AddComponent<AudioManager4Sfx>();
            SfxMgr.SetAudioMixerGrp(SfxMixer);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var musicReqListener = gameObject.AddComponent<AudioCueEventListener>();
        musicReqListener.OnEventRaised.AddListener(onMusicRequestChannel);
        musicReqListener.SetChannel(MusicRequestChannel);

        var sfxReqListener = gameObject.AddComponent<AudioCueEventListener>();
        sfxReqListener.OnEventRaised.AddListener(onSfxRequestChannel);
        sfxReqListener.SetChannel(SfxRequestChannel);
    }

    private void onMusicRequestChannel(AudioCueEventChannelSO.AudioCueReqest audioRequest)
    {
        PlayMusic(audioRequest.clip);
    }

    private void onSfxRequestChannel(AudioCueEventChannelSO.AudioCueReqest audioRequest)
    {
        PlaySfx(audioRequest.clip);
    }


    void PlayMusic(AudioClip clip)
    {
        musicMgr.PlayMusic(clip);
    }

    void PlaySfx(AudioClip clip)
    {
        SfxMgr.PlayMusic(clip);
    }



}
