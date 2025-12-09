using UnityEngine;

public class PartClick : MonoBehaviour
{
    public string partName;
    public AnimalController animalController;

    private void OnMouseDown()
    {
        animalController = GetComponent<AnimalController>();
        if (animalController != null)
        {
            animalController.OnPartClicked(partName);
        }
    }

    public void OnClicked()
    {
        Debug.Log("Bạn đã chạm vào1: " + partName);

        UIManager.Instance.ShowPartName(partName);
    }
}
