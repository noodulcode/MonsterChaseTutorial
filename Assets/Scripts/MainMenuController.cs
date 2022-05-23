using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void PlayGame() 
    {
        // int.Parse converts the string representation of a number to an integer, make sure the string only has numbers inside, no letters
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name); 

        // use classname to call a static variable - instance. meaning an object of this class is actually a variable of the class
        GameManager.instance.CharIndex = selectedCharacter;
        

        SceneManager.LoadScene("Gameplay"); // must add scenes to build settings as well
    }


} // class
