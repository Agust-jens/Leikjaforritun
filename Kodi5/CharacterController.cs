using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Magn krafts b�tt vi� �egar leikma�urinn hoppar.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Magn maxSpeed sem er nota� � kr�kahreyfingu. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // Hversu miki� � a� sl�tta �t hreyfinguna
	[SerializeField] private bool m_AirControl = false;                         // Hvort leikma�ur geti st�rt � me�an hann er � loftinu;
	[SerializeField] private LayerMask m_WhatIsGround;                          // Gr�ma sem �kvar�ar hva� er mala� fyrir pers�nuna
	[SerializeField] private Transform m_GroundCheck;                           // Sta�a sem merkir hvar � a� athuga hvort leikma�urinn s� jar�a�ur.
	[SerializeField] private Transform m_CeilingCheck;                          // Sta�setning sem merkir hvar � a� athuga me� loft
	[SerializeField] private Collider2D m_CrouchDisableCollider;                

	const float k_GroundedRadius = .2f; // Rad�us sk�runarhringsins til a� �kvar�a hvort hann s� jar�tengdur
	private bool m_Grounded;            // S�r hvort leikma�urinn er jar�a�ur e�a ekki.
	const float k_CeilingRadius = .2f; // Rad�us sk�runarhringsins til a� �kvar�a hvort leikma�urinn geti sta�i� upp
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

		// Spilarinn er jar�a�ur ef hringkast � markst��u lendir � einhverju sem er tilgreint sem j�r�
		// �etta er h�gt a� gera me� �v� a� nota l�g � sta�inn en Sample Assets mun ekki skrifa yfir verkstillingar ��nar.
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

		//a�eins stj�rna spilaranum ef hann er jar�tengdur e�a kveikt er � airControl
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

			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y); //F�r�u pers�nuna me� �v� a� finna markhra�ann

			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing); //Og svo sl�tta �a� svo �t og beita �v� � karakterinn
		}
		
		if (m_Grounded && jump) // Ef leikma�urinn �tti a� hoppa
		{
			m_Grounded = false; 
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce)); //b�tir l��r�ttum krafti vi� spilarann.
		}
	}
}