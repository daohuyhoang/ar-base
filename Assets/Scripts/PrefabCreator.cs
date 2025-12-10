using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [Header("Danh sách prefab theo tên ảnh")]
    [SerializeField]
    private List<ImagePrefabPair> prefabPairs;
    [SerializeField] private Transform spawnPoint;

    private Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    [System.Serializable]
    public class ImagePrefabPair
    {
        public string imageName;
        public GameObject prefab;
    }

    private void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (var pair in prefabPairs)
        {
            if (!prefabDict.ContainsKey(pair.imageName))
            {
                prefabDict.Add(pair.imageName, pair.prefab);
            }
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            string imgName = trackedImage.referenceImage.name;

            UIManager.Instance.ShowAnimalName(imgName);

            if (prefabDict.ContainsKey(imgName))
            {
                GameObject newPrefab = Instantiate(prefabDict[imgName], spawnPoint);
                newPrefab.transform.localPosition = Vector3.zero;
                newPrefab.transform.localRotation = Quaternion.identity;
            }
        }
    }

}
