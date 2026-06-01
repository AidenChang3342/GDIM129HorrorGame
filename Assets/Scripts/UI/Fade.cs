using UnityEngine;
using System.Collections;

public class Fade : MonoBehaviour
{
    [SerializeField] private Animator fadeTransition;
    [SerializeField] private float fadeWaitTime;
    private void OnEnable()
    {
        // subscribe to events
        GameEvents.OnChangeScene += StartFade;
    }
    private void OnDisable()
    {
        // unsubscribe from  events
        GameEvents.OnChangeScene -= StartFade;
    }
    public void StartFade(string sceneName)
    {
        StartCoroutine(PlayFade(sceneName));
    }
    public IEnumerator PlayFade(string sceneName)
    {
        fadeTransition.SetTrigger("FadeStart");

        yield return new WaitForSeconds(fadeWaitTime);
        
        GameManager.instance.manageScene.LoadScene(sceneName);
    }
}
