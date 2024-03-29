﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class IconToggle : MonoBehaviour
{
    [SerializeField] Sprite m_iconTrue;
    [SerializeField] Sprite m_iconFalse;

    [SerializeField] bool m_defaultIconState = true;

    Image m_image;

    // Start is called before the first frame update
    void Start()
    {
        m_image = GetComponent<Image>();
        m_image.sprite = (m_defaultIconState) ? m_iconTrue : m_iconFalse;
    }

    public void ToggleIcon (bool state)
    {
        if (!m_image || !m_iconTrue || !m_iconFalse)
        {
            Debug.LogWarning($"<color=red><b>WARNING!</b> IconToggle missing iconTrue or iconFalse!</color>");
        }
        m_image.sprite = (state) ? m_iconTrue : m_iconFalse;
    }
}
