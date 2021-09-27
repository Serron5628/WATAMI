using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeObject : MonoBehaviour
{
    public GameObject Boss;
    [SerializeField, Range(0.0f, 180.0f)]
    public float m_widthAngle = 0.0f;
    [SerializeField, Range(0.0f, 180.0f)]
    public float m_heightAngle = 0.0f;
    [SerializeField, Range(0.0f, 15.0f)]
    public float m_length = 0.0f;

    public float WidthAngle { get { return m_widthAngle; } }
    public float HeightAngle { get { return m_heightAngle; } }
    public float Length { get { return m_length; } }


    GetParticlePos particlePos;
    BossDonguriMove bossMove;
    float prePos = 0;
    private void Start()
    {
        particlePos = GetComponent<GetParticlePos>();
        bossMove = Boss.GetComponent<BossDonguriMove>();
    }

    private void Update()
    {
        if (bossMove.selectAttack == 2 && !bossMove.stopBreath)
        {
            m_length = particlePos.dist;

            if (m_length <= prePos)
            {
                m_length = prePos;
            }

            prePos = m_length;
        }
        else
        {
            m_length = 0;
            prePos = 0;
        }
       
    }
}
