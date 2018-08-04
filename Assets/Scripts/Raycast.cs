using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace DigitalRubyShared {

public class Raycast : MonoBehaviour {
        public GameObject[] OtherObjects;

        private TapGestureRecognizer[] TapGestures;

        private void CreateGesture(ref int index, GameObject obj) {
            TapGestures[index] = new TapGestureRecognizer {
                PlatformSpecificView = obj
            };
            TapGestures[index].StateUpdated += TapGestureUpdated;
            FingersScript.Instance.AddGesture(TapGestures[index]);
            index++;
        }

        // Use this for initialization
        void Start() {
            TapGestures = new TapGestureRecognizer[OtherObjects.Length];
            int index = 0;
            foreach (GameObject obj in OtherObjects) {
                CreateGesture(ref index, obj);
            }
        }

        private void TapGestureUpdated(DigitalRubyShared.GestureRecognizer gesture) {
            if (gesture.State == GestureRecognizerState.Ended) {
                Debug.Log("Tapped on " + gesture.PlatformSpecificView);
            }
        }

                // Update is called once per frame
                void Update() {

        }
    }
}