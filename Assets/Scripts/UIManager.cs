using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TMP_Text partNameText;
    public TMP_Text animalNameText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowPartName(string name)
    {
        partNameText.text = name;
    }

    public void ShowAnimalName(string name)
    {
        animalNameText.text = name;
    }
}
