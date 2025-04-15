using UnityEngine;
using UnityEngine.UI;

public class EyeElement : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private bool _isActive;
    private Color _color = Color.cyan;
    
    public bool inspectorToggle = false;
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (inspectorToggle)
        {
            inspectorToggle = false;
            Toggle();
        }
    }

    private void updateMaterial()
    {
        _meshRenderer.material.SetInt("_IsOn", _isActive ? 1 : 0);
        _meshRenderer.material.SetColor("_Color", _color);
    }

    public void SetColor(Color color)
    {
        this._color = color;
        updateMaterial();
    }

    public Color GetColor()
    {
        return _color;
    }
    
    public void Toggle()
    {
        _isActive = !_isActive;
        updateMaterial();
    }

    public void SetActive(bool active)
    {
        _isActive = active;
        updateMaterial();
    }

    public bool IsActive()
    {
        return _isActive;
    }
}
