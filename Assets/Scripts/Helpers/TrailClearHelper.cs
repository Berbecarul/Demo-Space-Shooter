using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper{
	 
public class TrailClearHelper : MonoBehaviour
	{

		public TrailRenderer trail;

		void OnDisable(){
			trail?.Clear ();

		} 
	}

}