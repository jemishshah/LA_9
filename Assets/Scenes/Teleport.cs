using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneToLoad = "Scene1";  // Set the target scene name
    public Vector3 teleportPosition = new Vector3(2, 1, 0); // Position in Scene 2

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier")) // Ensure the ball has the "Ball" tag
        {
            DontDestroyOnLoad(other.gameObject); // Keep the ball across scenes
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject Character = GameObject.FindWithTag("Character");
        if (Character != null)
        {
            Character.transform.position = teleportPosition; // Move the ball to the new position
        }
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe after teleportation
    }
}
