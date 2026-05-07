using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // creating singleton to call from anywhere
    public static AudioManager instance;
    [SerializeField] private AudioSource SFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        // keep sounds playing between scenes
        DontDestroyOnLoad(this);
    }

    public void PlaySFX(AudioClip audioClip, Transform spawnPoint, float volume)
    {
        // instantiate audioclip gameobject
        AudioSource audioSource = Instantiate(SFXObject, spawnPoint.position, Quaternion.identity);

        // assign audio clip
        audioSource.clip = audioClip;

        // assign volume
        audioSource.volume = volume;

        // play sound
        audioSource.Play();

        // get length of SFX clip
        float clipLength = audioSource.clip.length;

        // destroy audioclip gameobject after sfx is done
        Destroy(audioSource.gameObject, clipLength);
    }
}
