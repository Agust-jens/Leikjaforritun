using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Magn krafts bætt við þegar leikmaðurinn hoppar.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Magn maxSpeed sem er notað á krókahreyfingu. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // Hversu mikið á að slétta út hreyfinguna
	[SerializeField] private bool m_AirControl = false;                         // Hvort leikmaður geti stýrt á meðan hann er á loftinu;
	[SerializeField] private LayerMask m_WhatIsGround;                          // Gríma sem ákvarðar hvað er malað fyrir persónuna
	[SerializeField] private Transform m_GroundCheck;                           // Staða sem merkir hvar á að athuga hvort leikmaðurinn sé jarðaður.
	[SerializeField] private Transform m_CeilingCheck;                          // Staðsetning sem merkir hvar á að athuga með loft
	[SerializeField] private Collider2D m_CrouchDisableCollider;                

	const float k_GroundedRadius = .2f; // Radíus skörunarhringsins til að ákvarða hvort hann sé jarðtengdur
	private bool m_Grounded;            // Sér hvort leikmaðurinn er jarðaður eða ekki.
	const float k_CeilingRadius = .2f; // Radíus skörunarhringsins til að ákvarða hvort leikmaðurinn geti staðið upp
	private Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// Spilarinn er jarðaður ef hringkast í markstöðu lendir á einhverju sem er tilgreint sem jörð
		// Þetta er hægt að gera með því að nota lög í staðinn en Sample Assets mun ekki skrifa yfir verkstillingar þínar.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump)
	{
		
		if (!crouch)
		{
			
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//aðeins stjórna spilaranum ef hann er jarðtengdur eða kveikt er á airControl
		if (m_Grounded || m_AirControl)
		{

			
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				
				move *= m_CrouchSpeed;

				
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			}
			else
			{
				
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y); //Færðu persónuna með því að finna markhraðann

			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); //Og svo slétta það svo út og beita því á karakterinn
		}
		
		if (m_Grounded && jump) // Ef leikmaðurinn ætti að hoppa
		{
			m_Grounded = false; 
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); //bætir lóðréttum krafti við spilarann.
		}
	}
}