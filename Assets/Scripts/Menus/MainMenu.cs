using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string startScene;
    [SerializeField] private GameObject introCutscenePrefab;
    [SerializeField] private CanvasGroup mainMenuCanvasGroup;
    [SerializeField] private Button playButton;

    private void Start()
    {
        // ensure main menu canvas group is fully visible and play button is interactable at start
        mainMenuCanvasGroup.alpha = 1f;
        playButton.interactable = true;

        // hide inventory
        GameManager.instance.cutsceneActive = true;
    }
    public void StartGame()
    {
        // fade out main menu canvas group
        StartCoroutine(FadeOutMainMenu());
        GameManager.instance.manageScene.PlayUISound();

        // set play button to inactive so it cannot be clicked again while transition is happening
        playButton.interactable = false;
    }
    private IEnumerator FadeOutMainMenu()
    {
        float fadeDuration = 1f; // duration of fade in seconds
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            mainMenuCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }
        mainMenuCanvasGroup.alpha = 0f;

        Instantiate(introCutscenePrefab);
        GameManager.instance.StartGame();
    }
    public void ExitGame()
    {
        GameManager.instance.ExitGame();
    }
}
