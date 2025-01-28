using System;

public enum AccountType
{
    Guest,
    User,
    Moderator
}

[Flags]
public enum Permission : byte
{
    Read = 1 << 0,
    Write = 1 << 1,
    Delete = 1 << 2,
    All = Write | Delete | Read,
    None = 0
}


static class Permissions
{
    public static Permission Default(AccountType accountType) => accountType switch
    {
        AccountType.Guest => Permission.Read,
        AccountType.User => Permission.Write | Permission.Read,
        AccountType.Moderator => Permission.All,
        _ => Permission.None
    };
    public static Permission Grant(Permission current, Permission grant)
    {
        return current | grant;
    }
    public static Permission Revoke(Permission current, Permission revoke)
    {
        return current & ~revoke;
    }

    public static bool Check(Permission current, Permission check)
    {
        return current.HasFlag(check);
    }
}
