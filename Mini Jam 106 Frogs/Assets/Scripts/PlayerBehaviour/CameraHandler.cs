using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    public void LockCamera()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UnlockCamera()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}
