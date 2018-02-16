using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework; 


namespace ECS.Legacy.Test.Unit
{
    [TestFixture]
    public class ECSUnitTests
    {
        private ECS _uut;
        private IHeater _heater;
        private ITempSensor _tempSensor;
        

        [SetUp]
        public void SetUp()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();
            _uut = new ECS(24,_heater,_tempSensor);
        }

        [TestCase(24)]
        [TestCase(25)]
        public void Regulate_HigherTemp_HeaterTurnedOff(int temp)
        {
            _tempSensor.GetTemp().Returns(temp);
            _uut.Regulate();

            _heater.Received().TurnOff();
            
        }

        [Test] 
        public void Regulate_LowerTemp_HeaterTurnedOn()
        {
            _tempSensor.GetTemp().Returns(23);
            _uut.Regulate();

            _heater.Received().TurnOn();

        }

    }
}
