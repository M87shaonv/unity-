using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Dragon : MonoBehaviour
{

    private string Name;
    private Vector3 Scale;

    void Start()
    {
        ReadRandomNameAndScale(Application.dataPath + @"\004PrototypePattern\Dragons.json");
        Invoke(nameof(DestroyThis), 10f);
    }

    private void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void ReadRandomNameAndScale(string path)
    {
        string json = File.ReadAllText(path);
        var dragonsWrapper = JsonUtility.FromJson<DragonsWrapper>(json);
        if (dragonsWrapper != null && dragonsWrapper.dragons != null && dragonsWrapper.dragons.Count > 0)
        {
            int target = Random.Range(0, dragonsWrapper.dragons.Count);
            DragonData dragonData = dragonsWrapper.dragons[target];
            Name = dragonData.name;
            Scale = dragonData.scale;
            transform.localScale = Scale;
            name = Name;
        }
        else
        {
            Debug.LogError("Dragons list is empty or null.");
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * (-Time.deltaTime * 2));
    }
    [System.Serializable]
    public class DragonData
    {
        public string name;
        public Vector3 scale;
    }

    [System.Serializable]
    public class DragonsWrapper
    {
        public List<DragonData> dragons;
    }
}
