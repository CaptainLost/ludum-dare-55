using UnityEngine;

public class SpikesObject : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_spikeSpriteRenderer;
    [SerializeField]
    private Sprite m_openSprite;
    [SerializeField]
    private Sprite m_closedSprite;

    private GridObject m_gridObject;

    private void Awake()
    {
        m_gridObject = GetComponent<GridObject>();
    }

    public void Open()
    {
        m_gridObject.ObjectFlags &= ~EGridObjectFlags.Dynamic_Collision;

        m_spikeSpriteRenderer.sprite = m_openSprite;
    }

    public void Close()
    {
        m_gridObject.ObjectFlags |= EGridObjectFlags.Dynamic_Collision;

        m_spikeSpriteRenderer.sprite = m_closedSprite;
    }
}
