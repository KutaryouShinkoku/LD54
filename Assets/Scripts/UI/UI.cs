using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton<UI>
{
    private Dictionary<Type, UINode> uiNodes = new Dictionary<Type, UINode>();
    public void RegistNode(UINode node)
    {
        Type type = node.GetType();
        if (uiNodes.ContainsKey(type))
        {
            Debug.LogError("UI Node " + type + " has been registed!");
            return;
        }
        uiNodes.Add(type, node);
    }
    public T Get<T>() where T : UINode
    {
        Type type = typeof(T);
        if (uiNodes.ContainsKey(type))
        {
            return uiNodes[type] as T; ;
        }
        Debug.LogError("UI Node " + type + " has not been registed!");
        return null;
    }
}
