using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetButton : MonoBehaviour, ISetButton
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private TextMeshPro _text;

    private ISetButtonState state;

    private void Start()
    {
        State = new OffSetButtonSetState(this);
    }

    public event Action ButtonPressedEvent;
    public bool CanInterract => state.CanInterract;
    public Renderer Renderer { get => _renderer; }
    public TextMeshPro Inscription { get => _text; }
    public ISetButtonState State { get => state; set => state = value; }

    public void Interract()
    {
        if(CanInterract)
            ButtonPressedEvent?.Invoke();
    }
}
