using BepInEx;
using BepInEx.Configuration;
using ExitGames.Client.Photon;
using Pets.PetScripts;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace Pets
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public ConfigEntry<PetInfo.PetType> PetType;
        GameObject petTemp;
        GameObject bedTemp;
        private LocalPet pet;
        Dictionary<PetInfo.PetType, PetInfo.PetState> PetDitc = new Dictionary<PetInfo.PetType, PetInfo.PetState>();
        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
            PetType = Config.Bind("Settings", "PetType", PetInfo.PetType.None, "Your Pet Type");
        }
        void OnGameInitialized(object sender, EventArgs e)
        {
            Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("Pets.Assets.petstuff");
            AssetBundle bundle = AssetBundle.LoadFromStream(str);
            bedTemp = bundle.LoadAsset<GameObject>("Bed");
            petTemp = bundle.LoadAsset<GameObject>("Pet");
            str.Close();
            if (PetType.Value == PetInfo.PetType.None)
            {
                Debug.Log("Pick A Pet!");
                FirstSetUp();
            }
            else
            {
                CreatePet();
                SetBed();
            }
            Hashtable tabl = PhotonNetwork.LocalPlayer.CustomProperties;
            PetDitc.Add(LocalPet.instance.Type, LocalPet.instance.State);
            tabl.Add("PetInfo", PetDitc);
            PhotonNetwork.LocalPlayer.SetCustomProperties(tabl);
        }

        void FirstSetUp()
        {

        }

        void Update()
        {

        }

        void SetBed()
        {
            PetBed.instance = Instantiate(bedTemp).AddComponent<PetBed>();
            PetBed.instance.gameObject.name = "Pet Bed";
        }

        void ChangePet(PetInfo.PetType type)
        {
            pet.SetSkin(type);
        }

        void CreatePet()
        {
            pet = Instantiate(petTemp).AddComponent<LocalPet>();
            pet.Type = PetType.Value;
            pet.gameObject.name = PhotonNetwork.LocalPlayer.NickName + "'s Pet";
        }

        void PickAPet(PetInfo.PetType ttype)
        {
            PetType.Value = ttype;
        }
    }
}
