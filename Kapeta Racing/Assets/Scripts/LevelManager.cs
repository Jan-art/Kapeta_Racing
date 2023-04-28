using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject level2Button;

    private void Start()
    {
        // Check if Level 2 is already unlocked
        if (PlayerPrefs.GetInt("Level2Unlocked") == 1)
        {
            UnlockLevel2();
        }
        else
        {
            // Set the Level 2 button as inactive initially
            level2Button.SetActive(false);

            // Check if Level 1 race is won or already won before, and unlock Level 2 button if true
            if (Win.StateOn || PlayerPrefs.GetInt("Level1Won") == 1)
            {
                UnlockLevel(2);
                UnlockLevel2();
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        // Load the specified level scene
        SceneManager.LoadScene("Level" + levelIndex);
    }

    public void WinLevel(int levelIndex)
    {
        // Check if the player actually won the specified level before unlocking the next level
        if (Win.StateOn)
        {
            UnlockLevel(levelIndex + 1);
        }
    }

    private void UnlockLevel(int levelIndex)
    {
        // Use PlayerPrefs to unlock the specified level
        // The key for each level should be "LevelXUnlocked", where X is the level index
        PlayerPrefs.SetInt("Level" + levelIndex + "Unlocked", 1);
        PlayerPrefs.Save();
    }

    private void UnlockLevel2()
    {
        // Unlock Level 2 button and make it active
        level2Button.SetActive(true);
    }

     public void LoadMenu()
    {
        Debug.Log("Loading Menu");
        SceneManager.LoadScene("MainMenu");
    }
}


