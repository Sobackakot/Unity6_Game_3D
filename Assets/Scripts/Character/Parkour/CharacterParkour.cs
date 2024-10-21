 
using UnityEngine;

public class CharacterParkour : MonoBehaviour
{   
    public bool isParcourUp {  get; private set; }
    public Vector3 ledgePosition {  get; private set; }
    public Vector3 localScale { get; private set; }
    public GameObject ladgeObject { get; private set; }

    private byte maxHeightLedge = 3;

    [SerializeField] public string tagTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tagTrigger)
        { 
            ledgePosition = other.transform.position;
            localScale = other.transform.localScale;
            ladgeObject = other.gameObject;
            if (localScale.y <= maxHeightLedge)
                isParcourUp = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == tagTrigger)
        {
            isParcourUp = false; 
        }
    }
}
