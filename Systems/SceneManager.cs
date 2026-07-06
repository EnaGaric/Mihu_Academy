using System;

public class SceneManager
{
    public void RunScene(IScene startScene)
    {
        IScene? current = startScene;

        while (current != null)
        {
            SceneResult result = current.Run();

            if (!string.IsNullOrWhiteSpace(result.Message))
            {
                Console.WriteLine(result.Message);
            }

            if (result.EndGame)
                return;

            current = result.NextScene;
        }
    }
}