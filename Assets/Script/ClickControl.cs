using UnityEngine;
public class ClickControl : MonoBehaviour
{
    [SerializeField] private GameObject _effect;
    [SerializeField] private AudioSource _se;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            var effect = Instantiate(_effect);
            var screenPos = Input.mousePosition;
            var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            effect.transform.localPosition = new Vector3(worldPos.x, worldPos.y, 0.0f);
            effect.SetActive(true);
            _se.Play();

            Destroy(effect, 1.0f);
        }
    }
}
