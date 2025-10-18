using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsSettingsHandler : MonoBehaviour
{
    [Header("Danh sách nút có thể kéo")]
    public DraggableUI[] draggableElements;

    [Header("Khu vực kéo")]
    public RectTransform dragArea;

    private void Start()
    {
        // Áp dụng vùng giới hạn + load vị trí
        foreach (var element in draggableElements)
        {
            element.dragArea = dragArea;
            element.LoadSavedPosition();
        }
    }

    public void ResetLayout()
    {
        foreach (var element in draggableElements)
        {
            element.ResetPosition();
        }
        Debug.Log("Layout đã được đặt lại mặc định!");
    }

   
}
