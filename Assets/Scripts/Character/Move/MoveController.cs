
using System; 
using Zenject;

public class MoveController : IInitializable, IDisposable, ITickable, IFixedTickable, ILateTickable
{
    public MoveController(InputCharacter inputCharacter, CharacterMove character, 
        CharacterAnimator characterAnimator, CharacterParkour characterParkour, CharacterComponent components, ActiveInventory inventory)
    {
        this.inputCharacter = inputCharacter;
        this.character = character;
        this.characterAnimator = characterAnimator;
        this.characterParkour = characterParkour;
        this.components = components;
        this.inventory =  inventory;
    }

    private InputCharacter inputCharacter;
    private CharacterMove character;
    private CharacterAnimator characterAnimator;
    private CharacterParkour characterParkour;
    private CharacterComponent components;
    private ActiveInventory inventory;

    private bool isMoving;
    private bool isStateParcure;
    public void Initialize()
    { 
        inputCharacter.onInputGetAxis += character.GetAxisMove;
        inputCharacter.onGetKeyDownJump += character.GetKeyDownJump;
        inputCharacter.onGetKeyRun += character.GetKeyRun;
    }

    public void Dispose()
    { 
        inputCharacter.onInputGetAxis -= character.GetAxisMove;
        inputCharacter.onGetKeyDownJump -= character.GetKeyDownJump;
        inputCharacter.onGetKeyRun -= character.GetKeyRun;
    }

    public void Tick()
    {   
        components.SetAnimatorMatchTarget();
        isMoving = components.UpdateStateComponetn();
        isStateParcure = characterParkour.isParcourUp;

        if (character.isCollision && !isStateParcure)
            characterAnimator.JumpAnimation(character.isJumping);
        characterAnimator.MovAnimation(character.inputAxis);
        characterAnimator.SwithAnimation(character.isRunning);
        if (character.isJumping)
        { 
            characterAnimator.ParkourUp(isStateParcure);
        }
        inventory.Activate();
    }

    public void FixedTick()
    { 
        if (isMoving)
        {
            character.Jumping();
            character.Moving();
        }
            
    }

    public void LateTick()
    {
        if (isMoving)
        { 
            character.UpdateDirectionMove();
            character.SwitchMove();
        } 
    }
}
