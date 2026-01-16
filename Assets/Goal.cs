using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            string currentLevel = SceneManager.GetActiveScene().name;

            if (currentLevel == "Level1")
            {
                Debug.Log("On Level 1. Loading Level 2...");
                SceneManager.LoadScene("Level2");
            }
            else if (currentLevel == "Level2")
            {
                Debug.Log("On Level 2. Going back to start...");
                Time.timeScale = 1; 
                SceneManager.LoadScene("Level1");
            }
        }
    }
}