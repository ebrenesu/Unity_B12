using UnityEngine;

public class InputHandler {
    private IComando _Comando;
    public IComando HandleInput(){
        _Comando = null;

        if (SeleccionarPersonaje()) {
            if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Jump") )
                _Comando = new C_Salto();

            if (Input.GetAxis("Horizontal") != 0) 
                _Comando = new C_Movimiento();
            
            if (Input.GetButtonDown("Fire1") )
                if (ComandosRegistrados._PersonajeSeleccionado != null)
                    _Comando = new C_Disparo();                
        }

        return _Comando;
    }
    private bool SeleccionarPersonaje(){
        bool bSelect = false;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 100);

        if (hit.collider != null){
            if (hit.transform.gameObject.tag == "Player") { 
                ComandosRegistrados._PersonajeSeleccionado = hit.transform.gameObject;
                    bSelect = true;
            }
        }

        if (ComandosRegistrados._PersonajeSeleccionado != null)
            bSelect = true;

        return bSelect;
    }
}
