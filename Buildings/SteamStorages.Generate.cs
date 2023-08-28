﻿using CoI.Mod.Better.Shared;
using CoI.Mod.Better.Shared.Lang;
using CoI.Mod.Better.Shared.Utilities;
using Mafi.Base;
using Mafi.Core.Buildings.Storages;
using Mafi.Core.Entities.Static;
using Mafi.Core.Factory;
using Mafi.Core.Mods;

namespace CoI.Mod.Better.Buildings
{
	public partial class SteamStorages : IModData
	{
		private void SteamStoragesT1(ProtoRegistrator registrator)
		{
			// Set proto ids
			StaticEntityProto.ID protoID = MyIDs.Buildings.StorageSteamT1;
			StaticEntityProto.ID protoNextTier = MyIDs.Buildings.StorageSteamT2;


			// Generate LocStr
			string Name = LangManager.Instance.Get("steam_storage");
			string desc = LangManager.Instance.Get("steam_storage_desc", capacity_steam_T1.ToString());

			// Add new to Database
			StorageProtoBuilder.State creator = registrator.StorageProtoBuilder.Start(Name + " I", protoID)
				.Description(desc)
				.SetCost(Costs.Buildings.StorageFluid)
				.SetNextTier(registrator.PrototypesDb.GetOrThrow<StorageProto>(protoNextTier))
				.SetCapacity(capacity_steam_T1)
				.SetProductsFilter(ProductUtility.SteamFilter)
				.SetLayout("   [4][4][4][4][4]   ", "A@>[4][4][4][4][4]>@X", "   [4][4][4][4][4]   ", "B@>[4][4][4][4][4]>@Y", "   [4][4][4][4][4]   ")
				.SetPrefabPath("Assets/Base/Buildings/Storages/GasT1.prefab")
				.SetFluidIndicatorGfxParams("Object397/liquid", new FluidIndicatorGfxParams(1f, 1.3f, 2f))
				.SetAsLockedOnInit()
				.SetCategories(Ids.ToolbarCategories.Storages)
				.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluid).Graphics.IconPath);


			Utilities.ProductUtility.SetTransferLimitByT(creator, 1).BuildAsFluidAndAdd();
			BetterDebug.Info("SteamStoragesT1 >> created!");
		}

		private void SteamStoragesT2(ProtoRegistrator registrator)
		{
			// Set proto ids
			StaticEntityProto.ID protoID = MyIDs.Buildings.StorageSteamT2;

			// Generate LocStr
			string Name = LangManager.Instance.Get("steam_storage");
			string desc = LangManager.Instance.Get("steam_storage_desc", capacity_steam_T2.ToString());

			// Add new to Database
			StorageProtoBuilder.State creator = registrator.StorageProtoBuilder.Start(Name + " II", protoID)
				.Description(desc)
				.SetCost(Costs.Buildings.StorageFluidT2)
				.SetCapacity(capacity_steam_T2)
				.SetProductsFilter(ProductUtility.SteamFilter)
				.SetLayout("   [5][5][5][5][5]   ", "A@>[5][5][5][5][5]>@X", "   [5][5][5][5][5]   ", "B@>[5][5][5][5][5]>@Y", "   [5][5][5][5][5]   ")
				.SetPrefabPath("Assets/Base/Buildings/Storages/GasT2.prefab")
				.SetFluidIndicatorGfxParams("Object395/liquid001", new FluidIndicatorGfxParams(1f, 1.3f, 2f))
				.SetCategories(Ids.ToolbarCategories.Storages)
				.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT2).Graphics.IconPath);

			Utilities.ProductUtility.SetTransferLimitByT(creator, 2).BuildAsFluidAndAdd();
			BetterDebug.Info("SteamStoragesT2 >> created!");
		}

		private void SteamStoragesT3(ProtoRegistrator registrator)
		{
			// Set proto ids
			StaticEntityProto.ID protoID = MyIDs.Buildings.StorageSteamT3;
			StaticEntityProto.ID protoNextTier = MyIDs.Buildings.StorageSteamT4;

			// Generate LocStr
			string Name = LangManager.Instance.Get("steam_storage");
			string desc = LangManager.Instance.Get("steam_storage_desc", capacity_steam_T3.ToString());

			// Add new to Database
			StorageProtoBuilder.State creator = registrator.StorageProtoBuilder.Start(Name + " III", protoID)
				.Description(desc)
				.SetCost(Costs.Buildings.StorageFluidT3)
				.SetNextTier(registrator.PrototypesDb.GetOrThrow<StorageProto>(protoNextTier))
				.SetCapacity(capacity_steam_T3)
				.SetProductsFilter(ProductUtility.SteamFilter)
				.SetLayout("      [6][6][6][6][6][6][6][6]      ", "A@>[6][6][6][6][6][6][6][6][6][6]>@X", "   [6][6][6][6][6][6][6][6][6][6]   ", "B@>[6][6][6][6][6][6][6][6][6][6]>@Y", "   [6][6][6][6][6][6][6][6][6][6]   ", "   [6][6][6][6][6][6][6][6][6][6]   ", "C@>[6][6][6][6][6][6][6][6][6][6]>@Z", "   [6][6][6][6][6][6][6][6][6][6]   ", "D@>[6][6][6][6][6][6][6][6][6][6]>@W", "      [6][6][6][6][6][6][6][6]      ")
				.SetPrefabPath("Assets/Base/Buildings/Storages/GasT3.prefab")
				.SetFluidIndicatorGfxParams("gas_1010_T1_seg2/liquid", new FluidIndicatorGfxParams(1f, 2.6f, 2f))
				.SetCategories(Ids.ToolbarCategories.Storages)
				.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT3).Graphics.IconPath);

			Utilities.ProductUtility.SetTransferLimitByT(creator, 3).BuildAsFluidAndAdd();
			BetterDebug.Info("SteamStoragesT3 >> created!");
		}

		private void SteamStoragesT4(ProtoRegistrator registrator)
		{
			// Set proto ids
			StaticEntityProto.ID protoID = MyIDs.Buildings.StorageSteamT4;

			// Generate LocStr
			string Name = LangManager.Instance.Get("steam_storage");
			string desc = LangManager.Instance.Get("steam_storage_desc", capacity_steam_T4.ToString());

			// Add new to Database
			StorageProtoBuilder.State creator = registrator.StorageProtoBuilder.Start(Name + " IV", protoID)
				.Description(desc)
				.SetCost(Costs.Buildings.StorageFluidT4)
				.SetCapacity(capacity_steam_T4)
				.SetProductsFilter(ProductUtility.SteamFilter)
				.SetLayout("      [9][9][9][9][9][9][9][9]      ", "A@>[9][9][9][9][9][9][9][9][9][9]>@X", "   [9][9][9][9][9][9][9][9][9][9]   ", "B@>[9][9][9][9][9][9][9][9][9][9]>@Y", "   [9][9][9][9][9][9][9][9][9][9]   ", "   [9][9][9][9][9][9][9][9][9][9]   ", "C@>[9][9][9][9][9][9][9][9][9][9]>@Z", "   [9][9][9][9][9][9][9][9][9][9]   ", "D@>[9][9][9][9][9][9][9][9][9][9]>@W", "      [9][9][9][9][9][9][9][9]      ")
				.SetPrefabPath("Assets/Base/Buildings/Storages/GasT4.prefab")
				.SetFluidIndicatorGfxParams("gas_1010_T2_seg3/liquid", new FluidIndicatorGfxParams(1f, 2.6f, 2f))
				.SetCategories(Ids.ToolbarCategories.Storages)
				.SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<StorageProto>(Ids.Buildings.StorageFluidT4).Graphics.IconPath);

			Utilities.ProductUtility.SetTransferLimitByT(creator, 4).BuildAsFluidAndAdd();
			BetterDebug.Info("SteamStoragesT4 >> created!");
		}
	}
}