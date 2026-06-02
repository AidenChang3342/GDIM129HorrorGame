using UnityEngine;
using UnityEngine.UI;

public class HungryBarManager : MonoBehaviour
{
    public static HungryBarManager Instance { get; private set; }

    [Header("Hungry Bar 设置")]
    public float maxHunger = 100f;
    public float currentHunger;
    public float decreasePerClick = 1f;

    [Header("UI")]
    public Slider hungrySlider;

    void Awake()
    {
        // 单例核心逻辑
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // 跨场景保留（如果需要）
    }

    void Start()
    {
        currentHunger = maxHunger;
        UpdateUI();
    }

    public void Decrease()
    {
        currentHunger = Mathf.Max(0f, currentHunger - decreasePerClick);
        UpdateUI();

        if (currentHunger <= 0f)
        {
            OnHungry();
        }
    }

    void UpdateUI()
    {
        if (hungrySlider != null)
            hungrySlider.value = currentHunger / maxHunger;
    }

    void OnHungry()
    {
        Debug.Log("饿死了！触发游戏事件");
        // 这里触发恐怖事件、Game Over 等
    }
}