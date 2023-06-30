using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface I_3D_Button : IInteractable
{
    public Renderer Renderer { get; }
    TextMeshPro Inscription { get; }
}
