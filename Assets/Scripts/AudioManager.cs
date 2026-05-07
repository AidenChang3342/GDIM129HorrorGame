using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    [SerializeField] private AudioSource SFXObject;
    [SerializeField] private AudioSource ambienceSource;
    [SerializeField] private AudioClip ambience;


    private void Awake()
    {
        // creating singleton to call from anywhere
        if (instance == null)
        {
            instance = this;
            // keep sounds playing between scenes
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }


    }
    private void Start()
    {
        ambienceSource.clip = ambience;
        ambienceSource.Play();
    }

    // function to play sound effect by instantiating game object with audio source
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

    // plays random audio given an array of audio clips
    public void PlayRandomSFX(AudioClip[] audioClip, Transform spawnPoint, float volume)
    {
        // get random index
        int rand = Random.Range(0, audioClip.Length);

        // instantiate audioclip gameobject
        AudioSource audioSource = Instantiate(SFXObject, spawnPoint.position, Quaternion.identity);

        // assign audio clip
        audioSource.clip = audioClip[rand];

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
