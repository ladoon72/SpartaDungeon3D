using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIneractable
{
    public string GetIneractPrompt();
    public void OnIteract();
}

public class ItemObject : MonoBehaviour, IIneractable
{
    public ItemData data;

    public string GetIneractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnIteract()
    {
        CharacterManager.Instance.Player.itemData = data;
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
