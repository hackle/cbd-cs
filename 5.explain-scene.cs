public enum Place { Home, Office }
public enum Action { Greeting, Disagreement }
 
public struct Scene
{
    public Place Place;
    public string Person1;
    public string Person2;
    public Action Action;
};

public static class SceneExplainer
{
    /*
        There are many ways to express and implement this efficiently.
        Give it a go!
    */
    public static string Explain(Scene scene) 
    {
        if (scene.Action == Action.Disagreement) {
            string disagreement = null;

            switch (scene.Place) {
                case Place.Home: 
                    disagreement = $"{scene.Person1} shouts to {scene.Person2}: I hate you!";
                    break;
                case Place.Office:
                    disagreement = $"{scene.Person1} addresses {scene.Person2}: I beg to differ";
                    break;
            }     
            
            return disagreement;
        } 
        
        if (scene.Action == Action.Greeting) {
            string greeting = null;

            switch (scene.Place) {
                case Place.Home:
                    greeting = $"{scene.Person1} gives {scene.Person2} a bear hug";
                    break;
                case Place.Office:
                    greeting = $"{scene.Person1} shares a firm hand-shake with {scene.Person2}";
                    break;
            }

            return greeting;
        }

        return null;
    }
} 
