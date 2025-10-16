using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonAnimator : MonoBehaviour
{
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    } 

    // Khi click
    public void OnPointerClick()
    {
        anim.SetTrigger("Click");
    }
}
