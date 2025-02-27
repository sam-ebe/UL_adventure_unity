using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler2 : MonoBehaviour
{
    public static UIHandler2 instance { 
        get; 
        private set; 
    }

    private VisualElement m_Healthbar;

    private void Awake()
    {
        instance = this;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);

    }



    public void SetHealthValue(float percentage)
    {

        m_Healthbar.style.width = Length.Percent(percentage * 100.0f);
    }
}
