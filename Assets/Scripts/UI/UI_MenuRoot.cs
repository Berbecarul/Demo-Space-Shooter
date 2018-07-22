using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{

    public class UI_MenuRoot : MonoBehaviour
    {
        public UnityEvent onNoMenuCancel;

        List<UI_MenuElement> openedMenus;
         
		private void Awake (){
			openedMenus = new List<UI_MenuElement> ();

		}

        private void Update()
        {
			if (Input.GetButtonDown ("Cancel"))
			{
				if (openedMenus.Count > 0)
					CloseLastOpenedMenu ();
				else
					onNoMenuCancel.Invoke ();

			}
        }

        public void EnlistMenu(UI_MenuElement menuElement)
        {
            openedMenus.Add(menuElement);
        }

        public void RemoveMenu(UI_MenuElement menuElement)
        {
            openedMenus.Remove(menuElement);
        }


        void CloseLastOpenedMenu()
        {
            openedMenus[openedMenus.Count - 1].CloseMenu();
        }


    }

}