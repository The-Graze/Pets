using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pets.PetScripts
{
    public class PetBed : MonoBehaviour
    {
        public static volatile PetBed instance;
        List<Transform> Beds = new List<Transform>();
        public Transform sitPoint;
        PetInfo.PetType storedType;

        void Start()
        {
            instance = this;
            storedType = LocalPet.instance.Type;
            foreach(Transform t in transform.GetChild(0)) 
            {
                Beds.Add(t);
            }
            ChangeBed(LocalPet.instance.Type);
        }

        void Update()
        {
           if(storedType != LocalPet.instance.Type)
           {
                storedType = LocalPet.instance.Type;
           }
            CheckBedType();
        }

        void ChangeBed(Enum e)
        {
            foreach (Transform t in Beds)
            {
                t.gameObject.SetActive(false);
            }
            int i = Convert.ToInt32(e);
            Beds[i].gameObject.SetActive(true);
            sitPoint = Beds[i].Find("LayPoint");
        }

        void CheckBedType()
        {
            switch (storedType)
            {
                case PetInfo.PetType.None:
                    ChangeBed(PetInfo.PetType.None);
                    break;
                case PetInfo.PetType.Cat:
                    ChangeBed(PetInfo.PetType.Cat);
                    break;
                case PetInfo.PetType.Dog:
                    ChangeBed(PetInfo.PetType.Dog);
                    break;
                case PetInfo.PetType.Capibara:
                    ChangeBed(PetInfo.PetType.Capibara);
                    break;
                case PetInfo.PetType.Floppa:
                    ChangeBed(PetInfo.PetType.Floppa);
                    break;
                case PetInfo.PetType.Chao:
                    ChangeBed(PetInfo.PetType.Chao);
                    break;
                case PetInfo.PetType.Rock:
                    ChangeBed(PetInfo.PetType.Rock);
                    break;
                case PetInfo.PetType.Bug:
                    ChangeBed(PetInfo.PetType.Bug);
                    break;
                case PetInfo.PetType.Comodo_Dragon:
                    ChangeBed(PetInfo.PetType.Comodo_Dragon);
                    break;
                case PetInfo.PetType.Raccoon:
                    ChangeBed(PetInfo.PetType.Raccoon);
                    break;
                case PetInfo.PetType.Bird:
                    ChangeBed(PetInfo.PetType.Bird);
                    break;
                case PetInfo.PetType.Rat_w_Hat:
                    ChangeBed(PetInfo.PetType.Rat_w_Hat);
                    break;
                case PetInfo.PetType.Bat:
                    ChangeBed(PetInfo.PetType.Bat);
                    break;
            }
        }
    }
}