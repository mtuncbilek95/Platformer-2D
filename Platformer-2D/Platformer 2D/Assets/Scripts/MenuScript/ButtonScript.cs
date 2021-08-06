using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private RectTransform button;

    private Animator buttonAnimator;

    private bool onButton;
    private bool offButton;
    private bool clicked;
    private bool noneClicked;
    private float startTime;

    private void Awake()
    {

    }

    private void Start()
    {
        buttonAnimator = button.GetComponent<Animator>();
        buttonAnimator.SetBool("noneClicked", true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
        noneClicked = false;
        onButton = false;
        offButton = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        onButton = true;
        offButton = false;
        noneClicked = false;
        startTime = Time.time;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        offButton = true;
        onButton = false;
        noneClicked = false;
    }

    private void Update()
    {

        buttonAnimator.SetBool("onButton", onButton);
        buttonAnimator.SetBool("offButton", offButton);
        buttonAnimator.SetBool("noneClicked", noneClicked);

        if (clicked && Time.time >= startTime + 0.1f)
        {
            clicked = false;
            onButton = true;
        }
    }
}
