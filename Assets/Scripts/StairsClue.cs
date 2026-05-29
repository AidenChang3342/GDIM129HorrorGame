using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StairsClue : MonoBehaviour
{
    [SerializeField] private AudioClip footstepSFX;
    [SerializeField] private float initialDelay;
    [SerializeField] private float dialogueDelay;
    [SerializeField] private List<string> dialogueLines;

    private void Start()
    {
        // play footsteps sfx after a delay if player has found bedroom and hallway clues
        if( GameManager.instance.bedroomClueFound == true && 
        GameManager.instance.hallwayClueFound == true)
        {
            StartCoroutine(PlayFootsteps());
            
        }
    }

    // coroutine to play footstep sfx after a couple seconds delay
    private IEnumerator PlayFootsteps()
    {
        // wait for initial delay
        yield return new WaitForSeconds(initialDelay);

        // play footstep sfx
        AudioManager.instance.PlaySFX(footstepSFX, this.transform, 1f);

        // wait for dialogue delay
        yield return new WaitForSeconds(dialogueDelay);

        // show dialogue
        DialogueManager.instance.StartDialogue(dialogueLines);

        // set clue as found in game manager
        GameManager.instance.stairsClueFound = true;
        GameManager.instance.CheckClues();
    }
}
