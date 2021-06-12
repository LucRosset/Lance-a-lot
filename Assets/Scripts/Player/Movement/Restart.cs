using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour 
{
    void Update() 
    {
        if (Input.GetButton("Restart"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}