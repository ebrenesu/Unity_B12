using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    private Rigidbody2D _rb2D;

    
    #region Variables Movimiento
    private float _movimientoHorizontal = 0f;
    //[SerializeField] permite a las variables ser visualizadas en el editor grafico. 
    [Header("Movimiento")]
    [SerializeField] private float velocidadMovimiento;
    [Range(0, 0.3f)] [SerializeField] private float suavizadoMovimiento;
    private Vector3 _velocidad = Vector3.zero;
    private bool _mirandoDerecha = true;
    #endregion

    [Header("Salto")]
    #region Variables Salto"
    [SerializeField] private float fuerzaDeSalto;
    [SerializeField] private LayerMask mascarSuelo;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Vector3 dimensionesCaja;
    [SerializeField] private bool enSuelo;
    private bool _salto = false;
    #endregion

    /// <summary>
    /// Obtiene la referencia al componente Rigidbody2D al iniciar el juego.
    /// </summary>
    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Actualiza el valor del movimiento horizontal según el input del jugador en cada frame.
    /// Esta funcion se ejecuta en ciclo, una vez por cuadro. 
    /// </summary>
    private void Update() {
        _movimientoHorizontal = Input.GetAxisRaw("Horizontal") * velocidadMovimiento;
        if (Input.GetButtonDown("Jump"))
            _salto = true;
    }

    /// <summary>
    /// Llama a la función Mover para mover al personaje en intervalos de tiempo fijos.
    /// Esta funcion se ejecuta en ciclo, se usa para manejar las fisicas. Y que los cambios
    /// no afecten el rendimiento segun la computadora. Siempre sea igual sin importar las 
    /// caracteristicas del PC que lo ejecuta. 
    /// </summary>
    private void FixedUpdate() {
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, mascarSuelo);
        Mover(_movimientoHorizontal * Time.fixedDeltaTime, _salto);
        _salto = false;
    }

    /// <summary>
    /// Mueve al personaje con suavizado.
    /// </summary>
    /// <param name="pMover">Cantidad de movimiento a aplicar.</param>
    /// <param name="pSaltar">Si el personaje se mueve saltando.</param>
    private void Mover(float pMover, bool pSaltar) {
        Vector3 VelObjeto = new Vector2(pMover, _rb2D.velocity.y);
        _rb2D.velocity = Vector3.SmoothDamp(_rb2D.velocity, VelObjeto, ref _velocidad, suavizadoMovimiento);

        if (pMover > 0 && !_mirandoDerecha)
            Girar();
        else if (pMover < 0 && _mirandoDerecha)
            Girar();

        if (enSuelo && pSaltar) {
            enSuelo = false;
            _rb2D.AddForce(new Vector2(0f, fuerzaDeSalto));
        }
    }

    /// <summary>
    /// Cambia la dirección visual del personaje invirtiendo la escala en el eje X.
    /// </summary>
    private void Girar() {
        _mirandoDerecha = !_mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    /// <summary>
    /// Dibuja un Gizmo en el Editor para representar visualmente un cubo con alambre 
    /// alrededor de una posición en el suelo.
    /// </summary>
    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }


}
