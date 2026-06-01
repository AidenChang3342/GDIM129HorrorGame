using System;
using UnityEngine;
using System.Collections.Generic;

public static class GameEvents
{
    // event for when item is added to inventory
    public static Action<ItemData> OnItemAdded;
    // event for caching dialogueUI for dialogue to prevent errors
    public static Action OnUIReady;
    // event for activating keypad in kitchen
    public static Action ActivateKeypad;
    // event for continuing intro cutscene after dialogue ends
    public static Action IntroDialogueEnded;
    // event for changing scenes
    public static Action <string> OnChangeScene;
}
