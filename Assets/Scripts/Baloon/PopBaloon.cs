using UnityEngine;

public class PopBaloon : MonoBehaviour 
{
    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string layerName = LayerMask.LayerToName(other.transform.gameObject.layer);

        if (layerName == "Weapon")
        {
            Destroy(this.gameObject);
            sceneLoader.Restart(1);
        }
    }
}