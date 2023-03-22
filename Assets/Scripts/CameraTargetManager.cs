using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���Y�ާ@�b�V����
/// </summary>
public enum AxisType { XY, X, Y }
public class CameraTargetManager : MonoBehaviour
{
    /// <summary>
    /// �ƹ��k����U(�}�l�즲)���_�l�I
    /// </summary>
    private Vector3 startDragPos;
    /// <summary>
    /// �ƹ��즲�᪺��V�V�q��m(�H�_�I�����)
    /// </summary>
    private Vector3 endDragPos;

    private float angY
    {
        get
        {
            //�I�s�ש������A���oY�b��e����
            return transform.rotation.eulerAngles.y;
        }
    }

    private float angX
    {
        get
        {
            //�I�s�ש������A���oX�b��e����
            return transform.rotation.eulerAngles.x;
        }
    }
    /// <summary>
    /// Y���ਤ
    /// </summary>
    private float angRotaY
    {
        get
        {
            //Y�b���ਤ���ܶq
            return angY + endDragPos.normalized.x * Time.deltaTime * rotaSpeed;
        }
    }
    /// <summary>
    /// X���ਤ
    /// </summary>
    private Vector3 angRotaX
    {
        get
        {
            Vector3 ang;
            ang.x = endDragPos.normalized.y * rotaSpeed / 2f;
            ang.y = 0;
            ang.z = 0;
            // X�b���ਤ���ܶq
            return transform.rotation.eulerAngles + ang * Time.deltaTime;
        }
    }
    /// <summary>
    /// ���V����
    /// </summary>
    private Vector3 angRota
    {
        get
        {
            Vector3 ang;
            ang.x = endDragPos.normalized.y * rotaSpeed / 2f * flip;
            ang.y = endDragPos.normalized.x * rotaSpeed;
            ang.z = 0;
            // X + Y�b���ਤ���ܶq
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

    [Header("���Y����t��")]
    public float rotaSpeed = 120f;
    [Header("���Y���౱��")]
    public AxisType axisType;
    [Header("Y�b����")]
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
    /// ���H���a�\��
    /// </summary>
    public void FolllowPlayer()
    {
        transform.position = DataSystem.playerPos;
    }

    /// <summary>
    /// ����J�I�ؼ�(�a�����Y�ϧ�)
    /// </summary>
    public void RotaTarget()
    {
        //���U�k�䪺����(�u����@��)
        /*if (Input.GetMouseButtonDown(1))
        {
            //�����_�l��m
            startDragPos = Input.mousePosition;
        }*/
        if (Input.GetMouseButton(1))
        {
            //�ΰ_�l��m��s���Ц�m����V�V�q(��mB - ��mA)
            endDragPos = Input.mousePosition - startDragPos;
            switch (axisType)
            {
                case AxisType.XY:
                    //����(���V)
                    transform.rotation = Quaternion.Euler(angRota);
                    break;

                case AxisType.Y:
                    //����(�T�wY���D)
                    transform.rotation = Quaternion.AngleAxis(angRotaY, Vector3.up);
                    break;

                case AxisType.X:
                    //����(�T�wX���D)
                    transform.rotation = Quaternion.Euler(angRotaX);
                    break;
            }
            //��s(����)�_�l��m
            startDragPos = Input.mousePosition;
        }
    }
}
