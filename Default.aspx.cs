using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Assembly assembly = Assembly.LoadFrom(Server.MapPath("~/Viewers/DLL.dll"));
        Type type = assembly.GetType("CueViewer.Class1");
        object myDllClassLibrary = Activator.CreateInstance(type);

        object[] parametry = new object[] { 10, 15 };

        //volame vnorenou funkci uzivatelskeho controlu
        foreach (var mojeFunkce in myDllClassLibrary.GetType().GetMethods())
        {
            Debug.WriteLine(mojeFunkce.Name);
            MethodInfo mInfo = myDllClassLibrary.GetType().GetMethod(mojeFunkce.Name);
            object result = mInfo.Invoke(myDllClassLibrary, parametry);

        }
    }
}