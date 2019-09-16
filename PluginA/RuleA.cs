using PBPExample.UI.Interface;
using System;
using System.Diagnostics;

namespace PluginA
{
    public class RuleA : IPlugin
    {
        public int RuleCalculator(int a)
        {
            Debug.WriteLine($"RuleA worked !. {a * 2}");
            return a * a;
        }
    }
}
