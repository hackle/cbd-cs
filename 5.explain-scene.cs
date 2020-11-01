using System;
using System.Linq;

public enum Place { Home, Office }
public enum Action { Greeting, Disagreement }
 
public struct Scene
{
    public Place Place;
    public string Person1;
    public string Person2;
    public Action Action;
};

public struct Descriptor
{
    public Action Action;
    public Place Place;

    public Func<Scene, string> Describe;
}

public static class SceneExplainer
{
    static Descriptor[] descriptors = new Descriptor[]
    {
        new Descriptor 
        {
            Action = Action.Disagreement,
            Place = Place.Office,
            Describe = scene => $"{scene.Person1} addresses {scene.Person2}: I beg to differ"
        },
        new Descriptor 
        {
            Action = Action.Disagreement,
            Place = Place.Home,
            Describe = scene => $"{scene.Person1} shouts to {scene.Person2}: I hate you!"
        },
        new Descriptor 
        {
            Action = Action.Greeting,
            Place = Place.Office,
            Describe = scene => $"{scene.Person1} shares a firm hand-shake with {scene.Person2}"
        },
        new Descriptor 
        {
            Action = Action.Greeting,
            Place = Place.Home,
            Describe = scene => $"{scene.Person1} gives {scene.Person2} a bear hug"
        },
    };

    public static string Explain(Scene scene)
    {
        return descriptors
            .First(d => d.Action == scene.Action && d.Place == scene.Place)
            .Describe(scene);
    }

    /*
     it's more readable but less writeable, 
     but try this out below, and challenge is to support both ways of indexing!
     
     return descriptors[scene.Action][scene.Place](scene);
     // or,
     return descriptors[scene.Place][scene.Action](scene);
    */
} 
