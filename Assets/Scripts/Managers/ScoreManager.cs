﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    int m_score = 0;
    int m_lines;
    [HideInInspector] public int m_level;

    [HideInInspector] public bool m_didLevelUp = false;

    [SerializeField] int m_scorePadLength = 5;

    [SerializeField] int m_linesPerLevel;
    const int m_minLines = 1;
    const int m_maxLines = 4;

    [SerializeField] TMP_Text m_linesText;
    [SerializeField] TMP_Text m_levelText;
    [SerializeField] TMP_Text m_scoreText;

    [SerializeField] ParticleTrigger m_levelUpFx;

    public void ScoreLines(int n)
    {
        m_didLevelUp = false;

        n = Mathf.Clamp(n,m_minLines,m_maxLines);

        switch (n)
        {
            case 1:
                m_score += 100 * m_level;
                break;
            case 2:
                m_score += 250 * m_level;
                break;
            case 3:
                m_score += 400 * m_level;
                break;
            case 4:
                m_score += 1000 * m_level;
                break;

        }

        m_lines -= n;

        if (m_lines <= 0)
        {
            LevelUp();
        }

        UpdateUIText();
    }

    void Reset()
    {
        m_level = 1;
        m_lines = m_linesPerLevel * m_level;
        UpdateUIText();
    }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    void LevelUp()
    {
       m_level++;
       m_lines += (m_linesPerLevel * m_level);
       m_didLevelUp = true;

       if(m_levelUpFx)
       {
           m_levelUpFx.Play();
       }
    }
    void UpdateUIText()
    {
        if(m_linesText)
        {
            m_linesText.text = m_lines.ToString();
        }

        if(m_levelText)
        {
            m_levelText.text = m_level.ToString();
        }

        if(m_scoreText)
        {
            m_scoreText.text = PadZero(m_score, m_scorePadLength);
        }
    }

    // Add zeros to the text until the text is padDigits long
    string PadZero(int n, int padDigits)
    {
        string nStr = n.ToString();

        while (nStr.Length < padDigits)
        {
            nStr = "0" + nStr;
        }
        return nStr;
    }

}
