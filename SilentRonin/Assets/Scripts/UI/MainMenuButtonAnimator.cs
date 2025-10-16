using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonAnimator : MonoBehaviour
{
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Khi rê chuột vào
    public void OnPointerEnter(PointerEventData eventData)
    {
        anim.SetTrigger("Hover");
    }

    // Khi rê chuột ra ngoài
    public void OnPointerExit(PointerEventData eventData)
    {
        anim.SetTrigger("Normal");
    }

    // Khi click
    public void OnPointerClick()
    {
        anim.SetTrigger("Click");
    }
}
