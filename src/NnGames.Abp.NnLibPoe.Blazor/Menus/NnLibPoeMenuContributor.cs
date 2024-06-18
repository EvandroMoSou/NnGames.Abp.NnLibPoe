using System.Threading.Tasks;
using NnGames.Abp.NnLibPoe.Localization;
using NnGames.Abp.NnLibPoe.MultiTenancy;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;

namespace NnGames.Abp.NnLibPoe.Blazor.Menus;

public class NnLibPoeMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<NnLibPoeResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                NnLibPoeMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );

        //var databaseMenu =
        //    new ApplicationMenuItem(
        //        NnLibPoeMenus.DatabasePrefix,
        //        l["Menu:Database"],
        //        "/",
        //        icon: "fas fa-database",
        //        order: 1
        //    );

        //databaseMenu.AddItem(new ApplicationMenuItem(
        //    NnLibPoeMenus.Database_CharacterClass,
        //    l["Menu:Poe:Database:CharacterClass"],
        //    url: "/Poe/Database/CharacterClass",
        //    order: 0
        //));

        //context.Menu.Items.Insert(1, databaseMenu);

#pragma warning disable CS0162 // Unreachable code detected
        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }
#pragma warning restore CS0162 // Unreachable code detected

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        return Task.CompletedTask;
    }
}
