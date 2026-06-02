using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EndingCutscene : MonoBehaviour
{
    [SerializeField] private List<string> dialogueLines;
    [SerializeField] private GameObject endGameUI;
    [SerializeField] private CanvasGroup menuCanvasGroup;

    private void Start()
    {
        GameManager.instance.endingDialoguePlayed = false;
        GameManager.instance.cutsceneActive = true;
        GameManager.instance.snackFound = false; 
        endGameUI.SetActive(false);
        StartCoroutine(PlayCutscene());
    }
    private void OnEnable()
    {
        GameEvents.EndingDialogueEnded += EndGame;
    }
    private void OnDisable()
    {
        GameEvents.EndingDialogueEnded -= EndGame;
    }
    private IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(1f);
        DialogueManager.instance.StartDialogue(dialogueLines);
    }
    
    private void EndGame()
    {
        endGameUI.SetActive(true);
    }
    public void ReturnToMenu()
    {
        StartCoroutine(FadeOutMenu());
        InventoryManager.instance.ClearInventory();
        GameManager.instance.manageScene.PlayUISound();
    }
    private IEnumerator FadeOutMenu()
    {
        float fadeDuration = 1f; // duration of fade in seconds
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            menuCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }
        menuCanvasGroup.alpha = 0f;

        GameManager.instance.ChangeScene("MainMenu");
    }
}
