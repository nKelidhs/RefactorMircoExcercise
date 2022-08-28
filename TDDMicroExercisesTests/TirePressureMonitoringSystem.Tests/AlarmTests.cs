using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDMicroExercises.TirePressureMonitoringSystem.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests.Tests
{
    [TestClass()]
    public class AlarmTests
    {
        [TestMethod()]
        public void AlarmCheckTest()
        {
            // Arrange
            // We cant write correct test method because the sensor method PopNextPressurePsiValue returns a random value.
            // So we cant stage the Check method with expected and actual values. We need to mock the Sensor
            // in order to control the return of the method.
            var alarm = new Alarm();
            Boolean actual;

            // Act
            alarm.Check();
            actual = alarm.AlarmOn;

            alarm.Check();
            actual = alarm.AlarmOn;

            alarm.Check();
            actual = alarm.AlarmOn;

            alarm.Check();
            actual = alarm.AlarmOn;

            // Assert
            // What is the Actual and Expected value?
            Assert.Fail();
        }

    }
}