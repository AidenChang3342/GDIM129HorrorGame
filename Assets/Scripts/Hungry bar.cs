using UnityEngine;
using UnityEngine.UI;

public class HungryBarManager : MonoBehaviour
{
    public static HungryBarManager instance { get; private set; }

    [Header("Hungry Bar 设置")]
    public float maxHunger = 300f;
    public float currentHunger {get; private set;}
    public float decreasePerClick = 5f;
    public float HungerPercent => currentHunger / maxHunger; // For slider value.


    void Awake()
    {
        // 单例核心逻辑
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject); // 跨场景保留（如果需要）
    }

    void Start()
    {
        currentHunger = maxHunger;
    }

    public void Decrease()
    {
        currentHunger = Mathf.Max(0f, currentHunger - decreasePerClick);
        UpdateUI();

        if (currentHunger <= 0f)
        {
            GameManager.instance.PlayerLose();
        }
    }
    public void RestartHunger()
    {
        currentHunger = maxHunger;
    }

    private void UpdateUI()
    {
        if (UIManager.instance != null && UIManager.instance.hungerUI != null)
        {
            UIManager.instance.hungerUI.SetValue(HungerPercent);
        }
    }


    void OnHungry()
    {
        Debug.Log("饿死了！触发游戏事件");
        GameManager.instance.PlayerLose();
        // 这里触发恐怖事件、Game Over 等
    }
}