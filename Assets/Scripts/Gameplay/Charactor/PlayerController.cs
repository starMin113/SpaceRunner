/*
using DG.Tweening;
using System.Collections;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

*//*    EMovementType m_MovementType = EMovementType.Idle;
    public static PlayerController Instance => s_Instance;
    static PlayerController s_Instance;

    [SerializeField]
    Animator m_Animator;

    [SerializeField]
    SkinnedMeshRenderer m_SkinnedMeshRenderer;


    [SerializeField]
    AbstractGameEvent m_OrbitEvent;



    private Vector3 _circleCenter;
    Movement movementStrategy;

    private int _currRadius;



    public int currRadius => _currRadius;


    protected void Awake()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        s_Instance = this;
    }



    private void ChangeMovementStrategy(EMovementType movementType, Movement newMovmentStrategy)
    {
        if (this.movementStrategy != null)
        {
            this.movementStrategy.Stop();
        }
        this.movementStrategy = newMovmentStrategy;
        this.m_MovementType = movementType;
    }

    public EMovementType GetCurrentMovementType()
    {
        if (this.movementStrategy.IsRun)
        {
            return this.m_MovementType;
        }
        else
        {
            return EMovementType.Changing;
        }

    }
    public void StartCirularRun(Vector3 center, int startRadius)
    {
        _currRadius = startRadius;
        _circleCenter = center;
        transform.position = center + Vector3.right * startRadius;
        ChangeMovementStrategy(EMovementType.Circular, GenerateCirularMovement(center, transform,false));
    }

    private CircularMovement GenerateCirularMovement(Vector3 center, Transform tran,bool isTween)
    {
        return new CircularMovement(center, tran,isTween);
    }



    private LinearMovement GenerateLineMovement(bool direction)
    {
        int newRadius = direction ? currRadius + Consts.STEP : currRadius - Consts.STEP;
        return new LinearMovement(transform, _circleCenter, direction, newRadius, () =>
        {
            _currRadius = newRadius;
            SetDefault();
            m_OrbitEvent.Raise();
        });
    }



    public Vector3 GetPlayerTop()
    {
        return transform.position;
    }

    public Vector3 GetNextCirclePos()
    {
        return Utils.nextCirclePos(_circleCenter, transform.position);
    }
    

    private void FixedUpdate()
    {
        if (movementStrategy == null) return;
        if (movementStrategy.IsRun)
        {
            movementStrategy.Move();
        }
    }
    public float CalcRadius()
    {
        return Vector3.Distance(transform.position, _circleCenter);
    }
    private void SetDefault()
    {
        ChangeMovementStrategy(EMovementType.Circular, GenerateCirularMovement(_circleCenter, transform,true));
    }

    public void StartForceRun(bool dir)
    {
        if (dir && currRadius == GameManager.Instance.maxRadius) return;
        if (!dir && currRadius == GameManager.Instance.minRadius) return;
        if (m_MovementType == EMovementType.Line) return;
        ChangeMovementStrategy(EMovementType.Line, GenerateLineMovement(dir));

    }

    private void OnGUI()
    {
        GUIStyle guiStyle = new GUIStyle();
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(20, 30, 200, 20), "CurrentRadius:" + CalcRadius(), guiStyle);
    }*//*


}

*/