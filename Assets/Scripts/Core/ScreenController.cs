using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour
{
    [SerializeField] private Stack<Screen> _screensStack = new Stack<Screen>();
    [SerializeField] private List<Screen> _screensList;
    [SerializeField] private Screen InitScreen;

    public List<Screen> ScreensList => _screensList;


    private void Awake()
    {
        InitScreenController();

        DestroyExtraScreenController();
    }

    private void InitScreenController()
    {
        foreach (var screens in _screensList)
        {
            screens.gameObject.SetActive(false);
        }

        PushScreen(InitScreen);

        DontDestroyOnLoad(this);
    }

    private void DestroyExtraScreenController()
    {
        ScreenController[] allScreenControllers = FindObjectsOfType<ScreenController>();
        if (allScreenControllers.Length > 1)
        {
            Destroy(allScreenControllers[1].gameObject);
            GameController.Instance.ScreenController.PushScreen<MainMenuScreen>();
        }
    }

    private Screen PushScreen(Screen screen)
    {
        if (_screensStack.Count > 0)
        {
            Screen topScreen = _screensStack.Peek();
            topScreen.gameObject.SetActive(false);
            topScreen.OnPop();
        }
        _screensStack.Push(screen);
        screen.gameObject.SetActive(true);
        screen.OnPush();
        return screen;
    }

    public T PushScreen <T> () where T: Screen
    {
        Screen currentScreen = GetScreen(typeof(T));
        return (T)PushScreen(currentScreen);
        
    }

    public void PopScreen()
    {
        Screen topScreen = _screensStack.Pop();
        topScreen.gameObject.SetActive(false);
        topScreen.OnPop();
    }

    public void DisableScreen(Screen screen)
    {
        foreach(var screens in _screensList)
        {
            if (screens.Equals(screen))
            {
                screens.gameObject.SetActive(false);
            }
            else
            {
                throw new Exception("Screen not disable!");
            }
        }        
    }

    public void DisableScreen<T>() where T : Screen
    {
        Screen disabledScreen = GetScreen(typeof(T));
        DisableScreen(disabledScreen);
    }

    public void EnableScreen(Screen screen)
    {
        foreach (var screens in _screensList)
        {
            if (screens.Equals(screen))
            {
                screens.gameObject.SetActive(true);
            }
            else
            {
                throw new Exception("Screen not enable!");
            }
        }
    }

    public void EnableScreen<T>() where T : Screen
    {
        Screen enabledScreen = GetScreen(typeof(T));
        EnableScreen(enabledScreen);
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
        throw new Exception("Screen not found!");
    }
}
