using PBPExample.UI.Interface;
using System;
using System.Diagnostics;

namespace PluginB
{
    public class RuleB : IPlugin
    {
        public int RuleCalculator(int a)
        {
            Debug.WriteLine($"RuleB worked !. {a * 2}");
            return a * 2;
        }
    }
}
