﻿using CoI.Mod.Better.Shared;
using CoI.Mod.Better.Shared.Lang;
using CoI.Mod.Better.Shared.Utilities;
using Mafi.Base;
using Mafi.Core.Buildings.Storages;
using Mafi.Core.Factory;
using Mafi.Core.Mods;

namespace CoI.Mod.Better.Buildings
{
    internal partial class BigStorages : IModData
    {
        #region Fluid Storages

        private void FluidStoragesT1(ProtoRegistrator registrator)
        {
            // Set proto ids
            var protoID = Ids.Buildings.StorageFluid;
            var protoNextTier = Ids.Buildings.StorageFluidT2;

            if (BetterMod.Config.Storage.OverrideVanilla)
            {
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            }
            else
            {
                protoID = MyIDs.Buildings.StorageFluidT1;
                protoNextTier = MyIDs.Buildings.StorageFluidT2;
            }


            // Generate LocStr
            var Name = LangManager.Instance.Get("fluid_storage");
            var desc = LangManager.Instance.Get("fluid_storage_desc", capacity_fluid_T1.ToString());


            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start(Name + "I", protoID)
                .Description(desc)
                .SetCost(Costs.Buildings.StorageFluid)
                .SetNextTier(registrator.PrototypesDb.GetOrThrow<StorageProto>(protoNextTier))
                .SetCapacity(capacity_fluid_T1)
                .SetProductsFilter(ProductUtility.ProductFilter)
                .SetLayout("   [4][4][4][4][4]   ", "A@>[4][4][4][4][4]>@X", "   [4][4][4][4][4]   ", "B@>[4][4][4][4][4]>@Y", "   [4][4][4][4][4]   ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT1.prefab")
                .SetFluidIndicatorGfxParams("Object397/liquid", new FluidIndicatorGfxParams(1f, 1.3f, 2f))
                .SetAsLockedOnInit();

            if (!BetterMod.Config.Storage.OverrideVanilla)
                creator.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluid)
                    .Graphics.IconPath);

            creator = SetCategory(creator);
            Utilities.ProductUtility.SetTransferLimitByT(creator, 1).BuildAsFluidAndAdd();
            BetterDebug.Info("BigStorages >> FluidStoragesT1 (override:" + BetterMod.Config.Storage.OverrideVanilla +
                             ") >> created!");
        }

        private void FluidStoragesT2(ProtoRegistrator registrator)
        {
            // Set proto ids
            var protoID = Ids.Buildings.StorageFluidT2;

            if (BetterMod.Config.Storage.OverrideVanilla)
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            else
                protoID = MyIDs.Buildings.StorageFluidT2;

            // Generate LocStr
            var Name = LangManager.Instance.Get("fluid_storage");
            var desc = LangManager.Instance.Get("fluid_storage_desc", capacity_fluid_T2.ToString());

            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start(Name + "II", protoID)
                .Description(desc)
                .SetCost(Costs.Buildings.StorageFluidT2)
                .SetCapacity(capacity_fluid_T2)
                .SetProductsFilter(ProductUtility.ProductFilter)
                .SetLayout("   [5][5][5][5][5]   ", "A@>[5][5][5][5][5]>@X", "   [5][5][5][5][5]   ", "B@>[5][5][5][5][5]>@Y", "   [5][5][5][5][5]   ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT2.prefab")
                .SetFluidIndicatorGfxParams("Object395/liquid001", new FluidIndicatorGfxParams(1f, 1.3f, 2f));

            if (!BetterMod.Config.Storage.OverrideVanilla)
                creator.SetCustomIconPath(registrator.PrototypesDb
                    .GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT2).Graphics.IconPath);
            creator = SetCategory(creator);
            Utilities.ProductUtility.SetTransferLimitByT(creator, 2).BuildAsFluidAndAdd();
            BetterDebug.Info("BigStorages >> FluidStoragesT2 (override:" + BetterMod.Config.Storage.OverrideVanilla +
                             ") >> created!");
        }

        private void FluidStoragesT3(ProtoRegistrator registrator)
        {
            // Set proto ids
            var protoID = Ids.Buildings.StorageFluidT3;
            var protoNextTier = Ids.Buildings.StorageFluidT4;

            if (BetterMod.Config.Storage.OverrideVanilla)
            {
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            }
            else
            {
                protoID = MyIDs.Buildings.StorageFluidT3;
                protoNextTier = MyIDs.Buildings.StorageFluidT4;
            }

            // Generate LocStr
            var Name = LangManager.Instance.Get("fluid_storage");
            var desc = LangManager.Instance.Get("fluid_storage_desc", capacity_fluid_T3.ToString());

            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start(Name + "III", protoID)
                .Description(desc)
                .SetCost(Costs.Buildings.StorageFluidT3)
                .SetNextTier(registrator.PrototypesDb.GetOrThrow<StorageProto>(protoNextTier))
                .SetCapacity(capacity_fluid_T3)
                .SetProductsFilter(ProductUtility.ProductFilter)
                .SetLayout("      [6][6][6][6][6][6][6][6]      ", "A@>[6][6][6][6][6][6][6][6][6][6]>@X", "   [6][6][6][6][6][6][6][6][6][6]   ", "B@>[6][6][6][6][6][6][6][6][6][6]>@Y", "   [6][6][6][6][6][6][6][6][6][6]   ", "   [6][6][6][6][6][6][6][6][6][6]   ", "C@>[6][6][6][6][6][6][6][6][6][6]>@Z", "   [6][6][6][6][6][6][6][6][6][6]   ", "D@>[6][6][6][6][6][6][6][6][6][6]>@W", "      [6][6][6][6][6][6][6][6]      ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT3.prefab")
                .SetFluidIndicatorGfxParams("gas_1010_T1_seg2/liquid", new FluidIndicatorGfxParams(1f, 2.6f, 2f));

            if (!BetterMod.Config.Storage.OverrideVanilla)
                creator.SetCustomIconPath(registrator.PrototypesDb
                    .GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT3).Graphics.IconPath);
            creator = SetCategory(creator);
            Utilities.ProductUtility.SetTransferLimitByT(creator, 3).BuildAsFluidAndAdd();
            BetterDebug.Info("BigStorages >> FluidStoragesT3 (override:" + BetterMod.Config.Storage.OverrideVanilla +
                             ") >> created!");
        }

        private void FluidStoragesT4(ProtoRegistrator registrator)
        {
            // Set proto ids
            var protoID = Ids.Buildings.StorageFluidT4;

            if (BetterMod.Config.Storage.OverrideVanilla)
                // Remove from Database
                registrator.PrototypesDb.RemoveOrThrow(protoID);
            else
                protoID = MyIDs.Buildings.StorageFluidT4;

            // Generate LocStr
            var Name = LangManager.Instance.Get("fluid_storage");
            var desc = LangManager.Instance.Get("fluid_storage_desc", capacity_fluid_T4.ToString());

            // Add new to Database
            var creator = registrator.StorageProtoBuilder.Start(Name + "IV", protoID)
                .Description(desc)
                .SetCost(Costs.Buildings.StorageFluidT4)
                .SetCapacity(capacity_fluid_T4)
                .SetProductsFilter(ProductUtility.ProductFilter)
                .SetLayout("      [9][9][9][9][9][9][9][9]      ", "A@>[9][9][9][9][9][9][9][9][9][9]>@X", "   [9][9][9][9][9][9][9][9][9][9]   ", "B@>[9][9][9][9][9][9][9][9][9][9]>@Y", "   [9][9][9][9][9][9][9][9][9][9]   ", "   [9][9][9][9][9][9][9][9][9][9]   ", "C@>[9][9][9][9][9][9][9][9][9][9]>@Z", "   [9][9][9][9][9][9][9][9][9][9]   ", "D@>[9][9][9][9][9][9][9][9][9][9]>@W", "      [9][9][9][9][9][9][9][9]      ")
                .SetPrefabPath("Assets/Base/Buildings/Storages/GasT4.prefab")
                .SetFluidIndicatorGfxParams("gas_1010_T2_seg3/liquid", new FluidIndicatorGfxParams(1f, 2.6f, 2f));

            if (!BetterMod.Config.Storage.OverrideVanilla)
                creator.SetCustomIconPath(registrator.PrototypesDb
                    .GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT4).Graphics.IconPath);
            creator = SetCategory(creator);
            Utilities.ProductUtility.SetTransferLimitByT(creator, 4).BuildAsFluidAndAdd();
            BetterDebug.Info("BigStorages >> FluidStoragesT4 (override:" + BetterMod.Config.Storage.OverrideVanilla +
                             ") >> created!");
        }

        #endregion
    }
}