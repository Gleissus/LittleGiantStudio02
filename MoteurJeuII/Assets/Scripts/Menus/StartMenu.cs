using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private Button[] menuButtons;
    int selectedButtonIndex = 0;

    [SerializeField] private AudioSource menuSound;
    [SerializeField] private AudioSource confirmationSound;


    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButtonIndex = (selectedButtonIndex + menuButtons.Length - 1) % menuButtons.Length;
            menuSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButtonIndex = (selectedButtonIndex + 1) % menuButtons.Length;
            menuSound.Play();
        }
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            confirmationSound.Play();
            menuButtons[selectedButtonIndex].onClick.Invoke();
        }

        // Highlight the selected button
        for (int i = 0; i < menuButtons.Length; i++)
        {
            if (i == selectedButtonIndex)
            {
                menuButtons[i].Select();
            }
        }
    }

    public void StartGame()
    {
        // Code to start the game
        SceneManager.LoadScene("Map1_Scene");        
    }

    public void ExitGame()
    {
        // Code to exit the game
        Debug.Log("Exit button");
        Application.Quit();
    }
}
