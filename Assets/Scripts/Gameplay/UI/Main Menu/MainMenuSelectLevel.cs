using UnityEngine;
using Zenject;

public class MainMenuSelectLevel : MonoBehaviour
{
    [SerializeField]
    private LevelSelectButton m_selectButtonPrefab;
    [SerializeField]
    private Transform m_buttonParent;
    [SerializeField]
    private LevelListSO m_levelList;

    private void Awake()
    {
        CreateButtons();
    }

    private void CreateButtons()
    {
        for (int i = 0; i < m_levelList.Levels.Count; i++)
        {
            SceneField level = m_levelList.Levels[i];

            LevelSelectButton button = Instantiate(m_selectButtonPrefab, m_buttonParent);
            button.Initalize(level, i);

            button.gameObject.SetActive(true);
        }
    }
}
