using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 鏡頭操作軸向類型
/// </summary>
public enum AxisType { XY, X, Y }
public class CameraTargetManager : MonoBehaviour
{
    /// <summary>
    /// 滑鼠右鍵按下(開始拖曳)的起始點
    /// </summary>
    private Vector3 startDragPos;
    /// <summary>
    /// 滑鼠拖曳後的方向向量位置(以起點為基準)
    /// </summary>
    private Vector3 endDragPos;

    private float angY
    {
        get
        {
            //呼叫尤拉幫忙，取得Y軸當前角度
            return transform.rotation.eulerAngles.y;
        }
    }

    private float angX
    {
        get
        {
            //呼叫尤拉幫忙，取得X軸當前角度
            return transform.rotation.eulerAngles.x;
        }
    }
    /// <summary>
    /// Y旋轉角
    /// </summary>
    private float angRotaY
    {
        get
        {
            //Y軸旋轉角度變量
            return angY + endDragPos.normalized.x * Time.deltaTime * rotaSpeed;
        }
    }
    /// <summary>
    /// X旋轉角
    /// </summary>
    private Vector3 angRotaX
    {
        get
        {
            Vector3 ang;
            ang.x = endDragPos.normalized.y * rotaSpeed / 2f;
            ang.y = 0;
            ang.z = 0;
            // X軸旋轉角度變量
            return transform.rotation.eulerAngles + ang * Time.deltaTime;
        }
    }
    /// <summary>
    /// 全向旋轉
    /// </summary>
    private Vector3 angRota
    {
        get
        {
            Vector3 ang;
            ang.x = endDragPos.normalized.y * rotaSpeed / 2f * flip;
            ang.y = endDragPos.normalized.x * rotaSpeed;
            ang.z = 0;
            // X + Y軸旋轉角度變量
            return transform.rotation.eulerAngles + ang * Time.deltaTime ;
        }
    }

    private float flip
    {
        get
        {
            if (flipY) return -1f;
            else return 1f;
        }
    }

    [Header("鏡頭旋轉速度")]
    public float rotaSpeed = 120f;
    [Header("鏡頭旋轉控制")]
    public AxisType axisType;
    [Header("Y軸反轉")]
    public bool flipY;

    // Start is called before the first frame update
    void Start()
    {
        DataSystem.SetCameraTarget(this);
    }

    // Update is called once per frame
    void Update()
    {
        FolllowPlayer();
        RotaTarget();
    }

    /// <summary>
    /// 跟隨玩家功能
    /// </summary>
    public void FolllowPlayer()
    {
        transform.position = DataSystem.playerPos;
    }

    /// <summary>
    /// 旋轉焦點目標(帶動鏡頭甩尾)
    /// </summary>
    public void RotaTarget()
    {
        //按下右鍵的瞬間(只執行一次)
        /*if (Input.GetMouseButtonDown(1))
        {
            //紀錄起始位置
            startDragPos = Input.mousePosition;
        }*/
        if (Input.GetMouseButton(1))
        {
            //用起始位置到新指標位置的方向向量(位置B - 位置A)
            endDragPos = Input.mousePosition - startDragPos;
            switch (axisType)
            {
                case AxisType.XY:
                    //旋轉(全向)
                    transform.rotation = Quaternion.Euler(angRota);
                    break;

                case AxisType.Y:
                    //旋轉(固定Y為主)
                    transform.rotation = Quaternion.AngleAxis(angRotaY, Vector3.up);
                    break;

                case AxisType.X:
                    //旋轉(固定X為主)
                    transform.rotation = Quaternion.Euler(angRotaX);
                    break;
            }
            //刷新(紀錄)起始位置
            startDragPos = Input.mousePosition;
        }
    }
}
