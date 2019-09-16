using Microsoft.AspNetCore.Hosting;
using PBPExample.UI.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

namespace PBPExample.UI
{
    public class PluginGenerator : IPluginGenerator
    {
        private List<IPlugin> pluginInstanceList = new List<IPlugin>();

        public PluginGenerator(IHostingEnvironment hostingEnvironment)
        {
            string pluginsFolder = Path.Combine(Path.GetDirectoryName(hostingEnvironment.ContentRootPath + @"\Plugins\"));
            foreach (string pluginPath in Directory.GetFiles(pluginsFolder))
            {
                Assembly newAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(pluginPath);
                Type[] types = newAssembly.GetExportedTypes();
                foreach (var type in types)
                {
                    if (type.GetTypeInfo().IsClass && (type.GetTypeInfo().GetInterface(typeof(IPlugin).FullName) != null))
                    {
                        var ctor = type.GetConstructor(new Type[] { });
                        var plugin = ctor.Invoke(new object[] { }) as IPlugin;
                        pluginInstanceList.Add(plugin);
                    }
                }
            }
        }
        public List<IPlugin> GetPluginList() => pluginInstanceList;
    }

    public interface IPluginGenerator
    {
        List<IPlugin> GetPluginList();
    }
}
