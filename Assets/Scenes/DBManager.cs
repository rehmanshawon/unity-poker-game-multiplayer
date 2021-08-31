using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    // Start is called before the first frame update
    public static string username;
    public static string userpic="0";
    public static string t_username;
    public static string QuiterName;
    public static int coins=10000;
    public static int ActiveClock = 0;
    public static bool LoggedIn { get { return username != null; } }
    public static void Logout()
    {
        username = null;

    }

}
