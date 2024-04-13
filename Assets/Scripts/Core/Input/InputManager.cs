using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerInput InputAsset;

    private void Awake()
    {
        InputAsset = new PlayerInput();

        InputAsset.Movement.Enable();
    }
}
