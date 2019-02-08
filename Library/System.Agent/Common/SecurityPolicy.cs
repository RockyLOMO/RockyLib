using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetFwTypeLib;

namespace System.Agent
{
    internal class SecurityPolicy
    {
        internal static readonly string PipeName = Guid.NewGuid().ToString("N");

        /// <summary>
        /// 将应用程序添加到防火墙例外
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="execPath"></param>
        public static void App2Fw(string appName, string execPath)
        {
            var mgr = (INetFwMgr)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwMgr"));
            var q = from t in mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Cast<INetFwAuthorizedApplication>()
                    where t.Name == appName
                    select t;
            var app = q.FirstOrDefault();
            if (app != null)
            {
                if (app.ProcessImageFileName == execPath)
                {
                    return;
                }
                mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Remove(app.ProcessImageFileName);
            }
            app = (INetFwAuthorizedApplication)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication"));
            app.Enabled = true;
            app.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
            app.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
            app.Name = appName;
            app.ProcessImageFileName = execPath;
            mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(app);
        }
    }
}