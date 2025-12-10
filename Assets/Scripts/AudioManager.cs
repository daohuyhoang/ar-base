using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<PartAudioPair> partAudioPairs;

    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();

    [System.Serializable]
    public class PartAudioPair
    {
        public string partName;
        public AudioClip audioClip;
    }

    private void Awake()
    {
        Instance = this;

        foreach (var pair in partAudioPairs)
        {
            if (!audioDict.ContainsKey(pair.partName))
            {
                audioDict.Add(pair.partName, pair.audioClip);
            }
        }
    }

    public void PlayPartAudio(string partName)
    {
        if (audioDict.ContainsKey(partName) && audioDict[partName] != null)
        {
            audioSource.clip = audioDict[partName];
            audioSource.Play();
            Debug.Log("Đang phát âm thanh cho: " + partName);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy âm thanh cho bộ phận: " + partName);
        }
    }

    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}