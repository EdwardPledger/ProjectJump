using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUIManager : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button playAgainButton;
    private Button exitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        uiDocument = GetComponent<UIDocument>();

        playAgainButton = uiDocument.rootVisualElement.Q<Button>("PlayAgain");
        playAgainButton.clicked += OnPlayAgainClicked;
        exitButton = uiDocument.rootVisualElement.Q<Button>("Exit");
        exitButton.clicked += OnExitButtonClicked;

    }

    private void OnPlayAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
