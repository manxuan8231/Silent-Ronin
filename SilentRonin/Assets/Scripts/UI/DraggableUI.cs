using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 offset;

    [Header("Vị trí mặc định (đặt thủ công trong Inspector)")]
    public Vector2 defaultPosition;

    [Header("Chế độ chỉnh vị trí (bật khi người chơi đang ở Setting)")]
    public bool isEditMode = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        LoadSavedPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isEditMode) return;

        // Tính khoảng cách giữa con trỏ và tâm nút
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 localMousePos
        );

        offset = rectTransform.anchoredPosition - localMousePos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isEditMode) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            eventData.position,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        Vector2 newPos = localPoint + offset;

        // Giới hạn trong vùng canvas
        Vector2 halfButton = rectTransform.rect.size * rectTransform.lossyScale / 2f;
        Vector2 canvasHalf = (canvas.transform as RectTransform).rect.size / 2f;

        newPos.x = Mathf.Clamp(newPos.x, -canvasHalf.x + halfButton.x, canvasHalf.x - halfButton.x);
        newPos.y = Mathf.Clamp(newPos.y, -canvasHalf.y + halfButton.y, canvasHalf.y - halfButton.y);

        rectTransform.anchoredPosition = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isEditMode) return;

        PlayerPrefs.SetFloat(gameObject.name + "_X", rectTransform.anchoredPosition.x);
        PlayerPrefs.SetFloat(gameObject.name + "_Y", rectTransform.anchoredPosition.y);
        PlayerPrefs.Save();
    }

    public void LoadSavedPosition()
    {
        if (PlayerPrefs.HasKey(gameObject.name + "_X"))
        {
            float x = PlayerPrefs.GetFloat(gameObject.name + "_X");
            float y = PlayerPrefs.GetFloat(gameObject.name + "_Y");
            rectTransform.anchoredPosition = new Vector2(x, y);
        }
        else
        {
            rectTransform.anchoredPosition = defaultPosition;
        }
    }

    public void ResetPosition()
    {
        rectTransform.anchoredPosition = defaultPosition;
        PlayerPrefs.DeleteKey(gameObject.name + "_X");
        PlayerPrefs.DeleteKey(gameObject.name + "_Y");
        PlayerPrefs.Save();
    }
}
