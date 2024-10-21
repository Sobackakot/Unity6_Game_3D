
using UnityEngine;
using Zenject;

public class CameraCharacter : MonoBehaviour
{
    [SerializeField] private Transform transformCharacter;
    [HideInInspector]public Transform transformCamera;

    [SerializeField] private float sensitivityMouse = 45f;
    [SerializeField] private float scrollSpeed = 3f;

    private Vector3 offset;
    private float mouseAxisX;
    private float mouseAxisY;
    private float mouseZoom;

    private float minAngle = -65f;
    private float maxAngle = 65f;
    private float minZoom = 2f;
    private float maxZoom = 15f;
      

    private void Awake()
    {
        transformCamera = GetComponent<Transform>();
    }
    private void Start()
    {
        offset = transformCamera.position - transformCharacter.position;
    }
    public void RotateCamera()
    {
        mouseAxisY = Mathf.Clamp(mouseAxisY, minAngle, maxAngle);
        transformCamera.localEulerAngles = new Vector3(mouseAxisY, mouseAxisX, 0);
        transformCamera.position = transformCamera.localRotation * offset + transformCharacter.position; 
    }
    public void ZoomCamera()
    {
        mouseZoom = Mathf.Clamp(mouseZoom, Mathf.Abs(minZoom), Mathf.Abs(maxZoom));
        transformCamera.position = transformCharacter.position - transformCamera.forward * mouseZoom; 
    }

    public void GetInputAxisMouse(Vector2 inputAxis)
    {
        mouseAxisX += inputAxis.x * sensitivityMouse * Time.deltaTime;
        mouseAxisY -= inputAxis.y * sensitivityMouse * Time.deltaTime;
    }
    public void GetInputScrollMouse(Vector2 scrollMouse)
    {
        mouseZoom -= scrollMouse.y * scrollSpeed * Time.deltaTime;
    }
    
}
