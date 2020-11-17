using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;
using Trainworks.Builders;
using Trainworks.Utilities;

namespace GraveshackledClan_Main
{
    class SubtypeGraveshackledPhantasm
    {
        public static readonly string Key = "SubtypeGraveshackledPhantasm_ID";

        public static void RegisterSubtypes()
        {
            CustomCharacterManager.RegisterSubtype(Key, "Phantasm");
        }
    }
}
