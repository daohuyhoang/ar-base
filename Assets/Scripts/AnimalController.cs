using System;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public void OnPartClicked(string partName)
    {
        Debug.Log("Bạn đã chạm vào: " + partName);

        UIManager.Instance.ShowPartName(partName);
    }
}