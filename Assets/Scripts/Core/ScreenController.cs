using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private Stack<Screen> _screensStack = new Stack<Screen>();
    [SerializeField] private List<Screen> _screensList;
    [SerializeField] private Screen InitScreen;


    private void Awake()
    {
       foreach(var screen in _screensList)
        {
            screen.gameObject.SetActive(false);            
        }
        PushScreen(InitScreen);
        DontDestroyOnLoad(this);
    }

    private void PushScreen(Screen screen)
    {
        if (_screensStack.Count > 0)
        {
            var topScreen = _screensStack.Peek();
            topScreen.gameObject.SetActive(false);
            topScreen.OnPop();
        }
        _screensStack.Push(screen);
        screen.gameObject.SetActive(true);
        screen.OnPush();
    }

    public void PushScreen <T> () where T: Screen
    {
        var currentScreen = GetScreen(typeof(T));
        PushScreen(currentScreen);
    }

    public void PopScreen()
    {
        var topScreen= _screensStack.Pop();
        topScreen.gameObject.SetActive(false);
        topScreen.OnPop();
    }

    public Screen GetScreen(Type dataType)
    {
        foreach(var screen in _screensList)
        {
            if(screen.GetType()== dataType)
            {
                return screen;
            }
        }
        throw new Exception("Screen not found");
    }
}
