
using System;
using UnityEngine;
using Fusion;

namespace Labo7 {
    
    public class StartMenu : MonoBehaviour
    {
        public GameObject LoadingText;
        public GameObject VRButton;
        public GameObject DesktopButton;
        public GameManager Manager;

        private void OnEnable()
        {
            LoadingText.SetActive(false);
        }
        
        public void OnDesktopButtonClicked()
        {
            Manager.StartDesktop();
            DisableButtons();
        }

        public void OnDesktopVRClicked()
        {
            Manager.StartVR();
            DisableButtons();
        }

        void DisableButtons()
        {
            LoadingText.SetActive(true);
            VRButton.SetActive(false);
            DesktopButton.SetActive(false);
        }
    }

}