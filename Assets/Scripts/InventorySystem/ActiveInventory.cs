using UnityEngine;
using Zenject;

public class ActiveInventory : MonoBehaviour
{ 
    private InputCharacter input;
    public bool isActivate {  get; private set; }

    [Inject]
    private void Container(InputCharacter input)
    {
        this.input = input;
    } 
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        input.onActiveInventory += OnActivate;
    }
    private void OnDestroy()
    {
        input.onActiveInventory -= OnActivate;
    }
    private void OnActivate(bool isActive)
    {
        isActivate = isActive;
    }
    public void Activate()
    {
        gameObject.SetActive(isActivate); 
    }
}
