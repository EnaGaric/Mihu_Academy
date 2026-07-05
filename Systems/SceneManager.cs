using System;

public class SceneManager
{
    private IScene currentScene;

    public void SetScene(IScene scene)
    {
        currentScene = scene;
    }

    public int Run()
    {
        return currentScene.Run();
    }
}