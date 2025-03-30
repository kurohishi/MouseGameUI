using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UIActiveControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private GameObject _guide;
    [SerializeField] private bool f_enter = true;
    [SerializeField] private bool f_exit = true;
    [SerializeField] private bool f_click = false;

    [SerializeField] private AudioSource _se_enter;
    [SerializeField] private AudioSource _se_exit;
    [SerializeField] private AudioSource _se_click;

    bool f_press = false;
    [SerializeField] private Image _gauge;
    [SerializeField] private float interval = 0.0f;
    float time = 0.0f;
    void Update() 
    {
        if (f_press)
        {
            if (_guide.activeSelf) return;
            time += Time.deltaTime;
            _gauge.fillAmount = time / interval;

            if (time >= interval)
            {
                GaugeReset();
                _guide.SetActive(true);
            }
        }
    }
    void GaugeReset()
    {
        if (_gauge)
        {
            time = 0.0f;
            _gauge.fillAmount = 0.0f;
            _gauge.transform.parent.gameObject.SetActive(false);
            f_press = false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (f_enter)
        {
            if (_gauge && !_guide.activeSelf)
            {
                f_press = true;
                _gauge.transform.parent.gameObject.SetActive(true);
            }
            else 
            {
                _guide.SetActive(true);
            }
            if (_se_enter) _se_enter.Play();
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        GaugeReset();

        if (f_exit)
        {
            _guide.SetActive(false);
            if (_se_exit) _se_exit.Play();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (f_click)
        {
            _guide.SetActive(false);
            if (_se_click) _se_click.Play();
        }
    }
}
