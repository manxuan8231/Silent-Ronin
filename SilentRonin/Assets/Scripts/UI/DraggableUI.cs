using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    [Header("Giới hạn vùng kéo (drag area)")]
    public RectTransform dragArea; // Canvas chính hoặc panel cha

    [Header("Vị trí mặc định (đặt thủ công trong Inspector)")]
    public Vector2 defaultPosition;

    [Header("Chế độ chỉnh vị trí")]
    public bool isEditMode = false; // ⚙️ Chỉ true khi đang trong Settings

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
        if (!isEditMode) return; // ❌ Không cho kéo nếu đang trong gameplay
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isEditMode) return; // ❌ Không cho kéo

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            dragArea ?? (canvas.transform as RectTransform),
            eventData.position,
            canvas.worldCamera,
            out localPoint
        );

        // Giới hạn trong vùng canvas
        Vector2 halfSize = (dragArea ?? (canvas.transform as RectTransform)).rect.size / 2;
        localPoint.x = Mathf.Clamp(localPoint.x, -halfSize.x, halfSize.x);
        localPoint.y = Mathf.Clamp(localPoint.y, -halfSize.y, halfSize.y);

        rectTransform.anchoredPosition = localPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isEditMode) return; // ❌ Không lưu khi gameplay

        // ✅ Auto-save khi ở Setting
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
