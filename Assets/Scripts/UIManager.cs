using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text partNameText;
    [SerializeField] private TMP_Text animalNameText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPartName(string name)
    {
        partNameText.text = name;
        
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayPartAudio(name);
        }
    }

    public void ShowAnimalName(string name)
    {
        animalNameText.text = name;
    }
}
