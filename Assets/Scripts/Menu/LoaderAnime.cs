using UnityEngine;

public class LoaderAnime : MonoBehaviour {



		[Tooltip("Angular Speed in degrees per seconds")]
		public float speed = 180f;

		[Tooltip("Radius os the loader")]
		public float radius = 1f;

		public GameObject particles;



		Vector3 _offset;

		Transform _transform;

		Transform _particleTransform;

		bool _isAnimating;


		

		
	
		void Awake()
		{
			
			_particleTransform =particles.GetComponent<Transform>();
			_transform = GetComponent<Transform>();
		}

		

		void Update () {

			if (_isAnimating)
			{

				_transform.Rotate(0f,0f,speed*Time.deltaTime);
				

				_particleTransform.localPosition = Vector3.MoveTowards(_particleTransform.localPosition, _offset, 0.5f*Time.deltaTime);
			}
		}


	


		public void StartLoaderAnimation()
		{
			_isAnimating = true;
			_offset = new Vector3(radius,0f,0f);
			particles.SetActive(true);
		}

	
		public void StopLoaderAnimation()
		{
			particles.SetActive(false);
		}
}