using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;  // ����ʵ��
    public AudioSource backgroundAudioSource;  // ����������ƵԴ
    public AudioSource effectAudioSource;      // �������ֻ���Ч��ƵԴ

    public AudioClip[] backgroundMusicClips;   // ������������
    public AudioClip[] effectMusicClips;       // ������������

    private int currentMusicIndex = 0;         // Ĭ�ϲ��ŵ� 1 �ױ�������

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // ���õ���ʵ��
            DontDestroyOnLoad(gameObject);  // ��������
            SceneManager.sceneLoaded += OnSceneLoaded; // ע�᳡�������¼�
        }
        else
        {
            Destroy(gameObject);  // �����������ʵ�������ٵ�ǰ
        }
    }

    // �ڳ�������ʱ�Զ����ű�������
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("����������ɣ�" + scene.name);
        PlayBackgroundMusic(0); // ���ű��������б�ĵ� 1 ��
    }

    // �����ض������ı�������
    public void PlayBackgroundMusic(int musicIndex)
    {
        if (musicIndex < 0 || musicIndex >= backgroundMusicClips.Length)
        {
            Debug.LogWarning("Background music index out of range!");
            return;
        }

        // �����ǰ�����������ڲ�������ͬһ�����֣������²���
        if (backgroundAudioSource.isPlaying && backgroundAudioSource.clip == backgroundMusicClips[musicIndex])
        {
            Debug.Log("��ǰ�����������ڲ��ţ�" + backgroundMusicClips[musicIndex].name);
            return;
        }

        // �����µı�������
        backgroundAudioSource.Stop();
        backgroundAudioSource.clip = backgroundMusicClips[musicIndex];
        backgroundAudioSource.Play();
        currentMusicIndex = musicIndex; // ���µ�ǰ��������
        Debug.Log("���ű������֣�" + backgroundMusicClips[musicIndex].name);
    }

    // ����������Ч�����֣������������֣�
    public void PlayEffectMusic(int musicIndex)
    {
        if (musicIndex < 0 || musicIndex >= effectMusicClips.Length)
        {
            Debug.LogWarning("Effect music index out of range!");
            return;
        }

        effectAudioSource.Stop();
        effectAudioSource.clip = effectMusicClips[musicIndex];
        effectAudioSource.Play();
        Debug.Log("�����������֣�" + effectMusicClips[musicIndex].name);
    }

    // ֹͣ��ǰ��������
    public void StopBackgroundMusic()
    {
        if (backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Stop();
        }
    }

    // ֹͣ������Ч������
    public void StopEffectMusic()
    {
        if (effectAudioSource.isPlaying)
        {
            effectAudioSource.Stop();
        }
    }
}
