

using UnityEngine;
using Variables.Definitions;

public class UIHandler : MonoBehaviour
{
    public IntVariable DragModeV;


    public void OnPositionButtonClicked()
    {
        DragModeV.Value = (int)DragMode.Position;
    }

    public void OnRotationButtonClicked()
    {
        DragModeV.Value = (int)DragMode.Rotation;
    }

}
