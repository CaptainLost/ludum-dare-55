using UnityEngine;

public class TabSystem : MonoBehaviour
{
    [SerializeField]
    private Tab[] _tabs;
    [SerializeField]
    private int _initialTab = 0;

    public int CurrentTabIndex { get; private set; }

    private void Awake()
    {
        SelectTab(_initialTab);
    }

    public void SelectTab(int tabIndex)
    {
        CloseAllTabs();
        OpenTab(tabIndex);

        CurrentTabIndex = tabIndex;
    }

    public void SelectNextTab()
    {
        int targetIndex = CurrentTabIndex + 1;

        if (targetIndex >= _tabs.Length)
            targetIndex = 0;

        SelectTab(targetIndex);
    }

    public void SelectPreviousTab()
    {
        int targetIndex = CurrentTabIndex - 1;

        if (targetIndex < 0)
            targetIndex = _tabs.Length - 1;

        SelectTab(targetIndex);
    }

    public void OpenTab(int tabIndex)
    {
        if (!IsTabIndexValid(tabIndex))
            return;

        Tab tab = _tabs[tabIndex];

        if (tab == null || tab.gameObject.activeInHierarchy)
            return;

        tab.gameObject.SetActive(true);
        tab.OnTabOpened();
    }

    public void CloseTab(int tabIndex)
    {
        if (!IsTabIndexValid(tabIndex))
            return;

        Tab tab = _tabs[tabIndex];

        if (tab == null || !tab.gameObject.activeInHierarchy)
            return;

        tab.gameObject.SetActive(false);
        tab.OnTabClosed();
    }

    public void CloseAllTabs()
    {
        for (int i = 0; i < _tabs.Length; i++)
        {
            CloseTab(i);
        }
    }

    private bool IsTabIndexValid(int tabIndex)
    {
        return (tabIndex >= 0 && tabIndex < _tabs.Length);
    }
}
