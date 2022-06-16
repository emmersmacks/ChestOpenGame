using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller <T, U>
{
    protected T _view;
    protected U _model;

    public Controller(T view, U model)
    {
        _view = view;
        _model = model;
        Init();
    }

    protected virtual void Init()
    {
        
    }
}
