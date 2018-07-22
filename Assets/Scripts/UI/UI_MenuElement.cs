using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{

    public class UI_MenuElement : MonoBehaviour
    {

        UI_MenuRoot menuRoot;

        protected virtual void OnEnable()
        {
            if (menuRoot == null)
                menuRoot = GetComponentInParent<UI_MenuRoot>();

            if (menuRoot != null)
                menuRoot.EnlistMenu(this);
        }

        protected virtual void OnDisable()
        {
            if (menuRoot == null)
                menuRoot = GetComponentInParent<UI_MenuRoot>();

            if (menuRoot != null)
                menuRoot.RemoveMenu(this);

        }


        public virtual void CloseMenu()
        {
            this.gameObject.SetActive(false);
        }

    }

}