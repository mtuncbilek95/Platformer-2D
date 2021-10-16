using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private GameObject TopButton;

    [SerializeField] private PlayerInput inputMapping;

    private void Start()
    {

    }

    private void Update()
    {
        if (Keyboard.current.wKey.IsPressed() || Keyboard.current.sKey.IsPressed())
        {
            if (inputMapping.currentActionMap.name == "UI")
            {
                Cursor.visible = false;
                if (EventSystem.current.currentSelectedGameObject == null)
                {
                    EventSystem.current.SetSelectedGameObject(TopButton);
                }
            }

        }

        if (Gamepad.all.Count > 0)
        {
            if (Gamepad.current.dpad.up.IsPressed() || Gamepad.current.dpad.down.IsPressed())
            {
                if (inputMapping.currentActionMap.name == "UI")
                {
                    Cursor.visible = false;
                    if (EventSystem.current.currentSelectedGameObject == null)
                    {
                        EventSystem.current.SetSelectedGameObject(TopButton);
                    }
                }
            }
        }

        if (Mouse.current.delta.IsActuated())
        {
            Cursor.visible = false;
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }

}