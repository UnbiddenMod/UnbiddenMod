using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;
using System.Collections.Generic;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace ProvidenceMod.Subworld
{
	public class EndlessSea : ModWorld
	{
		public static bool enteredWorld;

		public override void Initialize() => enteredWorld = false;

		public override void PreUpdate()
		{
			//This hook also runs in the subworld if we choose to specify ExclusiveWorld for the "Register"
		}

		public override void PostUpdate()
		{
			//This hook also runs in the subworld if we choose to specify ExclusiveWorld for the "Register"

			if (!(SubworldManager.IsActive(SubworldManager.mySubworldID) ?? false)) return; //No point executing the code below if we aren't in the subworld we want

			if (!enteredWorld) {
				enteredWorld = true;
				string message = $"Hey, We successfully entered '{SubworldManager.mySubworldID}' and only the '{Name}' will update here!";
				if (Main.netMode == NetmodeID.Server) {
					NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(message), Color.Orange);
				}
				else {
					Main.NewText(message, Color.Orange);
				}
			}
		}
	}
}