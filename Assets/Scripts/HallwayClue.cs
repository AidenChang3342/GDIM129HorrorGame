using UnityEngine;

public class HallwayClue : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private GameObject closeupObject;
    private void Start()
    {
        closeupObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        AudioManager.instance.PlaySFX(pickupSFX, this.transform, 0.5f);
        closeupObject.SetActive(true);
        Debug.Log("add: pick up clue");
    }

    // hides closeup object
    public void ExitCloseup()
    {
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 0.5f);
        closeupObject.SetActive(false);
    }
}
