using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSoundManager : MonoBehaviour
{
    public AudioSource effectAudioSource;
    public AudioClip[] effectAudioList;
    private float volume = 0.05f;
    /*
     0 = ��
     1 = �� ��Ģ
     2 = ��������
     3 = ����
     4 = ����Ʈ��
     5 = Ŀ��
     6 = ����
     7 = �������� Ŭ����
     8 = �������� ����
      */
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundPlay(string name)
    {
        if (!MuteManager.EffectIsMuted)
        {
            if(name == "Money")
                effectAudioSource.clip = effectAudioList[0];
            if (name == "RuleMoney")
                effectAudioSource.clip = effectAudioList[1];
            if (name == "Bomb")
                effectAudioSource.clip = effectAudioList[2];
            if (name == "Mail")
                effectAudioSource.clip = effectAudioList[3];
            if (name == "PostIt")
                effectAudioSource.clip = effectAudioList[4];
            if (name == "Coffee")
                effectAudioSource.clip = effectAudioList[5];
            if (name == "Jump")
                effectAudioSource.clip = effectAudioList[5];
            if (name == "GameClear")
                effectAudioSource.clip = effectAudioList[5];
            if (name == "GameOver")
                effectAudioSource.clip = effectAudioList[5];


            effectAudioSource.loop = false;
            effectAudioSource.volume = volume;
            effectAudioSource.Play();


        }

    }
    

}
