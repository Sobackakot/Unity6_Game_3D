 
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{  
    public float startTime = 0;
    public float targetTime = 0;
    
    private Transform transformCharacter;
    private Rigidbody rigidbodyCharacter;
    private Collider colliderCharacter;
    private Animator animatorCharacter;

    private StateAnimatorCharacter stateMachine;
    private CharacterParkour parkour;
    private CharacterMove move;

    public Vector3 offset;
     
    private void Awake()
    {
        transformCharacter = GetComponent<Transform>();
        rigidbodyCharacter = GetComponent<Rigidbody>();
        colliderCharacter = GetComponent<Collider>();
        animatorCharacter = GetComponent<Animator>();
        move = GetComponent<CharacterMove>();
        parkour = transformCharacter.GetComponentInChildren<CharacterParkour>();
       stateMachine = animatorCharacter.GetBehaviour<StateAnimatorCharacter>();
         
    } 
    public bool UpdateStateComponetn()
    {
         rigidbodyCharacter.isKinematic = stateMachine.isKinematic;
        
        if (stateMachine.isKinematic)
        {
            colliderCharacter.enabled = false; 
        } 
        else
        {   
            colliderCharacter.enabled = true; 
        } 
        return stateMachine.isMoving;
    } 
    public void SetAnimatorMatchTarget()
    {
        ParkourTarget(); 
    }

    private void ParkourTarget()
    {
        offset.y = parkour.localScale.y / 2;
        Vector3 newOffset = transformCharacter.position - parkour.ledgePosition;
        offset.z = newOffset.z; 
        if (stateMachine.isParkour)
        {
            MatchTargetWeightMask WeightMask = new MatchTargetWeightMask(Vector3.one, 0);
            animatorCharacter.MatchTarget(parkour.ledgePosition + offset, Quaternion.identity, AvatarTarget.LeftHand, WeightMask, startTime, targetTime);
        }
    } 
}
