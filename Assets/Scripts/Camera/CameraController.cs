
using System;
using UnityEngine;
using Zenject;

public class CameraController: ILateTickable, IInitializable, IDisposable
{   
    public CameraController(InputCamera input, CameraCharacter camera)
    {
        this.input = input;
        this.camera = camera;   
    }
    private InputCamera input;
    private CameraCharacter camera;

  
    public void Initialize()
    {
        input.onInputAxis += camera.GetInputAxisMouse;
        input.onScrollZoom += camera.GetInputScrollMouse; 
    }
    public void Dispose()
    {
        input.onInputAxis -= camera.GetInputAxisMouse;
        input.onScrollZoom -= camera.GetInputScrollMouse;
    }

    public void LateTick()
    {
        camera.RotateCamera();
        camera.ZoomCamera();
    }
   

}
