﻿using CoI.Mod.Better.MyIDs;
using CoI.Mod.Better.Shared;
using CoI.Mod.Better.Shared.Extensions;
using CoI.Mod.Better.Shared.Lang;
using CoI.Mod.Better.Shared.Utilities;
using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Machines.PowerGenerators;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Factory.MechanicalPower;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Core.Research;

namespace CoI.Mod.Better.Buildings
{
	internal class PowerGenerators : IModData
	{
		public void RegisterData(ProtoRegistrator registrator)
		{
			if (!BetterMod.Config.Systems.PowerGeneators || !BetterMod.Config.Systems.Cheats) return;

			GeneratePowerMachine(registrator, Machines.VoidPowerEnergyT1Cheat, BetterMod.Config.VoidPower.EnergyT1InputMechPower, BetterMod.Config.VoidPower.EnergyT1OutputPower);
			GeneratePowerMachine(registrator, Machines.VoidPowerEnergyT2Cheat, BetterMod.Config.VoidPower.EnergyT2InputMechPower, BetterMod.Config.VoidPower.EnergyT2OutputPower);
			GeneratePowerMachine(registrator, Machines.VoidPowerEnergyT3Cheat, BetterMod.Config.VoidPower.EnergyT3InputMechPower, BetterMod.Config.VoidPower.EnergyT3OutputPower);
			GeneratePowerMachine(registrator, Machines.VoidPowerEnergyT4Cheat, BetterMod.Config.VoidPower.EnergyT4InputMechPower, BetterMod.Config.VoidPower.EnergyT4OutputPower);
			GeneratePowerMachine(registrator, Machines.VoidPowerEnergyT5Cheat, BetterMod.Config.VoidPower.EnergyT5InputMechPower, BetterMod.Config.VoidPower.EnergyT5OutputPower);

			// Generate Research
			ResearchNodeProtoBuilder.State research_state_t1 = registrator.ResearchNodeProtoBuilder
				.Start(LangManager.Instance.Get("research_power_generator"), MyIDs.Research.VoidPowerEnergyCheat)
				.AddLayoutEntityToUnlock(Machines.VoidPowerEnergyT1Cheat)
				.AddLayoutEntityToUnlock(Machines.VoidPowerEnergyT2Cheat)
				.AddLayoutEntityToUnlock(Machines.VoidPowerEnergyT3Cheat)
				.AddLayoutEntityToUnlock(Machines.VoidPowerEnergyT4Cheat)
				.AddLayoutEntityToUnlock(Machines.VoidPowerEnergyT5Cheat);

			if (BetterMod.Config.Default.UnlockAllCheatsResearches)
			{
				research_state_t1.SetCostsFree();
			}
			else
			{
				research_state_t1.SetCostsOne();
			}
			ResearchNodeProto research_t1 = research_state_t1.BuildAndAdd();

			// Add parent to my research CHEAT
			ResearchNodeProto master_cheat_research = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(MyIDs.Research.VoidDieselEnergyCheat);
			research_t1.AddGridPos(master_cheat_research, -Constants.UIStepSize);
		}

		private static void GeneratePowerMachine(ProtoRegistrator registrator, StaticEntityProto.ID protoID, int inputKwMech, int outputKW)
		{
			MechPower kwMech_amount = inputKwMech.KwMech();
			Electricity kw_amount = outputKW.Kw().ScaledBy(registrator.DifficultyConfig.PowerProductionMult);

			ElectricityGeneratorFromMechPowerProto generator = registrator.PrototypesDb.Add
			(
				new ElectricityGeneratorFromMechPowerProto(
					protoID,
					Proto.CreateStr(protoID, LangManager.Instance.Get("power_generator") + " " + kw_amount.Format(), LangManager.Instance.Get("power_generator_desc")),
					registrator.LayoutParser.ParseLayoutOrThrow("   [2][2]   ", "   [3][3]   ", "P|>[3][3]>|Q", "   [3][3]   ", "   [2][2]   "),
					Costs.Machines.PowerGeneratorT1.MapToEntityCosts(registrator),
					registrator.PrototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.MechanicalPower),
					kwMech_amount,
					registrator.PrototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.Electricity),
					kw_amount,
					5,
					25.Percent(),
					ImmutableArray.Create((AnimationParams)AnimationParams.Loop(80.Percent())),
					new ElectricityGeneratorFromMechPowerProto.Gfx
					(
						"Assets/Base/Machines/PowerPlant/Generator.prefab",
						"Assets/Base/Machines/PowerPlant/Generator/GeneratorSound.prefab",
						registrator.GetCategoriesProtos(ToolbarCategories.MachinesElectricity),
						EntityProtoUtility.GetIconPath<ElectricityGeneratorFromMechPowerProto>(registrator, Ids.Machines.PowerGeneratorT1)
					)
				)
			);
			generator.AddParam(new ShaftInertiaProtoParam(generator.InputMechPower, 2.Seconds()));
			BetterDebug.Info("GeneratePowerMachine (name: " + "Power generator " + kw_amount.Format() + " | input: " + kwMech_amount.Format() + " | output: " + kw_amount.Format() + ") >> created!");
		}
	}
}