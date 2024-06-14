using NnGames.Abp.NnLibPoe.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NnGames.Abp.NnLibPoe.Permissions;

public class NnLibPoePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NnLibPoePermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NnLibPoePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NnLibPoeResource>(name);
    }
}
