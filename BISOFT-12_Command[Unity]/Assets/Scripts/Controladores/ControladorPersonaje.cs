using UnityEngine;
public class ControladorPersonaje : MonoBehaviour
{
    private InputHandler _inputH;

    void Start()
    {
        _inputH = new InputHandler();
    }

    void Update()
    {
        //_inputH.UpdateInput();

        if (_inputH.HandleInput() != null)
        {
            IComando _cmd = _inputH.HandleInput();
            _cmd.Ejecutar(ComandosRegistrados._PersonajeSeleccionado);
        }
    }
}