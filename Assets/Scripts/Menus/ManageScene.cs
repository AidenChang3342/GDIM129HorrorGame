using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Name of scene to load into
    [SerializeField] private AudioClip[] UISoundClip;

    // Loads the scene based on name set in editor
    public void LoadScene(string sceneName)
    {
        // checks if dialogue is active or inventory is open before allowing scene change
        if (DialogueManager.instance.isDialogueActive)
        {
            Debug.Log("Cannot change scene while dialogue is active");
            return;
        }
        if (UIManager.instance.inventoryUI.isOpen)
        {
            Debug.Log("Cannot change scene while inventory is opened");
            return;
        }
        
        SceneManager.LoadScene(sceneName);
    }

    // Quits game
    public void Quit()
    {
        Debug.Log("Quitting game");

        /* if in-editor, stops playing
           if in real build, exits application */
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
      
    }
    public void PlayUISound()
    {
        // plays ui sfx
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 0.5f);
    }
}
