using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private UIDocument uiDocument;
    private Label scoreLabel;
    private Label highScoreLabel;

    private int score = 0;
    private readonly string scoreLabelText = "Score: ";
    private static int highScore = 0;
    private readonly string highScoreLabelText = "High Score: ";

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        scoreLabel = uiDocument.rootVisualElement.Q<Label>("Score");
        scoreLabel.text = scoreLabelText + score;

        highScoreLabel = uiDocument.rootVisualElement.Q<Label>("HighScore");
        highScoreLabel.text = highScoreLabelText + highScore;
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        ProjectileController.OnShouldUpdateScoreEvent += UpdateScore;
        ProjectileController.OnShouldUpdateHighScoreEvent += UpdateHighScore;
    }

    private void OnDisable()
    {
        ProjectileController.OnShouldUpdateScoreEvent -= UpdateScore;
        ProjectileController.OnShouldUpdateHighScoreEvent -= UpdateHighScore;
    }

    private void UpdateScore()
    {
        ++score;
        scoreLabel.text = scoreLabelText + score;
        
    }

    private void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreLabel.text = highScoreLabelText + highScore;
        }
    }
}
