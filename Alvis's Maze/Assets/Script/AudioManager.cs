using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;  // 单例实例
    public AudioSource backgroundAudioSource;  // 背景音乐音频源
    public AudioSource effectAudioSource;      // 特殊音乐或音效音频源

    public AudioClip[] backgroundMusicClips;   // 背景音乐数组
    public AudioClip[] effectMusicClips;       // 特殊音乐数组

    private int currentMusicIndex = 0;         // 默认播放第 1 首背景音乐

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;  // 设置单例实例
            DontDestroyOnLoad(gameObject);  // 不被销毁
            SceneManager.sceneLoaded += OnSceneLoaded; // 注册场景加载事件
        }
        else
        {
            Destroy(gameObject);  // 如果存在其他实例，销毁当前
        }
    }

    // 在场景加载时自动播放背景音乐
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("场景加载完成：" + scene.name);
        PlayBackgroundMusic(0); // 播放背景音乐列表的第 1 首
    }

    // 播放特定索引的背景音乐
    public void PlayBackgroundMusic(int musicIndex)
    {
        if (musicIndex < 0 || musicIndex >= backgroundMusicClips.Length)
        {
            Debug.LogWarning("Background music index out of range!");
            return;
        }

        // 如果当前背景音乐正在播放且是同一首音乐，不重新播放
        if (backgroundAudioSource.isPlaying && backgroundAudioSource.clip == backgroundMusicClips[musicIndex])
        {
            Debug.Log("当前背景音乐已在播放：" + backgroundMusicClips[musicIndex].name);
            return;
        }

        // 播放新的背景音乐
        backgroundAudioSource.Stop();
        backgroundAudioSource.clip = backgroundMusicClips[musicIndex];
        backgroundAudioSource.Play();
        currentMusicIndex = musicIndex; // 更新当前音乐索引
        Debug.Log("播放背景音乐：" + backgroundMusicClips[musicIndex].name);
    }

    // 播放特殊音效或音乐（例如死亡音乐）
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
        Debug.Log("播放特殊音乐：" + effectMusicClips[musicIndex].name);
    }

    // 停止当前背景音乐
    public void StopBackgroundMusic()
    {
        if (backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Stop();
        }
    }

    // 停止特殊音效或音乐
    public void StopEffectMusic()
    {
        if (effectAudioSource.isPlaying)
        {
            effectAudioSource.Stop();
        }
    }
}
