// Copyright 2014-2017 Elringus (Artyom Sovetnikov). All Rights Reserved.

namespace BlendModes
{
    using UnityEngine;
    
    public class DemoObject : MonoBehaviour
    {
        public BlendMode SelectedBlendMode
        {
            get
            {
                if (blendModeEffect)
                    return blendModeEffect.BlendMode;
                else return cameraOverlay.BlendMode;
            }
            set
            {
                if (blendModeEffect)
                    blendModeEffect.BlendMode = value;
                else cameraOverlay.BlendMode = value;
            }
        }
    
        private BlendModeEffect blendModeEffect;
        private CameraOverlay cameraOverlay;
    
        private void Awake ()
        {
            blendModeEffect = GetComponent<BlendModeEffect>();
            cameraOverlay = GetComponent<CameraOverlay>();
        }
    
        private void Update ()
        {
            if (DemoBlendModePicker.SelectedBlendMode != SelectedBlendMode)
                SelectedBlendMode = DemoBlendModePicker.SelectedBlendMode;
        }
    }
    
}
