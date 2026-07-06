using System;

public class SceneResult
{
    public IScene? NextScene { get; set; }  // <- BITNO ?

    public bool EndGame { get; set; } = false;

    public string? Message { get; set; }
}