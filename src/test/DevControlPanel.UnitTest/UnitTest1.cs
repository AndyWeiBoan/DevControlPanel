using DevControlPanel.Common.Models;
using DevControlPanel.Common.Scanners;
using DevControlPanel.Common.Scanners.Net31;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DevControlPanel.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            IProjScanner<Net31Configuration> s = new Net31ProjScanner();

            await foreach (var item in s.GetProjectsAsync(@"C:\hs-workspace\higgs"))
            {

            } ;
        }
    }
}
