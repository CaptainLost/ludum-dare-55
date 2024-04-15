using UnityEngine;
using Zenject;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI m_text;
    [SerializeField]
    private MainMenu m_mainMenu;

    private SceneField m_sceneField;

    public void Initalize(SceneField sceneField, int levelIndex)
    {
        m_sceneField = sceneField;

        m_text.text = "Level " + (levelIndex + 1);
    }

    public void OnButtonPressed()
    {
        m_mainMenu.LoadLevel(m_sceneField);
    }
}
