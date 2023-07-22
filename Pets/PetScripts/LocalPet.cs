using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pets.PetScripts
{
    public class LocalPet : MonoBehaviour
    {
        public PetInfo.PetType Type;
        public PetInfo.PetState State;
        public static volatile LocalPet instance;
        bool skined;
        Transform Shoulder;
        TransformFollow tffolow;
        void Awake()
        {
            instance = this;
            State = PetInfo.PetState.Caged;
            skined = false;
        }
        void Start()
        {
            SetSkin(Type);
            Shoulder = null;
            tffolow = gameObject.AddComponent<TransformFollow>();
            tffolow.transformToFollow = Shoulder;
        }

        public void SetSkin(PetInfo.PetType ttype)
        { 
            Type = ttype;
            skined = true;
        }

        void Update()
        {
            if(skined) StateUpdate();
            if (State == PetInfo.PetState.Following)
            {
                tffolow.enabled = true;
            }
            else tffolow.enabled =false;
        }
        void StateUpdate()
        {
            switch (State)
            {
                case PetInfo.PetState.Sleeping:
                    LayDown();
                    break;
                case PetInfo.PetState.Caged:
                    Cage();
                    break;
                case PetInfo.PetState.Following:
                    Follow();
                    break;
                case PetInfo.PetState.Held:
                    Hold();
                    break;
            }
        }

        void Hold()
        {

        }

        void Cage()
        {
            transform.position = PetBed.instance.sitPoint.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        void LayDown()
        {
            transform.position = PetBed.instance.sitPoint.position;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        void Follow()
        {
            if (Type == PetInfo.PetType.Comodo_Dragon)
            {

            }
        }
    }
}
