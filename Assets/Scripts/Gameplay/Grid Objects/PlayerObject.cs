using UnityEngine;

public class PlayerObject : GridObject
{
    [SerializeField]
    private Sprite[] m_leftSprites;
    [SerializeField]
    private Sprite[] m_RightSprites;
    [SerializeField]
    private SpriteRenderer m_playerSprite;

    private int m_spriteIndex;
    private bool m_facingLeft;

    public override void Move(Vector3Int newPosition)
    {
        float xDiff = GridObjectData.GridPosition.x - newPosition.x;

        if (xDiff > 0)
        {
            m_facingLeft = true;
        }
        else if (xDiff < 0)
        {
            m_facingLeft = false;
        }

        base.Move(newPosition);

        Sprite[] usedSprites = m_facingLeft ? m_leftSprites : m_RightSprites;
        MoveAnimation(usedSprites);
    }

    private void MoveAnimation(Sprite[] sprites)
    {
        if (m_spriteIndex >= sprites.Length)
        {
            m_spriteIndex = 0;
        }

        m_playerSprite.sprite = sprites[m_spriteIndex];

        m_spriteIndex++;
    }
}
