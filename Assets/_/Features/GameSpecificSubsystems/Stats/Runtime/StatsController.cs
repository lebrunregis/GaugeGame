using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Stats
{
    public Stat[]  stats;
}

[System.Serializable]
public class Stat
{
    #region Publics

    public string m_name;
    public AnimationCurve m_curve;
    public float m_minValue;
    public float m_maxValue;

    #endregion

    #region API

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }
    
        // Update is called once per frame
        void Update()
        {
            
        }

    #endregion

    #region Main Methods

    public float GetValueAtLevel(int level)
    {
        float normalizedValue = (m_curve.Evaluate(level) * m_maxValue);
        return Mathf.Clamp(normalizedValue, m_minValue, m_maxValue);
    }

    #endregion
}
