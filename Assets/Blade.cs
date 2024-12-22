using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetBladeToMouse();
    }
    private void SetBladeToMouse()
    {
        var MousePos = Input.mousePosition;
        MousePos.z = 10;

        rb.position = Camera.main.ScreenToWorldPoint(MousePos);
    }
}
