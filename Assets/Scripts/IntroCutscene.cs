using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IntroCutscene : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip grumbleSFX;
    [SerializeField] private List<string> introLines;
    [SerializeField] private float grumbleDelay;
    [SerializeField] private float eyesDelay;
    [SerializeField] private float startDelay;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(PlayIntroDialogue());
    }
    private void OnEnable()
    {
        // subscribe to events
        GameEvents.IntroDialogueEnded += ContinueIntroCutscene;
    }
    private void OnDisable()
    {
        // unsubscribe from  events
        GameEvents.IntroDialogueEnded -= ContinueIntroCutscene;
    }

    private IEnumerator PlayIntroDialogue()
    {
        GameManager.instance.cutsceneActive = true;
        // wait for a couple seconds before starting dialogue and sfx
        yield return new WaitForSeconds(startDelay);

        // play grumble sfx and show dialogue
        AudioManager.instance.PlaySFX(grumbleSFX, transform, 0.5f);
        yield return new WaitForSeconds(grumbleDelay);
        DialogueManager.instance.StartDialogue(introLines);
    }

    private void ContinueIntroCutscene()
    {
        // trigger open eyes animation, destroy object after a delay
        animator.SetTrigger("OpenEyes");
        StartCoroutine(DestroyAfterCutscene());
    }

    private IEnumerator DestroyAfterCutscene()
    {
        yield return new WaitForSeconds(eyesDelay);
        GameManager.instance.cutsceneActive = false;
        Destroy(this.gameObject);
    }
}
