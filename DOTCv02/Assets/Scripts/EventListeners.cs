using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListeners : MonoBehaviour
{
    public static EventListeners Instance;
    public List<GameObject> listeners = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void AddListener(GameObject listener)
    {
        if (!listeners.Contains(listener))
            listeners.Add(listener);
    }
}
