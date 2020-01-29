using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectButton : MonoBehaviour
{

    public Button button;                   //gets a button
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void selectthisbutton()
    {
        button.Select();                //selects that button so user can interact with it
    }
}
