using UnityEngine;

public class BedroomClue : MonoBehaviour
{
    [SerializeField] private AudioClip pickupSFX;
    [SerializeField] private AudioClip[] UISoundClip;
    [SerializeField] private GameObject closeupObject;
    private void Start()
    {
        closeupObject.SetActive(false);
    }

    // on mouse click, play pickup sfx and show closeup of key
    // add later: also add clue to inventory and implement unlocking door
    private void OnMouseDown()
    {
        AudioManager.instance.PlaySFX(pickupSFX, this.transform, 0.5f);
        closeupObject.SetActive(true);
        Debug.Log("add later: put in inventory");
    }

    // hides closeup object
    public void ExitCloseup()
    {
        AudioManager.instance.PlayRandomSFX(UISoundClip, this.transform, 0.5f);
        closeupObject.SetActive(false);
    }
}
