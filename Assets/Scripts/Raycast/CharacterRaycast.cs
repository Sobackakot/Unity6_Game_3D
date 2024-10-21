 
using UnityEngine; 

public class CharacterRaycast : MonoBehaviour
{ 
    private Transform transformRaycast;
    private CharacterMove character;
    private Transform rayPoint;

    [SerializeField] private LayerMask targetLayerMask;

    private float raycastLength = 15;
    private void Awake()
    {
        transformRaycast = GetComponent<Transform>();
        character = GetComponentInParent<CharacterMove>();
        rayPoint = transformRaycast.GetChild(0).GetComponent<Transform>(); 
    }
    public void UpdateCharacterPosition(bool isRaycasting)
    { 
        if(isRaycasting)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastLength, targetLayerMask))
            {
                character.transform.position = hit.point;
                rayPoint.position = hit.point; 
            }
        } 
    } 
}
