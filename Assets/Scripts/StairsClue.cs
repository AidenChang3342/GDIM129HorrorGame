using UnityEngine;
using System.Collections;

public class StairsClue : MonoBehaviour
{
    [SerializeField] private AudioClip footstepSFX;
    [SerializeField] private float initialDelay;

    private void Start()
    {
        // play footsteps sfx after a delay
        // add later: only play after certain clues are gathered
        StartCoroutine(PlayFootsteps());
    }

    // coroutine to play footstep sfx after a couple seconds delay
    private IEnumerator PlayFootsteps()
    {
        // wait for initial delay
        yield return new WaitForSeconds(initialDelay);

        // play footstep sfx
        AudioManager.instance.PlaySFX(footstepSFX, this.transform, 1f);
    }
}
