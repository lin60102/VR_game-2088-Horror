//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Valve.VR
{
    using System;
    using UnityEngine;
    
    
    public partial class SteamVR_Actions
    {
        
        private static SteamVR_Input_ActionSet_default p__default;
        
        private static SteamVR_Input_ActionSet_platformer p_platformer;
        
        private static SteamVR_Input_ActionSet_buggy p_buggy;
        
        private static SteamVR_Input_ActionSet_mixedreality p_mixedreality;
        
        private static SteamVR_Input_ActionSet_htc_viu p_htc_viu;
        
        private static SteamVR_Input_ActionSet_Gun p_Gun;
        
        private static SteamVR_Input_ActionSet_NewSet p_NewSet;
        
        public static SteamVR_Input_ActionSet_default _default
        {
            get
            {
                return SteamVR_Actions.p__default.GetCopy<SteamVR_Input_ActionSet_default>();
            }
        }
        
        public static SteamVR_Input_ActionSet_platformer platformer
        {
            get
            {
                return SteamVR_Actions.p_platformer.GetCopy<SteamVR_Input_ActionSet_platformer>();
            }
        }
        
        public static SteamVR_Input_ActionSet_buggy buggy
        {
            get
            {
                return SteamVR_Actions.p_buggy.GetCopy<SteamVR_Input_ActionSet_buggy>();
            }
        }
        
        public static SteamVR_Input_ActionSet_mixedreality mixedreality
        {
            get
            {
                return SteamVR_Actions.p_mixedreality.GetCopy<SteamVR_Input_ActionSet_mixedreality>();
            }
        }
        
        public static SteamVR_Input_ActionSet_htc_viu htc_viu
        {
            get
            {
                return SteamVR_Actions.p_htc_viu.GetCopy<SteamVR_Input_ActionSet_htc_viu>();
            }
        }
        
        public static SteamVR_Input_ActionSet_Gun Gun
        {
            get
            {
                return SteamVR_Actions.p_Gun.GetCopy<SteamVR_Input_ActionSet_Gun>();
            }
        }
        
        public static SteamVR_Input_ActionSet_NewSet NewSet
        {
            get
            {
                return SteamVR_Actions.p_NewSet.GetCopy<SteamVR_Input_ActionSet_NewSet>();
            }
        }
        
        private static void StartPreInitActionSets()
        {
            SteamVR_Actions.p__default = ((SteamVR_Input_ActionSet_default)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_default>("/actions/default")));
            SteamVR_Actions.p_platformer = ((SteamVR_Input_ActionSet_platformer)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_platformer>("/actions/platformer")));
            SteamVR_Actions.p_buggy = ((SteamVR_Input_ActionSet_buggy)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_buggy>("/actions/buggy")));
            SteamVR_Actions.p_mixedreality = ((SteamVR_Input_ActionSet_mixedreality)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_mixedreality>("/actions/mixedreality")));
            SteamVR_Actions.p_htc_viu = ((SteamVR_Input_ActionSet_htc_viu)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_htc_viu>("/actions/htc_viu")));
            SteamVR_Actions.p_Gun = ((SteamVR_Input_ActionSet_Gun)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_Gun>("/actions/Gun")));
            SteamVR_Actions.p_NewSet = ((SteamVR_Input_ActionSet_NewSet)(SteamVR_ActionSet.Create<SteamVR_Input_ActionSet_NewSet>("/actions/NewSet")));
            Valve.VR.SteamVR_Input.actionSets = new Valve.VR.SteamVR_ActionSet[] {
                    SteamVR_Actions._default,
                    SteamVR_Actions.platformer,
                    SteamVR_Actions.buggy,
                    SteamVR_Actions.mixedreality,
                    SteamVR_Actions.htc_viu,
                    SteamVR_Actions.Gun,
                    SteamVR_Actions.NewSet};
        }
    }
}
