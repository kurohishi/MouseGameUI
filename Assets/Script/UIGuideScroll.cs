using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIGuideScroll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float _num = 0.0f;
    [SerializeField] private GameObject _guide;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private bool f_click = false;
    [SerializeField] private bool f_cursor = false;
    [SerializeField] private bool f_2way = false;
    [SerializeField] private float _value_x = 10.0f;
    [SerializeField] private float _value_y = 10.0f;
    [SerializeField] private AudioSource _se;
    RectTransform rect;
    Vector3 pos;
    bool _trig = false;
    void Start()
    {
        _scrollbar.value = _num;
        rect = _guide.GetComponent<RectTransform>();
        pos = rect.anchoredPosition;
    }
    void Update()
    {
        if (!f_cursor)
        {
            if (!f_2way) //スクロールバー１本
            {
                if (f_click) { if (Input.GetMouseButton(1)) YaxisTextScroll(); } //右ボタンを押していれば【⇅】にスクロール
                else { if (!Input.GetMouseButton(1)) YaxisTextScroll(); } //右ボタンを押していなければ【⇅】にスクロール
            }
            else //スクロールバー２本
            {
                if (f_click) { if (Input.GetMouseButton(1)) XaxisTextScroll(); } //右ボタンを押していれば【⇄】にスクロール
                else { if (!Input.GetMouseButton(1)) YaxisTextScroll(); } //右ボタンを押していなければ【⇅】にスクロール
            }
        }
        else  //カーソルがUI上にあるときのみ
        {
            if (_trig)
            {
                if (!f_2way) //スクロールバー１本
                {
                    if (f_click) { if (Input.GetMouseButton(1)) YaxisTextScroll(); } //右ボタンを押していれば【⇅】にスクロール
                    else { if (!Input.GetMouseButton(1)) YaxisTextScroll(); } //右ボタンを押していなければ【⇅】にスクロール
                }
                else //スクロールバー２本
                {
                    if (f_click) { if (Input.GetMouseButton(1)) XaxisTextScroll(); } //右ボタンを押していれば【⇄】にスクロール
                    else { if (!Input.GetMouseButton(1)) YaxisTextScroll(); } //右ボタンを押していなければ【⇅】にスクロール
                }
            }
        }
    }
    void XaxisTextScroll() //横スクロール
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            if (_num >= 1.0f) return;
            else
            {
                _num += 0.1f;
                if (_num >= 1.0f) _num = 1.0f;
                _scrollbar.value = _num;
                rect.anchoredPosition = new Vector3(pos.x +_num * _value_x, rect.anchoredPosition.y, 0.0f);
                if (_se) _se.Play();
            }
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            if (_num <= 0.0f) return;
            else
            {
                _num -= 0.1f;
                if (_num <= 0.0f) _num = 0.0f;
                _scrollbar.value = _num;
                rect.anchoredPosition = new Vector3(pos.x + _num * _value_x, rect.anchoredPosition.y, 0.0f);
                if (_se) _se.Play();
            }
        }
    }
    void YaxisTextScroll() //縦スクロール
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            if (_num >= 1.0f) return;
            else
            {
                _num += 0.1f;
                if (_num >= 1.0f) _num = 1.0f;
                _scrollbar.value = _num;
                rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, pos.y + _num * _value_y, 0.0f);
                if (_se) _se.Play();
            }
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            if (_num <= 0.0f) return;
            else
            {
                _num -= 0.1f;
                if (_num <= 0.0f) _num = 0.0f;
                _scrollbar.value = _num;
                rect.anchoredPosition = new Vector3(rect.anchoredPosition.x, pos.y + _num * _value_y, 0.0f);
                if (_se) _se.Play();
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData) //カーソルがUIに入ったとき
    {
        _trig = true;
    }
    public void OnPointerExit(PointerEventData eventData) //カーソルがUIを出たとき
    {
        _trig = false;
    }
}
