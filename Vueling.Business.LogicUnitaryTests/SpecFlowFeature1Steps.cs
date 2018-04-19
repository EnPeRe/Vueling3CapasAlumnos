using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using Vueling.Business.Logic;

namespace Vueling.Business.LogicUnitaryTests
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private DateTime fechaprimera;
        private DateTime fechasegunda;
        private DateTime resultatatestejar;


        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(string fecha1)
        {
            fechaprimera = DateTime.Parse(fecha1);
        }
        
        [Given(@"I also have entered (.*) into the calculator")]
        public void GivenIAlsoHaveEnteredIntoTheCalculator(string fecha2)
        {
            fechasegunda = DateTime.Parse(fecha2);
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            //resultatatestejar = StudentBL.GetAge(fechaprimera, fechasegunda);
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string resultatdonat)
        {
            Assert.Equals(resultatdonat, resultatatestejar);
        }
    }
}
