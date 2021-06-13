using UnityEngine;

public class PopBaloon : MonoBehaviour 
{
    [SerializeField] private string nextScene = "Title";
    [SerializeField] private GameObject popEffectPrefab = null;
    [SerializeField] private AudioClip popSound = null;

    private SceneLoader sceneLoader;
    private AudioSource audioSource;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // string layerName = LayerMask.LayerToName(other.transform.gameObject.layer);

        // if (layerName == "Weapon")
        // {
        Destroy(Instantiate(
            popEffectPrefab,
            transform.position,
            Quaternion.identity
        ), 3f);
        audioSource.PlayOneShot(popSound);
        Destroy(this.gameObject);
        sceneLoader.LoadScene(nextScene);
        // }
    }
}