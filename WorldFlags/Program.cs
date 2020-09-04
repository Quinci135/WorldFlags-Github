using System;
using TShockAPI;
using Terraria;
using TerrariaApi.Server;


namespace WorldFlags
{
	[ApiVersion(2, 1)]
	public class WorldFlags : TerrariaPlugin
	{
		public override string Author => "Quinci";

		public override string Description => "Views and changes world seed flags.";

		public override string Name => "WorldFlags";

		public override Version Version => new Version(1, 0, 0, 0);

		public WorldFlags(Main game) : base(game)
		{
			Order = 60;
		}

		public override void Initialize()
		{
			Commands.ChatCommands.Add(new Command("changeflag.use", ChangeFlag, "changeflag") { HelpText = "Views and changes world seed flags." });
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{

			}
			base.Dispose(disposing);
		}

		private void ChangeFlag(CommandArgs args)
		{
			if (args.Parameters.Count == 0 || args.Parameters.Count > 1)
			{
				args.Player.SendInfoMessage($"[ChangeFlag] Current flag status:\nFor The Worthy(ftw): {Main.getGoodWorld}\nDrunk World(5162020 seed): {Main.drunkWorld}\nCommand usage: {TShock.Config.CommandSpecifier}changeflag <flag>");
				return;
			}
			switch (args.Parameters[0].ToLower())
			{
				case "ftw":
				case "for the worthy":
					Main.getGoodWorld = !Main.getGoodWorld;
					args.Player.SendSuccessMessage($"For the Worthy " + (Main.getGoodWorld ? "enabled." : "disabled."));
					break;
				case "drunk":
				case "drunkworld":
				case "05162020":
				case "5162020":
					Main.drunkWorld = !Main.drunkWorld;
					args.Player.SendSuccessMessage($"Drunk world " + (Main.drunkWorld ? "enabled." : "disabled."));
					break;
				default:
					args.Player.SendInfoMessage($"[ChangeFlag] Current flag status:\nFor The Worthy(ftw): {Main.getGoodWorld}\nDrunk World(5162020 seed): {Main.drunkWorld}\nCommand usage: {TShock.Config.CommandSpecifier}changeflag <flag|>");
					break;
			}
		}
	}
}