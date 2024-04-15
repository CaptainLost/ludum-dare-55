using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class InputManager : MonoBehaviour
{
    public PlayerInput InputAsset;

    private void Awake()
    {
        InputAsset = new PlayerInput();

        InputAsset.Movement.Enable();
    }
}
