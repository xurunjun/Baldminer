using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("线段渲染器")]
    public LineRenderer lineRenderer;
    [Header("起始位置")]
    public Vector2 startPosition;
    [Header("最大高度")]
    public float maxY;
    [Header("目标位置")]
    public Vector2 targetPosition;
    [Header("目标位置Z坐标")]
    public float targetPositionZ;
    [Header("基础速度因子")]
    public float baseSpeed;
    [Header("发射中")]
    public bool isFire;
    [Header("回收中")]
    public bool isBack;

    public bool isFiring{
        get{
            return isFire;
        }
    }
    public bool isBacking{
        get{
            return isBack;
        }
    }

    private InputManager inputManager;

    private void Awake() {
        inputManager = InputManager.Instance;
    }
    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position;
    }
    private void OnEnable() {
        inputManager.onEndTouch+=Fire;
    }

    private void OnDisable() {
        inputManager.onEndTouch -=Fire;
    }

    // Update is called once per frame
    void Update()
    {
        moveToPosition();
    }

    public void setTargetPosition(Vector2 value)
    {
        Vector2 vec=Camera.main.ScreenToWorldPoint(value);
        if(vec.y>maxY)
        {
            vec.y=maxY;
        }
        targetPosition=vec;
    }

    public void moveToPosition()
    {
        if(isFiring)
        {
            Vector2 currentPostion = lineRenderer.GetPosition(1);
            lineRenderer.SetPosition(1,Vector2.Lerp(currentPostion,targetPosition,baseSpeed));
            if(Vector2.Distance(targetPosition,currentPostion)<0.2f)
            {
                lineRenderer.SetPosition(1,targetPosition);
                targetPosition=startPosition;
                isFire=false;
                isBack=true;
            }
        }
        if(isBacking)
        {
            Vector2 currentPostion = lineRenderer.GetPosition(1);
            lineRenderer.SetPosition(1,Vector2.Lerp(currentPostion,targetPosition,baseSpeed));
            if(Vector2.Distance(targetPosition,currentPostion)<0.2f)
            {
                lineRenderer.SetPosition(1,targetPosition);
                isBack=false;
            }
        }
    }

    public void Fire(Vector2 screenPosition,float time)
    {
        if(!isBacking&&!isFiring)
        {
            setTargetPosition(screenPosition);
            isFire=true;
        }
    }
}
