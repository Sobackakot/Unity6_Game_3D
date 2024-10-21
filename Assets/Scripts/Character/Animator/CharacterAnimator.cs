
using System; 
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{ 
    private Animator animatorCharacter;  

    [SerializeField] private float speedWalkAnimation = 0.5f;
    [SerializeField] private float speedRunAnimation = 1f;
    private float speedAnimation;
     
    private void Awake()
    {     
        animatorCharacter = GetComponent<Animator>();  
    } 
    public void MovAnimation(Vector3 inputAxis)
    {
        if (inputAxis.sqrMagnitude > 0.2f)
        {
            animatorCharacter.SetFloat("X", inputAxis.x * speedAnimation, 0.1f, Time.deltaTime);
            animatorCharacter.SetFloat("Y", inputAxis.z * speedAnimation, 0.1f, Time.deltaTime); 
        }
        else
        {   
            animatorCharacter.SetFloat("Y", 0, 0.1f, Time.deltaTime);
            animatorCharacter.SetFloat("X", 0, 0.1f, Time.deltaTime);  
        } 
    }
 
    public void SwithAnimation(bool isRanning)
    {
        speedAnimation = isRanning ? speedRunAnimation: speedWalkAnimation;
    }
    public void JumpAnimation(bool isJumping)
    {
        if (isJumping)
            animatorCharacter.SetBool("isJumping", true);
        else
            animatorCharacter.SetBool("isJumping", false);
    } 
    public void ParkourUp(bool isParkour)
    {
        if (isParkour)
            animatorCharacter.SetBool("isParkourUp", true); 
    }  
}
