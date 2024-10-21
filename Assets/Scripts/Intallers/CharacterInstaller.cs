
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "Installer(Character)", menuName = "Installers/Character")]
public class CharacterInstaller : ScriptableObjectInstaller
{ 
    public override void InstallBindings()
    {
        BindCharacter();
        BindCamera(); 
    }

    private void BindCamera()
    {
        Container.BindInterfacesAndSelfTo<CameraController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputCamera>().AsSingle().NonLazy();
         
        Container.Bind<CameraCharacter>().FromComponentInHierarchy(this).AsSingle();
    }

    private void BindCharacter()
    {
        Container.BindInterfacesAndSelfTo<InputCharacter>().AsSingle().NonLazy(); 
        Container.BindInterfacesAndSelfTo<MoveController>().AsSingle().NonLazy();

        //MonoBehaviour  
        Container.Bind<CharacterMove>().FromComponentInHierarchy(this).AsSingle();
        Container.Bind<CharacterAnimator>().FromComponentInHierarchy(this).AsSingle();
        Container.Bind<CharacterParkour>().FromComponentInHierarchy(this).AsSingle();   
        Container.Bind<CharacterComponent>().FromComponentInHierarchy(this).AsSingle();   
    }
}
