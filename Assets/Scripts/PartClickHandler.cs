using UnityEngine;

public class PartClickHandler : MonoBehaviour
{
    [SerializeField] private string partName;
    [SerializeField] private AnimalController animalController;
    
    private void OnMouseDown()
    {

        if (animalController != null)
        {
            animalController.OnPartClicked(partName);
        }
        else
        {
            Debug.LogWarning("Không tìm thấy AnimalController cho bộ phận: " + partName);
        }
    }

    public void SetPartName(string name)
    {
        partName = name;
    }

    public string GetPartName()
    {
        return partName;
    }
}