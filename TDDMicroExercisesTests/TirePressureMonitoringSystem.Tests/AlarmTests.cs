using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Autofac.Extras.Moq;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests.Tests
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void AlarmCheck_Alarm_should_be_off_for_LowPressureThreshold_value()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Double psiValue = Alarm.LowPressureThreshold;
                
                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(psiValue);

                Alarm cls = mock.Create<Alarm>();
                var expected = false;

                // Act
                cls.Check();

                // Assert
                Assert.AreEqual(expected, cls.AlarmOn);
            }
        }

        [TestMethod]
        public void AlarmCheck_Alarm_should_be_off_for_HighPressureThreshold_value()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Double psiValue = Alarm.HighPressureThreshold;

                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(psiValue);

                Alarm cls = mock.Create<Alarm>();
                var expected = false;

                // Act
                cls.Check();

                // Assert
                Assert.AreEqual(expected, cls.AlarmOn);
            }
        }

        [TestMethod]
        public void AlarmCheck_Alarm_should_be_off_for_pressure_value_inside_the_thresshold()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Double psiValue = (Alarm.HighPressureThreshold + Alarm.LowPressureThreshold) / 2;

                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(psiValue);

                Alarm cls = mock.Create<Alarm>();
                var expected = false;

                // Act
                cls.Check();

                // Assert
                Assert.AreEqual(expected, cls.AlarmOn);
            }
        }

        [TestMethod]
        public void AlarmCheck_Alarm_should_be_on_for_pressure_value_bigger_than_HighPressureThreshold()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Double psiValue = Alarm.HighPressureThreshold + 1;

                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(psiValue);

                Alarm cls = mock.Create<Alarm>();
                var expected = true;

                // Act
                cls.Check();

                // Assert
                Assert.AreEqual(expected, cls.AlarmOn);
            }
        }

        [TestMethod]
        public void AlarmCheck_Alarm_should_be_on_for_pressure_value_lower_than_LowPressureThreshold()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                Double psiValue = Alarm.LowPressureThreshold - 1;

                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(psiValue);

                Alarm cls = mock.Create<Alarm>();
                var expected = true;

                // Act
                cls.Check();

                // Assert
                Assert.AreEqual(expected, cls.AlarmOn);
            }
        }

        [TestMethod]
        public void AlarmCheck_Alarm_should_stay_true()
        {
            // Here we test if the value of Alarm changes after multiple calls on Check.
            // The first Check makes the alarm true and the second Check with normal pressure
            // must leave the alarm true.
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(Alarm.HighPressureThreshold + 2);

                Alarm cls = mock.Create<Alarm>();
                var expected = true;

                // Act
                cls.Check();

                // Change return value for PopNextPressurePsiValue()
                mock.Mock<ISensor>()
                    .Setup(x => x.PopNextPressurePsiValue())
                    .Returns(Alarm.HighPressureThreshold);

                // Check again
                cls.Check();

                // Assert
                Assert.AreEqual(expected, cls.AlarmOn);
            }
        }
    }
}