using System;

public class SceneManager
{
    public int RunScene(IScene scene)
    {
        return scene.Run();
    }
}