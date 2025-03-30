using UnityEngine;
public class UISlideScroll : MonoBehaviour
{
    private int _num = 0;
    [SerializeField] private GameObject[] _slide;

    [SerializeField] private AudioSource _se;
    void Update()
    {
        if (!Input.GetMouseButton(1))
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                if (_num == _slide.Length - 1) return;
                else
                {
                    _slide[_num].SetActive(false);
                    _num++;
                    _slide[_num].SetActive(true);

                    if (_se) _se.Play();
                }
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                if (_num == 0) return;
                else
                {
                    _slide[_num].SetActive(false);
                    _num--;
                    _slide[_num].SetActive(true);

                    if (_se) _se.Play();
                }
            }
        }
    }
}
