using UnityEngine;

public class CursorAimControl : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    RectTransform rect;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RectTransform _canvasTransform;
    private void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasTransform,Input.mousePosition,_canvas.worldCamera,out var mousePosition);

        rect.anchoredPosition = new Vector2(mousePosition.x + _offset.x, mousePosition.y + _offset.y);
    }
}
