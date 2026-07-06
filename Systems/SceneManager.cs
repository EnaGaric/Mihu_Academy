using System;

public class SceneManager
{
    public void RunScene(IScene startScene)
    {
        IScene? current = startScene;

        while (current != null)
        {
            SceneResult result = current.Run();

            if (result.EndGame)
                break;

            current = result.NextScene;
        }
    }
}