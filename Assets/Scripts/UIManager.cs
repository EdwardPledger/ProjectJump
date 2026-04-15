using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    private UIDocument uiDocument;
    private Label scoreLabel;
    private int score = 0;
    private readonly string scoreLabelText = "Score: ";

    private void Awake()
    {
        uiDocument = GetComponent<UIDocument>();
        scoreLabel = uiDocument.rootVisualElement.Q<Label>("Score");
        scoreLabel.text = scoreLabelText + score;

        Debug.Log(scoreLabel);
    }

    private void Update()
    {
    }

    private void OnEnable()
    {
        ProjectileController.OnShouldUpdateScoreEvent += UpdateScore;
    }

    private void OnDisable()
    {
        ProjectileController.OnShouldUpdateScoreEvent -= UpdateScore;
    }

    private void UpdateScore()
    {
        ++score;
        scoreLabel.text = scoreLabelText + score;
    }
}
