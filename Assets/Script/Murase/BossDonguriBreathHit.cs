using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDonguriBreathHit : MonoBehaviour
{
    public GameObject target;
    public bool isBreathHit = false;
    Vector3 targetPos;
    Vector3 forward;
    RangeObject parameter;
    private void Start()
    {
        parameter = GetComponent<RangeObject>();
    }

    private void Update()
    {
        targetPos = target.transform.position;
        Vector3 myPos = this.transform.position;
        forward = this.transform.forward;

        float radius = parameter.Length;
        float startDeg = parameter.WidthAngle / 2;
        float endDeg = -parameter.WidthAngle / 2;
        float endDegY = parameter.HeightAngle / 2;

        bool isInsideOfSector = IsInsideOfSectorXZ(targetPos,myPos,forward,startDeg,endDeg,radius);
        bool isInsideOfSectorY = IsInsideOfSectorY(targetPos, myPos, forward, endDegY);

        if (isInsideOfSector && isInsideOfSectorY)
        {
            isBreathHit = true;
        }
        else
        {
            isBreathHit = false;
        }
    }
    public static bool IsInsideOfCircle(Vector3 target, float radius)
    {
        if (Mathf.Pow(target.x, 2) + Mathf.Pow(target.z, 2) <= Mathf.Pow(radius, 2))
        {
            return true;
        }
        return false;
    }

    public static bool IsInsideOfCircle(Vector3 target, Vector3 center, float radius)
    {
        var diff = target - center;
        return IsInsideOfCircle(diff, radius);
    }

    public static bool IsInsideOfSectorXZ(Vector3 target, Vector3 center,Vector3 forward, float startDeg, float endDeg, float radius)
    {
        var diff = target - center;

        var startVec = Quaternion.Euler(0, startDeg, 0) * forward;
        var endVec = Quaternion.Euler(0, endDeg, 0) * forward;
        Vector2 diffXZ = new Vector2(diff.x, diff.z);
        Vector2 startVecXZ = new Vector2(startVec.x, startVec.z);
        Vector2 endVecXZ = new Vector2(endVec.x, endVec.z);

        // 円の内外判定
        if (!IsInsideOfCircle(diff, radius))
        {
            return false;
        }

        // 扇型の角度が180度未満の場合
        if (GetCross2d(startVecXZ, endVecXZ) > 0)
        {
            // diff が startVec より左側 *かつ* diff が endVec より右側の時
            if (GetCross2d(startVecXZ, diffXZ) >= 0 && GetCross2d(endVecXZ, diffXZ) <= 0)
            {
                return true;
            }
            return false;
        }
        // 扇型の角度が180度以上の場合
        else
        {
            // diff が startVec より左側 *または* diff が endVec より右側の時
            if (GetCross2d(startVecXZ, diffXZ) >= 0 || GetCross2d(endVecXZ, diffXZ) <= 0)
            {
                return true;
            }
            return false;
        }
    }

    public static bool IsInsideOfSectorY(Vector3 target, Vector3 center, Vector3 forward,float endDeg)
    {
        var diff = target - center;
      
        var endVec = Quaternion.Euler(-endDeg, 0, 0) * forward;
        Vector2 diffY = new Vector2(diff.z, diff.y);
        Vector2 endVecY = new Vector2(endVec.z, endVec.y);

        // diff がendVec より右側の時
        if (GetCross2d(endVecY, diffY) <= 0)
        {
            return true;
        }
        return false;
    }

    static float GetCross2d(Vector2 a, Vector2 b)
    {
        return GetCross2d(a.x, a.y, b.x, b.y);
    }

    static float GetCross2d(float ax, float ay, float bx, float by)
    {
        return ax * by - bx * ay;
    }
}
