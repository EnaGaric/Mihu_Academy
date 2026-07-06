using System;

public class SceneResult
{
    public IScene? NextScene { get; set; }

    public bool EndGame { get; set; }

    public string? Message { get; set; }

    public SceneResult()
    {
        EndGame = false;
    }

    public static SceneResult Continue(IScene? next = null)
    {
        return new SceneResult
        {
            NextScene = next
        };
    }

    public static SceneResult End(string? message = null)
    {
        return new SceneResult
        {
            EndGame = true,
            Message = message
        };
    }
}