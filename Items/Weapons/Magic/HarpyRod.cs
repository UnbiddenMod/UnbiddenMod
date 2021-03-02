using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using static ProvidenceMod.ProvidenceUtils;
using static Terraria.ModLoader.ModContent;
using ProvidenceMod.Items.Materials;
using ProvidenceMod.Projectiles.Boss;

namespace ProvidenceMod.Items.Weapons.Magic
{
  public class HarpyRod : ModItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Harpy Rod");
      Tooltip.SetDefault("Shoots slow-moving but homing harpy feathers.\nThe down you used to make the crown is heavier then the rod itself.");
      Item.staff[item.type] = true;
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.RubyStaff);
      item.damage = 25;
      item.width = 40;
      item.height = 40;
      item.value = Item.buyPrice(0, 10, 0, 0);
      item.rare = 12;
      item.useStyle = ItemUseStyleID.HoldingOut;
      item.useTime = 20;
      item.useAnimation = 20;
      item.scale = 1.0f;
      item.magic = true;
      item.mana = 6;
      item.autoReuse = true;
      item.Providence().element = ElementID.Air; // Fire
      item.shoot = ProjectileType<RoyalFeather>();
      item.shootSpeed = 6f;
    }

    public override void AddRecipes()
    {
      // Recipes here. See Basic Recipe Guide2
      ModRecipe r = new ModRecipe(mod);

      r.AddIngredient(ItemType<ZephyrBar>(), 10);
      r.AddIngredient(ItemType<HarpyQueenFeather>(), 3);
      r.AddIngredient(ItemType<HarpyQueenTalon>(), 3);
      r.AddTile(TileID.SkyMill);
      r.SetResult(this);
      r.AddRecipe();
    }
  }
}